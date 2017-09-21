using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RocknCode.RocknCodeLib;

namespace IChameleon
{
    public partial class chameleon_viewItem : System.Web.UI.Page
    {
        #region User Defined Decs

        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        private DataTable prodDT = null;

        private DataSet itemDS = null;
        //private BindingSource itemBS = null;


        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            DataTable dt;
            DataSet ds = new DataSet();
            string itemCode = String.Empty;
            int itemID = 0;
            int parentID = 0;
            string sql = string.Empty;
            string itemName = String.Empty;

            if (!Page.IsPostBack)
            {
                itemCode = Request.QueryString["itemID"];
                sql = "Select * From chaProducts where itemCode = '" + itemCode + "'";

                mDataSet = loadData(sql, "chaProducts");
                Session["mDS"] = mDataSet;

                if (mDataSet != null && mDataSet.Tables[0].Rows.Count > 0)
                {
                    if (mDataSet.Tables["chaProducts"].Rows[0]["itemID"].ToString() != String.Empty)
                    {
                        itemID = Convert.ToInt32(mDataSet.Tables["chaProducts"].Rows[0]["itemID"].ToString());
                        itemName = mDataSet.Tables["chaProducts"].Rows[0]["item"].ToString();
                    }

                    if (mDataSet.Tables["chaProducts"].Rows[0]["parentID"].ToString() != String.Empty)
                    {
                        parentID = Convert.ToInt32(mDataSet.Tables["chaProducts"].Rows[0]["parentID"].ToString());
                    }

                    if (mDataSet.Tables["chaProducts"].Rows[0]["type"].ToString() == "Signature")
                    {
                        string sSql = "Select * from chaProducts where (type = 'Signature') and (parentID = " + parentID + " or itemID = " + parentID + " or parentID = " + itemID + " or itemID = " + itemID + ")  order by itemCode"; // and (itemID <> " + itemID + ")
                        //string sSql = "Select * from chaProducts where (type = 'Signature') and (parentID = " + parentID + " or itemID = " + parentID + " or parentID = " + itemID + ") and (itemID <> " + itemID + ") order by itemCode";

                        prodDT = loadData(sSql, "chaProducts").Tables[0];
                    }

                    bindItem();

                    Page.Title = "Chameleon Fine Lighting " + itemName + " " + itemCode;

                }

                renderHTML();
            }
        }  

        private void getItem(string sItemCode)
        {
            string sSQL = "Select * from " + mMain.sProductSource + " where itemCode = '" + sItemCode + "'";
            try
            {

                mConn = new SqlConnection(mMain.sDataPath);
                mAdapter = new SqlDataAdapter(sSQL, mConn);
                mAdapter.Fill(mDataSet, mMain.sProductSource);

                string count = mDataSet.Tables[mMain.sProductSource].Rows.Count.ToString();
                string s = mDataSet.Tables[mMain.sProductSource].Rows[0]["itemCode"].ToString();

                s = "";

                bindItem();

            }
            catch (SqlException e)
            {
                string eMsg = e.Message.ToString();
            }
        }

        private DataSet loadData(string sql, string tableName)
        {
            DataSet ds = new DataSet();
            try
            {
                if (sql != "")
                {
                    mConn = new SqlConnection(mMain.sDataPath);
                    mAdapter = new SqlDataAdapter(sql, mConn);
                    mAdapter.Fill(ds, tableName);

                }

            }
            catch (SqlException e)
            {
                //string eMsg = e.Message.ToString();
                string eMsg = e.Message;
            }

            return ds;
        }

