<%@ Page Title="Chameleon Fine Lighting Help Topics" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-helpTopics.aspx.cs" Inherits="IChameleon.chameleon_helpTopics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" 
        width="275">
        <tr>
            <td>
                <img alt="" src="Images/lbAboutTopic.gif" /><br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbInfo" runat="server" CssClass="regularGray" Font-Names="Arial" 
                    Font-Size="Smaller" Height="200px" Width="275px"></asp:Label>
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
