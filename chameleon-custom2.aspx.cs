using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RocknCode.RocknCodeLib;
using System.Data;
using System.Web.SessionState;

namespace IChameleon
{
    public partial class chameleon_custom2 : System.Web.UI.Page
    {
        #region User Defined Decs

        private string sWhere = "";
        private string sSearchHeading = "";
        public DataSet mDataSet = new DataSet();
        //		private SqlConnection mConn;	
        //		private SqlDataAdapter mAdapter = new SqlDataAdapter();			
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(webEnabled = 1)";
        protected System.Web.UI.HtmlControls.HtmlInputImage butLoginRegister_B;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}