using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IChameleon
{
    public partial class chameleon_manufacturing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Request.UserAgent.ToLower().Contains("ipad") || HttpContext.Current.Request.UserAgent.ToLower().Contains("iphone"))
            {
                //iPad is the requested client. 
                Server.Transfer("chameleon-manufacturing2.aspx");
            }          


        }
    }
}