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

namespace IChameleon
{
    public partial class chameleon_memberViewItem : System.Web.UI.Page
    {
        #region User Defined Decs

        public DataSet mDataSet = new DataSet();
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter = new SqlDataAdapter();
        public bool isLoggedIn = false;
        public bool isTrade = false;
        public decimal discountRate = 0;
        private DataTable prodDT = null;

        private DataSet itemDS = null;
       // private BindingSource itemBS = null;

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
                //string sItemNo = "0004";
                itemCode = Request.QueryString["itemID"];
                //getItem(sItemNo);
                sql = "Select * From chaProducts where itemCode = '" + itemCode + "'";

                mDataSet = loadData(sql, "chaProducts");
                Session["mDS"] = mDataSet;

                if (mDataSet != null && mDataSet.Tables[0].Rows.Count > 0)
                {
                    if (mDataSet.Tables["chaProducts"].Rows[0]["itemID"].ToString() != String.Empty)
                    {
                        itemID = Convert.ToInt32(mDataSet.Tables["chaProducts"].Rows[0]["itemID"].ToString());
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

            //renderHTML();
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
            if (checkSession())
            {
                isTrade = Convert.ToBoolean(Session["isTrade"].ToString());
            }

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

            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["type"].ToString() == "Signature")
            {
                ibIconInfo.Visible = true;
            }
            else
            {
                ibIconInfo.Visible = false;
            }

            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["type"].ToString() == "Signature")
            {
                lbFinishTypes.Visible = true;
            }
            else
            {
                lbFinishTypes.Visible = false;
            }


            lbAvailability.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["availability"].ToString();

            string sType = mDataSet.Tables[mMain.sProductSource].Rows[0]["type"].ToString();
            string sGrouping = mDataSet.Tables[mMain.sProductSource].Rows[0]["grouping"].ToString();

            //change pricing label if in the trade
            if (isTrade)
            {
                lbPrice.Text = "Trade Pricing";

            }

