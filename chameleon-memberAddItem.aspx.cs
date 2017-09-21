using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using RocknCode.RocknCodeLib;

namespace IChameleon
{
    public partial class chameleon_memberAddItem : System.Web.UI.Page
    {
        #region User Defined Decs
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        public DataSet iDataSet = new DataSet();
        private SqlConnection iConn;
        private SqlDataAdapter iAdapter = new SqlDataAdapter();
        private int pSelectedIndex;
        private string sItemCode;
        private string sStatus;

        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (checkSession())
            {

                if (this.IsPostBack)
                {

                    //						foreach (DataGridItem pItem in dgPortfolio.Items)
                    //						{
                    //							pItem.FindControl("ctlAnchor");
                    //							pItem.Cells[0].Text = "<a name=\"" + pItem.ItemIndex.ToString() + "\">";
                    //						}

                    if (Session["pSelectedIndex"] != null)
                    {
                        pSelectedIndex = Convert.ToInt32(Session["pSelectedIndex"]);
                        ViewState["portfolioID"] = dgPortfolio.DataKeys[pSelectedIndex].ToString();
                    }
                }
                else
                {
                    ViewState["itemCode"] = Request.QueryString["itemCode"];
                    ViewState["status"] = Request.QueryString["status"];
                    ViewState["backURL"] = Request.QueryString["back"];

                    getItemThumb(ViewState["itemCode"].ToString());
                    getPortfolioDataSet();

                }
            }

        }     

        private void getItemThumb(string sItemCode)
        {
            try
            {
                string sSQL = "Select * from chaProducts where itemCode = '" + sItemCode + "'";

                iConn = new SqlConnection(mMain.sDataPath);
                iAdapter = new SqlDataAdapter(sSQL, iConn);
                iAdapter.Fill(iDataSet, "chaProducts");

                if (iDataSet.Tables["chaProducts"].Rows.Count > 0)
                {
                    iItem.ImageUrl = iDataSet.Tables["chaProducts"].Rows[0]["image1Thumb"].ToString();
                    lbItemCode.Text = sItemCode;
                }

            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                lbInfo.Text = sError;
            }

        }

        public void getPortfolioDataSet()
        {
            try
            {
                string sSQL = "Select * from chaPortfolios where memberID = " + Session["memberID"];

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaPortfolios");

                if (mDataSet.Tables["chaPortfolios"].Rows.Count > 0)
                {
                    bindPortfolio();
                }
                else
                {
                    lbInfo2.Text = "You don't have any portfolios to add this item to."
                        + "<br><br>Please go to My Workshop and create a new portfolio.";
                    butMyWorkshop.Visible = true;
                    Panel1.Visible = false;
                }
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                lbInfo.Text = sError;
            }
        }	//end getAccountDataSet()	

        private void bindPortfolio()
        {
            try
            {
                dgPortfolio.DataSource = mDataSet.Tables["chaPortfolios"].DefaultView;
                dgPortfolio.DataMember = "chaPortfolio";
                dgPortfolio.DataBind();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }

        public void dgPortfolio_selectItemEventHandler(object sender, DataGridCommandEventArgs e)
        {
            if (Session["memberID"].ToString() == "")
            {
                showJSMessage("Your Session has expired due to inactivity.  Please login again.");
                Response.Redirect("chameleon-memberLogin.aspx");
            }

            try
            {
                dgPortfolio.SelectedIndex = e.Item.ItemIndex;
                ViewState["portfolioID"] = dgPortfolio.DataKeys[e.Item.ItemIndex].ToString();
                ViewState["portfolioName"] = dgPortfolio.SelectedItem.Cells[3].Text.Trim();

            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                lbInfo.Text = sError;
            }
        }

        protected void dgPortfolio_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {

                bool exists;
                if (addItemToPortfolio(Convert.ToInt32(ViewState["portfolioID"].ToString()), ViewState["itemCode"].ToString(), ViewState["status"].ToString(), out exists))
                {
                    lbInfo.Text = "Item Added Successfully";
                    txtNotes.Enabled = false;
                    //showJSMessage("Item Added Successfully");
                    butReturn.Visible = true;
                    //closeJSWindow();
                    //openJSWindow();


                }
                else if (exists)
                {
                    lbInfo.Text = "Item already exists in this portfolio.<br><br>Please check the Item Code and try again.";
                    //showJSMessage("Item already exists in this portfolio. Please check the Item Code and try again");
                    //closeJSWindow();
                }
                else
                {
                    lbInfo.Text = "An error was encountered";
                    //showJSMessage("An error was encountered");
                    //butReturn.Visible = true;
                    //closeJSWindow();
                }
            }
            catch (Exception ex)
            {
                lbInfo.Text = ex.Message;
                //closeJSWindow();
            }
        }

        public bool addItemToPortfolio(int iPortfolioID, string sItemCode, string sStatus, out bool bExists)
        {

            bool success = false;
            bExists = false;

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
                ipNotes.Value = txtNotes.Text;
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
                    bExists = true;
                    success = false;

                }	// end if
                if ((int)dataCmd.Parameters[0].Value == 9)
                {
                    bExists = false;
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

        private void closeJSWindow()
        {
            System.Text.StringBuilder jScript = new System.Text.StringBuilder();
            jScript.Append("<script language=\"JavaScript\">");
            jScript.Append("window.close()");
            jScript.Append(";");
            jScript.Append("</script>");

            this.RegisterClientScriptBlock("closeWindow", jScript.ToString());
        }

        private void openJSWindow()
        {
            System.Text.StringBuilder jScript = new System.Text.StringBuilder();
            jScript.Append("<script language=\"JavaScript\">");
            jScript.Append("window.location='chameleon-memberViewPortfolio.aspx?'");
            jScript.Append(";");
            jScript.Append("</script>");

            this.RegisterClientScriptBlock("closeWindow", jScript.ToString());
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

        protected void butReturn_Click(object sender, System.EventArgs e)
        {
            string sPortID = ViewState["portfolioID"].ToString();
            string sPortName = Server.UrlEncode(ViewState["portfolioName"].ToString());
            Response.Redirect("chameleon-memberViewPortfolio.aspx?portfolioID=" + ViewState["portfolioID"] + "&portfolioName=" + sPortName);

        }

        protected void butContinue_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(ViewState["backURL"].ToString(), true);
        }

        protected void butMyWorkshop_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("chameleon-memberHome.aspx", true);
        }
    }
}