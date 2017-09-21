<%@ Page Title="Chameleon Fine Lighting Recent Arrivals" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-recentArrivals.aspx.cs" Inherits="IChameleon.chameleon_recentArrivals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <font color="#ffffff"><font class="regularBackground" face="Arial">
        <font class="regular" size="2">At Chameleon Fine Lighting we reaffirm our 
        commitment every day to providing the best in antique and replica 
        lighting.keeping our inventory always fresh, always fun, and never, ever 
        ordinary.
        <br />
        <br />
        Our inventory changes daily, so check this page regularly for our most recently 
        acquired items.&nbsp;
        <br />
        <br />
        Use the QUICK LINKS below to speed your search:<br />
        </font></font></font>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="maxTable">
        <tr>
            <td align="center">
                <img alt="" src="Images/lbTasteOfNew.gif" align="middle" /></td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="dItems" runat="server" BackColor="#f7f4ef" Font-Name="Arial" 
                    Font-Size="10pt" HorizontalAlign="Center" RepeatColumns="3" 
                    RepeatDirection="Horizontal" Width="400px">
                    <HeaderTemplate>
                        <div align="center">
                            &nbsp;</div>
                    </HeaderTemplate>
                    <FooterTemplate>
                        <div align="center">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </FooterTemplate>
                    <ItemTemplate>
<DIV align="center"><A title="Click on Image to View Details" href='javascript:viewItemWin("chameleon-viewItem.aspx?item=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "item").ToString())%>&amp;itemID=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "itemCode").ToString())%>")'>
<asp:Image id=Image1 runat="server" cssclass="thumbnailimage" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image1") %>'>
</asp:Image></A><BR>
<B><FONT class="regulargray">
<%# DataBinder.Eval(Container.DataItem, "itemCode") %>
</FONT></B>
<BR>
<%--<asp:HyperLink id=hlAddItem runat="server" NavigateUrl='<%# "chameleon-memberAddItem.aspx?item=" + DataBinder.Eval(Container.DataItem, "item").ToString() + "&amp;" + "itemCode=" + DataBinder.Eval(Container.DataItem, "itemCode").ToString() + "&" + "status=" + DataBinder.Eval(Container.DataItem, "status").ToString() %>' CssClass="regularGray">Add To Portfolio</asp:HyperLink><BR>--%>
<asp:HyperLink ID="hlAddItem" runat="server" CssClass="regulargray" 
                            NavigateUrl='<%# "chameleon-memberAddItem.aspx?item=" + DataBinder.Eval(Container.DataItem, "item").ToString() + "&" + "itemCode=" + DataBinder.Eval(Container.DataItem, "itemCode").ToString() + "&" + "status=" + DataBinder.Eval(Container.DataItem, "status").ToString() %>'>Add To Portfolio</asp:HyperLink>
<BR>
</DIV>
</ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
     <script
    type="text/javascript"
    async defer data-pin-hover="true"
    src="//assets.pinterest.com/js/pinit.js"
></script>
</asp:Content>
