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
    public partial class chameleon_advancedSearch : System.Web.UI.Page
    {
        #region User Defined Decs

        private const string sourceName = "chaProducts";
        //private string sQuery = "";
        private string sWhere = "";
        //private string sStatus = "(status = 'Available' or status = 'On Hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks'  or (DATEDIFF (day,dateUpdated,getdate() ) <= 14 and status = 'Sold') ) and (isChild = 0)";
        private string sStatus = "(webEnabled = 1)";

        #endregion

        //protected System.Web.UI.HtmlControls.HtmlInputImage butLoginRegister_B;

        protected void Page_Load(object sender, System.EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                fillCombos();

            }
        }        

        public string where
        {
            get
            {
                return sWhere;
            }
        }

        public string sort
        {
            get
            {
                return cboOrderBy.SelectedItem.ToString();
            }
        }


        public void fillCombos()
        {
            try
            {
                string SQLstr = "";
                //mPopulateList combo = new mPopulateList();
                mPopulateList lBox = new mPopulateList();

                // Statement modified to exclude Antiques - 12-14-14
                //lbCategories
                SQLstr = "select distinct mainCategory from chaItemCategories where mainCategory <> 'Antique'";
                lbCategories = lBox.fillWebListBox(lbCategories, mData.sDBType, SQLstr, "chaItemCategories", true, mMain.sDataPath);

                //lbSubCategories
                SQLstr = "select distinct subCategory from chaItemCategories where subCategory <> 'All'";
                lbSubCategories = lBox.fillWebListBox(lbSubCategories, mData.sDBType, SQLstr, "chaItemCategories", true, mMain.sDataPath);

                //lbMaterials
                SQLstr = "select distinct material from chaMaterials";
                lbMaterials = lBox.fillWebListBox(lbMaterials, mData.sDBType, SQLstr, "chaMaterials", true, mMain.sDataPath);

                // lbFinishes
                SQLstr = "select distinct finish from chaFinishes";
                lbFinishes = lBox.fillWebListBox(lbFinishes, mData.sDBType, SQLstr, "chaFinishes", true, mMain.sDataPath);

                // lbStyles
                SQLstr = "select distinct style from chaStyles";
                lbStyles = lBox.fillWebListBox(lbStyles, mData.sDBType, SQLstr, "chaStyles", true, mMain.sDataPath);

                // lbOrigins
                SQLstr = "select distinct origin from chaOrigins";
                lbOrigins = lBox.fillWebListBox(lbOrigins, mData.sDBType, SQLstr, "chaOrigins", true, mMain.sDataPath);

                // lbYearManufactured
                SQLstr = "select distinct manufacturedYear from chaManufacturedYears";
                lbYearManufactured = lBox.fillWebListBox(lbYearManufactured, mData.sDBType, SQLstr, "chaManufacturedYears", true, mMain.sDataPath);

                // lbManufacturer
                SQLstr = "select distinct manufacturer from chaManufacturers";
                lbManufacturer = lBox.fillWebListBox(lbManufacturer, mData.sDBType, SQLstr, "chaManufacturers", true, mMain.sDataPath);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error Populating Drop-down Lists");
            }
        }

        protected void butSearch_Click(object sender, System.EventArgs e)
        {
            try
            {
                buildAdvancedSearch();
            }
            catch (Exception err)
            {
                string sError = err.Message.ToString();
            }
        }

        public void buildAdvancedSearch()
        {
            string sSqlWhere = "";
            string sTypeSQL = "";
            string sCatSQL = "";
            string sSubCatSQL = "";
            string sStyleSQL = "";
            string sFinishSQL = "";
            string sMaterialsSQL = "";
            string sOriginsSQL = "";
            string sYearManufacturedSQL = "";
            string sManufacturerSQL = "";
            string sAnd = " AND ";
            string sOr = " OR ";
            string sTemp = "";
            string sField = "";
            //				string sStatus = "(status = 'available' or status = 'on hold' or status = '4-6 weeks' or status = '6-8 weeks' or status = '8-12 weeks')";
            string sSearchHeading = "";



            sTypeSQL = cboType.SelectedItem.Text.Trim();

            // category
            sField = "category";
            sTemp = buildSearchStringFromList2(lbCategories, sField);
            if (sTemp != "")
            {
                //sCatSQL = "category IN (" + sTemp + ")";
                sCatSQL = "(" + sTemp + ")";
                sTemp = "";
            }
            sField = "";

            // subCategory
            sField = "subCategory";
            sTemp = buildSearchStringFromList2(lbSubCategories, sField);
            if (sTemp != "")
            {
                //sSubCatSQL = "subCategory IN (" + sTemp + ")";
                sSubCatSQL = "(" + sTemp + ")";
                sTemp = "";
            }
            sField = "";

            // style
            sField = "style";
            sTemp = buildSearchStringFromList2(lbStyles, sField);
            if (sTemp != "")
            {
                //sStyleSQL = "style IN (" + sTemp + ")";
                sStyleSQL = "(" + sTemp + ")";
                sTemp = "";
            }
            sField = "";

            sField = "finish";
            sTemp = buildSearchStringFromList2(lbFinishes, sField);
            if (sTemp != "")
            {
                //sFinishSQL = "finish IN (" + sTemp + ")";
                sFinishSQL = "(" + sTemp + ")";
                sTemp = "";
            }
            sField = "";

            sField = "material";
            sTemp = buildSearchStringFromList2(lbMaterials, sField);
            if (sTemp != "")
            {
                //sMaterialsSQL = "material IN (" + sTemp + ")";
                sMaterialsSQL = "(" + sTemp + ")";

                sTemp = "";
            }
            sField = "";

            // origin
            sField = "origin";
            sTemp = buildSearchStringFromList2(lbOrigins, sField);
            if (sTemp != "")
            {
                //sOriginsSQL = "origin IN (" + sTemp + ")";
                sOriginsSQL = "(" + sTemp + ")";
                sTemp = "";
            }
            sField = "";

            // year manufactured
            sField = "yearManufactured";
            sTemp = buildSearchStringFromList2(lbYearManufactured, sField);
            if (sTemp != "")
            {
                //sYearManufacturedSQL = "yearManufactured IN (" + sTemp + ")";
                sYearManufacturedSQL = "(" + sTemp + ")";
                sTemp = "";
            }
            sField = "";

            // manufacturer
            sField = "manufacturer";
            sTemp = buildSearchStringFromList2(lbManufacturer, sField);
            if (sTemp != "")
            {
                //sManufacturerSQL = "manufacturer IN (" + sTemp + ")";
                sManufacturerSQL = "(" + sTemp + ")";
                sTemp = "";
            }
            sField = "";

            // type				
            if (sTypeSQL != "" && sTypeSQL != "ALL")
            {
                sSqlWhere = " Where (type = '" + sTypeSQL + "')";
            }
            else
            {
                sSqlWhere = "";
            }

            if (sCatSQL != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + sCatSQL;
                }
                else
                {
                    sSqlWhere = " Where " + sCatSQL;
                }
            }

            if (sSubCatSQL != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + sSubCatSQL;
                }
                else
                {
                    sSqlWhere = " Where " + sSubCatSQL;
                }
            }

            if (sStyleSQL != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + sStyleSQL;
                }
                else
                {
                    sSqlWhere = " Where " + sStyleSQL;
                }
            }

            if (sFinishSQL != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + sFinishSQL;
                }
                else
                {
                    sSqlWhere = " Where " + sFinishSQL;
                }
            }

            if (sMaterialsSQL != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + sMaterialsSQL;
                }
                else
                {
                    sSqlWhere = " Where " + sMaterialsSQL;
                }
            }

            if (sOriginsSQL != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + sOriginsSQL;
                }
                else
                {
                    sSqlWhere = " Where " + sOriginsSQL;
                }
            }

            if (sYearManufacturedSQL != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + sYearManufacturedSQL;
                }
                else
                {
                    sSqlWhere = " Where " + sYearManufacturedSQL;
                }
            }

            if (sManufacturerSQL != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + sManufacturerSQL;
                }
                else
                {
                    sSqlWhere = " Where " + sManufacturerSQL;
                }
            }

            // Dimensions
            if (txtHeight.Text != "")
            {
                string sHeight = "height";
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + " " + sAnd + " " + sHeight + " " + cboHeightOperator.SelectedValue + " '" + txtHeight.Text.Trim() + "'";

                }
                else
                {
                    sSqlWhere = " Where " + sHeight + " " + cboHeightOperator.SelectedValue + " '" + txtHeight.Text.Trim() + "'";
                }

            }

            if (txtWidth.Text != "")
            {
                string sWidth = "width";
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + " " + sAnd + " " + sWidth + " " + cboWidthOperator.SelectedValue + " '" + txtWidth.Text.Trim() + "'";

                }
                else
                {
                    sSqlWhere = " Where " + sWidth + " " + cboWidthOperator.SelectedValue + " '" + txtWidth.Text.Trim() + "'";
                }
            }

            if (txtDepth.Text != "")
            {
                string sDepth = "depth";
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + " " + sAnd + " " + sDepth + " " + cboDepthOperator.SelectedValue + " '" + txtDepth.Text.Trim() + "'";
                }
                else
                {
                    sSqlWhere = " Where " + sDepth + " " + cboDepthOperator.SelectedValue + " '" + txtDepth.Text.Trim() + "'";
                }
            }

            if (txtPrice.Text != "")
            {
                string sPrice1 = "price1";
                string sPrice2 = "price2";
                string sPrice3 = "price3";
                string sPrice4 = "price4";
                string sPrice5 = "price5";
                string sValue = txtPrice.Text.Trim();
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + " " + sAnd + " (" + sPrice1 + " > 0 and " + sPrice1 + " " + cboPriceOperator.SelectedValue + " " + sValue +
                        " or " + sPrice2 + " > 0 and " + sPrice2 + " " + cboPriceOperator.SelectedValue + " " + sValue +
                        " or " + sPrice3 + " > 0 and " + sPrice3 + " " + cboPriceOperator.SelectedValue + " " + sValue +
                        " or " + sPrice4 + " > 0 and " + sPrice4 + " " + cboPriceOperator.SelectedValue + " " + sValue +
                        " or " + sPrice5 + " > 0 and " + sPrice5 + " " + cboPriceOperator.SelectedValue + " " + sValue + ")";
                }
                else
                {
                    sSqlWhere = " Where (" + sPrice1 + " > 0 and " + sPrice1 + " " + cboPriceOperator.SelectedValue + " " + sValue +
                        " or " + sPrice2 + " > 0 and " + sPrice2 + " " + cboPriceOperator.SelectedValue + " " + sValue +
                        " or " + sPrice3 + " > 0 and " + sPrice3 + " " + cboPriceOperator.SelectedValue + " " + sValue +
                        " or " + sPrice4 + " > 0 and " + sPrice4 + " " + cboPriceOperator.SelectedValue + " " + sValue +
                        " or " + sPrice5 + " > 0 and " + sPrice5 + " " + cboPriceOperator.SelectedValue + " " + sValue + ")";
                }



            }

            if (txtNumLights.Text != "")
            {
                string sNumLights = "numLights";
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + " " + sAnd + " " + sNumLights + " " + cboNumLightsOperator.SelectedValue + " '" + txtNumLights.Text.Trim() + "'";
                }
                else
                {
                    sSqlWhere = " Where " + sNumLights + " " + cboNumLightsOperator.SelectedValue + " '" + txtNumLights.Text.Trim() + "'";
                }
            }

            if (txtQuantity.Text != "")
            {
                string sQuantity = "availableQuantity";
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + " " + sAnd + " " + sQuantity + " " + cboQuantityOperator.SelectedValue + " '" + txtQuantity.Text.Trim() + "'";
                }
                else
                {
                    sSqlWhere = " Where " + sQuantity + " " + cboQuantityOperator.SelectedValue + " '" + txtQuantity.Text.Trim() + "'";
                }
            }

            if (txtKeyword.Text != "")
            {
                if (sSqlWhere != "")
                {
                    sSqlWhere = sSqlWhere + sAnd + "description LIKE '%" + txtKeyword.Text.Trim() + "%'";
                }
                else
                {
                    sSqlWhere = " Where description LIKE '%" + txtKeyword.Text.Trim() + "%'";
                }
            }

            if (sSqlWhere != "")
            {
                sWhere = sSqlWhere + sAnd + sStatus;

            }
            else
            {
                sSqlWhere = " WHERE ";
                sWhere = sSqlWhere + sStatus;
            }

            string sSort = this.sort;
            //sWhere =Server.UrlEncode(sWhere)
            Session["sWhere"] = sWhere;

            //showJSMessage(sWhere.Length.ToString());

            if (Session["memberID"] != null && Session["memberID"].ToString() != "")
            {
                //Response.Redirect("chameleon-memberResults.aspx?sort=" + sSort + "&where=" + sWhere, true);
                Response.Redirect("chameleon-memberResults.aspx?Line=Custom&sort=" + sSort, true);
            }
            else
            {
                //Response.Redirect("chameleon-advancedSearchresults.aspx?sort=" + sSort + "&where=" + sWhere, true);
                Response.Redirect("chameleon-searchresults.aspx?Line=Custom&sort=" + sSort, true);
            }
            //Server.Transfer("chameleon-advancedSearchresults.aspx");


        }

        private string buildSearchStringFromList(ListBox mList)
        {
            int i;
            string sSearchString = "";
            for (i = 0; i < mList.Items.Count; i++)
            {
                if (mList.Items[i].Selected)
                {
                    sSearchString = sSearchString + "'" + mList.Items[i].Text.Trim() + "',";

                }
            }
            sSearchString = sSearchString.TrimEnd(',');
            return sSearchString;
        }

        private string buildSearchStringFromList2(ListBox mList, string sFieldName)
        {
            int i;
            string sPrefix = sFieldName + " LIKE ";
            string sSearchString = "";
            for (i = 0; i < mList.Items.Count; i++)
            {
                if (mList.Items[i].Selected)
                {
                    sSearchString = sSearchString + sPrefix + "'%" + mList.Items[i].Text.Trim() + "%' OR ";

                }
            }

            if (sSearchString != "")
                sSearchString = sSearchString.Remove(sSearchString.Length - 4, 4);
            return sSearchString;
        }

        protected void butReset_Click(object sender, System.EventArgs e)
        {
            cboType.SelectedIndex = -1;
            lbCategories.SelectedIndex = -1;
            lbSubCategories.SelectedIndex = -1;
            lbStyles.SelectedIndex = -1;
            lbFinishes.SelectedIndex = -1;
            lbMaterials.SelectedIndex = -1;
            lbOrigins.SelectedIndex = -1;
            lbYearManufactured.SelectedIndex = -1;
            lbManufacturer.SelectedIndex = -1;
            cboHeightOperator.SelectedIndex = -1;

            cboHeightOperator.SelectedIndex = -1;
            txtHeight.Text = "";
            cboWidthOperator.SelectedIndex = -1;
            txtWidth.Text = "";
            cboDepthOperator.SelectedIndex = -1;
            txtDepth.Text = "";
            cboPriceOperator.SelectedIndex = -1;
            txtPrice.Text = "";
            cboNumLightsOperator.SelectedIndex = -1;
            txtNumLights.Text = "";
            cboQuantityOperator.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtKeyword.Text = "";
            cboOrderBy.SelectedIndex = -1;
        }


        protected void butMyWorkshop_B_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-memberHome.aspx", true);
        }

        //protected void butLoginRegister_ServerClick(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    if (IsLoggedIn())
        //    {
        //        Session["memberID"] = null;
        //        Response.Redirect("chameleon-home.aspx", true);
        //    }
        //    else
        //    {
        //        Response.Redirect("chameleon-memberLogin.aspx", true);
        //    }
        //}

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


        protected void butMyProfile_B_ServerClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("chameleon-memberProfile.aspx", true);
        }
    }
}