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
using ImageResizer;
using System.IO;
using System.Drawing;
using Dwg = System.Drawing;
using System.Drawing.Imaging;

namespace IChameleon
{
    public partial class chameleon_memberResults : System.Web.UI.Page
    {
        #region User Defined Decs

        private DataSet mDataSet = new DataSet();
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private SqlConnection mConn;
        private SqlCommand mCmd;
        private const string sourceName = "chaProducts";
        private const string sqlOrderBy = "prefix, suffix";
        private const int recPerPage = 51;
        private int recCount = 0;
        private int pageCount = 0;
        private int curPage = 0;
        private LinkButton lPrev1 = new LinkButton();
        private LinkButton lNext1 = new LinkButton();
        private LinkButton lPrev2 = new LinkButton();
        private LinkButton lNext2 = new LinkButton();
        private LinkButton link1 = new LinkButton();
        private LinkButton link2 = new LinkButton();
        private string sWhere = String.Empty;
        private string sSearchHeading = String.Empty;
        private string sLine = String.Empty;
        private string sSort = String.Empty;
        private string sLinkTo = String.Empty;
        private string sOrderBy = String.Empty;
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        //private string sStatus = "(webEnabled = 1 and status <> 'Sold') or (DATEDIFF (day,dateUpdated,getdate() ) <= 21 and status = 'Sold')";
        private string sStatus = "(webEnabled = 1 and status <> 'Sold' or (webEnabled = 1 and status = 'Sold' and DATEDIFF (day,dateSold,getdate() ) <= 21))";

        private bool hasPortfolio = false;

