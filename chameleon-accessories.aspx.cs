using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RocknCode.RocknCodeLib;
using System.Data;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using ImageResizer;
using System.Drawing.Imaging;
using Dwg = System.Drawing;
using System.Text;

namespace IChameleon
{
    public partial class chameleon_accessories : System.Web.UI.Page
    {
        #region User Defined Decs

        private string sWhere = "";
        private string sSearchHeading = "Accessory Line > Accessories > All";
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        protected System.Web.UI.HtmlControls.HtmlInputImage butLoginRegister_B;

        #endregion
        private DataSet mDataSet = new DataSet();
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private SqlConnection mConn;
        private SqlCommand mCmd;
        private const string sourceName = "chaProducts";
        //private const string sqlOrderBy = String.Empty;
        private const int recPerPage = 20;
        private int recCount = 0;
        private int pageCount = 0;
        private int curPage = 0;
        private LinkButton lPrev1 = new LinkButton();
        private LinkButton lNext1 = new LinkButton();
        private LinkButton lPrev2 = new LinkButton();
        private LinkButton lNext2 = new LinkButton();
        private LinkButton link1 = new LinkButton();
        private LinkButton link2 = new LinkButton();        
        private string sLine = String.Empty;
        private string sLinkTo = String.Empty;
        private string sOrderBy = String.Empty;
        private string sSort = String.Empty;
        private string sStatus = "(webEnabled = 1 and status <> 'Sold' or (webEnabled = 1 and status = 'Sold' and DATEDIFF (day,dateSold,getdate() ) <= 21))";
        private bool isAccessoriesChanged;
        private SqlConnection dataConn = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            string result = string.Empty;
            if (!Page.IsPostBack)
            {
                fillCombos();
                sSearchHeading = Request.QueryString["heading"];
                sWhere = Request.QueryString["where"];
                sLine = Request.QueryString["Line"] == null ? "line = Accessories" : Request.QueryString["Line"];
                sSort = Request.QueryString["sort"];
                result = Request.QueryString["pageNo"];
                curPage = Convert.ToInt32(Request.QueryString["curPage"]);



                if (Request.QueryString["sOrderBy"] != null)// && Request.QueryString["sOrderBy"].ToString() != String.Empty)
                {
                    sOrderBy = Request.QueryString["sOrderBy"];
                }
                else
                {
                    sOrderBy = "dateEntered";

                }
            }
            LoadPage(result);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
        }

