<%@ Page Title="Chameleon Fine Lighting Member Register" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-memberRegister.aspx.cs" Inherits="IChameleon.chameleon_memberRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table id="Table2" align="center" border="1" cellpadding="0" cellspacing="0" 
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
                                <img alt="" src="Images/lbMemberRegistration.gif" /><br />
                                <br />
                                Thank you for your interest in Chameleon Fine Lighting. Please use the form 
                                below to register for a login account and to receive exclusive site membership 
                                benefits.
                                <br />
                                <br />
                                Your information is confidential and secure and will never be shared with a 
                                third party.</font></td>
                        </tr>
                    </table>
                    <table id="Table4" align="center" bgcolor="#f7f4ef" border="0" cellpadding="1" 
                        cellspacing="1" width="500">
                        <tr>
                            <td style="width: 88px">
                            </td>
                            <td style="width: 402px">
                                <font color="#ff0000" face="Arial" size="2">
                                <br />
                                Fields marked * are required<br />
                                <br />
                                </font>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <font class="regularGray" color="#ff0000" face="Arial" size="2">* First Name</font></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:TextBox ID="txtFirstName" runat="server" CausesValidation="True" 
                                    ToolTip="first name" Width="146px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfFirstName" runat="server" 
                                    ControlToValidate="txtFirstName" ErrorMessage="First Name Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px; height: 27px;">
                                <font class="regularGray" color="#ff0000" face="Arial" size="2">* Last Name</font></td>
                            <td style="width: 402px; height: 27px;">
                                &nbsp;
                                <asp:TextBox ID="txtLastName" runat="server" CausesValidation="True" 
                                    TabIndex="1" ToolTip="last name" Width="146px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfLastName" runat="server" 
                                    ControlToValidate="txtLastName" ErrorMessage="Last Name Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="height: 27px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <font class="regularGray" color="#ff0000" face="Arial" size="2">* Organization</font></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:TextBox ID="txtOrganization" runat="server" CausesValidation="True" 
                                    TabIndex="2" ToolTip="organization" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfOrganization" runat="server" 
                                    ControlToValidate="txtOrganization" ErrorMessage="Organization Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px; height: 22px" valign="middle">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; Trade ?&nbsp;</span></td>
                            <td style="height: 22px; width: 402px;">
                                &nbsp;
                                <asp:CheckBox ID="chkTrade" runat="server" BorderStyle="None" 
                                    CssClass="regularGray" Font-Bold="True" Font-Italic="False" 
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                    TabIndex="3" 
                                    Text="Check here if you are in the trade and have a valid resale certificate.  This will enable trade pricing display." 
                                    Width="390px" />
                                <br />
                            </td>
                            <td style="height: 22px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px; height: 26px">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">* Address Line 
                                1</span></td>
                            <td style="height: 26px; width: 402px;">
                                &nbsp;
                                <asp:TextBox ID="txtAddress1" runat="server" CausesValidation="True" 
                                    TabIndex="4" ToolTip="organization" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfAddress1" runat="server" 
                                    ControlToValidate="txtAddress1" ErrorMessage="Address Line 1 Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="height: 26px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; Address Line 
                                2</span></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:TextBox ID="txtAddress2" runat="server" TabIndex="5" ToolTip="Address 2" 
                                    Width="300px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px; height: 26px">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">* City</span></td>
                            <td style="height: 26px; width: 402px;">
                                &nbsp;
                                <asp:TextBox ID="txtCity" runat="server" CausesValidation="True" TabIndex="6" 
                                    ToolTip="organization" Width="146px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfCity" runat="server" 
                                    ControlToValidate="txtCity" ErrorMessage="City Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="height: 26px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; State</span></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:DropDownList ID="cboState" runat="server" TabIndex="7" Width="146px">
                                    <asp:ListItem Value="&lt; Select State &gt;">&lt; Select State &gt;</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px; height: 21px">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; Region</span></td>
                            <td style="height: 21px; width: 402px;">
                                &nbsp;
                                <asp:TextBox ID="txtRegion" runat="server" TabIndex="8" Width="146px"></asp:TextBox>
                                <a href="javascript:infoWin('chameleon-helpTopics.aspx?helpTopic=ffRegion')">
                                <img alt="" border="0" src="Images/lbQMark.gif" /></a></td>
                            <td style="height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px; height: 21px">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">* Postal Code</span></td>
                            <td style="height: 21px; width: 402px;">
                                &nbsp;
                                <asp:TextBox ID="txtPostalCode" runat="server" CausesValidation="True" 
                                    TabIndex="9" ToolTip="organization" Width="146px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfPostalCode" runat="server" 
                                    ControlToValidate="txtPostalCode" ErrorMessage="Postal Code Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; Country</span></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:DropDownList ID="cboCountry" runat="server" TabIndex="10" Width="146px">
                                    <asp:ListItem Value="&lt; Select Country &gt;">&lt; Select Country&gt;</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <font class="regularGray" color="#ff0000" face="Arial" size="2">* Phone</font></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:TextBox ID="txtPhone" runat="server" TabIndex="11" ToolTip="phone" 
                                    Width="146px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfPhone" runat="server" 
                                    ControlToValidate="txtPhone" ErrorMessage="Phone Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <font class="regularGray" color="#ff0000" face="Arial" size="2">* Email</font></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:TextBox ID="txtEmail" runat="server" CausesValidation="True" TabIndex="12" 
                                    ToolTip="email" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfEmail" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="Valid Email Required">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="reEmail" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <font class="regularGray" color="#ff0000" face="Arial" size="2">* Confirm Email</font></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:TextBox ID="txtConfirmEmail" runat="server" CausesValidation="True" 
                                    TabIndex="13" ToolTip="confirm email" Width="300"></asp:TextBox>
                                <asp:CompareValidator ID="cvConfirmationEmail" runat="server" 
                                    ControlToCompare="txtEmail" ControlToValidate="txtConfirmEmail" 
                                    ErrorMessage="Emails Don't Match">*</asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="rfEmail2" runat="server" 
                                    ControlToValidate="txtConfirmEmail" ErrorMessage="Confirm Email Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <font class="regularGray" color="#ff0000" face="Arial" size="2">* Password</font></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:TextBox ID="txtPassword" runat="server" CausesValidation="True" 
                                    TabIndex="14" TextMode="Password" ToolTip="password" Width="146"></asp:TextBox>
                                &nbsp;<a href="javascript:infoWin('chameleon-helpTopics.aspx?helpTopic=ffPassword')"><img 
                                    alt="" border="0" src="Images/lbQMark.gif" /></a>
                                <asp:RequiredFieldValidator ID="rfPassword" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="Password Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">* Confirm 
                                Password</span></td>
                            <td style="width: 402px">
                                &nbsp;
                                <asp:TextBox ID="txtPasswordConfirm" runat="server" CausesValidation="True" 
                                    TabIndex="15" TextMode="Password" ToolTip="password" Width="146"></asp:TextBox>
                                &nbsp;
                                <asp:CompareValidator ID="cvPassword" runat="server" 
                                    ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" 
                                    ErrorMessage="Passwords Don't Match">*</asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="rfPWConfirm" runat="server" 
                                    ControlToValidate="txtPasswordConfirm" ErrorMessage="Confirm Password Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" valign="middle">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; E-alert ?</span></td>
                            <td style="width: 402px">
                                &nbsp;
                                <br />
                                <asp:CheckBox ID="chkEAlert" runat="server" BorderStyle="None" Checked="True" 
                                    CssClass="regularGray" Font-Bold="True" Font-Italic="False" 
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                    TabIndex="16" 
                                    Text="Check here to receive unobtrusive emails describing new products, and other relevant information.  You can always unsubscribe by unchecking and updating your profile." 
                                    Width="390px" />
                                <br />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                            </td>
                            <td style="width: 402px">
                                <asp:ValidationSummary ID="vSummary1" runat="server" Font-Names="Arial" 
                                    Font-Size="Smaller" HeaderText="PLEASE CHECK THE FOLLOWING:" TabIndex="30" 
                                    Width="333px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                            </td>
                            <td style="width: 402px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                            </td>
                            <td align="center" style="width: 402px">
                                <asp:Button ID="butSubmit" runat="server" onclick="butSubmit_Click" 
                                    TabIndex="17" Text="Register" Width="100px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 88px">
                            </td>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table id="Table5" align="center" border="0" cellpadding="1" cellspacing="1" 
                        width="450">
                        <tr>
                            <td bgcolor="#f7f4ef">
                                <asp:Label ID="lbInfo" runat="server" CssClass="regularGray" Font-Names="Arial" 
                                    Font-Size="Smaller" Height="32px" TabIndex="40" Visible="False" Width="425px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#f7f4ef">
                                <br />
                                <table id="Table3" align="center" border="0" cellpadding="1" cellspacing="1" 
                                    width="300">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="butHome" runat="server" CausesValidation="False" 
                                                CssClass="regulargray_Label" onclick="butHome_Click" TabIndex="18">Return Home</asp:LinkButton>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="butClose" runat="server" CausesValidation="False" 
                                                CssClass="regulargray_Label" onclick="butClose_Click" TabIndex="19">Close Window</asp:LinkButton>
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
    <script type = "text/javascript">

        function validatePWLength()
         {
            var textbox = document.getElementById("<%=txtPassword.ClientID%>");

            if (textbox.value.length < 6)
            {
                alert('password must be at least 6 characters long')
                textbox.focus();
                textbox.select();
                return false;
            }
            else
            {
                return true;
            }
        }
        
    </script> 
</asp:Content>
