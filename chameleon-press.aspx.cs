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
    public partial class chameleon_press : System.Web.UI.Page
    {
        #region User Defined Decs

        private DataSet mDataSet = new DataSet();
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private SqlConnection mConn;
        private SqlCommand mCmd;

        // initialize ADO objects
        private SqlConnection dataConn = null;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    loadEvents("Editorial");
                    //lPress.Text = " Editorial in the Press";
                }

            }
            catch
            {

            }
        }

        public void loadEvents(string eventType)
        {
            try
            {

                string sSQL = "Select * from chaEvents where (webEnabled = 'True') and (eventType = '" + eventType + "') order By pubDate Desc";

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaEvents");

                if (mDataSet.Tables["chaEvents"].DefaultView.Count > 0)
                {
                    //lbInfo.Text = "";

                    bindEvents();

                }
                else
                {
                    //lbInfo.Text = "There are no Projects for viewing";
                }

            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }	//end 

        private void bindEvents()
        {
            try
            {

                //dlEvents.DataSource = mDataSet.Tables["chaEvents"].DefaultView;
                //dlEvents.DataBind();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                //lbInfo.Text = sError;
                sError = "";

            }
        }

        protected void dlEvents_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void btnEditorial_Click(object sender, EventArgs e)
        {
            try
            {
                loadEvents("Editorial");
                //lPress.Text = " Editorial in the Press";
            }
            catch (Exception ex)
            {
                string sError = ex.Message.ToString();
            }
        }

        protected void btnAdvertising_Click(object sender, EventArgs e)
        {
            try
            {
                loadEvents("Advertising");
                //lPress.Text = " Advertising in the Press";
            }
            catch (Exception ex)
            {
                string sError = ex.Message.ToString();
            }
        }
    }
}