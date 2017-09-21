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
using System.IO;

namespace IChameleon
{

    public partial class chameleonMaster : System.Web.UI.MasterPage
    {
        #region User Defined Decs

        private string sWhere = String.Empty;
        private string sType = "Signature";
        private string sSearchHeading = "Signature Line > ";
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(webEnabled = 1)";
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        public bool blIsLoggedIn = false;
        public string bgImage = String.Empty;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //cboState
            if (!Page.IsPostBack)
            {
                string SQLstr = "";
                mPopulateList combo = new mPopulateList();
                SQLstr = "select distinct stateName from cmStates";
                cboState = combo.fillWebCombo(cboState, mData.sDBType, SQLstr, "cmStates", false, mMain.sDataPath);
            }

        }

        protected void butSubmit_Click(object sender, System.EventArgs e)
        {
            insertConsultationInfo();
            txtUserName.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            txtPhoneNumber.Text = "";
            txtArea.Text = "";
            cboState.SelectedIndex = 0;
            chbxSubscribe.Checked = false;
        }

        public bool insertConsultationInfo()
        {
            bool success = false;
            
            // initialize ADO objects
            SqlConnection dataConn = null;
            SqlDataReader dbReader = null;
            SqlCommand dataCmd = null;
            SqlTransaction trans = null;

            try
            {
                mEncryption tEncrypt = new mEncryption();
                

                // set connection attributes and open data connection
                dataConn = new SqlConnection(mMain.sDataPath);
                dataConn.Open();
                trans = dataConn.BeginTransaction();

                // set command object attributes
                dataCmd = new SqlCommand("usp_InsertchaConsultationInfo", dataConn, trans);
                dataCmd.CommandType = CommandType.StoredProcedure;

                // declare and instantiate parameters collection                
                dataCmd.Parameters.AddWithValue("@FullName", txtUserName.Text.Trim());
                dataCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                dataCmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim());                
                dataCmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                dataCmd.Parameters.AddWithValue("@State", cboState.SelectedItem.Text.Trim());
                
                dataCmd.Parameters.AddWithValue("@HelpMessage", txtArea.Text.Trim());
                dataCmd.Parameters.AddWithValue("@SubscribeNewsletter", chbxSubscribe.Checked ? 1 : 0);                

                dataCmd.Parameters.Add("@confirmation", SqlDbType.Int).Direction = ParameterDirection.Output;


                // execute command
                var result = dataCmd.ExecuteNonQuery();

                // test return value and transfer control as necessary
                if (result == 1)
                {
                    success = true;                   
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                    throw new Exception("Error Submitting Credit Card Information");

                }	// end if

            }	//end try
            catch (SqlException sqle)
            {
                trans.Rollback();
                throw new Exception("SqlException: " + sqle.Message);

            }	//end catch 
            catch (Exception z)
            {
                trans.Rollback();
                throw new Exception("Generic Exception: " + z.Message);

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
    }
}