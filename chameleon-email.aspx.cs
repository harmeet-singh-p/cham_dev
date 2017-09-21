using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using SendGrid;

namespace IChameleon
{
    public partial class chameleon_email : System.Web.UI.Page
    {
        #region User Defined Decs

        private string sURL = string.Empty;
        public DataSet iDataSet = new DataSet();
        private SqlConnection iConn;
        private SqlDataAdapter iAdapter = new SqlDataAdapter();

        private string sHtml = string.Empty;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //sURL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToString();//Request.RawUrl.ToString();
                //sURL = @"http://www.chameleon59.com/chameleon-viewItem.aspx?item=Baltic+Eight+Light&itemID=R58";
                sHtml = Context.Items["html"].ToString();
                ViewState["html"] = sHtml;

                sURL = Context.Items["url"].ToString();
                ViewState["url"] = sURL;
                string sItemCode = Context.Items["itemCode"].ToString();

                getItemThumb(sItemCode);

                txtFrom.Text = Session["userName"].ToString();

                txtSubject.Text = "Emailing Item " + sItemCode;
            }
        }
        
        private void getItemThumb(string sItemCode)
		{
			try
			{				
				string sSQL = "Select * from chaProducts where itemCode = '" + sItemCode + "'";					
				
				iConn = new SqlConnection(mMain.sDataPath);
				iAdapter = new SqlDataAdapter(sSQL,iConn);
				iAdapter.Fill(iDataSet,"chaProducts");
				
				if( iDataSet.Tables["chaProducts"].Rows.Count > 0)
				{								
					iItem.ImageUrl = iDataSet.Tables["chaProducts"].Rows[0]["image1Thumb"].ToString();
				}
				else
				{
					//						lbInfo2.Text = "You don't have any portfolios to add this item to."
					//							+ "<br><br>Please go to My Workshop and create 1 or more portfolios.";
					//						butMyWorkshop.Visible = true;
					//						Panel1.Visible = false;
				}
			}
			catch(Exception err)
			{				
				string sError = err.Message.ToString();	
				lbInfo.Text = sError;		
			}
			
		}

		private String readHtmlPage(string html)
		{
			String result;
			WebResponse objResponse;
			WebRequest objRequest = System.Net.HttpWebRequest.Create(html);
			objResponse = objRequest.GetResponse();
			using (StreamReader sr = 
					   new StreamReader(objResponse.GetResponseStream()) )
			{
				result = sr.ReadToEnd();
				// Close and clean up the StreamReader
				sr.Close();
			}
			return result;
		} 	

		protected void butSendEmail_Click(object sender, System.EventArgs e)
		{
			//string message = readHtmlPage(ViewState["url"].ToString());
			
			string message = "";

			if (Page.IsValid) 
			{
				//Trace.Write("Submit", "Page is valid -- send email.");

				try
				{
					//MailMessage Mailer = new MailMessage();
					
					if(chkLinkOnly.Checked)
					{
						message = "<A href='" + ViewState["url"].ToString()+ "'>" + ViewState["url"].ToString() + "</A>";
						//Mailer.BodyFormat = System.Web.Mail.MailFormat.Text;
					}
					else
					{
						message = ViewState["html"].ToString();
						//Mailer.BodyFormat = System.Web.Mail.MailFormat.Html;
					}

                    //SmtpClient mailClient = new SmtpClient();
                    //mailClient.Host = mMain.smtpServer;
                    //mailClient.Port = mMain.smtpPort;

                    string to = txtTo.Text.Trim();
                    string sFrom = txtFrom.Text.Trim();
                    string sSubject = txtSubject.Text.Trim();
                    string sCc = String.Empty;
                    string sBcc = "rdegiarde@chameleon59.com";
                    string userName = mMain.sendGridUser;
                    string pw = mMain.sendGridPw;

                    var regMessage = new SendGridMessage();

                    regMessage.AddTo(to);
                    regMessage.From = new MailAddress(sFrom);
                    regMessage.Subject = sSubject;
                    regMessage.AddCc(sCc);
                    regMessage.Html = message;

                    NetworkCredential netUser = new NetworkCredential(userName, pw);
                    var transportWeb = new Web(netUser);
                    transportWeb.DeliverAsync(regMessage);

                    //MailMessage m = new MailMessage();

                    //m.From = new MailAddress(sFrom);
                    //m.Subject = sSubject;
                    //MailAddress to = new MailAddress(txtTo.Text.Trim());
                    //m.To.Add(to);

                    //MailAddress bcc = new MailAddress(sBcc);
                    //m.Bcc.Add(bcc);

                    //m.Body = message;
                    //m.IsBodyHtml = true;

                    //NetworkCredential netUser = new NetworkCredential(userName, pw);
                    //mailClient.UseDefaultCredentials = false;
                    //mailClient.Credentials = netUser;

                    //mailClient.Send(m);

                    //Mailer.From = txtFrom.Text;
                    //Mailer.To = txtTo.Text;
                    //Mailer.Subject = txtSubject.Text;
                    //Mailer.Body = message;
                    //Mailer.BodyFormat = System.Web.Mail.MailFormat.Html;					
                    //SmtpMail.Send(Mailer);
					lbInfo.Text = "Page successfully sent!";
					showJSMessage("Page successfully sent!");
					closeJSWindow();

					//litSent.Text = message;
				}
                catch (SmtpException smtpEx)
                {
                    lbInfo.Text = "An error occurred: " + smtpEx.ToString();
                    lbInfo.Visible = true;

                    showJSMessage("An error occurred: " + smtpEx.ToString());
                }
				catch(Exception ex)
				{
					lbInfo.Text = "An error occurred: " + ex.ToString();
					showJSMessage("An error occurred: " + ex.ToString());
					closeJSWindow();
				}
			}
		}

		private void showJSMessage(string sMessage)
		{
			System.Text.StringBuilder sbMsg = new System.Text.StringBuilder();
			sbMsg.Append("<script language=javascript>"); 
			sbMsg.Append(" alert('");
			sbMsg.Append(sMessage);
			sbMsg.Append("')");
			sbMsg.Append("</script>"); 
			Response.Write (sbMsg.ToString());
		}

		private void closeJSWindow()
		{
			System.Text.StringBuilder jScript = new System.Text.StringBuilder();
			jScript.Append("<script language=\"JavaScript\">");
			jScript.Append("window.close()");
			jScript.Append(";");
			jScript.Append("</script>");

			//this.RegisterClientScriptBlock("closeWindow", jScript.ToString());
            ClientScript.RegisterClientScriptBlock(this.GetType(), "closeWindow", jScript.ToString());
		}
       
    }
}