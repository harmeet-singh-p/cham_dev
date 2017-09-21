<%@ Page Title="Chameleon Fine Lighting Email" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-email.aspx.cs" Inherits="IChameleon.chameleon_email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table3" align="center" border="1" cellpadding="0" cellspacing="0" 
        width="500">
        <tr>
            <td align="left" colspan="3" valign="top">
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
                            <img alt="" src="Images/lbEmailDetails.gif" />
                            <br />
                            <br />
                            Please use the form below to email the page that you were viewing to another 
                            client.</font></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="right">
                            <a href="chameleon-contact.aspx" 
                                onmouseout="MM_swapImgRestore()" 
                                onmouseover="MM_swapImage('Contact','','images/butContactUS_A.gif',1)"></a>
                        </td>
                    </tr>
                </table>
                &nbsp;
                <asp:Image ID="iItem" runat="server" BorderColor="Red" BorderWidth="1px" />
                <br />
                <table id="Table4" align="center" bgcolor="#f7f4ef" border="0" cellpadding="1" 
                    cellspacing="1" width="500">
                    <tr>
                        <td>
                            <font class="regularGray" color="#ff0000" face="Arial" size="2">Send To:</font></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtTo" runat="server" Width="275px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfTo" runat="server" ControlToValidate="txtTo" 
                                ErrorMessage="to is required and must be a valid email address">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="reEmailTo" runat="server" 
                                ControlToValidate="txtTo" ErrorMessage="to must be a valid email address" 
                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font class="regularGray" color="#ff0000" face="Arial" size="2">From:</font></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtFrom" runat="server" Width="275px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfFrom" runat="server" 
                                ControlToValidate="txtFrom" 
                                ErrorMessage="from is required and must be a valid email address">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="reEmailFrom" runat="server" 
                                ControlToValidate="txtFrom" ErrorMessage="from must be a valid email address" 
                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font class="regularGray" color="#ff0000" face="Arial" size="2">Subject:</font></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSubject" runat="server" Width="275px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfSubject" runat="server" 
                                ControlToValidate="txtSubject" ErrorMessage="subject is required">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkLinkOnly" runat="server" CssClass="regularGray" 
                                Text="Send As Link Only" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <asp:Button ID="butSendEmail" runat="server" onclick="butSendEmail_Click" 
                                Text="Email Item" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lbInfo" runat="server" Font-Names="Arial" Font-Size="Smaller" 
                                Height="32px" Width="374px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:ValidationSummary ID="vsEmail" runat="server" Font-Names="Arial" 
                                Font-Size="Smaller" HeaderText="Please note the following:" />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="500">
        <tr>
            <td>
                <div align="center">
                    <img height="22" src="images/copyright.jpg" width="325" /></div>
            </td>
        </tr>
    </table>
</asp:Content>
