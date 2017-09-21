<%@ Page Title="Chameleon Fine Lighting Member Confirmation" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-memberConfirmation.aspx.cs" Inherits="IChameleon.chameleon_memberConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    .style1
    {
        width: 500px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table id="Table2" align="center" border="1" cellpadding="0" cellspacing="0" 
            width="500">
            <tr>
                <td align="center" class="style1" valign="top">
                    <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" 
                        width="500">
                        <tr>
                            <td>
                                <div align="right">
                                    <a href="chameleon-home.aspx">
                                    <img border="0" height="104" 
                                        src="images/chameleon_logo.jpg" width="183" /></a></div>
                            </td>
                            <td>
                                <font class="regulargray" face="Arial" size="2">
                                <img alt="" src="Images/lbRegistrationConfirmation.gif" /></font></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="right">
                                <a href="chameleon-home.aspx"></a>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table id="Table5" align="center" bgcolor="#f7f4ef" border="0" cellpadding="1" 
                        cellspacing="1" width="400">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lbInfo" runat="server" CssClass="regularGray" Font-Names="Arial" 
                                    Font-Size="Smaller" Height="32px" Width="374px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="HEIGHT: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="butMemberHome" runat="server" onclick="butMemberHome_Click" 
                                    Text="Member Homepage" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" class="style1" valign="top">
                    <img height="22" src="images/copyright.jpg" width="325" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