            if (sType == "Antique")
            {
                //if it's an antique set discountRate = .8
                discountRate = (decimal).8;               

                if (mDataSet.Tables[mMain.sProductSource].Rows[0]["availableQuantity"].ToString() != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["availableQuantity"].ToString() != "" && Convert.ToInt32(mDataSet.Tables[mMain.sProductSource].Rows[0]["availableQuantity"]) != 0)
                {
                    lbQuantLB.Visible = true;
                    lbAvailQty.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["availableQuantity"].ToString();
                }
                else
                {
                    lbQuantLB.Visible = false;
                    lbAvailQty.Visible = false;
                }

                if (mDataSet.Tables[mMain.sProductSource].Rows[0]["saleEnabled"].ToString() == "True")
                {
                    if (mDataSet.Tables[mMain.sProductSource].Rows[0]["salePrice"] != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["salePrice"].ToString() != "" && (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["salePrice"] != 0)
                    {
                        decimal price1 = (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"];
                        decimal salePrice = (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["salePrice"];
                        int percentage = calcSalePercentage(price1, salePrice);

                        lbSale.Visible = true;
                        lbSale.Text = "Now only " + string.Format("{0:$#,#}", salePrice) + " " + sGrouping + " - save " + percentage + "%";

                        lbBasePrice.Text = string.Format("{0:$#,#}", price1) + " " + sGrouping;
                        lbBasePrice.Visible = true;
                        lbPrice.Visible = true;
                    }
                }
                else if (mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"] != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"].ToString() != "" && (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"] != 0)
                {
                    decimal price1 = (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"];

                    if (isTrade)
                    {
                        price1 = calcNetPrice(price1, discountRate);
                    }

                    lbBasePrice.Text = string.Format("{0:$#,#}", price1) + " " + sGrouping;
                    lbBasePrice.Visible = true;
                    lbPrice.Visible = true;


                }
                else
                {
                    lbBasePrice.Text = "";
                    lbBasePrice.Visible = false;
                    lbPrice.Visible = false;
                }
            }
            else if (sType == "Accessory")
            {
                lbQuantLB.Visible = false;
                lbAvailQty.Visible = false;
                discountRate = (decimal).7;

                if (mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"] != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"].ToString() != "" && (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"] != 0)
                {
                    decimal price1 = (decimal)mDataSet.Tables[mMain.sProductSource].Rows[0]["price1"];
                    lbBasePrice.Text = string.Format("{0:$#,#}", price1) + " " + sGrouping;
                    lbBasePrice.Visible = true;
                    lbPrice.Visible = true;


                }
                else
                {
                    lbBasePrice.Text = "";
                    lbBasePrice.Visible = false;
                    lbPrice.Visible = false;
                }
            }
            else
            {
                // is Signature - set discount rate accordingly
                discountRate = (decimal).7;

                lbQuantLB.Visible = false;
                lbAvailQty.Visible = false;
            }

            // set related items
            if (prodDT != null && prodDT.Rows.Count > 0)
            {
                foreach (DataRow r in prodDT.Rows)
                {
                    if (r["price1"] != null && r["price1"].ToString() != "" && (decimal)r["price1"] != 0)
                    {
                        decimal iPrice = Convert.ToDecimal(r["price1"]);

                        if (isTrade)
                        {
                            iPrice = calcNetPrice(iPrice, discountRate);
                        }

                        if (r["itemClass"].ToString() == "Brass")
                        {
                            if (r["price1"].ToString() != String.Empty)
                            {
                                decimal price2 = iPrice;
                                //decimal price2 = (decimal)r["price1"];
                                lbBrassPrice.Text = string.Format("{0:$#,#}", price2) + " " + r["grouping"].ToString();
                                lbBrassPrice.Visible = true;
                                lbBrass.Visible = true;

                                if (r["itemCode"].ToString() != itemCode)
                                {
                                    lbBrassImage.Visible = true;
                                    hlBrass.Visible = true;
                                    hlBrass.ImageUrl = r["image1Thumb"].ToString();
                                    hlBrass.NavigateUrl = @"javascript:viewItemWin('chameleon-memberViewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                    lbBrassImage.Text = r["itemClass"].ToString();
                                }
                            }
                        }
                        else if (r["itemClass"].ToString() == "Nickel")
                        {
                            if (r["price1"].ToString() != String.Empty)
                            {
                                decimal price3 = iPrice;
                                //decimal price3 = (decimal)r["price1"];
                                lbNickelPrice.Text = string.Format("{0:$#,#}", price3) + " " + r["grouping"].ToString(); ;
                                lbNickelPrice.Visible = true;
                                lbNickel.Visible = true;


                                if (r["itemCode"].ToString() != itemCode)
                                {
                                    lbNickelImage.Visible = true;
                                    hlNickel.Visible = true;
                                    hlNickel.ImageUrl = r["image1Thumb"].ToString();
                                    hlNickel.NavigateUrl = @"javascript:viewItemWin('chameleon-memberViewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                    lbNickelImage.Text = r["itemClass"].ToString();
                                }
                            }
                        }
                        else if (r["itemClass"].ToString() == "Silver")
                        {
                            if (r["price1"].ToString() != String.Empty)
                            {
                                decimal price4 = iPrice;
                                //decimal price4 = (decimal)r["price1"];
                                lbSilverPrice.Text = string.Format("{0:$#,#}", price4) + " " + r["grouping"].ToString(); ;
                                lbSilverPrice.Visible = true;
                                lbSilver.Visible = true;


                                if (r["itemCode"].ToString() != itemCode)
                                {
                                    lbSilverImage.Visible = true;
                                    hlSilver.ImageUrl = r["image1Thumb"].ToString();
                                    hlSilver.NavigateUrl = @"javascript:viewItemWin('chameleon-memberViewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                    hlSilver.Visible = true;
                                    lbSilverImage.Text = r["itemClass"].ToString();
                                }
                            }
                        }
                        else if (r["itemClass"].ToString() == "Gold")
                        {
                            if (r["price1"].ToString() != String.Empty)
                            {
                                decimal price5 = iPrice;
                                //ecimal price5 = (decimal)r["price1"];
                                lbGoldPrice.Text = string.Format("{0:$#,#}", price5) + " " + r["grouping"].ToString(); ;
                                lbGoldPrice.Visible = true;
                                lbGold.Visible = true;


                                if (r["itemCode"].ToString() != itemCode)
                                {
                                    lbGoldImage.Visible = true;
                                    hlGold.ImageUrl = r["image1Thumb"].ToString();
                                    hlGold.NavigateUrl = @"javascript:viewItemWin('chameleon-memberViewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                    hlGold.Visible = true;
                                    lbGoldImage.Text = r["itemClass"].ToString();
                                }
                            }
                        }
                        else if (r["itemClass"].ToString() == "Patinated")
                        {
                            decimal price6 = iPrice;
                            //decimal price6 = (decimal)r["price1"];
                            lbPatinatedPrice.Text = string.Format("{0:$#,#}", price6) + " " + r["grouping"].ToString(); ;
                            lbPatinated.Visible = true;
                            lbPatinatedPrice.Visible = true;


                            if (r["itemCode"].ToString() != itemCode)
                            {
                                lbPatinatedImage.Visible = true;
                                hlPatinated.ImageUrl = r["image1Thumb"].ToString();
                                hlPatinated.NavigateUrl = @"javascript:viewItemWin('chameleon-memberViewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                hlPatinated.Visible = true;
                                lbPatinatedImage.Text = r["itemClass"].ToString();
                            }
                        }
                        else if (r["itemClass"].ToString() == "Silver Leaf")
                        {
                            decimal price7 = iPrice;
                            lbSilverLeafPrice.Text = string.Format("{0:$#,#}", price7) + " " + r["grouping"].ToString(); ;
                            lbSilverLeaf.Visible = true;
                            lbSilverLeafPrice.Visible = true;


                            if (r["itemCode"].ToString() != itemCode)
                            {
                                lbSilverLeafImage.Visible = true;
                                hlSilverLeaf.ImageUrl = r["image1Thumb"].ToString();
                                hlSilverLeaf.NavigateUrl = @"javascript:viewItemWin('chameleon-memberViewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                hlSilverLeaf.Visible = true;
                                lbSilverLeafImage.Text = r["itemClass"].ToString();
                            }
                        }
                        else if (r["itemClass"].ToString() == "Gold Leaf")
                        {
                            decimal price8 = iPrice;
                            //decimal price8 = (decimal)r["price1"];
                            lbGoldLeafPrice.Text = string.Format("{0:$#,#}", price8) + " " + r["grouping"].ToString(); ;
                            lbGoldLeaf.Visible = true;
                            lbGoldLeafPrice.Visible = true;


                            if (r["itemCode"].ToString() != itemCode)
                            {
                                lbGoldLeafImage.Visible = true;
                                hlGoldLeaf.ImageUrl = r["image1Thumb"].ToString();
                                hlGoldLeaf.NavigateUrl = @"javascript:viewItemWin('chameleon-memberViewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                hlGoldLeaf.Visible = true;
                                lbGoldLeafImage.Text = r["itemClass"].ToString();
                            }
                        }
                        else if (r["itemClass"].ToString() == "Leafed")
                        {
                            decimal price9 = iPrice;
                            //decimal price9 = (decimal)r["price1"];
                            lbLeafedPrice.Text = string.Format("{0:$#,#}", price9) + " " + r["grouping"].ToString(); ;
                            lbLeafed.Visible = true;
                            lbLeafedPrice.Visible = true;


                            if (r["itemCode"].ToString() != itemCode)
                            {
                                lbLeafedImage.Visible = true;
                                hlLeafed.ImageUrl = r["image1Thumb"].ToString();
                                hlLeafed.NavigateUrl = @"javascript:viewItemWin('chameleon-memberViewItem.aspx?item=" + r["item"].ToString() + "&itemID=" + r["itemCode"].ToString() + "')";
                                hlLeafed.Visible = true;
                                lbLeafedImage.Text = r["itemClass"].ToString();
                            }
                        }
                        else if (r["itemClass"].ToString() == String.Empty)
                        {
                            if (r["price1"].ToString() != String.Empty)
                            {
                                decimal price = (decimal)r["price1"];
                                lbBasePrice.Text = string.Format("{0:$#,#}", price) + " " + r["grouping"].ToString(); ;
                                lbBasePrice.Visible = true;
                                lbPrice.Visible = true;

                            }
                        }

                    }
                }
            }

            if (prodDT != null && prodDT.Rows.Count > 0 && mDataSet.Tables[mMain.sProductSource].Rows[0]["subCategory"].ToString() != "Shade"
                 && mDataSet.Tables[mMain.sProductSource].Rows[0]["itemClass"].ToString() != "Silver Leaf"
                 && mDataSet.Tables[mMain.sProductSource].Rows[0]["itemClass"].ToString() != "Gold Leaf"
                 && mDataSet.Tables[mMain.sProductSource].Rows[0]["itemClass"].ToString() != String.Empty)
            {
                hlFinishes.Visible = true;
            }

            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["ulRating"] != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["ulRating"].ToString() != "" && mDataSet.Tables[mMain.sProductSource].Rows[0]["ulRating"].ToString() != "None")
            {
                lbULRatingLb.Text = "Listed For " + mDataSet.Tables[mMain.sProductSource].Rows[0]["ulRating"].ToString() + " Locations";
                lbULRatingLb.Visible = true;
                imageUL.Visible = true;
            }
            else
            {
                lbULRatingLb.Visible = false;
                imageUL.Visible = false;
            }

            // Dimensions
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
                lbDimensions.Text = sDimensions;
                lbDimLb.Visible = true;
                lbDimensions.Visible = true;
            }
            else
            {
                lbDimLb.Visible = false;
                lbDimensions.Visible = false;
            }

            if (mDataSet.Tables[mMain.sProductSource].Rows[0]["totalDrop"] != null && mDataSet.Tables[mMain.sProductSource].Rows[0]["totalDrop"].ToString() != "")
            {
                lbTotalDrop.Text = mDataSet.Tables[mMain.sProductSource].Rows[0]["totalDrop"].ToString();
                lbTotalDropLb.Visible = true;
                lbTotalDrop.Visible = true;
            }
            else
            {
                lbTotalDropLb.Visible = false;
                lbTotalDrop.Visible = false;
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
                lbBackplate.Text = sBackplate;
                lbBackplateLb.Visible = true;
                lbBackplate.Visible = true;
            }
            else
            {
                lbBackplate.Visible = false;
                lbBackplateLb.Visible = false;
            }

            // get bulbs
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
                lbBulbs.Text = sBulbs;
                lbBulbsLb.Visible = true;
                lbBulbs.Visible = true;
            }
            else
            {
                lbBulbsLb.Visible = false;
                lbBulbs.Visible = false;
            }


        }
       
        protected void butEmail_Click(object sender, System.EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["mDS"];

            //Get the rendered HTML
            StringBuilder SB = new StringBuilder();
            StringWriter SW = new StringWriter(SB);
            HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
            Panel1.RenderControl(htmlTW);

            string sHTML = SB.ToString();
            //ltlHTMLOutput.Text = Server.HtmlEncode(dataGridHTML)
            string sURL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToString();

            Context.Items.Add("html", sHTML);
            Context.Items.Add("url", sURL);
            Context.Items.Add("itemCode", ds.Tables[0].Rows[0]["itemCode"].ToString());

            Server.Transfer("chameleon-email.aspx", true);
        }

        private bool checkSession()
        {
            //string s = Session["memberID"].ToString();
            if (Session["memberID"] != null && Session["memberID"].ToString() != "")
            {
                return true;
            }
            else
            {
                //showJSMessage("Your Session has expired due to inactivity.  Please login again.");
                Response.Redirect("chameleon-memberLogin.aspx");
                return false;
            }
        }

        private decimal calcNetPrice(decimal retailPrice, decimal discountRate)
        {
            decimal netResult = retailPrice * discountRate;
            return netResult;


        }

        private void renderHTML()
        {
            //Get the rendered HTML
            try
            {
                StringBuilder SB = new StringBuilder();
                StringWriter SW = new StringWriter(SB);
                HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
                Panel1.RenderControl(htmlTW);

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
            DataSet ds = new DataSet();
            ds = (DataSet)Session["mDS"];

            try
            {
                Context.Items.Add("itemID", ds.Tables[0].Rows[0]["itemID"].ToString());
                Context.Items.Add("image1", ds.Tables[0].Rows[0]["image1"].ToString());
                Context.Items.Add("inTrade", "true");
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

                ds = null;
            }
        }

        private int calcSalePercentage(decimal origPrice, decimal salePrice)
        {
            int percent = 0;

            try
            {
                percent = (int)((1 - salePrice / origPrice) * 100);
            }
            catch (Exception ex)
            {

            }

            return percent;


        }
    }
}