using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RocknCode.RocknCodeLib;

namespace IChameleon
{
    public partial class chameleon_memberViewPortfolio : System.Web.UI.Page
    {
        #region User Defined Decs
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private int iUserID;
        private string sUserName;
        private int iPortfolioID;
        private string sSearchHeading = "";
        private string sUserCategory;
        private string sWhere = "";
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(webEnabled = 1)";


        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                butSaveItem.Attributes.Add("onclick", "return validateTexBox()");
            }

          
            if (!Page.IsPostBack)
            {
                iPortfolioID = Convert.ToInt32(Request.QueryString["portfolioID"].ToString());
                ViewState["portfolioName"] = Request.QueryString["portfolioName"].ToString();

                lbHeader.Text = "Portfolio: " + ViewState["portfolioName"].ToString();
                ViewState["portfolioID"] = iPortfolioID;

                getPortfolioDataSet();
            }
            else
            {
                iPortfolioID = Convert.ToInt32(ViewState["portfolioID"].ToString());
                lbHeader.Text = "Portfolio: " + ViewState["portfolioName"].ToString();
            }

        }   

        public void getPortfolioDataSet()
        {
            try
            {
                //string sSQL = "Select * from chaProducts where itemCode in (Select itemCode from chaPortfolioItems where portfolioID = " + Session["portfolioID"] + ")";					
                string sSQL = "Select * from chaPortfolioItems where portfolioID = " + iPortfolioID;

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaPortfolioItems");

                if (mDataSet.Tables["chaPortfolioItems"].DefaultView.Count > 0)
                {
                    //pnlPortfolio.Visible = true;						
                    lbInfo.Text = "";

                    bindItems();
                    butRemoveItem.Visible = true;
                    butEmail.Visible = true;

                    //lbHeader.Text = "";//mDataSet.Tables["chaPortfolioItems"].Rows[0]["name"].ToString();
                }
                else
                {
                    //pnlPortfolio.Visible = false;	
                    butRemoveItem.Visible = false;
                    butEmail.Visible = false;
                    lbInfo.Text = "You have no items saved in this portfolio";
                }

            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }	//end 

        private void bindItems()
        {
            try
            {
                //mDataSet.Tables["udsp_getPagedResults"].DefaultView.Sort = "prefix, suffix";	
                //dItems.DataSource = null;

                dItems.DataSource = mDataSet.Tables["chaPortfolioItems"].DefaultView;
                dItems.DataBind();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                lbInfo.Text = sError;
                sError = "";

            }
        }

        protected void butRemoveItem_Click(object sender, System.EventArgs e)
        {
            bool isDeleted;
            try
            {
                // Check each box and see if the item should be deleted.
                foreach (DataListItem mItem in dItems.Items)
                {
                    isDeleted = ((CheckBox)mItem.FindControl("chkRemoveItem")).Checked;
                    if (isDeleted)
                    {
                        //string itemCode = dItems.DataKeys.Count.ToString();
                        //Response.Write(mItem.ItemIndex.ToString());
                        int portfolioID = Convert.ToInt32(dItems.DataKeys[mItem.ItemIndex]);
                        deleteItem(portfolioID);
                    }
                }
                //getPortfolioDataSet();
                string sPortID = ViewState["portfolioID"].ToString();
                string sPortName = Server.UrlEncode(ViewState["portfolioName"].ToString());
                Response.Redirect("chameleon-memberViewPortfolio.aspx?portfolioID=" + ViewState["portfolioID"] + "&portfolioName=" + sPortName);
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                Response.Write(err);
            }

        }

        private bool deleteItem(int id)
        {
            // declare variables
            string sConnection = null;
            bool success = false;

            // initialize ADO objects
            SqlConnection dataConn = null;
            SqlDataReader dbReader = null;
            SqlCommand dataCmd = null;

            try
            {
                sConnection = mMain.sDataPath;

                dataConn = new SqlConnection(sConnection);
                dataConn.Open();

                // set command object attributes
                dataCmd = new SqlCommand("udsp_deletePortfolioItem", dataConn);
                dataCmd.CommandType = CommandType.StoredProcedure;


                // declare and instantiate parameters collection
                SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                SqlParameter ipPortfolioID = new SqlParameter("@pItemID", SqlDbType.Int);
                //SqlParameter ipItemCode = new SqlParameter("@itemCode", SqlDbType.VarChar, 50);

                // specify parameter direction
                opReturnCode.Direction = ParameterDirection.ReturnValue;
                ipPortfolioID.Direction = ParameterDirection.Input;
                //ipItemCode.Direction = ParameterDirection.Input;

                // initialize parameter values
                ipPortfolioID.Value = id;
                //ipItemCode.Value = sItemCode;

                // add parameters to collection
                dataCmd.Parameters.Add(opReturnCode);
                dataCmd.Parameters.Add(ipPortfolioID);
                //dataCmd.Parameters.Add(sItemCode);	

                // execute command
                dataCmd.ExecuteReader();


                // test return value and transfer control as necessary
                if ((int)dataCmd.Parameters[0].Value == 9)
                {
                    success = true;

                }	// end if

            }	//end try
            catch (SqlException sqle)
            {
                throw sqle;

            }	//end catch 
            catch (Exception z)
            {
                throw z;

            }	//end catch 
            finally
            {
                // clean up
                if (dbReader != null)
                {
                    dbReader.Close();

                }	// end if

                dataConn.Close();
                dataConn.Dispose();
                dataCmd.Dispose();

            }	// end finally
            return success;

        }

        protected void butAddItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                lbItemCode.Visible = true;
                txtItemCode.Visible = true;
                txtItemNotes.Visible = true;
                butSaveItem.Visible = true;
                butCancel.Visible = true;

                butRemoveItem.Visible = false;
                butAddItem.Visible = false;
                butEmail.Visible = false;

            }
            catch
            {

            }

        }

        protected void butSaveItem_Click(object sender, System.EventArgs e)
        {
            if (checkSession())
            {
                bool exists;
                if (addItemToPortfolio(iPortfolioID, txtItemCode.Text, txtItemNotes.Text, out exists))
                {
                    lbItemCode.Visible = false;
                    txtItemNotes.Text = "";
                    txtItemCode.Text = "";
                    txtItemCode.Visible = false;
                    txtItemNotes.Visible = false;
                    butSaveItem.Visible = false;
                    butCancel.Visible = false;

                    butRemoveItem.Visible = true;
                    butAddItem.Visible = true;
                    butEmail.Visible = true;

                    //getPortfolioDataSet();
                    string sPortID = ViewState["portfolioID"].ToString();
                    string sPortName = Server.UrlEncode(ViewState["portfolioName"].ToString());
                    Response.Redirect("chameleon-memberViewPortfolio.aspx?portfolioID=" + ViewState["portfolioID"] + "&portfolioName=" + sPortName);
                }
                else if (exists)
                {
                    showJSMessage("Item already exists in this portfolio. Please check the Item Code and try again");
                }
                else
                {
                    showJSMessage("Error Adding Item. Please check the Item Code and try again");
                }

            }
        }

        public bool addItemToPortfolio(int iPortID, string sItemCode, string sItemNotes, out bool blExists)
        {

            bool success = false;
            blExists = false;

            // declare variables
            string sConnection = null;

            // initialize ADO objects
            SqlConnection dataConn = null;
            SqlDataReader dbReader = null;
            SqlCommand dataCmd = null;

            try
            {
                sConnection = mMain.sDataPath;

                dataConn = new SqlConnection(sConnection);
                dataConn.Open();

                // set command object attributes
                dataCmd = new SqlCommand("udsp_insertPortfolioItem", dataConn);
                dataCmd.CommandType = CommandType.StoredProcedure;

                // declare and instantiate parameters collection
                SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                SqlParameter ipPortfolioID = new SqlParameter("@portfolioID", SqlDbType.Int);
                SqlParameter ipMemberID = new SqlParameter("@memberID", SqlDbType.Int);
                SqlParameter ipItemCode = new SqlParameter("@itemCode", SqlDbType.VarChar, 50);
                SqlParameter ipNotes = new SqlParameter("@notes", SqlDbType.VarChar, 2000);
                SqlParameter ipDateEntered = new SqlParameter("@dateEntered", SqlDbType.DateTime);

                // specify parameter direction
                opReturnCode.Direction = ParameterDirection.ReturnValue;
                ipPortfolioID.Direction = ParameterDirection.Input;
                ipMemberID.Direction = ParameterDirection.Input;
                ipItemCode.Direction = ParameterDirection.Input;
                ipNotes.Direction = ParameterDirection.Input;
                ipDateEntered.Direction = ParameterDirection.Input;

                // initialize parameter values
                ipPortfolioID.Value = iPortfolioID;
                ipMemberID.Value = Convert.ToInt32(Session["memberID"].ToString());
                ipItemCode.Value = sItemCode;
                ipNotes.Value = txtItemNotes.Text;
                ipDateEntered.Value = System.DateTime.Now;

                // add parameters to collection
                dataCmd.Parameters.Add(opReturnCode);
                dataCmd.Parameters.Add(ipPortfolioID);
                dataCmd.Parameters.Add(ipMemberID);
                dataCmd.Parameters.Add(ipItemCode);
                dataCmd.Parameters.Add(ipNotes);
                dataCmd.Parameters.Add(ipDateEntered);

                // execute command
                dataCmd.ExecuteReader();


                // test return value and transfer control as necessary
                if ((int)dataCmd.Parameters[0].Value == 1)
                {
                    blExists = true;
                    success = false;

                }	// end if
                if ((int)dataCmd.Parameters[0].Value == 9)
                {
                    blExists = false;
                    success = true;

                }	// end if

            }	//end try
            catch (SqlException sqle)
            {
                throw sqle;

            }	//end catch 
            catch (Exception z)
            {
                throw z;

            }	//end catch 
            finally
            {
                // clean up
                if (dbReader != null)
                {
                    dbReader.Close();

                }	// end if

                dataConn.Close();
                dataConn.Dispose();
                dataCmd.Dispose();

            }	// end finally

            return success;
        }

        private bool checkSession()
        {
            //string s = Session["memberID"].ToString();
            if (Session["memberID"] != null && Session["memberID"].ToString() != "")
            {
                return true;
            }
            else
            {
                showJSMessage("Your Session has expired due to inactivity.  Please login again.");
                Response.Redirect("chameleon-memberLogin.aspx");
                return false;
            }
        }

        private void showJSMessage(string sMessage)
        {
            System.Text.StringBuilder sbMsg = new System.Text.StringBuilder();
            sbMsg.Append("<script language=javascript>");
            sbMsg.Append(" alert('");
            sbMsg.Append(sMessage);
            sbMsg.Append("')");
            sbMsg.Append("</script>");
            Response.Write(sbMsg.ToString());
        }

        //private void dItems_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        //{
        //    dItems.EditItemIndex = e.Item.ItemIndex;
        //    //				ViewState["pItemID"] = Convert.ToInt32(dItems.DataKeys[e.Item.ItemIndex].ToString());
        //    //int id = Convert.ToInt32(dItems.DataKeys[e.Item.ItemIndex].ToString());
        //    System.Web.UI.WebControls.TextBox tbox = new TextBox();

        //    try
        //    {
        //        // Check each box and see if the item should be deleted.
        //        int pItemID = Convert.ToInt32(dItems.DataKeys[e.Item.ItemIndex]);
        //        tbox = ((System.Web.UI.WebControls.TextBox)e.Item.FindControl("txtNotes"));

        //        //string itemCode = dItems.DataKeys.Count.ToString();
        //        //Response.Write(mItem.ItemIndex.ToString());

        //        updateNotes(pItemID, tbox.Text);


        //        getPortfolioDataSet();
        //    }
        //    catch (Exception ex)
        //    {
        //        string err = ex.Message.ToString();
        //        Response.Write(err);
        //    }


        //}

        private bool updateNotes(int portfolioItemID, string sNotes)
        {
            try
            {
                //---updates the database---
                string sql = "UPDATE chaPortfolioItems SET notes ='" + sNotes + "' WHERE pItemID = " + portfolioItemID;
                string sConnection = null;

                // initialize ADO objects
                SqlConnection dataConn = null;
                //SqlDataReader dbReader = null;
                SqlCommand dataCmd = null;
                sConnection = mMain.sDataPath;

                dataConn = new SqlConnection(sConnection);
                dataCmd = new SqlCommand(sql, dataConn);

                dataConn.Open();
                dataCmd.ExecuteNonQuery();
                dataConn.Close();


                dItems.EditItemIndex = -1;
                return true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return false;
            }


        }

        protected void butCancel_Click(object sender, System.EventArgs e)
        {
            lbItemCode.Visible = false;
            txtItemCode.Text = "";
            txtItemCode.Visible = false;
            txtItemNotes.Visible = false;
            butSaveItem.Visible = false;
            butCancel.Visible = false;

            butRemoveItem.Visible = true;
            butAddItem.Visible = true;
            butEmail.Visible = true;
        }

        //protected void butLoginRegister_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    if (IsLoggedIn())
        //    {
        //        Session["memberID"] = null;
        //        Response.Redirect("chameleon-home.aspx", true);
        //    }
        //    else
        //    {
        //        Response.Redirect("chameleon-memberLogin.aspx", true);
        //    }
        //}

        private bool IsLoggedIn()
        {
            //string s = Session["memberID"].ToString();
            if (Session["memberID"] != null && Session["memberID"].ToString() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //			protected void butLogOff_B_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //			{
        //				Session["memberID"] = null;
        //				Response.Redirect("chameleon-home.aspx",true);
        //			}

        //protected void butMyWorkshop_B_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-memberHome.aspx", true);
        //}

        //protected void butAllInventory_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-searchResults.aspx?Line=All", true);
        //}

        //protected void butAllAntiques_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-searchResults.aspx?Line=Antiques", true);
        //}

        //protected void butAllSignature_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-searchResults.aspx?Line=Signature", true);
        //}

        //protected void butRequestCatalog_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-catalogRequest.aspx", true);
        //}

        //protected void butAdvancedSearch_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-advancedSearch.aspx", true);
        //}

        //protected void butRecentArrivals_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-recentArrivals.aspx", true);
        //}

        protected void butEmail_Click(object sender, System.EventArgs e)
        {
            //				Context.Items.Add("portfolioID", ViewState["portfolioID"]);
            //				Context.Items.Add("portfolioName", ViewState["portfolioName"]);			
            //				Server.Transfer("chameleon-emailPortfolio.aspx");
            string sPortID = ViewState["portfolioID"].ToString();
            string sPortName = Server.UrlEncode(ViewState["portfolioName"].ToString());
            Response.Redirect("chameleon-emailPortfolio.aspx?portfolioID=" + ViewState["portfolioID"] + "&portfolioName=" + sPortName);
        }

        protected void butMWS_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("chameleon-memberHome.aspx", true);
        }

        protected void dItems_EditCommand(object source, DataListCommandEventArgs e)
        {
                dItems.EditItemIndex = e.Item.ItemIndex;
                //				ViewState["pItemID"] = Convert.ToInt32(dItems.DataKeys[e.Item.ItemIndex].ToString());
                //int id = Convert.ToInt32(dItems.DataKeys[e.Item.ItemIndex].ToString());
                System.Web.UI.WebControls.TextBox tbox = new TextBox();

                try
                {
                    // Check each box and see if the item should be deleted.
                    int pItemID = Convert.ToInt32(dItems.DataKeys[e.Item.ItemIndex]);
                    tbox = ((System.Web.UI.WebControls.TextBox)e.Item.FindControl("txtNotes"));

                    //string itemCode = dItems.DataKeys.Count.ToString();
                    //Response.Write(mItem.ItemIndex.ToString());

                    updateNotes(pItemID, tbox.Text);


                    getPortfolioDataSet();
                }
                catch (Exception ex)
                {
                    string err = ex.Message.ToString();
                    Response.Write(err);
                }
        }

       



        //protected void butMyProfile_B_ServerClick(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-memberProfile.aspx", true);
        //}



        //ADDED BY ROB START

        //protected void butTraditional_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-searchResults.aspx?Line=Traditional", true);
        //}

        //protected void butContemporary_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-searchResults.aspx?Line=Contemporary", true);
        //}
    }
}