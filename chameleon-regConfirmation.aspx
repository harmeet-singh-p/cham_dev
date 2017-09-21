<%@ Page Title="Chameleon Fine Lighting Registration Confirmation" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-regConfirmation.aspx.cs" Inherits="IChameleon.chameleon_regConfirmation" %>
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
                <td align="center" class="style1" colspan="3" valign="top">
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
                                <img alt="" src="Images/lbRegistrationConfirmation.gif" /><br />
                                <br />
                                </font>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="right">
                                <a href="chameleon-home.aspx"></a>
                            </td>
                        </tr>
                    </table>
                    <table id="Table5" align="center" border="0" cellpadding="1" cellspacing="1" 
                        width="450">
                        <tr>
                            <td bgcolor="#f7f4ef">
                                <font class="regularGray" face="Arial" size="2">Thank you for your interest in 
                                Chameleon Fine Lighting!
                                <br />
                                <br />
                                Your new account has now been activated with the information you provided and an 
                                email confirmation has been successfully sent to the registered email address.&nbsp; 
                                You can now enjoy the added features of Chameleon web membership.
                                <br />
                                <br />
                                Please call the web support team at 212-355-6300 or<a 
                                    href="mailto:mail@chameleon59.com"> email us</a> if you experience any 
                                technical difficulties. </font>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#f7f4ef">
                                <br />
                                <table id="Table3" align="center" border="0" cellpadding="1" cellspacing="1" 
                                    width="300">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="butLogin" runat="server" CausesValidation="False" 
                                                CssClass="regulargray_Label" onclick="butLogin_Click">Login Now</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="butHome" runat="server" CausesValidation="False" 
                                                CssClass="regulargray_Label" onclick="butHome_Click">Return Home</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="butClose" runat="server" CausesValidation="False" 
                                                CssClass="regulargray_Label" onclick="butClose_Click">Close Window</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
