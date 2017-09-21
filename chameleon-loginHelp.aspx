<%@ Page Title="Chameleon Fine Lighting Login Help" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-loginHelp.aspx.cs" Inherits="IChameleon.chameleon_loginHelp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" 
        width="275">
        <tr>
            <td align="left">
                <font class="regularGray" face="Arial" size="2">
                <img alt="" src="Images/lbLoginHelp.gif" /><br />
                <br />
                Below please enter the email address you used to register for membership and 
                click &#39;Get Password&#39;.&nbsp; Your password will be sent to that email address 
                shortly.&nbsp; If you have any problems please don&#39;t hesitate to call us at 
                212-355-6300 or email us at
                <a href="mailto:membersupport@chameleon59.com?subject=Password%20Request%20Problem">
                membersupport@chameleon59.com</a></font><br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfEmail" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="valid email required">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="reEmail" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="invalid email format" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ValidationSummary ID="vSummary1" runat="server" Font-Names="Arial" 
                    Font-Size="Smaller" HeaderText="Please note the following errors:" 
                    Height="48px" Width="212px" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:Button ID="butSubmit" runat="server" onclick="butSubmit_Click"
                    Text="Get Password" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbInfo" runat="server" CssClass="regularGray" Font-Names="Arial" 
                    Font-Size="Smaller" Height="64px" Width="216px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <a href="" onclick="window.close();">
                <img alt="" border="0" src="Images/lbCloseWindow.gif" /></a><br />
            </td>
        </tr>
    </table>
</asp:Content>
