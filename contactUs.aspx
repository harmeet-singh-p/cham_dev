<%@ Page Title="" Language="C#" MasterPageFile="~/chameleonMaster.Master" AutoEventWireup="true" CodeBehind="contactUs.aspx.cs" Inherits="IChameleon.contactUs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <asp:table runat="server" CssClass="infoTable" ID="Table1">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" ColumnSpan="3">Thank you for taking the time to contact us at Chameleon. If you have any 
                            comments, opinions, or ideas regarding services, or ways to make this site more 
                            valuable to you, please do not hesitate to tell us. We truly appreciate your 
                            comments and feedback.<br /><br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    Call Us                  
                </asp:TableCell>                    
                <asp:TableCell runat="server">
                    Write Us
                </asp:TableCell>
                <asp:TableCell runat="server">
                    Mail Us
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    PH: 212.355.6300<br />
                    FX: 212.355.5390
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:HyperLink ID="HyperLink1" runat="server">mail@chameleon59.com</asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    Chameleon Fine Lighting</strong><br />
                            233 Lafayette Street<br />
                            New York, NY&nbsp;10012<br />
                            Attn: Robert Degiarde
                </asp:TableCell>
            </asp:TableRow>

        </asp:table>
    </div>
</asp:Content>
