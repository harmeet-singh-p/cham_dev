using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RocknCode.RocknCodeLib;
using ImageResizer;
using System.IO;
using System.Drawing;
using Dwg = System.Drawing;
using System.Drawing.Imaging;

namespace IChameleon
{
    public partial class chameleon_recentArrivals : System.Web.UI.Page
    {
        #region User Defined Decs

        private string sWhere = "";
        private string sSearchHeading = "";
        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(webEnabled = 1)";

        public bool blIsLoggedIn = false;

        #endregion

        protected System.Web.UI.HtmlControls.HtmlInputImage butLoginRegister_B;

        protected void Page_Load(object sender, System.EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                //fillCombos();
                getNewItemsDataSet();

            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dItems.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.dItems_ItemDataBound);

        }
        #endregion

        public void getNewItemsDataSet()
        {

            try
            {
                int days = -31;
                int count = 0;
                string sSQL = "";              

                sSQL = "Select TOP 45 * from " + mMain.sProductSource + " Where " + sStatus + " order by dateEntered desc";
                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, mMain.sProductSource);

                bindNewItems();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }	//end getNewItemsDataSet()

        private void bindNewItems()
        {
            try
            {
                dItems.DataSource = mDataSet.Tables[mMain.sProductSource].DefaultView;
                dItems.DataMember = mMain.sProductSource;
                dItems.DataBind();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
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

        protected String BitmapToEmbedded(Dwg.Bitmap src_bmp)
        {

            //If we're passed nothing, return nothing
            if (src_bmp == null)
                return "";

            //Create a memory stream into which we'll write the JPEG encoded image data
            var memStream = new MemoryStream();

            //Write the data to the memory stream, then convert its byte array to a base64 
            //string and prepend the inline data header

            src_bmp.Save(memStream, ImageFormat.Jpeg);
            return "data:image/jpeg;base64," + Convert.ToBase64String(memStream.ToArray());
        }

        private void dItems_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            string s = String.Empty;
            string iPath = String.Empty;
            string imageName = String.Empty;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hl = (HyperLink)(e.Item.FindControl("hlAddItem"));
                //hl.NavigateUrl = hl.NavigateUrl + "&backURL=" + ViewState["backURL"].ToString();

                if (blIsLoggedIn)
                    hl.Visible = true;
                else
                    hl.Visible = false;


                System.Web.UI.WebControls.Image i = (System.Web.UI.WebControls.Image)(e.Item.FindControl("image1"));
                s = mDataSet.Tables[mMain.sProductSource].Rows[e.Item.ItemIndex]["Image1"].ToString();
                imageName = s.Substring(s.LastIndexOf("/") + 1);
                iPath = "~/images/Products/" + imageName;

                MemoryStream ms = null;
                Bitmap bm = null;

                try
                {
                    if (!string.IsNullOrEmpty(iPath))
                    {
                        //if (File.Exists(iPath))
                        //{
                            ms = new MemoryStream();
                            ImageBuilder.Current.Build(iPath, ms, new ResizeSettings("width=200&height=200&&mode=pad&bgcolor=black"), true);
                            bm = new Bitmap(ms);
                            i.ImageUrl = BitmapToEmbedded(bm);
                        //}

                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
                finally
                {
                    ms.Flush();
                    ms.Dispose();
                    bm = null;
                }

            }
        }
       
       
    }
}