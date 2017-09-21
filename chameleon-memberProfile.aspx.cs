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
    public partial class chameleon_memberProfile : System.Web.UI.Page
    {
        #region User Defined Decs
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();

        #endregion


        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (checkSession())
            {
                // Put user code to initialize the page here
                if (!Page.IsPostBack)
                {
                    butSubmit.Attributes.Add("onclick", "return validatePWLength();");
                    fillCombos();
                    getMemberData();
                }
            }
        }

        private void getMemberData()
        {

            try
            {
                string sSQL = "Select * from chaMembers where memberID = " + Session["memberID"];

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaMembers");

                if (mDataSet.Tables["chaMembers"].DefaultView.Count > 0)
                {
                    txtFirstName.Text = mDataSet.Tables["chaMembers"].Rows[0]["firstName"].ToString();
                    txtLastName.Text = mDataSet.Tables["chaMembers"].Rows[0]["lastName"].ToString();
                    txtOrganization.Text = mDataSet.Tables["chaMembers"].Rows[0]["organization"].ToString();
                    chkTrade.Checked = Convert.ToBoolean(mDataSet.Tables["chaMembers"].Rows[0]["trade"].ToString());
                    txtAddress1.Text = mDataSet.Tables["chaMembers"].Rows[0]["address1"].ToString();
                    txtAddress2.Text = mDataSet.Tables["chaMembers"].Rows[0]["address2"].ToString();
                    txtCity.Text = mDataSet.Tables["chaMembers"].Rows[0]["city"].ToString();
                    cboState.Text = mDataSet.Tables["chaMembers"].Rows[0]["state"].ToString();
                    txtRegion.Text = mDataSet.Tables["chaMembers"].Rows[0]["region"].ToString();
                    txtPostalCode.Text = mDataSet.Tables["chaMembers"].Rows[0]["postalCode"].ToString();
                    cboCountry.Text = mDataSet.Tables["chaMembers"].Rows[0]["country"].ToString();
                    txtPhone.Text = mDataSet.Tables["chaMembers"].Rows[0]["phone1"].ToString();
                    txtEmail.Text = mDataSet.Tables["chaMembers"].Rows[0]["email"].ToString();
                    txtPassword.Text = mDataSet.Tables["chaMembers"].Rows[0]["password"].ToString();
                    txtPasswordConfirm.Text = mDataSet.Tables["chaMembers"].Rows[0]["password"].ToString();
                    chkEAlert.Checked = Convert.ToBoolean(mDataSet.Tables["chaMembers"].Rows[0]["eAlert"].ToString());
                }
                else
                {
                    lbInfo.Text = "You have no member profile";
                }


            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }

        }

        public void fillCombos()
        {
            try
            {
                string SQLstr = "";
                mPopulateList combo = new mPopulateList();
                //mPopulateList lBox = new mPopulateList();


                //cboState
                SQLstr = "select distinct stateName from cmStates";
                cboState = combo.fillWebCombo(cboState, mData.sDBType, SQLstr, "cmStates", false, mMain.sDataPath);

                //cboCountry
                SQLstr = "select distinct countryName from cmCountries";
                cboCountry = combo.fillWebCombo(cboCountry, mData.sDBType, SQLstr, "cmCountries", false, mMain.sDataPath);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error Populating Drop-down Lists");
            }
        }

        protected void butSubmit_Click(object sender, System.EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (updateMemberRegistration(Convert.ToInt32(Session["memberID"].ToString())))
            {
                showJSMessage("Registration Update Successful.");
            }
            else
            {
                showJSMessage("An error occured updating your registration");
            }
            Response.Redirect("chameleon-memberHome.aspx", true);
        }

        public bool updateMemberRegistration(int memberID)
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
                dataCmd = new SqlCommand("udsp_updateMemberRegistration", dataConn);
                dataCmd.CommandType = CommandType.StoredProcedure;


                // declare and instantiate parameters collection
                SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                SqlParameter ipMemberID = new SqlParameter("@memberID", SqlDbType.Int);
                SqlParameter ipFirstName = new SqlParameter("@firstName", SqlDbType.VarChar, 50);
                SqlParameter ipLastName = new SqlParameter("@lastName", SqlDbType.VarChar, 50);
                SqlParameter ipOrganization = new SqlParameter("@organization", SqlDbType.VarChar, 50);
                SqlParameter trade = new SqlParameter("@trade", SqlDbType.Bit);
                SqlParameter address1 = new SqlParameter("@address1", SqlDbType.VarChar, 100);
                SqlParameter address2 = new SqlParameter("@address2", SqlDbType.VarChar, 100);
                SqlParameter city = new SqlParameter("@city", SqlDbType.VarChar, 50);
                SqlParameter state = new SqlParameter("@state", SqlDbType.VarChar, 50);
                SqlParameter region = new SqlParameter("@region", SqlDbType.VarChar, 50);
                SqlParameter postalCode = new SqlParameter("@postalCode", SqlDbType.VarChar, 50);
                SqlParameter country = new SqlParameter("@country", SqlDbType.VarChar, 50);
                SqlParameter ipPhone1 = new SqlParameter("@phone1", SqlDbType.VarChar, 50);
                SqlParameter ipEmail = new SqlParameter("@email", SqlDbType.VarChar, 100);
                SqlParameter ipPassword = new SqlParameter("@password", SqlDbType.VarChar, 50);
                SqlParameter ipStatus = new SqlParameter("@status", SqlDbType.VarChar, 50);
                SqlParameter ipDateEntered = new SqlParameter("@dateEntered", SqlDbType.DateTime);
                SqlParameter eAlert = new SqlParameter("@eAlert", SqlDbType.Bit);

                // specify parameter direction
                opReturnCode.Direction = ParameterDirection.ReturnValue;
                ipMemberID.Direction = ParameterDirection.Input;
                ipFirstName.Direction = ParameterDirection.Input;
                ipLastName.Direction = ParameterDirection.Input;
                ipOrganization.Direction = ParameterDirection.Input;
                trade.Direction = ParameterDirection.Input;
                address1.Direction = ParameterDirection.Input;
                address2.Direction = ParameterDirection.Input;
                city.Direction = ParameterDirection.Input;
                state.Direction = ParameterDirection.Input;
                region.Direction = ParameterDirection.Input;
                postalCode.Direction = ParameterDirection.Input;
                country.Direction = ParameterDirection.Input;
                ipPhone1.Direction = ParameterDirection.Input;
                ipEmail.Direction = ParameterDirection.Input;
                ipPassword.Direction = ParameterDirection.Input;
                ipStatus.Direction = ParameterDirection.Input;
                ipDateEntered.Direction = ParameterDirection.Input;
                eAlert.Direction = ParameterDirection.Input;

                // initialize parameter values
                ipMemberID.Value = memberID;
                ipFirstName.Value = txtFirstName.Text;
                ipLastName.Value = txtLastName.Text;
                ipOrganization.Value = txtOrganization.Text;
                if (chkTrade.Checked)
                {
                    trade.Value = 1;
                }
                else
                {
                    trade.Value = 0;
                }
                address1.Value = txtAddress1.Text;
                address2.Value = txtAddress2.Text;
                city.Value = txtCity.Text;
                state.Value = cboState.Text;
                region.Value = txtRegion.Text;
                postalCode.Value = txtPostalCode.Text;
                country.Value = cboCountry.Text;
                ipPhone1.Value = txtPhone.Text;
                ipEmail.Value = txtEmail.Text;
                ipPassword.Value = txtPassword.Text;
                ipStatus.Value = "Active";
                ipDateEntered.Value = System.DateTime.Now;
                if (chkEAlert.Checked)
                {
                    eAlert.Value = 1;
                }
                else
                {
                    eAlert.Value = 0;
                }

                // add parameters to collection
                dataCmd.Parameters.Add(opReturnCode);
                dataCmd.Parameters.Add(ipMemberID);
                dataCmd.Parameters.Add(ipFirstName);
                dataCmd.Parameters.Add(ipLastName);
                dataCmd.Parameters.Add(ipOrganization);
                dataCmd.Parameters.Add(trade);
                dataCmd.Parameters.Add(address1);
                dataCmd.Parameters.Add(address2);
                dataCmd.Parameters.Add(city);
                dataCmd.Parameters.Add(state);
                dataCmd.Parameters.Add(region);
                dataCmd.Parameters.Add(postalCode);
                dataCmd.Parameters.Add(country);
                dataCmd.Parameters.Add(ipPhone1);
                dataCmd.Parameters.Add(ipEmail);
                dataCmd.Parameters.Add(ipPassword);
                dataCmd.Parameters.Add(ipStatus);
                dataCmd.Parameters.Add(ipDateEntered);
                dataCmd.Parameters.Add(eAlert);

                // execute command
                dataCmd.ExecuteReader();


                // test return value and transfer control as necessary				
                if ((int)dataCmd.Parameters[0].Value == 9)
                {
                    success = true;
                    if (chkTrade.Checked)
                        Session["isTrade"] = true;
                    else
                        Session["isTrade"] = false;

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

        private void closeJSWindow()
        {
            System.Text.StringBuilder jScript = new System.Text.StringBuilder();
            jScript.Append("<script language=\"JavaScript\">");
            jScript.Append("window.close()");
            jScript.Append(";");
            jScript.Append("</script>");

            this.RegisterClientScriptBlock("closeWindow", jScript.ToString());
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

        protected void butMyWorkshop_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("chameleon-memberHome.aspx", true);
        }
    }
}