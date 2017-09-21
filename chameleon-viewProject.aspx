<%@ Page Title="Chameleon Fine Lighting View Recent Projects and Installations" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-viewProject.aspx.cs" Inherits="IChameleon.chameleon_viewProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table4" align="center" bgcolor="#f7f4ef" border="0" cellpadding="0" 
        cellspacing="0" width="100%">
        <tr>
            <td width="100%" align="center">
                <br />
                <asp:Label ID="lProjectTitle" runat="server" CssClass="largeGray_Label"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" height="7">
                <asp:Image ID="Image1" runat="server" ImageAlign="Middle" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <img height="1" src="http://localhost:3409/images/div.jpg" width="489" /></td>
        </tr>
        <tr>
            <td align="left" height="7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="regulargray" align="center">
                <asp:Label ID="lProjectDetails" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <img height="1" src="http://localhost:3409/images/div.jpg" width="489" /></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
