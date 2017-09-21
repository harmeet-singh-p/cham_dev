<%@ Page Title="Chameleon Fine Lighting Member Results" Language="C#" MasterPageFile="~/chameleonMaster.Master" AutoEventWireup="true" CodeBehind="chameleon-memberResults.aspx.cs" Inherits="IChameleon.chameleon_memberResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <font color="#ffffff"><font class="regularBackground" face="Arial">
        <font class="regular" size="2"><font class="regularBackground" face="Arial">
        <font class="regular" size="2">Any of the items in the Search Results at right 
        can be added to a My Workshop Portfolio.&nbsp;
        <br />
        <br />
        <br />
        Use the QUICK LINKS below to speed your search:<br />
        </font></font></font></font></font>
    </p>
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="searchTable" align="center" style="border: thin solid #000000; background-color: #F7F4EF; width: 1500px;">
    <tr>
        <td align="center">
            <asp:Image ID="Image3" runat="server" ImageAlign="Middle" 
                    ImageUrl="Images/title_searchresults.jpg" />
        </td>
    </tr>
    <tr>
        <td align="center">
            <br />
            <asp:Label ID="lbSearchHeading" runat="server" CssClass="regulargray_Label" 
                    Height="5px" Width="345px"></asp:Label>
            <br />
        </td>
    </tr>
    <tr>
        <td align="center">
            <br />
            <table width="300">
                <tr>
                    <td align="center">
                        <asp:Label ID="lbSortBy" runat="server" CssClass="regulargray_Label" 
                                Height="5px">Sort By</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="True" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center" class="regulargray">
            <br />
            <asp:PlaceHolder ID="phTopNav" runat="server"></asp:PlaceHolder>
            <br />
        </td>
    </tr>
    <tr>
        <td align="center">
            <br />
            <asp:Label ID="lbInfo" runat="server" CssClass="largeGray_Label" 
                    Font-Names="Arial" Height="22px" Width="345px">Click Image below to Display Details </asp:Label>
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList ID="dItems" runat="server" BackColor="#F7F4EF" Font-Name="Arial" 
                    Font-Size="10pt" HorizontalAlign="Center" 
                    OnItemDataBound="dItems_ItemDataBound" RepeatColumns="4" 
                    RepeatDirection="Horizontal" Width="1500px" CssClass="">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                    <ItemTemplate>
                    <div align="center" class="contentTable2">
    <asp:Label ID="lbStatus" runat="server" CssClass="regularGray"></asp:Label>
    <br />
    <a title="Click on Image to View Details" href='javascript:viewItemWin("chameleon-viewItem.aspx?item=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "item").ToString())%>&itemID=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "itemCode").ToString())%>")'>
<asp:Image id="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image1") %>'>
</asp:Image></a><br>
<b><font class="regulargray">
<%# DataBinder.Eval(Container.DataItem, "itemCode") %><br />
<%# DataBinder.Eval(Container.DataItem, "item") %>
</font></b>
                        &nbsp;<b><font class="regulargray"><br />
                        <asp:HyperLink ID="hlAddItem" runat="server" CssClass="regulargray" 
                            NavigateUrl='<%# "chameleon-memberAddItem.aspx?item=" + DataBinder.Eval(Container.DataItem, "item").ToString() + "&" + "itemCode=" + DataBinder.Eval(Container.DataItem, "itemCode").ToString() + "&" + "status=" + DataBinder.Eval(Container.DataItem, "status").ToString() %>'>Add To Portfolio</asp:HyperLink>
                        <br /> <br />
                        </font></b></div>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br /><br />
                </SeparatorTemplate>
            </asp:DataList>
        </td>
    </tr>
    <tr>
        <td align="center" class="regulargray">
            <asp:PlaceHolder ID="phBottomNav" runat="server"></asp:PlaceHolder>
            <br />
        </td>
    </tr>
    <tr>
        <td align="center" class="regulargray">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="regulargray">
            <table align="center" class="style4">
                <tr>
                    <td align="left" class="style5" colspan="2">
                <font __designer:mapid="1aa" color="#ffffff"><font __designer:mapid="1ab" 
                    class="regularBackground" face="Arial">
                        <font __designer:mapid="1ac" 
                    class="regulargray" size="2">
                        If you wish to save this search for future use in My Workshop, enter a name in 
                        the textbox below and click &#39;Save Search&#39;.</font></font></font></td>
                </tr>
                <tr>
                    <td>
                <font __designer:mapid="1ae" color="#ffffff"><font __designer:mapid="1af" 
                    class="regularBackground" face="Arial"><font __designer:mapid="1b0" 
                    class="regular" size="2">
                <asp:TextBox ID="txtQueryName" runat="server" 
                    Width="90px"></asp:TextBox>
                </font></font></font>
                    </td>
                    <td>
                <font __designer:mapid="1b2" color="#ffffff"><font __designer:mapid="1b3" 
                    class="regularBackground" face="Arial"><font __designer:mapid="1b4" 
                    class="regular" size="2">
                <asp:Button ID="butSaveQuery" runat="server" 
                    BackColor="WhiteSmoke" BorderStyle="Outset" Font-Names="Arial" 
                    Font-Size="XX-Small" ForeColor="#404040" onclick="butSaveQuery_Click" 
                    Text="Save Search" Width="70px" />
                </font></font></font>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center" class="regulargray">
            <font color="#ffffff"><font class="regularBackground" face="Arial">
            <font class="regular" size="2">
            <asp:Label ID="lbQueryInfo" runat="server" CssClass="regulargray"></asp:Label>
            </font></font></font></td>
    </tr>
</table>
    <table align="center" width="700">
    <tr>
        <td align ="center" colspan ="1"><a data-pin-do="buttonBookmark" href="https://www.pinterest.com/pin/create/button/"></a></td>
        
       
    </tr>
</table>
     <script    type="text/javascript"
                 async defer data-pin-hover="true"
                src="//assets.pinterest.com/js/pinit.js"></script>
 
    <script type = "text/javascript">

     function validateQuery() {

         var textbox = document.getElementById("<%=txtQueryName.ClientID%>");
         if (textbox.value == '') {
             alert('search name is required')
             textbox.focus();
             return false;
         }
         else {
             return true;
         }

     }

    </script> 
</asp:Content>
