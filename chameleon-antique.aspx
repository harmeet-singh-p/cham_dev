<%@ Page Title="Chameleon Fine Lighting Antiques" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-antique.aspx.cs" Inherits="IChameleon.chameleon_antique" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <font color="#ffffff"><font class="regularBackground" face="Arial">
        <font class="regular" size="2">At Chameleon we are committed to providing the 
        best in quality antique lighting keeping our inventory fresh, fun and never, 
        ever ordinary&nbsp;
        <br />
        <br />
        Use the QUICK LINKS below to speed your search:</font></font></font></p>
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
        <tr>
            <td align="center">
                <object height="289" width="513">
                    <param name="movie" value="flash/antique.swf" />
                    <embed height="289" src="flash/antique.swf" width="513" type ="application/x-shockwave-flash"/>
</embed>
</object>
            </td>
        </tr>
        <tr>
            <td background="images/bg_content.jpg">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="650">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="100%">
                                        <div align="center">
                                            <br />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                <asp:DataList ID="dItems" runat="server" BackColor="#f7f4ef" Font-Name="Arial" 
                    Font-Size="10pt" HorizontalAlign="Center" RepeatColumns="5" 
                    RepeatDirection="Horizontal" Width="530px">
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
<asp:Image id=Image1 runat="server" cssclass="thumbnailimage" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image1Thumb") %>'>
</asp:Image></A>
</DIV>
</ItemTemplate>
                </asp:DataList>
                                       
                                            <asp:Label ID="lblAntique" runat="server" CssClass="extraLargeGray_Label" 
                                                Text="Antique Line"></asp:Label>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td height="7" align="center">
                                            <table id="Table10" align="center" border="0" cellpadding="0" cellspacing="0" 
                                                width="85%">
                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <br />
                                                    </td>
                                                    <!-- spacer under title graphic -->
                                                </tr>
                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <div align="center">
                                                            <img alt="" src="Images/Lb-BrowseInventory.gif" /></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" height="5" width="100%">
                                                        <br />
                                                        <br />
                                                        <a href="chameleon-searchResults.aspx?Line=Antiques" 
                                                            onmouseout="fix('lbAllAntiques')" onmouseover="display('lbAllAntiques')" 
                                                            title="Browse our Line of Quality Origionals">
                                                        <img alt="" border="0" name="lbAllAntiques" 
                                                            src="Images/lbAllAntiques.gif" /></a><br />
                                                        <br />
                                                    </td>
                                                    <!-- spacer under title graphic -->
                                                </tr>
                                                <tr valign="middle">
                                                    <td valign="top" width="35%">
                                                        &nbsp;&nbsp;&nbsp;<img alt="" src="Images/Lb-Ceiling.gif" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td valign="top" width="65%">
                                                        <asp:DropDownList ID="cboCeiling" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="cboCeiling_SelectedIndexChanged" Width="175px">
                                                            <asp:ListItem>&lt; Select &gt;</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        &nbsp;&nbsp;&nbsp;<img alt="" src="Images/Lb-Wall.gif" /></td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="cboWall" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="cboWall_SelectedIndexChanged" Width="175px">
                                                            <asp:ListItem>&lt; Select &gt;</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="HEIGHT: 3px" valign="top">
                                                        &nbsp;&nbsp;&nbsp;<img alt="" src="Images/Lb-Lamps.gif" /></td>
                                                    <td style="HEIGHT: 3px" valign="top">
                                                        <asp:DropDownList ID="cboLamps" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="cboLamps_SelectedIndexChanged" Width="175px">
                                                            <asp:ListItem>&lt; Select &gt;</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        &nbsp;&nbsp;&nbsp;<img alt="" src="Images/Lb-Date.gif" /></td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="cboDate" runat="server" AutoPostBack="True" 
                                                            onselectedindexchanged="cboDate_SelectedIndexChanged" Width="175px">
                                                            <asp:ListItem Value=" "> &lt; Select &gt;</asp:ListItem>
                                                            <asp:ListItem Value="This Week">This Week</asp:ListItem>
                                                            <asp:ListItem Value="Last Week">Last Week</asp:ListItem>
                                                            <asp:ListItem Value="Last Month">Last Month</asp:ListItem>
                                                            <asp:ListItem Value="Last 2 Months">Last 2 Months</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="regulargray">
                                        <p align="center">
                                            &nbsp;</p>
                                    </td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <img height="6" src="images/bg_content_bottom.jpg" 
                    width="513" /></td>
        </tr>
    </table>
</asp:Content>
