using System;
using System.Collections;
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
using System.Text;
using SendGrid;

namespace IChameleon
{
    public partial class chameleon_emailPortfolio : System.Web.UI.Page
    {
        #region User Defined Decs
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private int iUserID;
        private string sUserName;
        private int iPortfolioID;
        private string sSearchHeading = "";
        private string sUserCategory;
        private string sWhere = "";
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(webEnabled = 1)";


        #endregion



        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //				iPortfolioID = Convert.ToInt32(Context.Items["portfolioID"].ToString());
                //				ViewState["portfolioName"] = Context.Items["portfolioName"].ToString();

                iPortfolioID = Convert.ToInt32(Request.QueryString["portfolioID"].ToString());
                ViewState["portfolioName"] = Request.QueryString["portfolioName"].ToString();

                lbHeader.Text = "Portfolio: " + ViewState["portfolioName"].ToString();
                ViewState["portfolioID"] = iPortfolioID;
                getPortfolioDataSet();
                renderHTML();
                txtFrom.Text = Session["userName"].ToString();
                txtSubject.Text = "Portfolio " + ViewState["portfolioName"].ToString() + " at Chameleon Fine Lighting";
            }
            else
            {
                //sHtml = Context.Items["html"].ToString();
                //ViewState["html"] = sHtml;

                //sURL = Context.Items["url"].ToString();
                //ViewState["url"] = sURL;

                iPortfolioID = Convert.ToInt32(ViewState["portfolioID"].ToString());
                //lbHeader.Text = "Viewing Portfolio: " + ViewState["portfolioName"].ToString();
            }
        }       

        public void getPortfolioDataSet()
        {
            try
            {
                //string sSQL = "Select * from chaProducts where itemCode in (Select itemCode from chaPortfolioItems where portfolioID = " + Session["portfolioID"] + ")";					
                string sSQL = "Select * from chaPortfolioItems where portfolioID = " + Convert.ToInt32(ViewState["portfolioID"].ToString());

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, "chaPortfolioItems");

                if (mDataSet.Tables["chaPortfolioItems"].DefaultView.Count > 0)
                {
                    //pnlPortfolio.Visible = true;						
                    lbInfo.Text = "";

                    bindItems();


                    //lbHeader.Text = "";//mDataSet.Tables["chaPortfolioItems"].Rows[0]["name"].ToString();
                }
                else
                {
                    //pnlPortfolio.Visible = false;	

                    lbInfo.Text = "You have no items saved in this portfolio";
                }



                //string count = mDataSet.Tables["chaPortfolio"].Rows.Count.ToString();
                //string s = mDataSet.Tables["chaPortfolio"].Rows[0]["userID"].ToString();				
                //bindPortfolio();				
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }	//end 

        private void bindItems()
        {
            try
            {
                //mDataSet.Tables["udsp_getPagedResults"].DefaultView.Sort = "prefix, suffix";	
                //dItems.DataSource = null;

                dItems.DataSource = mDataSet.Tables["chaPortfolioItems"].DefaultView;
                dItems.DataBind();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
                lbInfo.Text = sError;
                sError = "";

            }
        }

        private void renderHTML()
        {
            //Get the rendered HTML
            StringBuilder SB = new StringBuilder();
            StringWriter SW = new StringWriter(SB);
            HtmlTextWriter htmlTW = new HtmlTextWriter(SW);

            //htmlTW = "<Form runat=server>" + htmlTW + "</Form>";

            //Panel1.RenderControl(htmlTW);
            Panel1.RenderControl(htmlTW);

            string sHTML = SB.ToString();
            //ltlHTMLOutput.Text = Server.HtmlEncode(dataGridHTML)
            string sURL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToString();

            ViewState["html"] = sHTML;
            ViewState["url"] = sURL;

            //Server.Transfer("chameleon-email.aspx",true);
        }

        private String readHtmlPage(string html)
        {
            String result;
            WebResponse objResponse;
            WebRequest objRequest = System.Net.HttpWebRequest.Create(html);
            objResponse = objRequest.GetResponse();
            using (StreamReader sr =
                       new StreamReader(objResponse.GetResponseStream()))
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



            if (Page.IsValid)
            {
                //Trace.Write("Submit", "Page is valid -- send email.");

                try
                {
                    string to = txtTo.Text.Trim();
                    string sFrom = "donotreply@chameleonmailer.com";
                    string sSubject = txtSubject.Text.Trim();
                    string sCc = "membersupport@chameleon59.com";
                    string sBcc = String.Empty;
                    string userName = mMain.sendGridUser;
                    string pw = mMain.sendGridPw;
                    string message = String.Empty;
                    string sName = Session["firstName"].ToString() + " " + Session["lastName"].ToString(); ;
                    string sEmail = txtFrom.Text.Trim();

                    if (chkLinkOnly.Checked)
                    {
                        message = "<A href='" + ViewState["url"].ToString() + "'>" + ViewState["url"].ToString() + "</A>";
                        //Mailer.BodyFormat = System.Web.Mail.MailFormat.Text;
                    }
                    else
                    {
                        message = ViewState["html"].ToString();
                        //Mailer.BodyFormat = System.Web.Mail.MailFormat.Html;
                    }

                    message = message + "<br><br>This Portfolio was sent to you on behalf of " + sName + " at " +
                    "<A href='mailto:" + sEmail + "'>" + sEmail + ".</A><br><br>" +
                    "Please email the sender directly or call us at 212-355-6300";

                    var regMessage = new SendGridMessage();

                    regMessage.AddTo(to);
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

                    //MailMessage m = new MailMessage();

                    //m.From = new MailAddress(sFrom);
                    //m.Subject = sSubject;
                    //MailAddress to = new MailAddress(txtTo.Text.Trim());
                    //m.To.Add(to);
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
                    lbInfo.Text = "Portfolio successfully sent!<br><br>Click below to return to your portfolio.";
                    //showJSMessage("Page successfully sent!");

                    //closeJSWindow();

                    //litSent.Text = message;
                }
                catch (SmtpException smtpEx)
                {
                    lbInfo.Text = "An error occurred: " + smtpEx.ToString();
                    lbInfo.Visible = true;

                    showJSMessage("An error occurred: " + smtpEx.ToString());
                }
                catch (Exception ex)
                {
                    lbInfo.Text = "An error occurred: " + ex.ToString();
                    showJSMessage("An error occurred: " + ex.ToString());
                    //closeJSWindow();
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

        protected void butReturn_Click(object sender, System.EventArgs e)
        {
            string sPortID = ViewState["portfolioID"].ToString();
            string sPortName = Server.UrlEncode(ViewState["portfolioName"].ToString());
            Response.Redirect("chameleon-memberViewPortfolio.aspx?portfolioID=" + ViewState["portfolioID"] + "&portfolioName=" + sPortName);
        }
    }
}