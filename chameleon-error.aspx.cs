using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IChameleon
{
    public partial class chameleon_error : System.Web.UI.Page
    {
        #region DECS

        string errMsg = String.Empty;

        #endregion
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            errMsg = Request.QueryString["errMsg"].ToString();
            Response.Write(errMsg);
        }
    }
}