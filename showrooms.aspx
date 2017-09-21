<%@ Page Title="" Language="C#" MasterPageFile="~/chameleonMaster.Master" AutoEventWireup="true" CodeBehind="showrooms.aspx.cs" Inherits="IChameleon.showrooms" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div>
       <br />
       <br />
       <br />
       <br />       
       <asp:Table ID="Table1" runat="server" CssClass="infoTable">
           
           <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="4" >Chameleon is proud to have our Signature Line represented in the following fine showrooms:</asp:TableHeaderCell>
           </asp:TableHeaderRow> 
           <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
           <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    Chameleon/Nesle<br />
                    38-15 30th Street<br />
                    Long Island City, NY  11101<br />
                    212-355-6300<br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.chameleonhome.com" ForeColor="White">www.chameleonhome</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.nesleinc.com" ForeColor="White">www.nesleinc.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="https://www.google.com/maps/place/38-15+30th+St,+Queens,+NY+11101/@40.7536678,-73.9350924,17z/data=!3m1!4b1!4m5!3m4!1s0x89c25f2c62f8ff59:0x1eb3f9db170e4b2e!8m2!3d40.7536678!4d-73.9329037" ForeColor="White">Map</asp:HyperLink>

                </asp:TableCell>                
                <asp:TableCell HorizontalAlign="Center">
                    Edward Ferrell + Lewis Mittman<br />
                    D &amp; D Building<br />
                    979 Third Avenue, Suite #903<br />
                    New York, NY 10022<br />
                    212-758-5000<br />
                    <asp:HyperLink ID="hlEFLM" runat="server" NavigateUrl="http://www.ef-lm.com" ForeColor="White">www.ef-lm.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink18" runat="server" ForeColor="White" 
                        NavigateUrl="https://www.google.com/maps/place/979+3rd+Ave,+New+York,+NY+10022/@40.7609388,-73.9664562,17z/data=!4m2!3m1!1s0x89c258e5bde7cfcf:0xb4f23dbb12b74209" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    Webster and Company<br />
                    Boston Design Center<br />
                    One Design Ctr. Place #242<br />
                    Boston, MA 02210<br />
                    617-261-9660<br />
                    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="http://www.webstercompany.com" ForeColor="White">www.webstercompany.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink16" runat="server" ForeColor="White" 
                        NavigateUrl="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=One+Design+Center+Place,+Boston,+MA+02210&amp;sll=42.344185,-71.034111&amp;sspn=0.010943,0.015514&amp;ie=UTF8&amp;z=16&amp;iwloc=A" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    J. Lambeth and Co.<br />
                    Washington Design Center<br />
                    300 D Street SW, Suite 117<br />
                    Washington, D.C.&nbsp; 20024<br />
                    202-646-1774<br />
                    <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="http://www.jlambeth.com" ForeColor="White">www.jlambeth.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink14" runat="server" ForeColor="White" 
                        NavigateUrl="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=300+D+Street+SW,+Washington,+D.C.+20024&amp;sll=42.344185,-71.034111&amp;sspn=0.010943,0.015514&amp;ie=UTF8&amp;z=16&amp;iwloc=A" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>                
                <asp:TableCell HorizontalAlign="Center">
                    Grizzel and Mann<br />
                    Atlanta Decorative Arts Center (ADAC)<br />
                    351 Peachtree Hills Avenue, Suite 120<br />
                    Atlanta, GA &nbsp;30305<br />
                    404-261-5932<br />
                    <asp:HyperLink ID="hlGrizzelandMann" runat="server" NavigateUrl="http://www.grizzelandmann.com" ForeColor="White">www.grizzelandmann.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink13" runat="server" ForeColor="White" 
                        NavigateUrl="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=351+Peachtree+Hills+Ave.,+Atlanta,+GA+%C2%A030305&amp;sll=40.761203,-73.96554&amp;sspn=0.011182,0.015514&amp;ie=UTF8&amp;z=16&amp;iwloc=A" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    J. Nelson<br />
                    2866 Pershing Street<br />
                    Hollywood, FL 33020<br />
                    954-929-8880<br />
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.jnelsoninc.com" ForeColor="White">www.jnelsoninc.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink15" runat="server" ForeColor="White" 
                        NavigateUrl="https://maps.google.com/maps?q=2866+Pershing+Street,+Hollywood,+FL+33020&hl=en&sll=26.062636,-80.160925&sspn=0.006496,0.007339&hnear=2866+Pershing+St,+Hollywood,+Florida+33020&t=m&z=17&iwloc=A" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    Gregory Alonso, Inc.<br />
                    Ohio Design Centre<br />
                    23533 Mercantile Road, Suite 113<br />
                    Beachwood, OH&nbsp; 44122<br />
                    216-765-1810<br />
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://www.gregoryalonsoinc.com" ForeColor="White">www.gregoryalonsoinc.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink17" runat="server" ForeColor="White" 
                        NavigateUrl="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=23533+Mercantile+Road,+Beachwood,+OH+44122&amp;sll=41.459968,-81.50932&amp;sspn=0.011064,0.015514&amp;ie=UTF8&amp;z=16" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    Edward Ferrell and Lewis Mittman<br />
                    222 Merchandise Mart Suite 1483<br />
                    Chicago, IL 60654<br />
                    (312) 822-9966<br />
                    <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="White" NavigateUrl="http://www.Ef-lm.com">www.Ef-lm.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink19" runat="server" ForeColor="White" 
                        NavigateUrl="https://www.google.com/maps/place/222+W+Merchandise+Mart+Plaza/@41.8883695,-87.6353645,17z/data=!4m2!3m1!1s0x880e2cb6fb232d35:0xc56ee978a2facb75" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
            </asp:TableRow>            
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    ID Collection&nbsp;Dallas<br />
                    1025 N. Stemmons Fwy,&nbsp; #745<br />
                    Dallas, TX&nbsp; 75207<br />
                    214-698-0226<br />
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="http://www.interiordesigncollection.com" ForeColor="White">www.interiordesigncollection.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink20" runat="server" ForeColor="White" 
                        NavigateUrl="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=1025+N.+Stemmons+Fwy,+Dallas,+TX+75207&amp;sll=34.081544,-118.382685&amp;sspn=0.012263,0.015514&amp;ie=UTF8&amp;z=16&amp;iwloc=A" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    ID Collection&nbsp;Houston<br />
                    5120 Woodway,&nbsp; #4001<br />
                    Houston, TX&nbsp; 77056<br />
                    713-623-2344<br />
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="http://www.interiordesigncollection.com" ForeColor="White">www.interiordesigncollection.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink21" runat="server" ForeColor="White" 
                        NavigateUrl="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=5120+Woodway,+Houston,+TX+77056&amp;sll=32.788411,-96.813519&amp;sspn=0.012447,0.015514&amp;ie=UTF8&amp;z=17&amp;iwloc=A" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    Thomas Lavin<br />
                    Pacific Design Center (PDC)<br />
                    8687 Melrose Ave #B310<br />
                    West Hollywood, CA&nbsp; 90069<br />
                    310-278-2456<br />
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="http://www.thomaslavin.com" ForeColor="White">www.thomaslavin.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink22" runat="server" ForeColor="White" 
                        NavigateUrl="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=8687+Melrose+Avenue,+West+Hollywood,+CA+90069&amp;sll=37.0625,-95.677068&amp;sspn=47.704107,63.544922&amp;ie=UTF8&amp;z=16&amp;iwloc=A" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    Hadleigh Home<br />
                    SFDC, Galleria 245<br />
                    San Francisco, CA  94103<br />
                    415-863-8815<br />
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="http://www.hadleighhome.com" ForeColor="White">www.hadleighhome.com</asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink23" runat="server" ForeColor="White" 
                        NavigateUrl="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=101+Henry+Adams,+San+Francisco,+CA+94103&amp;sll=41.459968,-81.50932&amp;sspn=0.011064,0.015514&amp;ie=UTF8&amp;z=16&amp;iwloc=A" 
                        Target="_blank">Map</asp:HyperLink>
                </asp:TableCell>                
            </asp:TableRow>  
           <asp:TableRow><asp:TableCell><asp:LinkButton runat="server" PostBackUrl="~/chameleon-viewReport.aspx" CssClass="styLinkBtn">Price List</asp:LinkButton></asp:TableCell>

           </asp:TableRow>         
        </asp:Table>
   </div>
    
    
    

</asp:Content>
