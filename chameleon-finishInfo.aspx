<%@ Page Title="Chameleon Fine Lighting Finish Information" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-finishInfo.aspx.cs" Inherits="IChameleon.chameleon_finishInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table1" align="center" border="5" cellpadding="10" cellspacing="1" 
        width="425">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="#666666" Text="FINISH INFORMATION"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td align="justify">
                <font class="regularGray" face="Arial" size="2">Chameleon prices our finishes in 
                types:&nbsp; Brass, Nickel, Silver, Gold, Patinated.&nbsp; So for example pricing for 
                &quot;Brass&quot; includes ANY Brass finish, Satin or Polished.<br />
                <br />
                Brass includes:&nbsp; Polished Brass finish.<br />
                <br />
                Nickel includes these Nickel plated finishes:&nbsp; Satin and Polished Nickel.<br />
                <br />
                Silver includes these Silver plated finishes:&nbsp; Satin, Butler or Butler Antique 
                Silver.<br />
                <br />
                Gold includes these Gold plated finishes: Butler and Old Gold.<br />
                <br />
                Patinated includes brass patina finishes:&nbsp; Antique Brass, Oil Rubbed Bronze and 
                Statuary Bronze.<br />
                <br />
                Other finishes exist including Gold Leaf and Silver Leaf but are specific to the 
                style of fixture. For example wrought iron &quot;Bagues&quot; type fixtures lend 
                themselves better to leafed finishes than to plated finishes.&nbsp; If you have a 
                custom color in mind or need to match a color chip, don&#39;t hesitate to call us to 
                discuss.<br />
                <br />
                For convenience, most individual models in our Signature Line can be viewed on 
                our website in the most popular finishes.&nbsp; Since all computer monitors are 
                different and many aren&#39;t color calibrated, the actual fixture finish colors may 
                be slightly different from the ones on your screen.&nbsp; Always consult our
                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#666666" 
                    NavigateUrl="~/chameleon-finishes.aspx" Target="_blank"><font 
                    class="regularGray" face="Arial" size="2">Color 
    Chart</font></asp:HyperLink>
                &nbsp;and if you have any questions on finishes please don&#39;t hesitate to call us and 
                we can send you an actual finish sample.</font></td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <br />
                <a href="" onclick="window.close();">
                <img alt="" border="0" src="Images/lbCloseWindow.gif" /></a><br />
            </td>
        </tr>
    </table>
</asp:Content>
