using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using RocknCode.RocknCodeLib;
using System.Web.SessionState;

namespace IChameleon
{
    public partial class chameleon_signature : System.Web.UI.Page
    {
        #region User Defined Decs
        private string sWhere = "";
        private string sSearchHeading = "Signature Line > ";
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        protected System.Web.UI.HtmlControls.HtmlInputImage butLoginRegister_B;

        
        private DataSet mDataSet = new DataSet();
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private SqlConnection mConn;
        private SqlCommand mCmd;
        private const string sourceName = "chaProducts";
        //private const string sqlOrderBy = String.Empty;
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
        private string sLine = String.Empty;
        private string sLinkTo = String.Empty;
        private string sOrderBy = String.Empty;
        private string sSort = String.Empty;
        private string sStatus = "(webEnabled = 1 and status <> 'Sold' or (webEnabled = 1 and status = 'Sold' and DATEDIFF (day,dateSold,getdate() ) <= 21))";

        private SqlConnection dataConn = null;
        
        private string sType = "Signature";
        
        public bool blIsLoggedIn = false;
        #endregion



        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillCombos();
                getNewItemsDataSet();
                Session["sqlWhere"] = "";                				
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);

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
                //					
                // cboCeiling
                //SQLstr = "select distinct subCategory, categoryID from chaItemCategories where mainCategory = 'Ceiling' order by categoryID";
                //cboCeiling = combo.fillWebCombo(cboCeiling, mData.sDBType, SQLstr, "chaStyles", false, mMain.sDataPath);

                //// cboWall
                //SQLstr = "select distinct subCategory, categoryID  from chaItemCategories where mainCategory = 'Wall' order by categoryID";
                //cboWall = combo.fillWebCombo(cboWall, mData.sDBType, SQLstr, "chaStyles", false, mMain.sDataPath);

                //// cboLamps
                //SQLstr = "select distinct subCategory, categoryID  from chaItemCategories where mainCategory = 'Lamp' order by categoryID";
                //cboLamps = combo.fillWebCombo(cboLamps, mData.sDBType, SQLstr, "chaStyles", false, mMain.sDataPath);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error Populating Drop-down Lists");
            }
        }

        private void resetPage()
        {

            //cboCeiling.SelectedIndex = 0;
            //cboWall.SelectedIndex = 0;
            //cboLamps.SelectedIndex = 0;


        }

        protected void cboCeiling_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //sSearchHeading = sSearchHeading + " Ceiling > " + cboCeiling.SelectedItem;
            //sWhere = "";

            //if (cboCeiling.SelectedValue == "All")
            //{
            //    //Session["sqlWhere"] = " Where (type = 'Signature' and category = 'Ceiling') and (status = 'available' or status = 'On Hold')";
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and category = 'Ceiling') and " + sStatus);

            //}
            //else
            //{
            //    //Session["sqlWhere"] = " Where (type = 'Signature' and category = 'Ceiling' and subCategory = '" + cboCeiling.SelectedValue + "') and (status = 'available' or status = 'On Hold')";
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and category = 'Ceiling' and subCategory = '" + cboCeiling.SelectedValue + "') and " + sStatus);
            //}

            Response.Redirect("chameleon-searchresults.aspx?Line=Custom&heading=" + sSearchHeading + "&where=" + sWhere, true);

        }

        protected void cboWall_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //sSearchHeading = sSearchHeading + "Wall > " + cboWall.SelectedItem;
            //sWhere = "";

            //if (cboWall.SelectedValue == "All")
            //{
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and category = 'Wall') and " + sStatus);
            //}
            //else
            //{
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and category = 'Wall' and subCategory = '" + cboWall.SelectedValue + "') and " + sStatus);
            //}


            Response.Redirect("chameleon-searchresults.aspx?Line=Custom&heading=" + sSearchHeading + "&where=" + sWhere, true);

        }

        protected void cboLamps_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //sSearchHeading = sSearchHeading + "Lamps > " + cboLamps.SelectedItem;
            //sWhere = "";

            //if (cboLamps.SelectedValue == "All")
            //{
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and category = 'Lamp') and " + sStatus);
            //}
            //else
            //{
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and category = 'Lamp' and subCategory = '" + cboLamps.SelectedValue + "') and " + sStatus);
            //}


            Response.Redirect("chameleon-searchresults.aspx?Line=Custom&heading=" + sSearchHeading + "&where=" + sWhere, true);

        }

        protected void cboDate_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //sSearchHeading = sSearchHeading + " Date > " + cboDate.SelectedItem;
            //sWhere = "";

            //if (cboDate.SelectedIndex == 1)
            //{
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and dateEntered > '" + DateTime.Today.AddDays(-7).ToShortDateString() + "') and " + sStatus);
            //}
            //else if (cboDate.SelectedIndex == 2)
            //{
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and dateEntered > '" + DateTime.Today.AddDays(-14).ToShortDateString() + "') and " + sStatus);
            //}
            //else if (cboDate.SelectedIndex == 3)
            //{
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and dateEntered > '" + DateTime.Today.AddDays(-30).ToShortDateString() + "') and " + sStatus);
            //}
            //else if (cboDate.SelectedIndex == 4)
            //{
            //    sWhere = Server.UrlEncode(" Where (type = '" + sType + "' and dateEntered > '" + DateTime.Today.AddDays(-60).ToShortDateString() + "') and " + sStatus);
            //}


            Response.Redirect("chameleon-searchresults.aspx?Line=Custom&heading=" + sSearchHeading + "&where=" + sWhere, true);

        }

        private void butAllSignature_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            sSearchHeading = sSearchHeading + "All Items";
            sWhere = Server.UrlEncode(" Where (type = '" + sType + "') and " + sStatus);

            Response.Redirect("chameleon-searchresults.aspx?Line=Signature&heading=" + sSearchHeading + "&where=" + sWhere, true);
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

        public void getNewItemsDataSet()
        {

            try
            {
                int days = -31;
                int count = 0;
                string sSQL = "";

                sSQL = "Select TOP 5 * from " + mMain.sProductSource + " Where Type = 'Signature' and (webEnabled = 1) order by dateEntered desc";
                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, mMain.sProductSource);

                bindNewItems();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }	//end getNewItemsDataSet()

        private void bindNewItems()
        {
            try
            {
                //dItems.DataSource = mDataSet.Tables[mMain.sProductSource].DefaultView;
                //dItems.DataMember = mMain.sProductSource;
                //dItems.DataBind();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }

        private void dItems_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{

            //    HyperLink hl = (HyperLink)(e.Item.FindControl("hlAddItem"));
            //    //hl.NavigateUrl = hl.NavigateUrl + "&backURL=" + ViewState["backURL"].ToString();

            //    if (blIsLoggedIn)
            //        hl.Visible = true;
            //    else
            //        hl.Visible = false;
            //}
        }
       
    }
}