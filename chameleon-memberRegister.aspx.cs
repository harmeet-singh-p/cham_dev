using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using RocknCode.RocknCodeLib;
using SendGrid;

namespace IChameleon
{
    public partial class chameleon_memberRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            if (!Page.IsPostBack)
            {
                butSubmit.Attributes.Add("onclick", "return validatePWLength();");
                fillCombos();
                cboCountry.Text = "United States";
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
            //sendEmailConfirmation(101, "charrison@rockncode.com");

            if (!Page.IsValid)
                return;

            bool exists = false;
            int iMemberID;

            if (addMemberRegistration(out exists, out iMemberID))
            {
                if (sendEmailConfirmation(iMemberID, txtEmail.Text.Trim()))
                {
                    Response.Redirect("chameleon-RegConfirmation.aspx", true);
                }
            }
            else if (exists)
            {

                showJSMessage("A member already exists with this email address");
                //Response.Redirect("chameleon-home.aspx", true);

            }
            else
            {
                showJSMessage("An error occured during the registration process");
                //Response.Redirect("chameleon-home.aspx", true);
            }

            closeJSWindow();
        }

        public bool addMemberRegistration(out bool bExists, out int memberID)
        {

            bool success = false;
            bExists = false;
            memberID = -1;

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
                dataCmd = new SqlCommand("udsp_insertMemberRegistration", dataConn);
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
                ipMemberID.Direction = ParameterDirection.Output;
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
                //ipAccountNumber.Value = System.DBNull.Value;
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

                //showJSMessage(ipEmail.Value.ToString() + " DB Call");
                // execute command
                dataCmd.ExecuteReader();


                // test return value and transfer control as necessary
                if ((int)dataCmd.Parameters[0].Value == 1)
                {
                    bExists = true;
                    success = false;

                }	// end if
                if ((int)dataCmd.Parameters[0].Value == 9)
                {
                    memberID = (int)dataCmd.Parameters[1].Value;
                    bExists = false;
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

        private bool sendEmailConfirmation(int memberID, string sTo)
        {
            bool success = false;
            string message = String.Empty;

            //				if (Page.IsValid) 
            //				{
            //Trace.Write("Submit", "Page is valid -- send email.");

            try
            {

                //mEncryption tEncrypt = new mEncryption();

                //string sCategory = cboLCategory.Text;
                //byte[] arID = tEncrypt.tdesEncrypt(memberID.ToString());

                //string sID = tEncrypt.tdesEncryptString(memberID.ToString());

                string sRegLink = mMain.sRegistrationLink; // +sID;									

                UTF8Encoding sUTFtext = new UTF8Encoding();
                //MailMessage Mailer = new MailMessage();

                var regMessage = new SendGridMessage();


                message = "Welcome " + txtFirstName.Text + " " + txtLastName.Text + "! <br><br>"
                    + "Thank you for registering for web membership with Chameleon Fine Lighting.<br><br>"
                    + "You can now enjoy the added benefits of Chameleon Web Membership which include trade pricing display and<br>"
                    + "access to My Workshop where you can save, organize and email your favorite items and also save your custom searches<br>"
                    + "for future use.<br><br>"
                    + "Please click on the link below to login to My Workshop with the information you provided.<br><br>"
                    + "<A href='" + sRegLink + "'>" + sRegLink + "</A><br><br>"
                    + "If the text doesn't show as an underlined internet link, copy the text and paste it into your browser's address bar.<br><br>"
                    + "If you have any problems or have forgotten your login or password, please don't hesitate to call us at 212-355-6300 <br>"
                    + "or email us at <A href='mailto:membersupport@chameleon59.com'>membersupport@chameleon59.com.</A><br><br>"
                    + "Thank you, <br>"
                    + "Chameleon Member Support";



                //List<String> recipients = new List<String>
                //{
                //    @"Jeff Smith <jeff@example.com>",
                //    @"Anna Lidman <anna@example.com>",
                //    @"Peter Saddow <peter@example.com>"
                //};

                string sFrom = "donotreply@chameleonmailer.com"; ;
                string sSubject = "Chameleon Member Support";
                string sCc = "membersupport@chameleon59.com";
                string sBcc = String.Empty;
                string userName = mMain.sendGridUser;
                string pw = mMain.sendGridPw;

                regMessage.AddTo(sTo);
                regMessage.From = new MailAddress(sFrom);
                regMessage.Subject = sSubject;
                regMessage.AddCc(sCc);
                regMessage.Html = message;

                NetworkCredential netUser = new NetworkCredential(userName, pw);
                var transportWeb = new Web(netUser);
                transportWeb.DeliverAsync(regMessage);




                //SmtpClient mailClient = new SmtpClient();
                //mailClient.Host = mMain.smtpServer;
                //mailClient.Port = mMain.smtpPort;


                

               // MailMessage m = new MailMessage();

               // m.From = new MailAddress(sFrom);
               // m.Subject = sSubject;
               // MailAddress to = new MailAddress(sTo);
               // m.To.Add(to);
               //// m.CC.Add(sCc);

               // m.Body = message;
               // m.IsBodyHtml = true;

               // NetworkCredential netUser = new NetworkCredential(userName, pw);
               // mailClient.UseDefaultCredentials = false;
               // mailClient.Credentials = netUser;

               // mailClient.Send(m);



                //Mailer.From = "mail@chameleon59.com";//"charrison@rockncode.com";
                //Mailer.To = sTo;
                //Mailer.Subject = "Chameleon Member Support";
                //Mailer.Body = message;
                //Mailer.BodyFormat = System.Web.Mail.MailFormat.Html;
                ////System.Net.Mail.s
                //SmtpMail.Send(Mailer);

                showJSMessage("Page successfully sent!");
                closeJSWindow();

                success = true;
            }
            catch (SmtpException smtpEx)
            {
                lbInfo.Text = "An error occurred: " + smtpEx.ToString();
                lbInfo.Visible = true;

                showJSMessage("An error occurred: " + smtpEx.ToString());
                success = false;
            }
            catch (Exception ex)
            {
                lbInfo.Text = "An error occurred: " + ex.ToString();
                lbInfo.Visible = true;

                showJSMessage("An error occurred: " + ex.ToString());
                success = false;
            }
            //				}
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

        protected void butClose_Click(object sender, System.EventArgs e)
        {
            closeJSWindow();
        }

        protected void butHome_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("chameleon-home.aspx", true);
        }
    }
}