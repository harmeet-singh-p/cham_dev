<%@ Page Title="Chameleon Fine Lighting Sale" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-sale.aspx.cs" Inherits="IChameleon.chameleon_sale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="maxTable">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" CssClass="extraLargeGray_Label" 
                    Text="Inventory Clearance "></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="dItems" runat="server" BackColor="#f7f4ef" Font-Name="Arial" 
                    Font-Size="10pt" HorizontalAlign="Center" RepeatColumns="3" 
                    RepeatDirection="Horizontal" Width="400px" 
                    onitemdatabound="dItems_ItemDataBound">
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
                        <DIV align="center">
                            <A title="Click on Image to View Details" href='javascript:viewItemWin("chameleon-viewItem.aspx?item=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "item").ToString())%>&amp;itemID=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "itemCode").ToString())%>")'>
                                <asp:Image id=Image1 runat="server" cssclass="thumbnailimage" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image1Thumb") %>'>
                                </asp:Image>
                            </A>
                            <BR>
                                <B><FONT class="regulargray"><%# DataBinder.Eval(Container.DataItem, "itemCode") %>
                                    </FONT></B>
                                <BR>
                                    <asp:HyperLink id=hlAddItem runat="server" NavigateUrl='<%# "chameleon-memberAddItem.aspx?item=" + DataBinder.Eval(Container.DataItem, "item").ToString() + "&amp;" + "itemCode=" + DataBinder.Eval(Container.DataItem, "itemCode").ToString() + "&amp;" + "status=" + DataBinder.Eval(Container.DataItem, "status").ToString() %>' CssClass="regularGray">Add To Portfolio</asp:HyperLink>
                                    <BR>
                                        <BR>
                        </DIV>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lbInfo" runat="server" CssClass="regularRed"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