        // initialize ADO objects
        private SqlConnection dataConn = null;


        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {


            if (checkSession())
            {
                try
                {
                    if (!Page.IsPostBack)
                    {

                        sSearchHeading = Request.QueryString["heading"];
                        //sWhere = Request.QueryString["where"];
                        sLine = Request.QueryString["Line"];
                        sSort = Request.QueryString["sort"];

                        if (Request.QueryString["sOrderBy"] != null)// && Request.QueryString["sOrderBy"].ToString() != String.Empty)
                        {
                            sOrderBy = Request.QueryString["sOrderBy"];
                            ViewState["sOrderBy"] = sOrderBy;
                        }
                        else
                        {
                            sOrderBy = "itemCode";
                            ViewState["sOrderBy"] = sOrderBy;
                        }

                        sLine = Request.QueryString["Line"];

                        if (sSearchHeading == "Custom Query Results")
                        {
                            sLine = "Custom";
                        }

                        string str = Request.QueryString["where"];
                        if (str != null && str != "")
                        {
                            sWhere = str;
                        }
                        else if (Session["linkSqlWhere"] != null && Session["linkSqlWhere"].ToString() != "")
                        {
                            sWhere = Session["linkSqlWhere"].ToString();
                            Session["linkSqlWhere"] = null;
                        }
                        else
                        {
                            str = Request.QueryString["queryID"];
                            if (str != null && str != "")
                            {

                                try
                                {
                                    string sSQL = "Select * from chaMemberQueries where queryID = " + Convert.ToInt32(str);

                                    mConn = new SqlConnection(mMain.sDataPath);
                                    mAdapter = new SqlDataAdapter(sSQL, mConn);
                                    mAdapter.Fill(mDataSet, "chaMemberQueries");

                                    if (mDataSet.Tables["chaMemberQueries"].DefaultView.Count > 0)
                                    {
                                        // ViewState["sWhere"] = mDataSet.Tables["chaMemberQueries"].Rows[0]["query"].ToString();
                                        sWhere = mDataSet.Tables["chaMemberQueries"].Rows[0]["query"].ToString();
                                    }

                                }
                                catch (Exception err)
                                {
                                    string sError = err.Message.ToString();
                                }

                            }
                        }

                        sSort = Request.QueryString["sort"];

                        ViewState["backURL"] = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToString();

                        if (Request.QueryString["sOrderBy"] != null)// && Request.QueryString["sOrderBy"].ToString() != String.Empty)
                        {
                            sOrderBy = Request.QueryString["sOrderBy"];
                            ViewState["sOrderBy"] = sOrderBy;
                        }
                        else
                        {
                            sOrderBy = "itemCode";
                            ViewState["sOrderBy"] = sOrderBy;
                        }

                        if (sLine != null && sLine != string.Empty)
                        {
                            initSortList(sLine);

                            switch (sLine)
                            {
                                case "All":
                                    {
                                        sSearchHeading = "All Product Lines";
                                        // Statement modified to exclude Antiques - 12-14-14
                                        sWhere = " Where (type = 'Signature') and " + sStatus; // +" and " + sOrderBy + " is not null";		

                                        break;
                                    }
                                case "Antiques":
                                    {
                                        sWhere = " Where type = 'Antique' and " + sStatus;
                                        sSearchHeading = "Antique > all Items";
                                        sLinkTo = "<br> to search within these results <a href=chameleon-antique.aspx class='linkRed'> click here</a>";

                                        break;
                                    }
                                case "Signature":
                                    {
                                        sWhere = " Where type = 'Signature' and " + sStatus; // +" and " + sOrderBy + " is not null";		
                                        sSearchHeading = "Signature > All Items";
                                        sLinkTo = "<br> to search within these results <a href=chameleon-signature.aspx class='linkRed'> click here</a>";

                                        break;
                                    }

                                //ADDED BY ROB START             

                                case "Traditional":
                                    {
                                        sSearchHeading = "Traditional";
                                        // Statement modified to exclude Antiques - 12-14-14
                                        sWhere = " Where (type = 'Signature') and " + sStatus + " AND style NOT LIKE '%Murano%' AND style NOT LIKE '%Moderne%' AND style NOT LIKE '%Deco%' AND style NOT LIKE '%Nautical%' AND style NOT LIKE '%Industrial%' AND style NOT LIKE '%Art Nouveau%' AND style NOT LIKE '%Arts && Crafts%' AND style NOT LIKE '%Bagues%' AND style NOT LIKE '%Decoupage%' AND style NOT LIKE '%Venetian%'";

                                        break;
                                    }

                                case "Contemporary":
                                    {
                                        sSearchHeading = "Contemporary";
                                        // Statement modified to exclude Antiques - 12-14-14
                                        sWhere = " Where (type = 'Signature') and " + sStatus + " AND (style LIKE '%Murano%' OR style LIKE '%Moderne%' OR style LIKE '%Deco%' OR style LIKE '%Nautical%' OR style LIKE '%Industrial%' OR style LIKE '%Art Nouveau%' OR style LIKE '%Arts && Crafts%' OR style LIKE '%Bagues%' OR style LIKE '%Decoupage%' OR style LIKE '%Venetian%')";

                                        break;
                                    }
                                case "Custom":
                                    {
                                        sSearchHeading = "Custom Query Results";

                                        break;
                                    }

                                default:
                                    enableSortList(false);
                                    break;

                                //ADDED BY ROB END


                            }
                        }

                        if (sWhere == null || sWhere == "")
                        {
                            if (Session["sWhere"] != null && Session["sWhere"].ToString() != "")
                                sWhere = Session["sWhere"].ToString();
                            else
                            {
                                showJSMessage("Your session has expired.  Please begin your search again");
                                jsLocation("chameleon-advancedSearch.aspx");
                                //jsHistory();
                            }

                            //Session["sWhere"] = null;
                        }

                        if (sSearchHeading != null && sSearchHeading != string.Empty)
                        {
                            ViewState["sSearchHeading"] = sSearchHeading;

                            if (sLinkTo != "")
                            {
                                lbSearchHeading.Text = sSearchHeading + sLinkTo;
                            }
                            else
                            {
                                lbSearchHeading.Text = sSearchHeading;  //ROB CHANGED...FOLLOWING WAS APPENDED TO PRIOR   +"<br>Click 'Back' on your browser to refine your search.";
                            }
                        }

                        if (sWhere != null && sWhere != string.Empty)
                        {
                            ViewState["sWhere"] = sWhere;
                        }

                        if (sLine != null && sLine != string.Empty)
                        {
                            ViewState["sLine"] = sLine;
                        }

                        buildQuery();

                        string result = Request.QueryString["pageNo"];
                        if (result != null && result != string.Empty)
                        {
                            pageCount = Convert.ToInt32(ViewState["pageCount"].ToString());

                            switch (Request.QueryString["pageNo"].ToString())
                            {
                                case "next":
                                    {
                                        curPage = Convert.ToInt32(Request.QueryString["curPage"]);
                                        if (curPage < pageCount)
                                        {
                                            curPage = curPage + 1;
                                        }
                                        else
                                        {
                                            curPage = pageCount;
                                        }
                                        break;
                                    }
                                case "prev":
                                    {
                                        curPage = Convert.ToInt32(Request.QueryString["curPage"]);
                                        if (curPage > 1)
                                        {
                                            curPage = curPage - 1;
                                        }
                                        else
                                        {
                                            curPage = 1;
                                        }
                                        break;
                                    }
                                default:
                                    curPage = Convert.ToInt32(Request.QueryString["pageNo"]);
                                    break;
                            } // end switch
                        }
                        else
                        {
                            curPage = 1;

                        }

                        ViewState["curPage"] = curPage;

                        createLinksTable(curPage);
                    }

                    else
                    {
                        Control cause = GetPostBackControl(Page);
                        if (cause != null)
                        {
                            if (cause.ID == "ddlSort")
                            {
                                curPage = 1;
                                ViewState["curPage"] = curPage;
                                ViewState["sOrderBy"] = ddlSort.SelectedValue.ToString();
                                // set page count to null in case # records change due to sort - this will set gettotalPages to fire
                                ViewState["pageCount"] = null;

                                sOrderBy = ViewState["sOrderBy"].ToString();
                            }
                            else
                            {
                                sOrderBy = "itemCode";
                                ViewState["sOrderBy"] = sOrderBy;
                            }
                        }
                        else
                        {
                            curPage = Convert.ToInt32(ViewState["curPage"]);
                        }

                        buildQuery();
                        createLinksTable(curPage);
                        //curPage = Convert.ToInt32(ViewState["curPage"]);
                        //createLinksTable(curPage);

                    }
                    getItemsDataSet();
                    setSortIndex(ViewState["sOrderBy"].ToString());

                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetAllowResponseInBrowserHistory(false);
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    err = "";
                }
            }
        }

