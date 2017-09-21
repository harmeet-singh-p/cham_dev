using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Drawing;
using RocknCode.RocknCodeLib;

namespace IChameleon
{
    public partial class chameleon_viewItemDetail : System.Web.UI.Page
    {
        # region DECS


        # endregion

        protected void Page_Init(object sender, EventArgs e)
        {

            mImage img = null;
            int itemID = 0;
            string reportPath = String.Empty;
            string imagePath = String.Empty;
            string imageName = String.Empty;
            string mappedImage = string.Empty;

            bool inTrade;
            int hTwips = 0;
            int vTwips = 0;
            int i = 0; //index for substring
            ReportDocument rptDoc;
            ParameterDiscreteValue val1;
            ParameterDiscreteValue val2;
            ParameterDiscreteValue val3;
            ParameterDiscreteValue val4;

            try
            {

                //itemID = Convert.ToInt32(Request.QueryString["itemID"].ToString());
                //imagePath = Request.QueryString["image1"].ToString();

                //itemID = 356;
                //imagePath = @"http://www.chameleon59.com/Images/Products/cha005.jpg";

                itemID = Convert.ToInt32(Context.Items["itemID"]);
                imagePath = @Context.Items["image1"].ToString();

                reportPath = Server.MapPath(@"Reports\Product_Tearsheet.rpt");

                i = imagePath.LastIndexOf('/');
                imageName = imagePath.Substring(i + 1);

                mappedImage = Server.MapPath(@"Images\Products\" + imageName);

                img = new mImage(mappedImage, mMain.defaultImage);

                inTrade = Convert.ToBoolean(@Context.Items["inTrade"].ToString());

                getImageSizeInTwips(img.Image, out hTwips, out vTwips);

                //printDetailReport(reportPath, itemID, hTwips, vTwips, inTrade);                                    


                //try
                //{
                rptDoc = new ReportDocument();
                rptDoc.Load(reportPath);

                // need for web report
                //rptDoc.DataSourceConnections[0].SetConnection(");
                rptDoc.DataSourceConnections[0].SetConnection(@"tcp:chamsql1.database.windows.net,1433", "chameleon59", "sqlAdmin@chamsql1", "jurassicM39");

                val1 = new ParameterDiscreteValue();
                val2 = new ParameterDiscreteValue();
                val3 = new ParameterDiscreteValue();
                val4 = new ParameterDiscreteValue();

                val1.Value = itemID;
                val2.Value = hTwips;
                val3.Value = vTwips;
                val4.Value = inTrade;

                rptDoc.SetParameterValue(0, val1);
                rptDoc.SetParameterValue(1, val2);
                rptDoc.SetParameterValue(2, val3);
                rptDoc.SetParameterValue(3, val4);

                //rptDoc.Load(Server.MapPath(@"Reports\cr2.rpt"));
                System.IO.Stream oStream = null;
                byte[] byteArray = null;

                oStream = rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rptDoc.Close();
                rptDoc.Dispose();

                //rptDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");

            }
            catch (Exception ex)
            {
                // log error
                string error = ex.Message.ToString();
                Server.Transfer("chameleon-error.aspx?errMsg=" + error, false);
            }
            finally
            {


            }

        }

        private void getImageSizeInTwips(System.Drawing.Image i, out int hSz, out int vSz)
        {
            hSz = 0;
            vSz = 0;
            Graphics g;
            int hPixelsPerInch = 0;
            int vPixelsPerInch = 0;
            int hTwipsPerPixel = 0;
            int vTwipsPerPixel = 0;

            try
            {
                g = Graphics.FromHwnd(IntPtr.Zero);
                hPixelsPerInch = (int)g.DpiX;
                vPixelsPerInch = (int)g.DpiY;

                hTwipsPerPixel = 1440 / hPixelsPerInch;
                vTwipsPerPixel = 1440 / vPixelsPerInch;

                hSz = hTwipsPerPixel * i.Width;
                vSz = vTwipsPerPixel * i.Height;

            }
            catch (Exception ex)
            {
                // log error
                string error = ex.Message.ToString();
                Server.Transfer("chameleon-error.aspx?errMsg=" + error, false);
            }


        }

        private void printDetailReport(string rptPath, int id, int width, int height, bool isTrade)
        {
            ReportDocument rptDoc;
            ParameterDiscreteValue val1;
            ParameterDiscreteValue val2;
            ParameterDiscreteValue val3;
            ParameterDiscreteValue val4;


            //try
            //{
            rptDoc = new ReportDocument();
            rptDoc.Load(rptPath);

            // need for web report
            rptDoc.DataSourceConnections[0].SetConnection(@"206.123.73.74,14005", "chameleon59", "chamWeb", "Seven09Zx7M2");

            val1 = new ParameterDiscreteValue();
            val2 = new ParameterDiscreteValue();
            val3 = new ParameterDiscreteValue();
            val4 = new ParameterDiscreteValue();

            val1.Value = id;
            val2.Value = width;
            val3.Value = height;
            val4.Value = isTrade;

            rptDoc.SetParameterValue(0, val1);
            rptDoc.SetParameterValue(1, val2);
            rptDoc.SetParameterValue(2, val3);
            rptDoc.SetParameterValue(3, val4);

            rptDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");


            //}
            //catch (Exception ex)
            //{
            //   // throw new Exception(ex.Message);
            //}
            //finally
            //{
            //    //val1 = null;
            //    //val2 = null;
            //    //val3 = null;
            //    //val4 = null;
            //    //rptDoc = null;

            //}

        }
    }
}