        private void bindItem()
        {
            lbItem1.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["item"].ToString();
            string itemCode = mDataSet.Tables[mMain.sProductSource].Rows[0]["itemCode"].ToString();

            Image1.ImageUrl = mDataSet.Tables[mMain.sProductSource].Rows[0]["image1"].ToString();
            lbItem.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["item"].ToString();
            lbItemNo.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["itemCode"].ToString();
            lbDescription.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["description"].ToString();

            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["shownFinish"].ToString() == "")
            {
                lbItemClass.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["itemClass"].ToString();
            }
            else
            {
                lbItemClass.Text = "";
            }

            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["shownFinish"].ToString() != "")
            {
                lbShownFinish.Text = "(Shown in " + mDataSet.Tables[mMain.sProductSource].Rows[0]["shownFinish"].ToString() + " finish)";
            }
            else
            {
                lbShownFinish.Text = "";
            }

            lbAvailability.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["availability"].ToString();

            string sType = mDataSet.Tables[mMain.sProductSource].Rows[0]["type"].ToString();
            string sGrouping = mDataSet.Tables[mMain.sProductSource].Rows[0]["grouping"].ToString();
            StringBuilder stbuilder = new StringBuilder();
            stbuilder.Append("<table width = '' border = '0'><tr><td colspan = '2' > Retail Pricing </td></tr>");
            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["availableQuantity"].ToString() != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["availableQuantity"].ToString() != "" && Convert.ToInt32(mDataSet.Tables[mMain.sProductSource].Rows[0]["availableQuantity"]) != 0)
            {                
                stbuilder.Append("<tr><td> Available Qty: </td><td>" + mDataSet.Tables[mMain.sProductSource].Rows[0]["availableQuantity"].ToString() + "</td></tr>");
            }
            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["saleEnabled"].ToString() == "True")
            {
                if (mDataSet.Tables[mMain.sProductSource].Rows[0]["salePrice"] != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["salePrice"].ToString() != "" && (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["salePrice"] != 0)
                {
                    decimal price1 = (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"];
                    decimal salePrice = (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["salePrice"];
                    int percentage = calcSalePercentage(price1, salePrice);
                    var saleMsg = "Now only " + string.Format("{0:$#,#}", salePrice) + " " + sGrouping + " - save " + percentage + "%";
                    stbuilder.Append("<tr><td> Sale Price: </td><td>" + saleMsg + "</td></tr>");
                    stbuilder.Append("<tr><td> Base Price: </td><td>" + string.Format("{0:$#,#}", price1) + " " + sGrouping + "</td></tr>");

                }
            }
            else if (mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"] != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"].ToString() != "" && (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"] != 0)
            {
                decimal price1 = (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"];
                stbuilder.Append("<tr><td> Price:</td><td>" + string.Format("{0:$#,#}", price1) + " " + sGrouping + "</td></tr>");

            }            

            if (prodDT != null && prodDT.Rows.Count > 0)
            {
                StringBuilder stbld = new StringBuilder();
                stbld.Append("<ul>");
                foreach (DataRow r in prodDT.Rows)
                {
                    if (r["price1"] != null && r["price1"].ToString() != "" && (decimal)r["price1"] != 0)
                    {                        
                        if (r["price1"].ToString() != String.Empty)
                        {
                            decimal price2 = (decimal)r["price1"];
                            stbuilder.Append("<tr><td> "+ r["itemClass"].ToString() + "</td><td>" + string.Format("{0:$#,#}", price2) + " " + r["grouping"].ToString() + "</td></tr>");
                                
                            if (r["itemCode"].ToString() != itemCode)
                            {
                                var url = @"javascript:viewItemWin('chameleon-viewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                stbld.Append("<li><a href = "+ url + "><img src = '" + r["image1Thumb"].ToString() + "' /><p> "+ r["itemClass"].ToString() + " </p></a></li>");                                    
                            }
                        }                                       

                    }
                }
                stbld.Append("</ul>");
                thumbDiv.InnerHtml = stbld.ToString();
            }


            //// Dimensions
            string sHeight = mDataSet.Tables[mMain.sProductSource].Rows[0]["height"].ToString();
            string sWidth = mDataSet.Tables[mMain.sProductSource].Rows[0]["width"].ToString();
            string sDepth = mDataSet.Tables[mMain.sProductSource].Rows[0]["depth"].ToString();

            string sDimensions;

            if (sHeight != "" && sWidth != "" && sDepth != "")
            {
                sDimensions = sHeight + "h x " + sWidth + "w x " + sDepth + "d";
            }
            else if (sHeight != "" && sWidth != "")
            {
                sDimensions = sHeight + "h x " + sWidth + "w";
            }
            else if (sHeight != "" && sDepth != "")
            {
                sDimensions = sHeight + "h x " + sDepth + "d";
            }
            else if (sWidth != "" && sDepth != "")
            {
                sDimensions = sWidth + "w x " + sDepth + "d";
            }
            else if (sWidth != "")
            {
                sDimensions = sWidth + "w";
            }
            else if (sHeight != "")
            {
                sDimensions = sHeight + "h";
            }
            else if (sDepth != "")
            {
                sDimensions = sDepth + "d";
            }

            else
            {
                sDimensions = "";
            }

            if (sDimensions != "")
            {
                stbuilder.Append("<tr><td> Fixture Dimen (in.): </td><td>" + sDimensions + "</td></tr>");
            }


            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["totalDrop"] != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["totalDrop"].ToString() != "")
            {                
                stbuilder.Append("<tr><td> Overall Drop (in.): </td><td>" + mDataSet.Tables[mMain.sProductSource].Rows[0]["totalDrop"].ToString() + "</td></tr>");
            }


            string sBackplate;
            string sBackplateWidth = mDataSet.Tables[mMain.sProductSource].Rows[0]["backplateWidth"].ToString();
            string sBackplateHeight = mDataSet.Tables[mMain.sProductSource].Rows[0]["backplateHeight"].ToString();



            if (sBackplateHeight != "" && sBackplateWidth != "")
            {
                sBackplate = sBackplateHeight + "h x " + sBackplateWidth + "w";
            }
            else if (sBackplateHeight != "")
            {
                sBackplate = sBackplateHeight + "h";
            }
            else if (sBackplateWidth != "")
            {
                sBackplate = sBackplateWidth + "w";
            }
            else
            {
                sBackplate = "";
            }

            if (sBackplate != "")
            {
                stbuilder.Append("<tr><td> Backplate: </td><td>" + sBackplate + "</td></tr>");
            }

            //// get bulbs
            string sNumLights = mDataSet.Tables[mMain.sProductSource].Rows[0]["numLights"].ToString();
            string sWattage = mDataSet.Tables[mMain.sProductSource].Rows[0]["maxWattage"].ToString();
            string sBulbType = mDataSet.Tables[mMain.sProductSource].Rows[0]["bulbType"].ToString();

            string sBulbs;

            if (sWattage != "" && sNumLights != "")
            {
                sBulbs = sWattage + "W x " + sNumLights + " " + sBulbType;
            }
            else if (sNumLights != "")
            {
                sBulbs = sNumLights + " " + sBulbType;
            }
            else if (sWattage != "")
            {
                sBulbs = sWattage + "W" + " " + sBulbType;
            }
            else
            {
                sBulbs = "";
            }

            if (sBulbs != "")
            {
                stbuilder.Append("<tr><td> Bulb(s): </td><td>" + sBulbs + "</td></tr>");
            }
            stbuilder.Append("</table>");

            retailPricingTable.InnerHtml = stbuilder.ToString();           

        }

        private void renderHTML()
        {
            //Get the rendered HTML
            try
            {
                StringBuilder SB = new StringBuilder();
                StringWriter SW = new StringWriter(SB);
                HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
                //Panel1.RenderControl(htmlTW);

                string sHTML = SB.ToString();
                string sURL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToString();

                ViewState["html"] = sHTML;
                ViewState["url"] = sURL;
            }
            catch (Exception ex)
            {
                // log error
            }
        }


        protected void btnViewPDf_Click(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //Graphics g;
            //// Doc theDoc = new Doc();
            // string pdfHtml = String.Empty;

            // bool inTrade = true;

            itemDS = (DataSet)Session["mDS"];

            try
            {
                Context.Items.Add("itemID", itemDS.Tables[0].Rows[0]["itemID"].ToString());
                Context.Items.Add("image1", itemDS.Tables[0].Rows[0]["image1"].ToString());
                Context.Items.Add("inTrade", "false");
                Server.Transfer("chameleon-viewItemDetail.aspx", false);

            }
            catch (Exception ex)
            {
                // log error
                //string error = ex.Message.ToString();
                //Server.Transfer("chameleon-error.aspx?errMsg=" + error, false); 
            }
            finally
            {

                //ds = null;
            }
        }

        private int calcSalePercentage(decimal origPrice, decimal salePrice)
        {
            int percent = 0;

            try
            {
                percent = (int) ((1 - salePrice / origPrice) * 100);
            }
            catch(Exception ex)
            {
                
            }

            return percent;


        }
    }
}