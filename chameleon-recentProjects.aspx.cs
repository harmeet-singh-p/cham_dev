using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RocknCode.RocknCodeLib;

namespace IChameleon
{
    public partial class chameleon_recentProjects : System.Web.UI.Page
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
                loadProjects();
            }
            catch (Exception ex)
            {

            }
        }

        public void loadProjects()
        {
            try
            {
                string sSQL = "Select * from chaProjects where webEnabled = 1";

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaProjects");

                if (mDataSet.Tables["chaProjects"].DefaultView.Count > 0)
                {
                    //lbInfo.Text = "";

                    bindProjects();

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

        private void bindProjects()
        {
            try
            {

                dlProjects.DataSource = mDataSet.Tables["chaProjects"].DefaultView;
                dlProjects.DataBind();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                //lbInfo.Text = sError;
                sError = "";

            }
        }

        protected void dlProjects_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Label lb = (Label)(e.Item.FindControl("lbStatus"));
                //if (mDataSet.Tables["udsp_getPagedResults"].Rows[e.Item.ItemIndex]["status"].ToString() == "On Hold")
                //{
                //    lb.Text = "On Hold";
                //}

                //if (mDataSet.Tables["udsp_getPagedResults"].Rows[e.Item.ItemIndex]["status"].ToString() == "Sold")
                //{
                //    lb.Text = "Sold Recently";
                //}
            }

        }
    }
}