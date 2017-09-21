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
    public partial class chameleon_viewProject : System.Web.UI.Page
    {
        #region User Defined Decs

        private DataSet mDataSet = new DataSet();
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private SqlConnection mConn;
        private SqlCommand mCmd;
        private string projID = string.Empty;

        // initialize ADO objects
        private SqlConnection dataConn = null;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            projID = Request.QueryString["projectID"];
            loadProject();
        }

        public void loadProject()
        {
            try
            {
                string sSQL = "Select * from chaProjects where projectID = " + projID;

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaProjects");

                if (mDataSet.Tables["chaProjects"].DefaultView.Count > 0)
                {

                    bindProject();

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

        private void bindProject()
        {
            try
            {
                lProjectTitle.Text = mDataSet.Tables["chaProjects"].Rows[0]["projectTitle"].ToString();
                lProjectDetails.Text = mDataSet.Tables["chaProjects"].Rows[0]["projectDetails"].ToString();
                Image1.ImageUrl = mDataSet.Tables["chaProjects"].Rows[0]["projectImage1"].ToString();

            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                //lbInfo.Text = sError;
                sError = "";

            }
        }
    }
}