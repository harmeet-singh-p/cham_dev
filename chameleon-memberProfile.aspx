<%@ Page Title="Chameleon Fine Lighting Member Profile" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-memberProfile.aspx.cs" Inherits="IChameleon.chameleon_memberProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table id="Table2" align="center" border="1" cellpadding="0" cellspacing="0" 
            width="500">
            <tr>
                <td align="center" colspan="3" valign="top">
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
                                <img alt="" src="Images/lbMemberProfile.gif" /><br />
                                <br />
                                Please use the form below to update your member profile</font></td>
                        </tr>
                    </table>
                    <br />
                    <table id="Table4" align="center" bgcolor="#f7f4ef" border="0" cellpadding="1" 
                        cellspacing="1" width="500">
                        <tr>
                            <td style="width: 90px" align="left">
                            </td>
                            <td align="left">
                                <font color="#ff0000" face="Arial" size="2">
                                <br />
                                &nbsp;Fields marked * are required<br />
                                <br />
                                </font>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                                <font class="regulargray" color="#ff0000" face="Arial" size="2">* First Name</font></td>
                            <td align="left">
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
                            <td style="width: 90px" align="left">
                                <font class="regulargray" color="#ff0000" face="Arial" size="2">* Last Name</font></td>
                            <td align="left">
                                &nbsp;
                                <asp:TextBox ID="txtLastName" runat="server" CausesValidation="True" 
                                    TabIndex="1" ToolTip="last name" Width="146px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfLastName" runat="server" 
                                    ControlToValidate="txtLastName" ErrorMessage="Last Name Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                                <font class="regulargray" color="#ff0000" face="Arial" size="2">* Organization</font></td>
                            <td align="left">
                                &nbsp;
                                <asp:TextBox ID="txtOrganization" runat="server" CausesValidation="True" 
                                    TabIndex="2" ToolTip="organization" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfOrganization" runat="server" 
                                    ControlToValidate="txtOrganization" ErrorMessage="Organization Required">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px; height: 22px" valign="middle" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; Trade ?&nbsp;</span></td>
                            <td style="height: 22px" valign="top" align="left">
                                &nbsp;
                                <asp:CheckBox ID="chkTrade" runat="server" BackColor="Transparent" 
                                    CssClass="regulargray" Font-Bold="True" TabIndex="3" 
                                    Text="Check here if you are in the trade and have a valid resale certificate.  This will enable trade pricing display." 
                                    Width="390px" />
                                <br />
                                <br />
                            </td>
                            <td style="height: 22px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px; height: 26px" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">* Address Line 
                                1</span></td>
                            <td style="height: 26px" align="left">
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
                            <td style="width: 90px" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; Address Line 
                                2</span></td>
                            <td align="left">
                                &nbsp;
                                <asp:TextBox ID="txtAddress2" runat="server" TabIndex="5" ToolTip="Address 2" 
                                    Width="300px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px; height: 26px" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">* City</span></td>
                            <td style="height: 26px" align="left">
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
                            <td style="width: 90px" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; State</span></td>
                            <td align="left">
                                &nbsp;
                                <asp:DropDownList ID="cboState" runat="server" TabIndex="7" Width="146px">
                                    <asp:ListItem Value="&lt; Select State &gt;">&lt; Select State &gt;</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px; height: 21px" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; Region</span></td>
                            <td style="height: 21px" align="left">
                                &nbsp;
                                <asp:TextBox ID="txtRegion" runat="server" TabIndex="8" Width="146px"></asp:TextBox>
                                <a href="javascript:infoWin('chameleon-helpTopics.aspx?helpTopic=ffRegion')">
                                <img alt="" border="0" src="Images/lbQMark.gif" /></a></td>
                            <td style="height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px; height: 21px" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">* Postal Code</span></td>
                            <td style="height: 21px" align="left">
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
                            <td style="width: 90px" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; Country</span></td>
                            <td align="left">
                                &nbsp;
                                <asp:DropDownList ID="cboCountry" runat="server" TabIndex="10" Width="146px">
                                    <asp:ListItem Value="&lt; Select Country &gt;">&lt; Select Country&gt;</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                                <font class="regulargray" color="#ff0000" face="Arial" size="2">* Phone</font></td>
                            <td align="left">
                                &nbsp;
                                <asp:TextBox ID="txtPhone" runat="server" CausesValidation="True" TabIndex="11" 
                                    ToolTip="phone" Width="146px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfPhone" runat="server" 
                                    ControlToValidate="txtPhone" ErrorMessage="Phone Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                                <font class="regulargray" color="#ff0000" face="Arial" size="2">* Email</font></td>
                            <td align="left">
                                &nbsp;
                                <asp:TextBox ID="txtEmail" runat="server" CausesValidation="True" TabIndex="12" 
                                    ToolTip="email" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfEmail" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="Valid Email Required" Width="1px">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="reEmail" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" 
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                                <font class="regulargray" color="#ff0000" face="Arial" size="2">* Password</font></td>
                            <td align="left">
                                &nbsp;
                                <asp:TextBox ID="txtPassword" runat="server" CausesValidation="True" 
                                    TabIndex="13" TextMode="Password" ToolTip="password" Width="146"></asp:TextBox>
                                &nbsp;<a href="javascript:infoWin('chameleon-helpTopics.aspx?helpTopic=ffPassword')"><img 
                                    alt="" border="0" src="Images/lbQMark.gif" /></a>
                                <asp:RequiredFieldValidator ID="rfPassword" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="Password Required">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">* Confirm 
                                Password</span></td>
                            <td align="left">
                                &nbsp;
                                <asp:TextBox ID="txtPasswordConfirm" runat="server" CausesValidation="True" 
                                    TabIndex="14" TextMode="Password" ToolTip="password" Width="146"></asp:TextBox>
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
                            <td style="width: 90px" valign="middle" align="left">
                                <span style="font-size: 8pt; color: #666666; font-family: Arial">&nbsp; E-alert ?</span></td>
                            <td align="left">
                                &nbsp;
                                <asp:CheckBox ID="chkEAlert" runat="server" BorderStyle="None" 
                                    CssClass="regulargray" Font-Bold="True" Font-Italic="False" 
                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                    TabIndex="15" 
                                    Text="Check here to receive unobtrusive emails describing new products, and other relevant information.  You can always unsubscribe by unchecking and updating your profile." 
                                    Width="390px" />
                                <br />
                                <br />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                            </td>
                            <td align="left">
                                <asp:ValidationSummary ID="vSummary1" runat="server" Font-Names="Arial" 
                                    Font-Size="Smaller" HeaderText="PLEASE CHECK THE FOLLOWING:" Width="333px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                            </td>
                            <td align="left">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 90px" align="left">
                            </td>
                            <td align="left">
                                <asp:Button ID="butSubmit" runat="server" onclick="butSubmit_Click" 
                                    TabIndex="16" Text="Update Profile" Width="100px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 90px">
                            </td>
                            <td align="left" colspan="2">
                                <asp:Label ID="lbInfo" runat="server" CssClass="regulargray" Font-Names="Arial" 
                                    Font-Size="Smaller" Height="32px" Width="374px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 90px">
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="butMyWorkshop" runat="server" CausesValidation="False" 
                                    onclick="butMyWorkshop_Click" TabIndex="17" Text="Cancel" Width="100px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
        </table>
    </div>
     <script type = "text/javascript">

         function validatePWLength() {
             var textbox = document.getElementById("<%=txtPassword.ClientID%>");

             if (textbox.value.length < 6) {
                 alert('password must be at least 6 characters long')
                 textbox.focus();
                 textbox.select();
                 return false;
             }
             else {
                 return true;
             }
         }        

    </script> 
</asp:Content>
