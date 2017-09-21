<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test2.aspx.cs" Inherits="IChameleon.Test2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style38 {
            width: 213px;
        }
        .auto-style43 {
            width: 100px;
            text-align:center;
            
        }
        
        .auto-style49 {
            height: 37px;
            width: 100px;
        }

        html {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
        }

        body {
            background-image:url('Images/Background/IMG_5504.jpg');
            background-size: cover;
            background-repeat: no-repeat-y;
        }
        .search {
                padding:8px 10px;
                background:rgba(50, 50, 50, 0.2);
                border:0px solid #dbdbdb;
        }
        .button {
                position:relative;
                padding:6px 10px;
                left:-8px;
                border:2px solid #207cca;
                background-color:#207cca;
                color:#fafafa;
                height:20px;
        }
        .button:hover {
            background-color: #fafafa;
            color: #207cca;
        }
        
        .styLinkBtn {
                    font-family:'Microsoft YaHei';
                    font-size:large;
                    color:white;
                    font-weight:bold;
                    text-decoration:none;                    
        }
        .styLinkBtn:hover {
                    font-family:'Microsoft YaHei';
                    font-size:large;
                    color:#999966;
                    font-weight:bold;
                    text-decoration:none;
                    del

        }

        
      </style>
</head>
<body >
    <form id="form1" runat="server">

        <div itemid="div1">      
            
            
            
        <table style="color: #FFFFFF; font-family: 'Microsoft YaHei UI'; width: 100%; height: 242px;">
            <tr style="vertical-align: middle; font-size: small;">    
                <td class="auto-style38"><asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager></td>
                <td class="auto-style43"></td>
                <td class="auto-style43">&nbsp;</td>
                <td class="auto-style43"><input type="text" placeholder="Search..." required style="width: 91px; height: 20px;">
                     <input type="button" value="Search" style="width: 57px; height: 28px;text-align:center"></td>
                <td class="auto-style43">&nbsp;</td>
                <td class="auto-style43">&nbsp;</td>
                <td class="auto-style43"></td>
                <td class="auto-style43" style="text-align: right">
                    <asp:LinkButton ID="LinkButton7" runat="server" CssClass="styLinkBtn" PostBackUrl="~/chameleon-memberLogin.aspx">Login/Register</asp:LinkButton></td>
                <td class="auto-style43" style="text-align: center">
                    <asp:LinkButton ID="LinkButton8" runat="server" CssClass="styLinkBtn">My Profile</asp:LinkButton></td>
                <td class="auto-style43" style="text-align: left">
                    <asp:LinkButton ID="LinkButton9" runat="server" CssClass="styLinkBtn">My Workshop</asp:LinkButton></td>
            </tr>
            <tr style="vertical-align: top; font-size: small;">    
                <td class="auto-style38"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Logo_Brown.jpg" Height="190px" Width="190px" /></td>
                <td class="auto-style43">
                    <asp:LinkButton ID="LinkButton6" runat="server" CssClass="styLinkBtn" PostBackUrl="~/Test2.aspx">HOME</asp:LinkButton></td>
                <td class="auto-style43"><asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" DisappearAfter="250">
                        <DynamicHoverStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" ForeColor="#999966" />
                        <DynamicMenuItemStyle Font-Names="Microsoft YaHei" Font-Size="Large" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" HorizontalPadding="5px" VerticalPadding="5px" Font-Bold="True" />
                        <DynamicMenuStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                        <DynamicSelectedStyle Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" />
                        <Items>
                            <asp:MenuItem Text="LIGHTING" Value="LIGHTING">
                                <asp:MenuItem Text="Ceiling" Value="Ceiling">
                                    <asp:MenuItem Text="Chandelier" Value="Chandelier"></asp:MenuItem>
                                    <asp:MenuItem Text="Lantern" Value="Lantern"></asp:MenuItem>
                                    <asp:MenuItem Text="Pendant" Value="Pendant"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="Wall" Value="Wall">
                                    <asp:MenuItem Text="1-Light" Value="1-Light"></asp:MenuItem>
                                    <asp:MenuItem Text="2-Light" Value="2-Light"></asp:MenuItem>
                                    <asp:MenuItem Text="3-Light" Value="3-Light"></asp:MenuItem>
                                    <asp:MenuItem Text="Shaded" Value="Shaded"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="Table" Value="Table"></asp:MenuItem>
                                <asp:MenuItem Text="Floor" Value="Floor"></asp:MenuItem>
                                <asp:MenuItem Text="Purpose" Value="Purpose">
                                    <asp:MenuItem Text="Kitchen" Value="Kitchen"></asp:MenuItem>
                                    <asp:MenuItem Text="Bathroom" Value="Bathroom"></asp:MenuItem>
                                    <asp:MenuItem Text="Dining Room" Value="Dining Room"></asp:MenuItem>
                                    <asp:MenuItem Text="Foyer/Hallway" Value="Foyer/Hallway"></asp:MenuItem>
                                    <asp:MenuItem Text="Outdoor" Value="Outdoor"></asp:MenuItem>
                                </asp:MenuItem>
                            </asp:MenuItem>
                        </Items>
                        <StaticHoverStyle Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" ForeColor="#999966" />
                        <StaticMenuItemStyle Font-Names="Microsoft YaHei" ForeColor="White" Font-Bold="True" Font-Size="Large" />
                        <StaticSelectedStyle Font-Size="Large" />
                    </asp:Menu>
                </td>
                <td class="auto-style43">
                    <asp:Menu ID="Menu2" runat="server" Orientation="Horizontal" Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" DisappearAfter="250">
                        <DynamicHoverStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" ForeColor="#999966" />
                        <DynamicMenuItemStyle Font-Names="Microsoft YaHei" Font-Size="Large" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" HorizontalPadding="5px" VerticalPadding="5px" Font-Bold="True" />
                        <DynamicMenuStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                        <DynamicSelectedStyle Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" />
                        <Items>
                            <asp:MenuItem Text="QUICK SEARCH" Value="QUICK SEARCH">
                                <asp:MenuItem Text="Modern" Value="Modern"></asp:MenuItem>
                                <asp:MenuItem Text="Traditional" Value="Traditional"></asp:MenuItem>
                                <asp:MenuItem Text="Kitchen" Value="Kitchen"></asp:MenuItem>
                                <asp:MenuItem Text="Bathroom" Value="Bathroom"></asp:MenuItem>
                                <asp:MenuItem Text="Dining Room" Value="Dining Room"></asp:MenuItem>
                                <asp:MenuItem Text="Foyer/Hallway" Value="Foyer/Hallway"></asp:MenuItem>
                                <asp:MenuItem Text="Outdoor" Value="Outdoor"></asp:MenuItem>
                             </asp:MenuItem>
                        </Items>
                        <StaticHoverStyle Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" ForeColor="#999966" />
                        <StaticMenuItemStyle Font-Names="Microsoft YaHei" ForeColor="White" Font-Bold="True" Font-Size="Large" />
                        <StaticSelectedStyle Font-Size="Large" />
                    </asp:Menu>
                    </td>
                <td class="auto-style43">
                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/chameleon-showrooms.aspx" CssClass="styLinkBtn">SHOWROOMS</asp:LinkButton></td>
                <td class="auto-style43">
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/chameleon-contact.aspx" CssClass="styLinkBtn">CONTACT US</asp:LinkButton></td>
                <td class="auto-style43">
                        <asp:Menu ID="Menu3" runat="server" Orientation="Horizontal" Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" DisappearAfter="250">
                        <DynamicHoverStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" ForeColor="#999966" />
                        <DynamicMenuItemStyle Font-Names="Microsoft YaHei" Font-Size="Large" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" HorizontalPadding="5px" VerticalPadding="5px" Font-Bold="True" />
                        <DynamicMenuStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                        <DynamicSelectedStyle Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" />
                        <Items>
                            <asp:MenuItem Text="SOCIAL MEDIA" Value="SOCIAL MEDIA">
                                <asp:MenuItem Text="Facebook" Value="Facebook" NavigateUrl="http://www.facebook.com/chameleonfinelighting"></asp:MenuItem>
                                <asp:MenuItem Text="Pinterest" Value="Pinterest" NavigateUrl="http://www.pinterest.com/chameleonlights/"></asp:MenuItem>
                                <asp:MenuItem Text="Twitter" Value="Twitter" NavigateUrl="http://twitter.com/chameleonlights"></asp:MenuItem>
                            </asp:MenuItem>
                        </Items>
                            <StaticHoverStyle Font-Bold="True" Font-Names="Microsoft YaHei" Font-Size="Large" ForeColor="#999966" />
                        <StaticMenuItemStyle Font-Names="Microsoft YaHei" ForeColor="White" Font-Bold="True" Font-Size="Large" />
                        <StaticSelectedStyle Font-Size="Large" />
                    </asp:Menu>
                </td>
                <td class="auto-style43">
                    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/chameleon-recentProjects.aspx" CssClass="styLinkBtn">PROJECTS</asp:LinkButton></td>
                <td class="auto-style43">
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="styLinkBtn">MANUFACTURING</asp:LinkButton></td>
                <td class="auto-style43">
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/chameleon-sustainability.aspx" CssClass="styLinkBtn" >SUSTAINABILITY</asp:LinkButton></td>
            </tr>
            
        </table>         
    </div>
    </form>
    </body>
</html>
