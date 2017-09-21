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
    public partial class chameleon_sale : System.Web.UI.Page
    {
        #region User Defined Decs

        private string sWhere = "";
        private string sSearchHeading = "";
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(saleEnabled = 1)";

        public bool blIsLoggedIn = false;

        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //fillCombos();
                getSaleItemsDataSet();

            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
        }

        public void getSaleItemsDataSet()
        {

            try
            {               
                string sSQL = "";

                sSQL = "Select * from " + mMain.sProductSource + " Where " + sStatus + " order by dateEntered desc";
                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, mMain.sProductSource);

                if (mDataSet.Tables[0].Rows.Count > 0)
                {
                    lbInfo.Visible = false;
                    bindNewItems();
                }
                else
                {
                    lbInfo.Visible = true;
                    lbInfo.Text = "Sorry, no clearance items are available at this time.  Please check back soon.";
                }
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
                dItems.DataSource = mDataSet.Tables[mMain.sProductSource].DefaultView;
                dItems.DataMember = mMain.sProductSource;
                dItems.DataBind();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
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

        protected void dItems_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                HyperLink hl = (HyperLink)(e.Item.FindControl("hlAddItem"));
                //hl.NavigateUrl = hl.NavigateUrl + "&backURL=" + ViewState["backURL"].ToString();

                if (IsLoggedIn())
                    hl.Visible = true;
                else
                    hl.Visible = false;
            }

        }        
       
    }
}