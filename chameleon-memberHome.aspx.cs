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
    public partial class chameleon_memberHome : System.Web.UI.Page
    {
        #region User Defined Decs
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private int iUserID;
        private string sUserName;
        private string sWhere = "";
        private string sSearchHeading = "";
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(webEnabled = 1 and status <> 'Sold' or (webEnabled = 1 and status = 'Sold' and DATEDIFF (day,dateSold,getdate() ) <= 21))";

        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
         {
            if (!Page.IsPostBack)
            {
                butSavePortfolio.Attributes.Add("onclick", "return validatePortfolioName();");
            }

         
            if (this.IsPostBack)
            {
                if (checkSession())
                {
                    iUserID = Convert.ToInt32(Session["memberID"]);
                    sUserName = Session["userName"].ToString();
                    string s = "";


                }

                // Set up the Anchor control with the row location to
                // be used as a bookmark to set datagrid to the selected row	
                //ref: 	http://p2p.wrox.com/topic.asp?TOPIC_ID=7653
                //					foreach (DataGridItem pItem in dgPortfolio.Items)
                //					{
                //						pItem.FindControl("ctlAnchor");
                //						pItem.Cells[0].Text = "<a name=\"" + pItem.ItemIndex.ToString() + "\">";
                //					}
                //
                //					foreach (DataGridItem qItem in dgQueries.Items)
                //					{
                //						qItem.FindControl("ctlAnchor");
                //						qItem.Cells[0].Text = "<a name=\"" + qItem.ItemIndex.ToString() + "\">";
                //					}

            }
            else
            {
                if (checkSession())
                {
                    getPortfolioDataSet();
                    getQueryDataSet();
                    //						if(Session["firstName"].ToString() == "Robert")
                    //							lbName.Text = "Welcome " + Session["firstName"].ToString()+ " !  Feeling anally retentive today?";
                    //						else
                    lbName.Text = "Welcome " + Session["firstName"].ToString() + " !";
                }
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

                if (mDataSet.Tables["chaPortfolios"].DefaultView.Count > 0)
                {
                    pnlPortfolio.Visible = true;
                    //dgPortfolio.Enabled = true;
                    lbInfo.Text = "";
                    bindPortfolio();
                }
                else
                {
                    pnlPortfolio.Visible = false;
                    //dgPortfolio.Enabled = false;
                    //bindPortfolio();	
                    lbInfo.Text = "You have no saved portfolios";
                }


            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }	//end getAccountDataSet()

        private void bindPortfolio()
        {
            try
            {
                dgPortfolio.DataSource = mDataSet.Tables["chaPortfolios"].DefaultView;
                dgPortfolio.DataMember = "chaPortfolio";
                dgPortfolio.DataBind();
                dgPortfolio.SelectedIndex = -1;
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }

        public void dgPortfolio_selectItemEventHandler(object sender, DataGridCommandEventArgs e)
        {
            if (checkSession())
            {


                try
                {
                    dgPortfolio.SelectedIndex = e.Item.ItemIndex;
                    ViewState["portfolioID"] = Convert.ToInt32(dgPortfolio.DataKeys[e.Item.ItemIndex].ToString());

                    //string s = ViewState["portfolioID"].ToString();

                    ViewState["pSelectedIndex"] = e.Item.ItemIndex;


                }
                catch (Exception err)
                {

                    string sError = err.Message.ToString();

                    sError = "";
                }
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

        
        private void SetGridBookmark()
        {
            try
            {
                // - ref: http://p2p.wrox.com/topic.asp?TOPIC_ID=7653
                System.Text.StringBuilder jScript = new System.Text.StringBuilder();
                jScript.Append("<script language=\"JavaScript\">");
                jScript.Append("location.href=\"#");
                jScript.Append(ViewState["GridBookmark"].ToString());
                jScript.Append("\";");
                jScript.Append("</script>");
                string js = jScript.ToString();

                this.RegisterClientScriptBlock("Bookmark", jScript.ToString());
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

      
        private void viewPortfolio()
        {
            //				Context.Items.Add("portfolioID",ViewState["portfolioID"]);
            //				Context.Items.Add("portfolioName", ViewState["portfolioName"]);
            //				Server.Transfer("chameleon-memberViewPortfolio.aspx");

            string sPortID = ViewState["portfolioID"].ToString();
            string sPortName = Server.UrlEncode(ViewState["portfolioName"].ToString());
            Response.Redirect("chameleon-memberViewPortfolio.aspx?portfolioID=" + ViewState["portfolioID"] + "&portfolioName=" + sPortName);
        }

        public void getQueryDataSet()
        {
            try
            {
                string sSQL = "Select * from chaMemberQueries where memberID = " + Session["memberID"];

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaMemberQueries");

                //string count = mDataSet.Tables["chaPortfolio"].Rows.Count.ToString();
                //string s = mDataSet.Tables["chaPortfolio"].Rows[0]["userID"].ToString();
                if (mDataSet.Tables["chaMemberQueries"].DefaultView.Count > 0)
                {
                    pnlQuery.Visible = true;
                    lbInfo2.Text = "";
                    bindDGQueries();
                }
                else
                {
                    pnlQuery.Visible = false;
                    lbInfo2.Text = "You have no saved searches.";
                }

            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }	//end getAccountDataSet()

        private void bindDGQueries()
        {
            try
            {
                dgQueries.DataSource = mDataSet.Tables["chaMemberQueries"].DefaultView;
                dgQueries.DataMember = "chaMemberQueries";
                dgQueries.DataBind();
                dgQueries.SelectedIndex = -1;
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }

        //public void dgQueries_selectItemEventHandler(object sender, DataGridCommandEventArgs e)
        //{
        //    if (checkSession())
        //    {
        //        try
        //        {
        //            dgQueries.SelectedIndex = e.Item.ItemIndex;
        //            //Session["userID"] = dgPortfolio.DataKeys[e.Item.ItemIndex].ToString();
        //            ViewState["queryID"] = dgQueries.DataKeys[e.Item.ItemIndex].ToString();

        //            //DataRowView rv = (DataRowView)e.Item.DataItem;
        //            //string i = e.Item.Cells[.ToString();
        //            //string s = mDataSet.Tables["chaMemberQueries"].Rows[e.Item.ItemIndex]["query"].ToString();
        //            //ViewState["query"] = mDataSet.Tables[0].DefaultView["query"].ToString();
        //            ViewState["qSelectedIndex"] = e.Item.ItemIndex;

        //            //Response.Redirect("chameleon-viewPortfolio.aspx");

        //        }
        //        catch (Exception err)
        //        {
        //            string sError = err.Message.ToString();
        //        }
        //    }
        //}

        //protected void dgQueries_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        // bookmark the selected datagrid row (so that 3rds row above shows at the top)	
        //        //ref: 	http://p2p.wrox.com/topic.asp?TOPIC_ID=7653
        //        //ViewState["GridBookmark"] = dgQueries.Items[dgQueries.SelectedIndex].ItemIndex-3;			
        //        //SetGridBookmark();
        //        loadQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //}

        private void loadQuery()
        {
            if (checkSession())
            {
                //Context.Items.Add("queryID", ViewState["queryID"]);
                //Server.Transfer("chameleon-memberResults.aspx");
                string qID = ViewState["queryID"].ToString();
                Response.Redirect("chameleon-memberResults.aspx?line=Custom&queryID=" + qID);
            }
        }

        protected void butNewPortfolio_Click(object sender, System.EventArgs e)
        {
            try
            {
                butNewPortfolio.Visible = false;
                lbPortfolioName.Visible = true;
                txtPortfolioName.Visible = true;
                butSavePortfolio.Visible = true;
            }
            catch
            {
            }
        }

        protected void butSavePortfolio_Click(object sender, System.EventArgs e)
        {
            if (checkSession())
            {
                if (createPortfolio(Convert.ToInt32(Session["memberID"].ToString())))
                {
                    lbPortfolioName.Visible = false;
                    txtPortfolioName.Text = "";
                    txtPortfolioName.Visible = false;
                    butSavePortfolio.Visible = false;
                    butNewPortfolio.Visible = true;

                    getPortfolioDataSet();
                    //dgPortfolio.SelectedIndex = -1;
                }
                else
                {
                    showJSMessage("Error Creating Portfolio.");
                }

            }

        }

        public bool createPortfolio(int iMemberID)
        {
            bool success = false;

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
                dataCmd = new SqlCommand("udsp_insertPortfolio", dataConn);
                dataCmd.CommandType = CommandType.StoredProcedure;


                // declare and instantiate parameters collection
                SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                SqlParameter ipMemberID = new SqlParameter("@memberID", SqlDbType.Int);
                SqlParameter ipPortfolioName = new SqlParameter("@portfolioName", SqlDbType.VarChar, 50);
                SqlParameter ipDateCreated = new SqlParameter("@dateCreated", SqlDbType.DateTime);

                // specify parameter direction
                opReturnCode.Direction = ParameterDirection.ReturnValue;
                ipMemberID.Direction = ParameterDirection.Input;
                ipPortfolioName.Direction = ParameterDirection.Input;
                ipDateCreated.Direction = ParameterDirection.Input;

                // initialize parameter values
                ipMemberID.Value = iMemberID;
                ipPortfolioName.Value = txtPortfolioName.Text;
                ipDateCreated.Value = System.DateTime.Now;

                // add parameters to collection
                dataCmd.Parameters.Add(opReturnCode);
                dataCmd.Parameters.Add(ipMemberID);
                dataCmd.Parameters.Add(ipPortfolioName);
                dataCmd.Parameters.Add(ipDateCreated);

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

        private bool checkSession()
        {
            //string s = Session["memberID"].ToString();
            if (Session["memberID"] != null && Session["memberID"].ToString() != "")
            {
                return true;
            }
            else
            {
                //showJSMessage("Your Session has expired due to inactivity.  Please login again.");
                Response.Redirect("chameleon-memberLogin.aspx");
                return false;
            }
        }

       
        private bool deletePortfolio(int portfolioID)
        {

            string sConn;
            string sSql;

            sConn = mMain.sDataPath;
            sSql = "DELETE chaPortfolios WHERE portfolioID = " + portfolioID;
            SqlConnection conn = new SqlConnection(sConn);
            SqlCommand cmd = new SqlCommand(sSql, conn);

            //Declare parameters
            SqlParameter param1;

            //Define parameters' data types
            param1 = cmd.Parameters.Add("@portfolioID", SqlDbType.Int);

            //Assign parameters' values
            param1.Value = portfolioID;

            try
            {
                //Open db connection and execute stored proc
                conn.Open();
                cmd.ExecuteNonQuery();
                //int rows = cmd.ExecuteNonQuery();
                //showJSMessage(rows.ToString() + " rows deleted");
                return true;
            }
            catch (Exception err)
            {
                //showJSMessage(err.ToString());
                return false;
            }
            finally
            {
                //close db connection
                conn.Close();
            }
            //bool success = false;

            //// declare variables
            //string sConnection = null;

            //// initialize ADO objects
            //SqlConnection dataConn = null;
            //SqlDataReader dbReader = null;
            //SqlCommand dataCmd = null;

            //try
            //{
            //    sConnection = mMain.sDataPath;

            //    dataConn = new SqlConnection(sConnection);
            //    dataConn.Open();

            //    // set command object attributes
            //    dataCmd = new SqlCommand("udsp_deletePortfolio", dataConn);
            //    dataCmd.CommandType = CommandType.StoredProcedure;


            //    // declare and instantiate parameters collection
            //    SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            //    SqlParameter ipPortfolioID = new SqlParameter("@portfolioID", SqlDbType.Int);

            //    // specify parameter direction
            //    opReturnCode.Direction = ParameterDirection.ReturnValue;
            //    ipPortfolioID.Direction = ParameterDirection.Input;

            //    // initialize parameter values
            //    ipPortfolioID.Value = portfolioID;

            //    // add parameters to collection
            //    dataCmd.Parameters.Add(opReturnCode);
            //    dataCmd.Parameters.Add(ipPortfolioID);

            //    // execute command
            //    dataCmd.ExecuteReader();


            //    // test return value and transfer control as necessary
            //    if ((int)dataCmd.Parameters[0].Value == 9)
            //    {
            //        success = true;

            //    }	// end if

            //}	//end try
            //catch (SqlException sqle)
            //{
            //    throw sqle;

            //}	//end catch 
            //catch (Exception z)
            //{
            //    throw z;

            //}	//end catch 
            //finally
            //{
            //    // clean up
            //    if (dbReader != null)
            //    {
            //        dbReader.Close();

            //    }	// end if

            //    dataConn.Close();
            //    dataConn.Dispose();
            //    dataCmd.Dispose();

            //}	// end finally

            //return success;
        }

        private bool deleteQuery(int queryID)
        {
            string sConn;
            string sSql;

            sConn = mMain.sDataPath;
            sSql = "DELETE chaMemberQueries WHERE queryID = " + queryID;
            SqlConnection conn = new SqlConnection(sConn);
            SqlCommand cmd = new SqlCommand(sSql, conn);

            //Declare parameters
            SqlParameter param1;

            //Define parameters' data types
            param1 = cmd.Parameters.Add("@queryID", SqlDbType.Int);

            //Assign parameters' values
            param1.Value = queryID;

            try
            {
                //Open db connection and execute stored proc
                conn.Open();
                cmd.ExecuteNonQuery();
                //int rows = cmd.ExecuteNonQuery();
                //showJSMessage(rows.ToString() + " rows deleted");
                return true;
            }
            catch (Exception err)
            {
                //showJSMessage(err.ToString());
                return false;
            }
            finally
            {
                //close db connection
                conn.Close();
            }
        }

        protected void butLoginRegister_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (IsLoggedIn())
            {
                Session["memberID"] = null;
                Response.Redirect("chameleon-home.aspx", true);
            }
            else
            {
                Response.Redirect("chameleon-memberLogin.aspx", true);
            }
        }

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

        protected void butMyWorkshop_B_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-memberHome.aspx", true);
        }

        protected void butMyProfile_B_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-memberProfile.aspx", true);
        }

        protected void butAllInventory_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=All", true);
        }

        protected void butAllAntiques_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=Antiques", true);
        }

        protected void butAllSignature_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=Signature", true);
        }

        protected void butRequestCatalog_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-catalogRequest.aspx", true);
        }

        protected void butAdvancedSearch_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-advancedSearch.aspx", true);
        }

        protected void butRecentArrivals_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-recentArrivals.aspx", true);
        }


        //ADDED BY ROB START

        protected void butTraditional_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=Traditional", true);
        }

        protected void butContemporary_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=Contemporary", true);
        }

        //ADDED BY ROB END



       
        //private void dgQueries_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{


        //    try
        //    {

        //        if (deleteQuery(Convert.ToInt32(ViewState["queryID"].ToString())))
        //        {
        //            //showJSMessage("Query ID " + ViewState["queryID"].ToString() + " deleted");
        //            // Do this to avoid reposting delete command if user presses back button on browser
        //            Response.Redirect("chameleon-memberHome.aspx");
        //            //getQueryDataSet();
        //        }
        //        else
        //        {
        //            showJSMessage("error deleting query");
        //        }

        //    }
        //    catch { }

        //}

       

        protected void butNewQuery_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("chameleon-advancedSearch.aspx", true);
        }

        private void bldJSConfirmDel(string sMessage)
        {

            System.Text.StringBuilder sbConfirm = new System.Text.StringBuilder();
            sbConfirm.Append("<script language=javascript>");
            sbConfirm.Append(Environment.NewLine);

            sbConfirm.Append(Environment.NewLine);
            sbConfirm.Append("function mConfirmDel()");
            sbConfirm.Append(Environment.NewLine);
            sbConfirm.Append("{");


            sbConfirm.Append(Environment.NewLine);
            sbConfirm.Append(" if(confirm('");
            sbConfirm.Append(sMessage);
            sbConfirm.Append("')== true)");
            sbConfirm.Append(Environment.NewLine);
            sbConfirm.Append("  return true;");
            sbConfirm.Append(Environment.NewLine);

            sbConfirm.Append("else ");
            sbConfirm.Append(Environment.NewLine);

            sbConfirm.Append("{return false;}");

            sbConfirm.Append(Environment.NewLine);
            sbConfirm.Append("}");

            sbConfirm.Append(Environment.NewLine);
            //sbConfirm.Append("confirm()");
            sbConfirm.Append("</script>");
            Response.Write(sbConfirm.ToString());
        }

      
        
      

        public bool updatePortfolioName(int iPortfolioID, string sPortfolioName)
        {
            bool success = false;

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
                dataCmd = new SqlCommand("udsp_updatePortfolioName", dataConn);
                dataCmd.CommandType = CommandType.StoredProcedure;


                // declare and instantiate parameters collection
                SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                SqlParameter ipPortfolioID = new SqlParameter("@portfolioID", SqlDbType.Int);
                SqlParameter ipPortfolioName = new SqlParameter("@portfolioName", SqlDbType.VarChar, 50);


                // specify parameter direction
                opReturnCode.Direction = ParameterDirection.ReturnValue;
                ipPortfolioID.Direction = ParameterDirection.Input;
                ipPortfolioName.Direction = ParameterDirection.Input;


                // initialize parameter values
                ipPortfolioID.Value = iPortfolioID;
                ipPortfolioName.Value = sPortfolioName;


                // add parameters to collection
                dataCmd.Parameters.Add(opReturnCode);
                dataCmd.Parameters.Add(ipPortfolioID);
                dataCmd.Parameters.Add(ipPortfolioName);

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

        public bool updateQueryName(int queryID, string sQueryName)
        {
            string sConn;
            string sSql;

            sConn = mMain.sDataPath;
            sSql = "Update chaMemberQueries set queryName = '" + sQueryName + "'  WHERE queryID = " + queryID;
            SqlConnection conn = new SqlConnection(sConn);
            SqlCommand cmd = new SqlCommand(sSql, conn);

            //Declare parameters
            SqlParameter param1;
            SqlParameter param2;

            //Define parameters' data types
            param1 = cmd.Parameters.Add("@queryID", SqlDbType.Int);
            param2 = cmd.Parameters.Add("@queryName", SqlDbType.VarChar);

            //Assign parameters' values
            param1.Value = queryID;
            param2.Value = sQueryName;

            try
            {
                //Open db connection and execute stored proc
                conn.Open();
                cmd.ExecuteNonQuery();
                //int rows = cmd.ExecuteNonQuery();
                //showJSMessage(rows.ToString() + " rows deleted");
                return true;
            }
            catch (Exception err)
            {
                //showJSMessage(err.ToString());
                return false;
            }
            finally
            {
                //close db connection
                conn.Close();
            }
            
            //bool success = false;

            //// declare variables
            //string sConnection = null;

            //// initialize ADO objects
            //SqlConnection dataConn = null;
            //SqlDataReader dbReader = null;
            //SqlCommand dataCmd = null;

            //try
            //{
            //    sConnection = mMain.sDataPath;

            //    dataConn = new SqlConnection(sConnection);
            //    dataConn.Open();

            //    // set command object attributes
            //    dataCmd = new SqlCommand("udsp_updateQueryName", dataConn);
            //    dataCmd.CommandType = CommandType.StoredProcedure;


            //    // declare and instantiate parameters collection
            //    SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            //    SqlParameter ipQueryID = new SqlParameter("@queryID", SqlDbType.Int);
            //    SqlParameter ipQueryName = new SqlParameter("@queryName", SqlDbType.VarChar, 50);


            //    // specify parameter direction
            //    opReturnCode.Direction = ParameterDirection.ReturnValue;
            //    ipQueryID.Direction = ParameterDirection.Input;
            //    ipQueryName.Direction = ParameterDirection.Input;


            //    // initialize parameter values
            //    ipQueryID.Value = iQueryID;
            //    ipQueryName.Value = sQueryName;


            //    // add parameters to collection
            //    dataCmd.Parameters.Add(opReturnCode);
            //    dataCmd.Parameters.Add(ipQueryID);
            //    dataCmd.Parameters.Add(ipQueryName);

            //    // execute command
            //    dataCmd.ExecuteReader();


            //    // test return value and transfer control as necessary
            //    if ((int)dataCmd.Parameters[0].Value == 9)
            //    {
            //        success = true;

            //    }	// end if

            //}	//end try
            //catch (SqlException sqle)
            //{
            //    throw sqle;

            //}	//end catch 
            //catch (Exception z)
            //{
            //    throw z;

            //}	//end catch 
            //finally
            //{
            //    // clean up
            //    if (dbReader != null)
            //    {
            //        dbReader.Close();

            //    }	// end if

            //    dataConn.Close();
            //    dataConn.Dispose();
            //    dataCmd.Dispose();

            //}	// end finally

            //return success;
        }

        private void dgQueries_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btn2 = (LinkButton)(e.Item.Cells[5].Controls[0]);
                btn2.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this search?');");
            }
        }

       
        protected void dgPortfolio_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgPortfolio.EditItemIndex = -1;
            getPortfolioDataSet();
        }

        protected void dgPortfolio_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
                            //bldJSConfirmDel("This will delete the selected portfolio.  " +
                            //        "If you wish to continue, press OK.  Otherwise press Cancel");
                            //btnDelete.Attributes.Add("onclick", "return mConfirmDel();");

                try
                {
                    if (deletePortfolio(Convert.ToInt32(ViewState["portfolioID"].ToString())))
                    {
                        //showJSMessage("Portfolio ID " + ViewState["portfolioID"].ToString() + " deleted");
                        //getPortfolioDataSet();
                        // Do this to avoid reposting delete command if user presses back button on browser
                        Response.Redirect("chameleon-memberHome.aspx");
                    }
                    else
                    {
                        showJSMessage("error deleting portfolio");
                    }


                }
                catch { }
        }

        protected void dgPortfolio_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgPortfolio.EditItemIndex = e.Item.ItemIndex;
            getPortfolioDataSet();
        }

        protected void dgPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // bookmark the selected datagrid row (so that 3rds row above shows at the top)	
            //ref: 	http://p2p.wrox.com/topic.asp?TOPIC_ID=7653
            //ViewState["GridBookmark"] = dgPortfolio.Items[dgPortfolio.SelectedIndex].ItemIndex-3;

            //SetGridBookmark();

            ViewState["portfolioName"] = dgPortfolio.SelectedItem.Cells[3].Text.Trim();
            //string s = 	ViewState["portfolioName"].ToString();	
            viewPortfolio();
        }

        protected void dgPortfolio_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox pName = new TextBox();
            pName = (TextBox)(e.Item.Cells[3].Controls[0]);
            //dgQueries.DataKeys[e.Item.ItemIndex].ToString();
            if (pName.Text != "")
            {
                updatePortfolioName(Convert.ToInt32(ViewState["portfolioID"].ToString()), pName.Text);
            }
            dgPortfolio.EditItemIndex = -1;
            getPortfolioDataSet();
        }

        protected void dgPortfolio_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            try
            {
                //string sSQL = "Select * from chaPortfolio where owner = '" + Session["userID"] + "'";	
                this.getPortfolioDataSet();
                mDataSet.Tables["chaportfolios"].DefaultView.Sort = e.SortExpression; //sortExpr;
                bindPortfolio();
            }
            catch { }
        }

        protected void dgQueries_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgQueries.EditItemIndex = -1;
            getQueryDataSet();
        }

        protected void dgQueries_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {

                if (deleteQuery(Convert.ToInt32(ViewState["queryID"].ToString())))
                {
                    //showJSMessage("Query ID " + ViewState["queryID"].ToString() + " deleted");
                    // Do this to avoid reposting delete command if user presses back button on browser
                    Response.Redirect("chameleon-memberHome.aspx");
                    //getQueryDataSet();
                }
                else
                {
                    showJSMessage("error deleting query");
                }

            }
            catch { }
        }

        protected void dgQueries_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgQueries.EditItemIndex = e.Item.ItemIndex;
            getQueryDataSet();
        }

        protected void dgQueries_selectItemEventHandler(object source, DataGridCommandEventArgs e)
        {
            if (checkSession())
            {
                try
                {
                    dgQueries.SelectedIndex = e.Item.ItemIndex;
                    //Session["userID"] = dgPortfolio.DataKeys[e.Item.ItemIndex].ToString();
                    ViewState["queryID"] = dgQueries.DataKeys[e.Item.ItemIndex].ToString();

                    //DataRowView rv = (DataRowView)e.Item.DataItem;
                    //string i = e.Item.Cells[.ToString();
                    //string s = mDataSet.Tables["chaMemberQueries"].Rows[e.Item.ItemIndex]["query"].ToString();
                    //ViewState["query"] = mDataSet.Tables[0].DefaultView["query"].ToString();
                    ViewState["qSelectedIndex"] = e.Item.ItemIndex;

                    //Response.Redirect("chameleon-viewPortfolio.aspx");

                }
                catch (Exception err)
                {
                    string sError = err.Message.ToString();
                }
            }
        }

        protected void dgQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // bookmark the selected datagrid row (so that 3rds row above shows at the top)	
                //ref: 	http://p2p.wrox.com/topic.asp?TOPIC_ID=7653
                //ViewState["GridBookmark"] = dgQueries.Items[dgQueries.SelectedIndex].ItemIndex-3;			
                //SetGridBookmark();
                loadQuery();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        protected void dgQueries_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            try
            {
                this.getQueryDataSet();
                mDataSet.Tables["chaMemberQueries"].DefaultView.Sort = e.SortExpression; //sortExpr;
                bindDGQueries();
            }
            catch { }
        }

        protected void dgQueries_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox qName = new TextBox();
            qName = (TextBox)(e.Item.Cells[3].Controls[0]);
            //dgQueries.DataKeys[e.Item.ItemIndex].ToString();
            if (qName.Text != "")
            {
                updateQueryName(Convert.ToInt32(ViewState["queryID"].ToString()), qName.Text);
            }
            dgQueries.EditItemIndex = -1;
            getQueryDataSet();
        }

        //private void dgQueries_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    dgQueries.EditItemIndex = -1;
        //    getQueryDataSet();
        //}

        //private void dgQueries_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    dgQueries.EditItemIndex = e.Item.ItemIndex;
        //    getQueryDataSet();
        //}

        //private void dgQueries_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    TextBox qName = new TextBox();
        //    qName = (TextBox)(e.Item.Cells[3].Controls[0]);
        //    //dgQueries.DataKeys[e.Item.ItemIndex].ToString();
        //    if (qName.Text != "")
        //    {
        //        updateQueryName(Convert.ToInt32(ViewState["queryID"].ToString()), qName.Text);
        //    }
        //    dgQueries.EditItemIndex = -1;
        //    getQueryDataSet();
        //}
        
        

        
    }
}