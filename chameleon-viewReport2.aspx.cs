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
    public partial class chameleon_viewReport2 : System.Web.UI.Page
    {
        # region DECS


        # endregion

        protected void Page_Init(object sender, EventArgs e)
        {

           
            string reportPath = String.Empty;
           

            bool isTrade_Param;
           
            ReportDocument rptDoc;
           
            ParameterDiscreteValue val4;

            try
            {
                             
               
                              

                reportPath = Server.MapPath(@"Reports\Product_Tearsheet.rpt");

                
                isTrade_Param = true;

              
                rptDoc = new ReportDocument();
                rptDoc.Load(reportPath);

                // need for web report
                rptDoc.DataSourceConnections[0].SetConnection(string.Empty, string.Empty, string.Empty, string.Empty);

               
                val4 = new ParameterDiscreteValue();

               
                val4.Value = true;

                
                rptDoc.SetParameterValue(0, isTrade_Param);

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

       
       


        private void printDetailReport(string rptPath, bool isTrade_Param)  //, int id, int width, int height,
        {
            ReportDocument rptDoc;
            
            ParameterDiscreteValue val4;


           
            rptDoc = new ReportDocument();
            rptDoc.Load(rptPath);

            // need for web report
            rptDoc.DataSourceConnections[0].SetConnection(string.Empty, string.Empty, string.Empty, string.Empty);            

          
            val4 = new ParameterDiscreteValue();

            val4.Value =  true;

           
            rptDoc.SetParameterValue(0, isTrade_Param);

            rptDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");


           

        }
    }
}