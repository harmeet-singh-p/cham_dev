<%@ Page Title="Chameleon Fine Lighting Member View Portfolio" Language="C#" MasterPageFile="~/chameleonMaster.Master" AutoEventWireup="true" CodeBehind="chameleon-memberViewPortfolio.aspx.cs" Inherits="IChameleon.chameleon_memberViewPortfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <font color="#ffffff"><font class="regularBackground" face="Arial">
        <font class="regular" size="2">The portfolio at right has several useful 
        features. Individual items can be saved, edited, emailed or deleted. The 
        portfolio as a whole can also be emailed for the recipient to browse.&nbsp;
        <br />
        <br />
        Use the QUICK LINKS below to speed your search:<br />
        </font></font></font>
    </p>
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="maxTable">
        <tr>
            <td>
                <table id="Table3" align="center" border="0" cellpadding="1" cellspacing="1" 
                    width="500">
                    <tr>
                        <td align="center" valign="bottom">
                            <asp:Label ID="lbHeader" runat="server" CssClass="largeGray_Label" 
                                Height="15px" Width="250px"></asp:Label>
                        </td>
                        <td align="left" valign="bottom">
                            <asp:LinkButton ID="butAddItem" runat="server" 
                                CssClass="regulargray" onclick="butAddItem_Click">Add Item</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="butEmail" runat="server" CssClass="regulargray" 
                                onclick="butEmail_Click">Email Portfolio</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="butRemoveItem" runat="server" CssClass="regulargray" 
                                onclick="butRemoveItem_Click" Visible="False">Remove Checked Items</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <br />
                            <asp:LinkButton ID="butMWS" runat="server" 
                                CssClass="regulargray" onclick="butMWS_Click">Back To My Workshop</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table10" align="center" border="0" cellpadding="1" cellspacing="1" 
                    width="325">
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:Label ID="lbItemCode" runat="server" CssClass="regulargray" 
                                Visible="False" Width="325px">Enter the item number and note you wish to add or browse to find it</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:TextBox ID="txtItemCode" runat="server" Visible="False"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtItemNotes" runat="server" Height="25px" Rows="2" 
                                TextMode="MultiLine" Visible="False" Width="125px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:LinkButton ID="butCancel" runat="server" CausesValidation="False" 
                                CssClass="regulargray" onclick="butCancel_Click" Visible="False">Cancel</asp:LinkButton>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="butSaveItem" runat="server" CssClass="regulargray" 
                                onclick="butSaveItem_Click" Visible="False">Save Item</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="dItems" runat="server" BackColor="#f7f4ef" 
                    DataKeyField="pItemID" Font-Name="Arial" Font-Size="10pt" 
                    HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" 
                    Width="500px" OnEditCommand="dItems_EditCommand">
                    <HeaderTemplate>
                        <div align="center">
                            &nbsp;</div>
                    </HeaderTemplate>
                    <FooterTemplate>
                        <div align="center">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </FooterTemplate>
                    <ItemTemplate>
<DIV align="center"><A href='javascript:viewItemWin("chameleon-memberViewItem.aspx?itemID=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "itemCode").ToString())%>")'>
<asp:Image id=Image1 runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "imagePath").ToString() %>' cssclass="thumbnailimage">
</asp:Image><BR>
</A><STRONG><FONT color="#666666" size="2">
<asp:Label id="Label1" runat="server" CssClass="regulargray_Label">
<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "itemCode").ToString())%>
</asp:Label><BR>
<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="150" align="center" border="0">
<TR>
<TD align="left"><FONT class="regularGray" color="#666666" size="2">&nbsp;&nbsp; Note</FONT></TD>
</TR>
<TR>
<TD class="regularGray" align="center">
<asp:TextBox id=txtNotes runat="server" Height="25px" Width="125px" CssClass="regularGray" Rows="2" TextMode="MultiLine" Font-Size="11px" Font-Names="Arial" ForeColor="#666666" Text='<%# DataBinder.Eval(Container.DataItem, "notes") %>'>
</asp:TextBox></TD>
</TR>
<TR>
<TD align="center">
<asp:CheckBox id="chkRemoveItem" runat="server" CssClass="regularGray" Text="remove"></asp:CheckBox>&nbsp;
<asp:LinkButton id="lkEdit" runat="server" CssClass="regularGray" CommandName="Edit">save note</asp:LinkButton></TD>
</TR>
</TABLE>
<BR>
</FONT></STRONG>
</DIV>
</ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbInfo" runat="server" CssClass="regularGray" Font-Names="Arial" 
                    Font-Size="Smaller" Height="32px" Width="374px"></asp:Label>
            </td>
        </tr>
    </table>    

<script type = "text/javascript">

    function validateTexBox()
     {
       
        var textbox = document.getElementById("<%=txtItemCode.ClientID%>");
       // alert("TextBox Value is " + textbox.value);

        if (textbox.value == '')
        {
            alert('item is required')
            textbox.focus();
            return false;
        }
        else
        {
            return true;
        }

    } 

    </script> 

</asp:Content>