        private void LoadPage(string result)
        {
            if (string.IsNullOrEmpty(sOrderBy))
            {
                sOrderBy = "dateEntered";
            }

            if (!Page.IsPostBack)
            {               

                ViewState["sOrderBy"] = sOrderBy;

                // sOrderBy = "dateEntered";

                if (Session["memberID"] != null && Session["memberID"].ToString() != "")
                {
                    sWhere = Server.UrlEncode(sWhere);

                    Response.Redirect("chameleon-accessories.aspx?Line=" + sLine + "&heading=" + sSearchHeading + "&where=" + sWhere, true);

                }

                if (sWhere == null || sWhere == "")
                {
                    if (Session["sWhere"] != null && Session["sWhere"].ToString() != "")
                        sWhere = Session["sWhere"].ToString();
                    else
                        sWhere = " Where (category = 'Accessories')";
                }

                if (sLine != null && sLine != string.Empty)
                {
                    initSortList(sLine);
                    enableSortList(false);
                }

                if (sSearchHeading != null && sSearchHeading != string.Empty)
                {
                    ViewState["sSearchHeading"] = sSearchHeading;
                    lbSearchHeading.Text = sSearchHeading;

                }
                else
                {
                    sSearchHeading = "Accessory Line > Accessories > All";
                    ViewState["sSearchHeading"] = sSearchHeading;
                    lbSearchHeading.Text = sSearchHeading;
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


                if (result != null && result != string.Empty)
                {
                    pageCount = Convert.ToInt32(ViewState["pageCount"].ToString());

                    switch (result)
                    {
                        case "next":
                            {
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
                    } // end switch
                }
                else
                {
                    curPage = 1;
                    //curPage = Convert.ToInt32(ViewState["curPage"].ToString()); 
                }

                ViewState["curPage"] = curPage;


                createLinksTable(curPage);
            }
            else
            {
                //cboAccessories.SelectedItem 
                Control cause = GetPostBackControl(Page);
                if (isAccessoriesChanged)
                {
                    buildQuery();
                    createLinksTable(curPage);
                    isAccessoriesChanged = false;
                }
                //cboAccessories.SelectedItem =                

            }
            getItemsDataSet();

            setSortIndex(ViewState["sOrderBy"].ToString());
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



                //ipOrderBY.Value = "dateEntered";


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
                        bindRItems();
                    }
                    else
                    {
                        lbInfo.Text = "No Records Matched your Search Criteria";
                        imageDisplay.InnerHtml = "";

                    }

                }
                else
                {
                    lbInfo.Text = "Error Querying Database";
                    imageDisplay.InnerHtml = "";


                }	// end if

            }	//end try
            catch (SqlException sqle)
            {

                lbInfo.Text = "Error Querying Database. Please contact the System Administrator with the following message: " + sqle.Message.ToString();
                imageDisplay.InnerHtml = "";

            }	//end catch 
            catch (Exception z)
            {
                lbInfo.Text = "Error Querying Database. Error Detail: " + z.Message.ToString() + " Please make sure input values are in correct format.";
                imageDisplay.InnerHtml = "";
            }	//end catch
            finally
            {

                dataConn.Close();
                dataConn.Dispose();
                //dataCmd.Dispose();

            }	// end finally


        }

        private void bindRItems()
        {
            try
            {
                DataView dv = new DataView();
                dv = mDataSet.Tables["udsp_getPagedResults9"].DefaultView;
                if (sSort == "Price")
                {                    
                    dv.Sort = "price1";
                    //dItems.DataSource = dv;
                }            

                StringBuilder str = new StringBuilder();
                foreach (var drow in dv.ToTable().Rows)
                {
                    str.Append("<div class='col-sm-3'> <div class='box'> <a href = '" + "chameleon-viewItem.aspx?item=" + Convert.ToString(((DataRow)drow).ItemArray[1]) + "&itemID=" + Convert.ToString(((DataRow)drow).ItemArray[3]) + "'><div class='img'><div class='overlay'>&nbsp;</div><img src = '" + Convert.ToString(((DataRow)drow).ItemArray[6]) + "' /></div><div class='text'><p><strong>" + Convert.ToString(((DataRow)drow).ItemArray[3]) + " </strong>" + Convert.ToString(((DataRow)drow).ItemArray[1]) + "</p></div></a></div></div>");
                }
                lbInfo.Text = "";
                lbInfo.Text = ViewState["recCount"].ToString() + " record(s) matched your search <br>";
                //lbInfo.Text = lbInfo.Text + "Showing Page " + ViewState["curPage"].ToString() + " of " + ViewState["pageCount"].ToString();
                lbInfo.Text = lbInfo.Text + "<br>click on image to display details<br><br>";
                imageDisplay.InnerHtml = str.ToString();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                lbInfo.Text = sError;
                sError = "";

            }
        }

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

        private void createLinksTable(int curPage)
        {
            pageCount = Convert.ToInt32(ViewState["pageCount"].ToString());
            string sqlWhere = Server.UrlEncode(ViewState["sWhere"].ToString());
            string sOrderBy = Server.UrlEncode(ViewState["sOrderBy"].ToString());

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

            lkPrev1.NavigateUrl = "chameleon-accessories.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=prev&curPage=" + curPage.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy;
            lkNext1.NavigateUrl = "chameleon-accessories.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=next&curPage=" + curPage.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy;
            lkPrev2.NavigateUrl = "chameleon-accessories.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=prev&curPage=" + curPage.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy;
            lkNext2.NavigateUrl = "chameleon-accessories.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=next&curPage=" + curPage.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy;

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

                lk1.CssClass = "regularGray";
                lk2.CssClass = "regularGray";

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
                lk1.NavigateUrl = "chameleon-accessories.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=" + i.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy;
                lk2.NavigateUrl = "chameleon-accessories.aspx?line=" + ViewState["sLine"] + "&heading=" + ViewState["sSearchHeading"] + "&pageNo=" + i.ToString() + "&where=" + sqlWhere + "&sOrderBy=" + sOrderBy;

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
            try
            {
                if (ViewState["pageCount"] == null || isAccessoriesChanged)
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

                }
                else
                {
                    pageCount = Convert.ToInt32(ViewState["pageCount"].ToString());
                }

            }	//end try
            catch (SqlException sqle)
            {

                lbInfo.Text = "Error Querying Database. Please contact the System Administrator with the following message: " + sqle.Message.ToString();


            }   //end catch 

            finally
            {
                if (mConn != null)
                {
                    mConn.Close();
                }
                //mConn.Dispose();
                //dataCmd.Dispose();

            }	// end finally

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
                ListItem number = new ListItem("Item Number", "itemCode");
                ListItem date = new ListItem("Date Added", "dateEntered");
                ddlSort.Items.Insert(0, number);
                ddlSort.Items.Insert(1, date);                
            }
            catch (Exception ex)
            {

            }
        }

        public void fillCombos()
        {
            try
            {
                string SQLstr = "";
                mPopulateList combo = new mPopulateList();

                // cboStyles
                //					SQLstr = "select distinct style from chaStyles order by style";
                //					cboStyles = combo.fillWebCombo(cboStyles, mData.sDBType, SQLstr, "chaStyles", true, mMain.sDataPath);

                // cboAccessories
                SQLstr = "select distinct subCategory, categoryID from chaItemCategories where mainCategory = 'Accessories' order by categoryID";
                cboAccessories = combo.fillWebCombo(cboAccessories, mData.sDBType, SQLstr, "chaItemCategories", false, mMain.sDataPath);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error Populating Drop-down Lists");
            }
        }

        protected void cboAccessories_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            sSearchHeading = "Accessories > " + cboAccessories.SelectedItem;
            sWhere = "";
            
            if (cboAccessories.SelectedValue == "All")
            {
                sWhere = " Where (category = 'Accessories')";                
            }
            else
            {
                sWhere = " Where (category = 'Accessories' and subCategory = '" + cboAccessories.SelectedValue + "')";
            }
            ViewState["sWhere"] = sWhere;
            ViewState["sSearchHeading"] = sSearchHeading;
            sLine = "Accessories";
            ViewState["Line"] = sLine;
            //sSort = Request.QueryString["sort"];
            curPage = Convert.ToInt32(ViewState["curPage"]);
            isAccessoriesChanged = true;
            lbSearchHeading.Text = sSearchHeading;
            LoadPage("");

            //Response.Redirect("chameleon-accessories.aspx?line=Accessories&heading=" + sSearchHeading + "&where=" + sWhere, true);

        }

    }
}