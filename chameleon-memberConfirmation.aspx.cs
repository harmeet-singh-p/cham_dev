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
    public partial class chameleon_memberConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string sID = Request.QueryString["ID"];
                string sMessage = "";

                if (completeRegistration(sID))
                {

                    sMessage = "Thank you for completing the registration process. Please click on the 'Members Homepage' button below to start enjoying "
                        + "the exclusive benefits available to our members.<br><br>";

                    sMessage = sMessage + "If you have any questions please contact us directly at 212-355-6300.<br><br>";
                    sMessage = sMessage + "Thanks,<br>";
                    sMessage = sMessage + "The chameleon team";

                }
                else
                {
                    sMessage = "We apologize, there was a problem completing the automated registration process.<br><br>"
                    + "Please email us at <A href='mailto:membersupport@chameleon59.com'>membersupport@chameleon59.com</A> or call us at 212-355-6300"
                    + "to activate your account<br><br>"
                    + "Thanks,<br>"
                    + "the chameleon team";
                }

                lbInfo.Text = sMessage;
            }
        }      

        private bool completeRegistration(string id)
        {
            try
            {
                mEncryption tEncrypt = new mEncryption();
                byte[] arID = Convert.FromBase64String(id);
                string memberID = tEncrypt.tdesDecrypt(arID);

                if (activatetNewUserID(Convert.ToInt32(memberID)))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                lbInfo.Text = ex.Message;
                return false;
            }
        }

        public bool activatetNewUserID(int iUserID)
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
                dataCmd = new SqlCommand("udsp_activateNewMemberID", dataConn);
                dataCmd.CommandType = CommandType.StoredProcedure;


                // declare and instantiate parameters collection
                SqlParameter opReturnCode = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                SqlParameter ipMemberID = new SqlParameter("@memberID", SqlDbType.Int);
                SqlParameter opUserName = new SqlParameter("@userName", SqlDbType.VarChar, 100);
                SqlParameter opFirstName = new SqlParameter("@firstName", SqlDbType.VarChar, 50);

                // specify parameter direction
                opReturnCode.Direction = ParameterDirection.ReturnValue;
                ipMemberID.Direction = ParameterDirection.Input;
                opUserName.Direction = ParameterDirection.Output;
                opFirstName.Direction = ParameterDirection.Output;


                // initialize parameter values
                ipMemberID.Value = iUserID;


                // add parameters to collection
                dataCmd.Parameters.Add(opReturnCode);
                dataCmd.Parameters.Add(ipMemberID);
                dataCmd.Parameters.Add(opUserName);
                dataCmd.Parameters.Add(opFirstName);


                // execute command
                dataCmd.ExecuteReader();


                // test return value and transfer control as necessary
                if ((int)dataCmd.Parameters[0].Value == 9)
                {
                    Session["memberID"] = iUserID;
                    Session["userName"] = opUserName.Value.ToString();
                    Session["firstName"] = opFirstName.Value.ToString();
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

        protected void butMemberHome_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("chameleon-memberHome.aspx", true);
            //Server.Transfer("chameleon-memberHome.aspx");
        }
    }
}