        private void enableSortList(bool enable)
        {
            if (enable)
            {
                lbSortBy.Visible = true;
                ddlSort.Enabled = true;
                ddlSort.Visible = true;
            }
            else
            {
                lbSortBy.Visible = false;
                ddlSort.Enabled = false;
                ddlSort.Visible = false;
            }

        }

        private void initSortList(string line)
        {
            try
            {
                if (line == "Signature")
                {
                    ListItem number = new ListItem("Item Number", "itemCode");
                    ListItem item = new ListItem("Item Name", "item");
                    ListItem date = new ListItem("Date Added", "dateEntered");

                    ddlSort.Items.Insert(0, number);
                    ddlSort.Items.Insert(1, item);
                    ddlSort.Items.Insert(2, date);
                }
                else
                {
                    ListItem number = new ListItem("Item Number", "itemCode");
                    ListItem date = new ListItem("Date Added", "dateEntered");
                    ddlSort.Items.Insert(0, number);
                    ddlSort.Items.Insert(1, date);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void setSortIndex(string sortBy)
        {
            try
            {
                if (sortBy != String.Empty)
                {
                    ddlSort.SelectedValue = sortBy;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //private void setSortIndex(string sortBy)
        //{
        //    switch (sortBy)
        //    {
        //        case "itemCode":
        //            {
        //                //ddlSort.SelectedItem.Text = "Item Code";
        //                ddlSort.SelectedIndex = 0;
        //                break;
        //            }
        //        case "item":
        //            {
        //                //ddlSort.SelectedItem.Text = "Item";
        //                ddlSort.SelectedIndex = 1;
        //                break;
        //            }
        //        case "dateEntered":
        //            {
        //                //ddlSort.SelectedItem.Text = "Date Created";
        //                ddlSort.SelectedIndex = 2;
        //                break;
        //            }
        //        default:

        //            ddlSort.SelectedItem.Text = "Item Code";
        //            break;

        //    }

        //}

        public static Control GetPostBackControl(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }

        public static Control GetPostBackControl2(Page page)
        {

            Control postbackControlInstance = null;



            string postbackControlName = page.Request.Params.Get("__EVENTTARGET");

            if (postbackControlName != null && postbackControlName != string.Empty)
            {

                postbackControlInstance = page.FindControl(postbackControlName);

            }

            else
            {

                // handle the Button control postbacks

                for (int i = 0; i < page.Request.Form.Keys.Count; i++)
                {

                    postbackControlInstance = page.FindControl(page.Request.Form.Keys[i]);

                    if (postbackControlInstance is System.Web.UI.WebControls.Button)
                    {

                        return postbackControlInstance;

                    }

                }

            }

            // handle the ImageButton postbacks

            if (postbackControlInstance == null)
            {

                for (int i = 0; i < page.Request.Form.Count; i++)
                {

                    if ((page.Request.Form.Keys[i].EndsWith(".x")) || (page.Request.Form.Keys[i].EndsWith(".y")))
                    {

                        postbackControlInstance = page.FindControl(page.Request.Form.Keys[i].Substring(0, page.Request.Form.Keys[i].Length - 2));

                        return postbackControlInstance;

                    }

                }

            }

            return postbackControlInstance;

        }

        private void buildQuery()
        {

            string sSqlSelect = "SELECT TOP " + recPerPage + " * ";
            string sSqlFrom = " FROM " + sourceName;
            string sSqlWhere = " WHERE status = " + sStatus;
            string sSqlOrderBy = "";
            string sSqlStatement = "";
            string sSqlCount = "Select Count(*)";

            //if(Session["sqlWhere"] != null)
            if (ViewState["sWhere"] != null)
            {
                sSqlWhere = ViewState["sWhere"].ToString() + " and " + sOrderBy + " is not null";
                sSqlCount = sSqlCount + sSqlFrom + sSqlWhere;

            }
            else
            {
                ViewState["sWhere"] = sSqlWhere;
                sSqlCount = sSqlCount + sSqlFrom + sSqlWhere + " and " + sOrderBy + " is not null";
            }


            //sSqlStatement = sSqlSelect + sSqlFrom + sSqlWhere;

            //sSqlCount = sSqlCount + sSqlFrom + sSqlWhere;

            getTotalPages(sSqlCount);


        }

        public void getTotalPages(string sqlQuery)
        {
            if (ViewState["pageCount"] == null)
            {
                mConn = new SqlConnection(mMain.sDataPath);
                mCmd = new SqlCommand(sqlQuery, mConn);
                mConn.Open();
                recCount = Convert.ToInt32(mCmd.ExecuteScalar().ToString());
                ViewState["recCount"] = recCount;

                if (recCount % recPerPage == 0)
                {
                    pageCount = recCount / recPerPage;
                }
                else
                {
                    pageCount = recCount / recPerPage + 1;
                }

                ViewState["pageCount"] = pageCount;
                mConn.Close();
            }
            else
            {
                pageCount = Convert.ToInt32(ViewState["pageCount"].ToString());
            }

        }

        public void getItemsDataSet()
        {
            int pageNo = Convert.ToInt32(ViewState["curPage"].ToString());

            // declare variables
            string sConnection = null;

            try
            {

                sConnection = mMain.sDataPath;
                dataConn = new SqlConnection(sConnection);
                dataConn.Open();
                mDataSet = new DataSet();
                mAdapter = new SqlDataAdapter("udsp_getPagedResults9", dataConn);
                mAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                // declare and instantiate parameters collection
                SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);

                //	ACCOUNT PARAMETERS
                SqlParameter ipGoToPageNum = new SqlParameter("@GoToPageNum", SqlDbType.Int);
                SqlParameter ipRecordsPerPage = new SqlParameter("@RecordsPerPage", SqlDbType.Int);
                SqlParameter ipSQLWhere = new SqlParameter("@SQLWhere", SqlDbType.VarChar, 3000);
                SqlParameter ipTableName = new SqlParameter("@TableName", SqlDbType.VarChar, 255);
                SqlParameter ipOrderBY = new SqlParameter("@OrderBy", SqlDbType.VarChar, 255);
                SqlParameter ipSQLStatement = new SqlParameter("@sqlStatement", SqlDbType.VarChar, 3000);

                // specify parameter direction
                opReturnCode.Direction = ParameterDirection.ReturnValue;
                ipGoToPageNum.Direction = ParameterDirection.Input;
                ipRecordsPerPage.Direction = ParameterDirection.Input;
                ipSQLWhere.Direction = ParameterDirection.Input;
                ipTableName.Direction = ParameterDirection.Input;
                ipOrderBY.Direction = ParameterDirection.Input;
                ipSQLStatement.Direction = ParameterDirection.Output;

                // initialize query parameter values
                ipGoToPageNum.Value = Convert.ToInt32(ViewState["curPage"].ToString());
                ipRecordsPerPage.Value = recPerPage;

                if (ViewState["sWhere"] != null)
                    ipSQLWhere.Value = ViewState["sWhere"].ToString() + " and " + sOrderBy + " is not null";
                else
                    ipSQLWhere.Value = System.DBNull.Value;

                ipTableName.Value = sourceName;
                //ipOrderBY.Value = sqlOrderBy;
                if (ViewState["sOrderBy"] != null)
                    ipOrderBY.Value = ViewState["sOrderBy"].ToString();
                else
                    ipOrderBY.Value = sOrderBy;


                mAdapter.SelectCommand.Parameters.Add(opReturnCode);
                mAdapter.SelectCommand.Parameters.Add(ipGoToPageNum);
                mAdapter.SelectCommand.Parameters.Add(ipRecordsPerPage);
                mAdapter.SelectCommand.Parameters.Add(ipSQLWhere);
                mAdapter.SelectCommand.Parameters.Add(ipTableName);
                mAdapter.SelectCommand.Parameters.Add(ipOrderBY);
                mAdapter.SelectCommand.Parameters.Add(ipSQLStatement);

                mAdapter.Fill(mDataSet, "udsp_getPagedResults9");


                // test return value and transfer control as necessary
                string s = ipSQLStatement.Value.ToString();
                //s = mDataSet.Tables["udsp_getPagedResults"].Rows[0]["itemNumber"].ToString();
                if ((int)mAdapter.SelectCommand.Parameters[0].Value == 9)
                {
                    string sql = mAdapter.SelectCommand.Parameters["@sqlStatement"].Value.ToString();

                    if (mDataSet.Tables["udsp_getPagedResults9"].Rows.Count > 0)
                    {

                        lbInfo.Text = "";
                        lbInfo.Text = ViewState["recCount"].ToString() + " record(s) matched your search <br>";
                        //lbInfo.Text = lbInfo.Text + "Showing Page " + ViewState["curPage"].ToString() + " of " + ViewState["pageCount"].ToString();
                        lbInfo.Text = lbInfo.Text + "<br>click on image to display details<br><br>";
                        bindRItems();
                    }
                    else
                    {
                        lbInfo.Text = "No Records Matched your Search Criteria";

                    }

                }
                else
                {
                    lbInfo.Text = "Error Querying Database";


                }	// end if

            }	//end try
            catch (SqlException sqle)
            {

                lbInfo.Text = "Error Querying Database. Please contact the System Administrator with the following message: " + sqle.Message.ToString();


            }	//end catch 
            catch (Exception z)
            {
                lbInfo.Text = "Error Querying Database. Error Detail: " + z.Message.ToString() + " Please make sure input values are in correct format.";

            }	//end catch
            finally
            {

                dataConn.Close();
                dataConn.Dispose();
                //dataCmd.Dispose();

            }	// end finally


        }	//end getItemsDataSet()

        private void bindRItems()
        {
            try
            {
                if (sSort == "Price")
                {
                    DataView dv = new DataView();
                    dv = mDataSet.Tables["udsp_getPagedResults9"].DefaultView;
                    dv.Sort = "price1";

                    dItems.DataSource = dv;
                }
                else
                {
                    dItems.DataSource = mDataSet.Tables["udsp_getPagedResults9"].DefaultView;
                }
                dItems.DataBind();

            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                lbInfo.Text = sError;
                sError = "";

            }
        }

        private void checkForPortfolio()
        {

            try
            {
                string sSQL = "Select * from chaPortfolios where memberID = " + Session["memberID"];

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaPortfolios");

                if (mDataSet.Tables["chaPortfolios"].Rows.Count > 0)
                    hasPortfolio = true;
                else
                    hasPortfolio = false;
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                lbInfo.Text = sError;
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

        private void closeWindow()
        {
            System.Text.StringBuilder jScript = new System.Text.StringBuilder();
            jScript.Append("<script language=\"JavaScript\">");
            jScript.Append("window.close()");
            //jScript.Append(this.bookmarkIndex.ToString());
            jScript.Append(";");
            jScript.Append("</script>");

            this.RegisterClientScriptBlock("closeWindow", jScript.ToString());
        }

        private void jsLocation(string sLocation)
        {
            System.Text.StringBuilder jScript = new System.Text.StringBuilder();
            jScript.Append("<script language=\"JavaScript\">");
            jScript.Append("window.location = '" + sLocation + "'");
            //jScript.Append(this.bookmarkIndex.ToString());
            jScript.Append(";");
            jScript.Append("</script>");

            this.RegisterClientScriptBlock("closeWindow", jScript.ToString());
        }

        private void jsHistory()
        {
            System.Text.StringBuilder jScript = new System.Text.StringBuilder();
            jScript.Append("<script language=\"JavaScript\">");
            jScript.Append("history.go(-1)");
            //jScript.Append(this.bookmarkIndex.ToString());
            jScript.Append(";");
            jScript.Append("</script>");

            this.RegisterClientScriptBlock("closeWindow", jScript.ToString());
        }

        private void createLinksTable(int curPage)
        {
            pageCount = Convert.ToInt32(ViewState["pageCount"].ToString());
            string sqlWhere = Server.UrlEncode(ViewState["sWhere"].ToString());
            string sOrderBy = Server.UrlEncode(ViewState["sOrderBy"].ToString());

            if (sqlWhere.Length > 1000)
            {
                Session["linkSqlWhere"] = ViewState["sWhere"].ToString();
                sqlWhere = "";
            }


            Table t1 = new Table();
            Table t2 = new Table();
            TableRow tr1 = new TableRow();
            TableRow tr2 = new TableRow();

            HyperLink lkPrev1 = new HyperLink();
            HyperLink lkNext1 = new HyperLink();
            HyperLink lkPrev2 = new HyperLink();
            HyperLink lkNext2 = new HyperLink();

            lkPrev1.CssClass = "regularGray";
            lkNext1.CssClass = "regularGray";
            lkPrev2.CssClass = "regularGray";
            lkNext2.CssClass = "regularGray";

            lkPrev1.EnableViewState = true;
            lkNext1.EnableViewState = true;
            lkPrev2.EnableViewState = true;
            lkNext2.EnableViewState = true;

            lkPrev1.Text = "<< Prev";
            lkNext1.Text = "Next >>";
            lkPrev2.Text = "<< Prev";
            lkNext2.Text = "Next >>";

            if (curPage < pageCount)
            {
                lkNext1.Visible = true;
                lkNext2.Visible = true;
            }
            else
            {
                lkNext1.Visible = false;
                lkNext2.Visible = false;
            }

            if (curPage > 1)
            {
                lkPrev1.Visible = true;
                lkPrev2.Visible = true;
            }
            else
            {
                lkPrev1.Visible = false;
                lkPrev2.Visible = false;
            }

            lkPrev1.NavigateUrl = "chameleon-memberResults.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=prev&curPage=" + curPage.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy; ;
            lkNext1.NavigateUrl = "chameleon-memberResults.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=next&curPage=" + curPage.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy; ;
            lkPrev2.NavigateUrl = "chameleon-memberResults.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=prev&curPage=" + curPage.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy; ;
            lkNext2.NavigateUrl = "chameleon-memberResults.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=next&curPage=" + curPage.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy; ;

            TableCell tcPrev = new TableCell();
            TableCell tcNext = new TableCell();
            TableCell tcPrev2 = new TableCell();
            TableCell tcNext2 = new TableCell();

            tcPrev.Controls.Add(lkPrev1);
            tcNext.Controls.Add(lkNext1);
            tcPrev2.Controls.Add(lkPrev2);
            tcNext2.Controls.Add(lkNext2);

            tr1.Cells.Add(tcPrev);
            tr2.Cells.Add(tcPrev2);

            int j = 0;
            for (int i = 1; i <= pageCount; i++, j++)
            {
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                HyperLink lk1 = new HyperLink();
                HyperLink lk2 = new HyperLink();

                if (j == 20)
                {
                    t1.Rows.Add(tr1);
                    t2.Rows.Add(tr2);
                    j = 0;
                    tr1 = new TableRow();
                    tr2 = new TableRow();
                }

                if (i == curPage)
                {
                    lk1.CssClass = "linkRed";
                    lk2.CssClass = "linkRed";
                }
                else
                {
                    lk1.CssClass = "regularGray";
                    lk2.CssClass = "regularGray";
                }

                lk1.Text = i.ToString();
                lk2.Text = i.ToString();
                lk1.NavigateUrl = "chameleon-memberResults.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=" + i.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy; ;
                lk2.NavigateUrl = "chameleon-memberResults.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=" + i.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy; ;

                if (pageCount == 1)
                {
                    lk1.Visible = false;
                    lk2.Visible = false;
                }
                else
                {
                    lk1.Visible = true;
                    lk2.Visible = true;
                }

                tc1.Controls.Add(lk1);
                tc2.Controls.Add(lk2);
                tr1.Cells.Add(tc1);
                tr2.Cells.Add(tc2);

            }// end for
            tr1.Cells.Add(tcNext);
            tr2.Cells.Add(tcNext2);

            t1.Rows.Add(tr1);
            t2.Rows.Add(tr2);

            phTopNav.Controls.Add(t1);
            phBottomNav.Controls.Add(t2);

        }

        protected void butSaveQuery_Click(object sender, System.EventArgs e)
        {
            if (checkSession())
            {
                try
                {
                    string sQuery = ViewState["sWhere"].ToString();
                    string sQueryName = txtQueryName.Text;
                    int iMemberID = Convert.ToInt32(Session["memberID"].ToString());

                    if (saveCurrentQuery(iMemberID, sQueryName, sQuery))
                    {
                        lbQueryInfo.Text = "Search Saved";
                        txtQueryName.Text = "";
                    }
                    else
                    {
                        lbQueryInfo.Text = "Error Saving Search";
                        txtQueryName.Text = "";
                    }

                }
                catch
                {

                }

            }

        }

        public bool saveCurrentQuery(int iMemberID, string sQueryName, string sQuery)
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
                dataCmd = new SqlCommand("udsp_insertQuery", dataConn);
                dataCmd.CommandType = CommandType.StoredProcedure;


                // declare and instantiate parameters collection
                SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                SqlParameter ipMemberID = new SqlParameter("@memberID", SqlDbType.Int);
                SqlParameter ipQueryName = new SqlParameter("@queryName", SqlDbType.VarChar, 50);
                SqlParameter ipQuery = new SqlParameter("@query", SqlDbType.VarChar, 2000);
                SqlParameter ipDateEntered = new SqlParameter("@dateEntered", SqlDbType.DateTime);

                // specify parameter direction
                opReturnCode.Direction = ParameterDirection.ReturnValue;
                ipMemberID.Direction = ParameterDirection.Input;
                ipQueryName.Direction = ParameterDirection.Input;
                ipQuery.Direction = ParameterDirection.Input;
                ipDateEntered.Direction = ParameterDirection.Input;

                // initialize parameter values
                ipMemberID.Value = iMemberID;
                ipQueryName.Value = sQueryName;
                ipQuery.Value = sQuery;
                ipDateEntered.Value = System.DateTime.Now;

                // add parameters to collection
                dataCmd.Parameters.Add(opReturnCode);
                dataCmd.Parameters.Add(ipMemberID);
                dataCmd.Parameters.Add(ipQueryName);
                dataCmd.Parameters.Add(ipQuery);
                dataCmd.Parameters.Add(ipDateEntered);

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
                showJSMessage("Your Session has expired due to inactivity.  Please login again.");
                Response.Redirect("chameleon-memberLogin.aspx");
                return false;
            }
        }

        private void setJSFocus(string sControl)
        {
            System.Text.StringBuilder jScript = new System.Text.StringBuilder();
            jScript.Append("<script language=\"JavaScript\">");
            jScript.Append(sControl);
            jScript.Append(".focus()");
            //jScript.Append(this.bookmarkIndex.ToString());
            jScript.Append(";");
            jScript.Append("</script>");

            this.RegisterClientScriptBlock("setJSFocus", jScript.ToString());
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
            if (Session["memberID"] != null && Session["memberID"].ToString() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void dItems_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            //				if(e.CommandName == addItem)
            //				{
            //					Response.Redirect("");
            //				}
        }

        protected String BitmapToEmbedded(Dwg.Bitmap src_bmp)
        {

            //If we're passed nothing, return nothing
            if (src_bmp == null)
                return "";

            //Create a memory stream into which we'll write the JPEG encoded image data
            var memStream = new MemoryStream();

            //Write the data to the memory stream, then convert its byte array to a base64 
            //string and prepend the inline data header

            src_bmp.Save(memStream, ImageFormat.Jpeg);
            return "data:image/jpeg;base64," + Convert.ToBase64String(memStream.ToArray());
        }

        protected void dItems_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    //Label lb = (Label)(e.Item.FindControl("lbStatus"));
            //    HyperLink hl = (HyperLink)(e.Item.FindControl("hlAddItem"));
            //    //if (mDataSet.Tables["udsp_getPagedResults9"].Rows[e.Item.ItemIndex]["status"].ToString() == "On Hold")
            //    //{
            //    //    // lb.Text = "On Hold";
            //    //    hl.NavigateUrl = "";
            //    //    hl.Text = "On Hold";
            //    //    // hl.Visible = false;
            //    //}
            //    //else
            //    //{
            //        //HyperLink hl = (HyperLink)(e.Item.FindControl("hlAddItem"));
            //        // lb.Visible = false;
            //        hl.NavigateUrl = hl.NavigateUrl + "&back=" + Server.UrlEncode(ViewState["backURL"].ToString());
            //    //}

            //    Label lb = (Label)(e.Item.FindControl("lbStatus"));
            //    if (mDataSet.Tables["udsp_getPagedResults9"].Rows[e.Item.ItemIndex]["status"].ToString() == "On Hold")
            //    {
            //        lb.Text = "On Hold";
            //    }

            //    if (mDataSet.Tables["udsp_getPagedResults9"].Rows[e.Item.ItemIndex]["status"].ToString() == "Sold")
            //    {
            //        lb.Text = "Sold Recently";
            //    }

            //}


            string s = String.Empty;
            string iPath = String.Empty;
            string imageName = String.Empty;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lb = (Label)(e.Item.FindControl("lbStatus"));
                if (mDataSet.Tables["udsp_getPagedResults9"].Rows[e.Item.ItemIndex]["status"].ToString() == "On Hold")
                {
                    lb.Text = "On Hold";
                }

                if (mDataSet.Tables["udsp_getPagedResults9"].Rows[e.Item.ItemIndex]["status"].ToString() == "Sold")
                {
                    lb.Text = "Sold Recently";
                }


                System.Web.UI.WebControls.Image i = (System.Web.UI.WebControls.Image)(e.Item.FindControl("image1"));


                s = mDataSet.Tables["udsp_getPagedResults9"].Rows[e.Item.ItemIndex]["Image1"].ToString();
                //string str = "this is a #string";
                imageName = s.Substring(s.LastIndexOf("/") + 1);
                iPath = "~/images/Products/" + imageName;


                MemoryStream ms = null;
                Bitmap bm = null;

                try
                {
                    if (!string.IsNullOrEmpty(iPath))
                    {

                        ms = new MemoryStream();
                        ImageBuilder.Current.Build(iPath, ms, new ResizeSettings("width=200&height=200&&mode=pad&bgcolor=black"), true);
                        bm = new Bitmap(ms);
                        i.ImageUrl = BitmapToEmbedded(bm);


                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    ms.Flush();
                    ms.Dispose();
                    bm = null;
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
}