using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IChameleon
{
    public partial class chameleon_regConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void butLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("chameleon-memberLogin.aspx", true);
        }
    }
}