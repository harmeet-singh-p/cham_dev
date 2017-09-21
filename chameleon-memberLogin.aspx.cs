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
    public partial class chameleon_memberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {

            string IsExpired = "";
            IsExpired = Request.QueryString["expired"];
            if (IsExpired == "true")
            {
                //lbInfo.Text = "<br><br>You are not currently logged in. Please login again to continue,"
                //    + "<br>or register for membership if you don't have an account.<br><br>";
            }


        }

        protected void butLogin_Click(object sender, System.EventArgs e)
        {
            login();
        }

        private void login()
        {
            int iUser = 0;

            bool loggedIn = false;
            int memberID;
            string userName = String.Empty; ;
            string sFName = String.Empty; ;
            string sLName = String.Empty;
            bool isTrade = false;
            //try
            //{
            if (checkWebUserID(txtUserName.Text, txtPassword.Text, out iUser, out sFName, out sLName, out isTrade))
            {
                Session["memberID"] = iUser;
                Session["userName"] = txtUserName.Text;
                Session["firstName"] = sFName;
                Session["lastName"] = sLName;
                Session["isTrade"] = isTrade;


                loggedIn = true;
                memberID = iUser;
                userName = "";


                //lbInfo.ForeColor = System.Drawing.Color.Teal;
                //lbInfo.Text = "Thank you!  Your information has been verified.  Please wait to be transfered to the main menu.";
                Response.Redirect("chameleon-memberHome.aspx");
                //Server.Transfer("chameleon-memberHome.aspx");

                //Response.Redirect("chameleon-memberHome.aspx?LoggedIn=" + loggedIn + "&userName=" + userName + "&memberID=" + memberID;

            }
            else
            {
                //lbInfo.ForeColor = System.Drawing.Color.Red;
                //lbInfo.Text = "We are unable to verify your information.  Please ensure your User Name and Password are correct and try again."
                //    + "  If the problem persists, please email support at membersupport@chameleon59.com or call 212-355-6300.";

            }
            //}
            //				catch(Exception ex)
            //				{
            //					lbInfo.Text = ex.Message.ToString();
            //					string s = lbInfo.Text;
            //				}
        }

        public bool checkWebUserID(string sUserName, string sPassword, out int iUserID, out string sFirstName, out string sLastName, out bool trade)
        {
            // Initialize variables
            iUserID = -1;
            bool success = false;
            sFirstName = String.Empty;
            sLastName = String.Empty;
            trade = false;

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
                dataCmd = new SqlCommand("udsp_getMemberID", dataConn);
                dataCmd.CommandType = CommandType.StoredProcedure;

                dataCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                dataCmd.Parameters.AddWithValue("@userName", sUserName);
                dataCmd.Parameters.AddWithValue("@password", sPassword);
                dataCmd.Parameters.Add("@memberID", SqlDbType.Int).Direction = ParameterDirection.Output;
                dataCmd.Parameters.Add("@firstName", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                dataCmd.Parameters.Add("@lastName", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                dataCmd.Parameters.Add("@isTrade", SqlDbType.Bit).Direction = ParameterDirection.Output;


                // execute command
                dataCmd.ExecuteNonQuery();


                // test return value and transfer control as necessary
                if ((int)dataCmd.Parameters[0].Value == 9)
                {
                    //if(opUserID != null)
                    //{
                    iUserID = Convert.ToInt32(dataCmd.Parameters["@memberID"].Value);
                    sFirstName = dataCmd.Parameters["@firstName"].Value.ToString();
                    sLastName = dataCmd.Parameters["@lastName"].Value.ToString();
                    if (dataCmd.Parameters["@isTrade"].Value.ToString() != String.Empty)
                        trade = Convert.ToBoolean(dataCmd.Parameters["@isTrade"].Value.ToString());
                    else
                        trade = false;
                    //}
                    //else

                    //sUserCategory = opUserCategory.Value.ToString();
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

        //protected void butLoginRegister_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    if (IsLoggedIn())
        //    {
        //        Session["memberID"] = null;
        //        Response.Redirect("chameleon-home.aspx", true);
        //    }
        //    else
        //    {
        //        Response.Redirect("chameleon-memberLogin.aspx", true);
        //    }
        //}

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

        //protected void butMyWorkshop_B_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-memberHome.aspx", true);
        //}

        //protected void butAllInventory_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-searchResults.aspx?Line=All", true);
        //}

        //protected void butAllAntiques_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-searchResults.aspx?Line=Antiques", true);
        //}

        //protected void butAllSignature_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-searchResults.aspx?Line=Signature", true);
        //}

        //protected void butRequestCatalog_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-catalogRequest.aspx", true);
        //}

        //protected void butAdvancedSearch_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-advancedSearch.aspx", true);
        //}

        //protected void butRecentArrivals_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-recentArrivals.aspx", true);
        //}

        protected void butRegister_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("chameleon-memberRegister.aspx", true);
        }

        private void butReset_Click(object sender, System.EventArgs e)
        {
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            //lbInfo.Text = String.Empty;
        }


        //protected void butMyProfile_B_ServerClick(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect("chameleon-memberProfile.aspx", true);
        //}
    }
}