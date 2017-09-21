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
    public partial class ICham : System.Web.UI.MasterPage
    {
        #region User Defined Decs

        private string sWhere = "";
        private string sSearchHeading = "";
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(webEnabled = 1)";

        #endregion

        protected System.Web.UI.HtmlControls.HtmlInputImage butLoginRegister_B;

        protected void Page_Load(object sender, System.EventArgs e)
        {


            if (IsLoggedIn())
            {
                //LoginRegister.Attributes.Add("onmouseover", "this.src='Images/butLogOff_A.gif'");
                //LoginRegister.Attributes.Add("onmouseout", "this.src='Images/butLogOff_B.gif'");
                //LoginRegister.ImageUrl = "Images/butLogOff.gif";

            }
            else
            {
                //LoginRegister.Attributes.Add("onmouseover", "this.src='Images/butLoginRegister_A.gif'");
                //LoginRegister.Attributes.Add("onmouseout", "this.src='Images/butLoginRegister_B.gif'");
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);

          
        }
       
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

        protected void butMyWorkshop_B_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-memberHome.aspx", true);
        }

        protected void butAllInventory_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=All", true);
        }

        protected void butAllAntiques_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //Response.Redirect("chameleon-searchResults.aspx?Line=Antiques", true);
        }

        protected void butAllSignature_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=Signature", true);
        }

        protected void butRequestCatalog_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-catalogRequest.aspx", true);
        }

        protected void butAdvancedSearch_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-advancedSearch.aspx", true);
        }

        protected void butRecentArrivals_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-recentArrivals.aspx", true);
        }

        protected void butMyProfile_B_ServerClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-memberProfile.aspx", true);
        }
        
        //ADDED BY ROB START
        protected void butTraditional_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=Traditional", true);
        }

        protected void butContemporary_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-searchResults.aspx?Line=Contemporary", true);
        }

        protected void butSubmit_Click(object sender, ImageClickEventArgs e)
        {
            //sSearchHeading = "All Lines > Item Code > " + txtItemNo.Text;
            //sWhere = "";

            //if (txtItemNo.Text != "")
            //{
            //    string keyWord = txtItemNo.Text.Trim();
            //    sWhere = Server.UrlEncode(" where (itemCode LIKE '%" + keyWord + "%' or itemNumber LIKE '%" + keyWord + "%' or item LIKE '%" + keyWord + "%' or description LIKE '%" + keyWord + "%') and " + sStatus);
            //    Response.Redirect("chameleon-searchresults.aspx?Line=custom&heading=" + sSearchHeading + "&where=" + sWhere, true);

            //}
        }

        protected void butReset_Click(object sender, ImageClickEventArgs e)
        {
            //txtItemNo.Text = String.Empty;
        }

        protected void LoginRegister_Click(object sender, ImageClickEventArgs e)
        {
            //if (LoginRegister.ImageUrl == "Images/butLogOff.gif")
            //{
            //    logOff();
            //    Response.Redirect("chameleon-home.aspx");
            //}
            //else
            //{
            //    Response.Redirect("chameleon-memberLogin.aspx");
            //}
        }

        private void logOff()
        {
            Session["memberID"] = null;

        }

        //private void showJSMessage(string sMessage)
        //{
        //    System.Text.StringBuilder sbMsg = new System.Text.StringBuilder();
        //    sbMsg.Append("<script language=javascript>");
        //    sbMsg.Append(" alert('");
        //    sbMsg.Append(sMessage);
        //    sbMsg.Append("')");
        //    sbMsg.Append("</script>");
        //    Response.Write(sbMsg.ToString());
        //}
    }
}