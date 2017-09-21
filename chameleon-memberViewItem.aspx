<%@ Page Title="Chameleon Fine Lighting Member View Item" Language="C#" MasterPageFile="~/mContentWhite.Master" AutoEventWireup="true" CodeBehind="chameleon-memberViewItem.aspx.cs" Inherits="IChameleon.chameleon_memberViewItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

a.regulargray:link
{
	font-family:Arial, Helvetica, sans-serif;
	font-size: 11px;
	color: #666666;
	line-height: 14px;
}

.regulargray
{
	font-family:Arial, Helvetica, sans-serif;
	font-size: 11px;
	color: #666666;
	line-height: 14px;
}
        .auto-style1 {
            width: 500px;
            height: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center" align="center">
        <table align="center">
            <tr>
                <td style="TEXT-ALIGN: center">
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                        <table ID="Table1" align="center" border="0" cellPadding="1" cellSpacing="1" 
                            width="780">
                            <tbody>
                                <tr>
                                    <td style="TEXT-ALIGN: center">
                                        &nbsp;<img src="Images/viewItem_noAddress_500.jpg" alt="Chameleon Fine Lighting" class="auto-style1" /></td>
                                </tr>
                                <tr>
                                    <td style="TEXT-ALIGN: center">
                                        <br />
                                        &nbsp;<asp:Image ID="Image1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 18px; text-align: center">
                                        <br />
                                        <asp:Label ID="lbItem" runat="server" Font-Bold="True" Font-Names="Arial" 
                                            Font-Size="Smaller"></asp:Label>
                                        &nbsp;<asp:Label ID="lbItemClass" runat="server" Font-Bold="True" Font-Names="Arial" 
                                            Font-Size="Smaller"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="TEXT-ALIGN: center">
                                        <asp:Label ID="lbItemNo" runat="server" Font-Bold="True" Font-Names="Arial" 
                                            Font-Size="Smaller" Width="40px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="TEXT-ALIGN: center">
                                        <asp:Label ID="lbShownFinish" runat="server" Font-Bold="True" 
                                            Font-Names="Arial" Font-Size="Smaller" Width="688px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="HEIGHT: 25px; TEXT-ALIGN: center">
                                        <img height="1" 
                src="Images/div.jpg" width="400" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="6" style="TEXT-ALIGN: center">
                                        <asp:Label ID="lbDescription" runat="server" CssClass="regularblack" 
                                            Font-Names="Arial" Height="16px" Width="688px"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="TEXT-ALIGN: center">
                                        <br />
                                        <asp:Label ID="lbSale" runat="server" CssClass="regularRed"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="TEXT-ALIGN: center">
                                        <table ID="Table3" align="center" border="0" bordercolor="#000000" 
                                            cellspacing="3" width="680">
                                            <tbody>
                                                <tr>
                                                    <td align="center">
                                                        <table ID="Table4" border="0" width="675">
                                                            <tbody>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <div align="left">
                                                                            <table ID="Table2" align="center" border="0" cellpadding="1" cellspacing="1">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="HEIGHT: 13px">
                                                                                            <asp:Label ID="lbStatusLb" runat="server" CssClass="regulargray_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="64px">Lead 
                                                                                            Time:</asp:Label>
                                                                                        </td>
                                                                                        <td style="HEIGHT: 13px">
                                                                                            <asp:Label ID="lbAvailability" runat="server" CssClass="regularblack_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" Width="65px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lbQuantLB" runat="server" CssClass="regulargray_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="56px">Avail. 
                                                                                            Qty:</asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lbAvailQty" runat="server" CssClass="regularblack_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" Width="40px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                            <font face="Arial" size="2"></font>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                    <td valign="top">
                                                                        &nbsp;</td>
                                                                    <td valign="top">
                                                                        <table ID="Table9" align="center" border="0" cellpadding="1" cellspacing="1">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="HEIGHT: 14px">
                                                                                        <asp:Label ID="lbPrice" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="100px">Retail 
                                                                                        Pricing</asp:Label>
                                                                                    </td>
                                                                                    <td style="HEIGHT: 14px">
                                                                                        <asp:Label ID="lbBasePrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Width="100px"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lbBrass" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                                                                            Width="42px">Brass:</asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <span>
                                                                                        <asp:Label ID="lbBrassPrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Visible="False" Width="100px"></asp:Label>
                                                                                        </span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lbNickel" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                                                                            Width="40px">Nickel:</asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <span>
                                                                                        <asp:Label ID="lbNickelPrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Visible="False" Width="100px"></asp:Label>
                                                                                        </span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lbSilver" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                                                                            Width="40px">Silver:</asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <span>
                                                                                        <asp:Label ID="lbSilverPrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Visible="False" Width="100px"></asp:Label>
                                                                                        </span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lbGold" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                                                                            Width="40px">Gold:</asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <span>
                                                                                        <asp:Label ID="lbGoldPrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Visible="False" Width="100px"></asp:Label>
                                                                                        </span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="HEIGHT: 18px">
                                                                                        <asp:Label ID="lbPatinated" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                                                                            Width="40px">Patinated:</asp:Label>
                                                                                    </td>
                                                                                    <td style="HEIGHT: 18px">
                                                                                        <asp:Label ID="lbPatinatedPrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Visible="False" Width="100px"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lbSilverLeaf" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                                                                            Width="64px">Silver Leaf:</asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lbSilverLeafPrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Visible="False" Width="100px"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lbGoldLeaf" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                                                                            Width="62px">Gold Leaf:</asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lbGoldLeafPrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Visible="False" Width="100px"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lbLeafed" runat="server" CssClass="regulargray_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                                                                            Width="62px">Leafed:</asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lbLeafedPrice" runat="server" CssClass="regularblack_Label" 
                                                                                            Font-Names="Arial" Font-Size="11px" Visible="False" Width="100px"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td valign="top">
                                                                        &nbsp;</td>
                                                                    <td valign="top">
                                                                        <div align="right">
                                                                            <table ID="Table10" align="center" border="0" cellpadding="1" cellspacing="1">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="HEIGHT: 12px">
                                                                                            <asp:Label ID="lbBulbsLb" runat="server" CssClass="regulargray_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="50px">Bulb(s):</asp:Label>
                                                                                        </td>
                                                                                        <td style="HEIGHT: 12px">
                                                                                            <span>
                                                                                            <asp:Label ID="lbBulbs" runat="server" CssClass="regularblack_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" Width="121px"></asp:Label>
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lbDimLb" runat="server" CssClass="regulargray_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="105px">Fixture 
                                                                                            Dimen (in.):</asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lbDimensions" runat="server" CssClass="regularblack_Label" 
                                                                                                Font-Bold="True" Font-Names="Arial" Font-Size="11px" Width="125px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lbTotalDropLb" runat="server" CssClass="regulargray_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="105px">Overall 
                                                                                            Drop (in.):</asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lbTotalDrop" runat="server" CssClass="regularblack_Label" 
                                                                                                Font-Bold="True" Font-Names="Arial" Font-Size="11px" Width="125px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lbBackplateLb" runat="server" CssClass="regulargray_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="105px">Backplate 
                                                                                            (in.):</asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lbBackplate" runat="server" CssClass="regularblack_Label" 
                                                                                                Font-Names="Arial" Font-Size="11px" Width="125px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:Image ID="imageUL" runat="server" Height="25px" 
                                                                                                ImageUrl="http://www.chameleon59.com/Images/UL.gif" Width="25px" />
                                                                                        </td>
                                                                                        <td>
                                                                                            &nbsp;<asp:Label ID="lbULRatingLb" runat="server" CssClass="regulargray" 
                                                                                                Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="111px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                            <p align="center">
                                                                                                &nbsp;</p>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        &nbsp;&nbsp;&nbsp;</td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                    <table style="width: 100%;">
                        <tr>
                            <td width="33%">
                                &nbsp;</td>
                            <td align="center" width="33%">
                                <asp:Button ID="btnViewPDf" runat="server" onclick="btnViewPDf_Click" 
                                    Text="View Tearsheet" />
                                <asp:Button ID="butEmail" runat="server" onclick="butEmail_Click" 
                                    style="height: 26px" Text="Email Tearsheet" />
                            </td>
                            <td align="center" width="33%">
                                <a class="regulargray" 
                                    href="http://www.adobe.com/products/acrobat/readstep2.html" target="_blank">
                                <img border="0" src="Images/adobe_link_image.bmp" /></a></td>
                        </tr>
                    </table>
                </td>
                <td style="HEIGHT: 587px; TEXT-ALIGN: center" valign="top">
                    <div style="TEXT-ALIGN: center">
                        <table style="WIDTH: 100px; HEIGHT: 110px" align="center">
                            <tr style="line-height: 15px" valign="bottom">
                                <td align="center" height="15" style="width: 90px" valign="bottom">
                                    <asp:Label ID="lbFinishTypes" runat="server" BorderStyle="None" 
                                        Font-Bold="True" Font-Names="Arial" Font-Size="10pt" ForeColor="#666666" 
                                        Height="15px" Text="Finish Types" Width="90px"></asp:Label>
                                </td>
                                <td align="right" height="15" valign="bottom" width="15">
                                    <a id="ibIconInfo" runat="server" 
                                        href="javascript:openMediumWin('chameleon-finishInfo.aspx')">
                                    <img align="middle" border="none" height="15" hspace="0" 
                                        src="Images/icon_info.gif" vspace="0" width="15" /></a>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table width="125">
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:HyperLink ID="hlBrass" runat="server" Visible="False">[hlBrass]</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px; HEIGHT: 14px">
                                <asp:Label ID="lbBrassImage" runat="server" CssClass="regulargray_Label" 
                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                    Width="64px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:HyperLink ID="hlNickel" runat="server" Visible="False">[hlNickel]</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px; HEIGHT: 17px">
                                <asp:Label ID="lbNickelImage" runat="server" CssClass="regulargray_Label" 
                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                    Width="64px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:HyperLink ID="hlSilver" runat="server" Visible="False">[hlSilver]</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px; HEIGHT: 14px">
                                <asp:Label ID="lbSilverImage" runat="server" CssClass="regulargray_Label" 
                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                    Width="64px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:HyperLink ID="hlGold" runat="server" Visible="False">[hlGold]</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:Label ID="lbGoldImage" runat="server" CssClass="regulargray_Label" 
                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                    Width="64px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:HyperLink ID="hlPatinated" runat="server" Visible="False">[hlPatinated]</asp:HyperLink>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:Label ID="lbPatinatedImage" runat="server" CssClass="regulargray_Label" 
                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                    Width="64px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:HyperLink ID="hlSilverLeaf" runat="server" Visible="False">[hlSilverLeaf]</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px; HEIGHT: 14px">
                                <asp:Label ID="lbSilverLeafImage" runat="server" CssClass="regulargray_Label" 
                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                    Width="64px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:HyperLink ID="hlGoldLeaf" runat="server" Visible="False">[hlGoldLeaf]</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:Label ID="lbGoldLeafImage" runat="server" CssClass="regulargray_Label" 
                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                    Width="64px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 95px">
                                <asp:HyperLink ID="hlLeafed" runat="server" Visible="False">[hlLeafed]</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 95px">
                                <asp:Label ID="lbLeafedImage" runat="server" CssClass="regulargray_Label" 
                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Visible="False" 
                                    Width="64px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="WIDTH: 95px">
                                <asp:HyperLink ID="hlFinishes" runat="server" CssClass="regulargray_Label" 
                                    NavigateUrl="~/chameleon-finishes.aspx" Target="_blank" Visible="False">More Finishes</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
         <script
    type="text/javascript"
    async defer data-pin-hover="true"
    src="//assets.pinterest.com/js/pinit.js"
></script>
    </div>
</asp:Content>
