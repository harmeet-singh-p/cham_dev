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
    public partial class chameleon_viewPress : System.Web.UI.Page
    {
        #region User Defined Decs

        private DataSet mDataSet = new DataSet();
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private SqlConnection mConn;
        private SqlCommand mCmd;
        private string eventID = string.Empty;

        // initialize ADO objects
        private SqlConnection dataConn = null;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            eventID = Request.QueryString["eventID"];
            loadEvent();
        }

        public void loadEvent()
        {
            try
            {
                string sSQL = "Select * from chaEvents where eventID = " + eventID;

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaEvents");

                if (mDataSet.Tables["chaEvents"].DefaultView.Count > 0)
                {
                    //lbInfo.Text = "";

                    bindEvent();

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

        private void bindEvent()
        {
            try
            {
                lEventTitle.Text = mDataSet.Tables["chaEvents"].Rows[0]["eventTitle"].ToString();
                lEventDetails.Text = mDataSet.Tables["chaEvents"].Rows[0]["eventDetails"].ToString();
                Image1.ImageUrl = mDataSet.Tables["chaEvents"].Rows[0]["Image1"].ToString();

                if (mDataSet.Tables["chaEvents"].Rows[0]["pubPDF"].ToString() != String.Empty)
                {
                    hlViewPDF.Visible = true;
                    hlViewPDF.NavigateUrl = mDataSet.Tables["chaEvents"].Rows[0]["pubPDF"].ToString();
                }
                else
                {
                    hlViewPDF.Visible = false;
                }

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