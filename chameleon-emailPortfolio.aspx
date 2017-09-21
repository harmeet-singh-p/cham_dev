<%@ Page Title="Chameleon Fine Lighting Email Fixture Portfolio" Language="C#" MasterPageFile="~/mContentWhite.Master" AutoEventWireup="true" CodeBehind="chameleon-emailPortfolio.aspx.cs" Inherits="IChameleon.chameleon_emailPortfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


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
    <div style="text-align: center" align="center">
        <asp:Panel ID="Panel1" runat="server" BackColor="White" 
            HorizontalAlign="Center" Width="100%">
            <br>
                <a href="http://www.chameleon59.com">
                    <img></img></a>
                <img alt="Chameleon Fine Lighing" class="auto-style1" src="Images/viewItem_noAddress_500.jpg" />
                <br>
                    <asp:Label ID="lbHeader" runat="server" Font-Names="Arial" Font-Size="14px" 
                        Forecolor="#666666" Height="25px" Width="408px"></asp:Label>
                    <br>
                        <br>
                            <table id="Table1" align="center" bgcolor="#ffffff" border="1" cellpadding="1" 
                                cellspacing="1" width="600">
                                <tr>
                                    <td align="center">
                                        <asp:DataList ID="dItems" runat="server" DataKeyField="pItemID" 
                                            Font-Names="Arial" Font-Size="10pt" HorizontalAlign="Center" RepeatColumns="3" 
                                            RepeatDirection="Horizontal" Width="500px">
                                            <HeaderTemplate>
                                                <div align="center">
                                                    &nbsp;</div>
                                            </HeaderTemplate>
                                            <FooterTemplate>
                                                <div align="center">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <div align="center">
                                                    <a href='http://www.chameleon59.com/chameleon-viewItem.aspx?itemID=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "itemCode").ToString())%>'>
                                                        <asp:Image ID="Image1" runat="server" cssclass="thumbnailimage" 
                                                            ImageUrl='<%# DataBinder.Eval(Container.DataItem, "imagePath").ToString() %>' />
                                                    </a>
                                                </div>
                                                <table id="Table3" align="center" border="0" cellpadding="1" cellspacing="1" 
                                                    width="150">
                                                    <tr>
                                                        <td align="center">
                                                            <b>
                                                                <asp:Label ID="Label1" runat="server" CssClass="regulargray_Label" 
                                                                    Font-Names="Arial" Font-Size="11px" ForeColor="#666666">
<%# DataBinder.Eval(Container.DataItem, "itemCode") %>
                                                                

                                                                </asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lbSidemark" runat="server" CssClass="regulargray" 
                                                                Font-Names="Arial" Font-Size="11px" ForeColor="#666666" Width="110px">
<%# DataBinder.Eval(Container.DataItem, "notes") %>
                                                            

                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                               <br />
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                           <br />
        </asp:Panel>
       <br/><table id="Table9" align="center" bgcolor="#ffffff" border="0" cellpadding="1" 
            cellspacing="1" width="500">
            <tr>
                <td align="justify">
                    <font class="regularGray" color="#ff0000" face="Arial" size="2">Send To:</font></td>
                <td align="justify" style="width: 137px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="justify">
                    <asp:TextBox ID="txtTo" runat="server" Width="275px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfTo" runat="server" ControlToValidate="txtTo" 
                        ErrorMessage="to is required and must be a valid email address">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reEmailTo" runat="server" 
                        ControlToValidate="txtTo" ErrorMessage="to must be a valid email address" 
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
                <td align="justify" style="width: 137px">
                </td>
            </tr>
            <tr>
                <td align="justify">
                    <font class="regularGray" color="#ff0000" face="Arial" size="2">From:</font></td>
                <td align="justify" style="width: 137px">
                </td>
            </tr>
            <tr>
                <td align="justify">
                    <asp:TextBox ID="txtFrom" runat="server" Width="275px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfFrom" runat="server" 
                        ControlToValidate="txtFrom" 
                        ErrorMessage="from is required and must be a valid email address">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reEmailFrom" runat="server" 
                        ControlToValidate="txtFrom" ErrorMessage="from must be a valid email address" 
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
                <td align="justify" style="width: 137px">
                </td>
            </tr>
            <tr>
                <td align="justify">
                    <font class="regularGray" color="#ff0000" face="Arial" size="2">Subject:</font></td>
                <td align="justify" style="width: 137px">
                </td>
            </tr>
            <tr>
                <td align="justify">
                    <asp:TextBox ID="txtSubject" runat="server" Width="275px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfSubject" runat="server" 
                        ControlToValidate="txtSubject" ErrorMessage="subject is required">*</asp:RequiredFieldValidator>
                </td>
                <td align="justify" style="width: 137px">
                    <asp:CheckBox ID="chkLinkOnly" runat="server" CssClass="regulargray" 
                        Text="Send As Link Only" Visible="False" />
                </td>
            </tr>
            <tr>
                <td align="justify">
                    <br />
                    <br />
                    <asp:Button ID="butSendEmail" runat="server" onclick="butSendEmail_Click" 
                        Text="Email Portfolio" />
                </td>
                <td align="justify" style="width: 137px">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lbInfo" runat="server" CssClass="regularGray" Font-Names="Arial" 
                        Font-Size="Smaller" Height="32px" Width="374px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:ValidationSummary ID="vsEmail" runat="server" Font-Names="Arial" 
                        Font-Size="Smaller" HeaderText="Please note the following:" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 16px">
                    <asp:LinkButton ID="butReturn" runat="server" CausesValidation="False" 
                        CssClass="regulargray" onclick="butReturn_Click">Return To Portfolio</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <p>
    </p>
</asp:Content>
