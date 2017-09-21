using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IChameleon
{
    public partial class chameleon_helpTopics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string sHelpTopic = Request.QueryString["helpTopic"];

            switch (sHelpTopic)
            {
                case "ffRegion":
                    {
                        lbInfo.Text = "If you live outside of the United States, enter your province or region here" +
                            " instead of selecting a US state.";
                        break;
                    }

                case "ffPassword":
                    {
                        lbInfo.Text = "Your password must be at least 6 characters long";
                        break;
                    }

                case "ffSecurityCode":
                    {
                        lbInfo.Text = "For Master Card, Visa And Discover, the security code is the last 3 digits in the <br>" +
                            "signature strip on the back of the card.<br><br>For American Express, look for a 4 digit code on the front " +
                            "right side just above your main credit card number.";
                        break;
                    }
                default:
                    {
                        lbInfo.Text = "No information is available for this topic.";
                        break;
                    }
            }
        }
    }
}