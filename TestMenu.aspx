<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMenu.aspx.cs" Inherits="IChameleon.TestMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="mStyles1.css" rel="stylesheet" />
    <style type="text/css">

        .divMainMenu {
           
            background-color: #6F654A;
            /*margin: 0;*/
            height: 170px;
            width: 100%;
            
            position: fixed;
            left: 0;
            top: 0;
        }

        .divMainMenu {
            /*background-image: url('Images/Background/IMG_5504.jpg');
            background-size: cover;*/
            /*background-color: #6F654A;*/
            margin: 0;
            height: 170px;
            width: 100%;
            /*border: 2px solid black;*/
            /*background-attachment:fixed;*/
            position: fixed;
            left: 0;
            top: 0;
        }

        /*div.menu { width:100% }

        div.menu li { right:0; position:absolute; top:0 }*/

                 /*ul.level1 {
            width:100% !important;

        }
            .level1 li {
                width:10%;
            }
        ul.level2 {
            width:100% !important;
        }
            .level2 li {
                width:100%;
            }*/

                 /*.menu ul li ul
{
    display: none;
}

.menu ul li 
{
    position: relative; 
    float: left;
    list-style: none;
}*/    

        .auto-style1 {
           
            width: 100%;
            /*margin-left:15%;*/
            height: auto;
            font-family: 'Microsoft YaHei';
            font-size: medium;
            /*text-align: left;*/
            /*border: 2px solid black;*/
            table-layout: fixed;
            /*padd: 5px;*/
            /*position: fixed;*/
        }

    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div class="divMainMenu"">
        
        <table class="auto-style1">
            <tr>
                <td>
        
   <asp:Menu runat="server"  Target="_blank" Orientation="Horizontal" Font-Size="0.8em" Font-Names="Verdana" m StaticMenuItemStyle-Width="175px" DynamicVerticalOffset="10" DynamicHorizontalOffset="2" Width="100%" BackColor="#E3EAEB" ForeColor="#666666" StaticSubMenuIndent="10px">

                    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#E3EAEB" />
                    <DynamicSelectedStyle BackColor="#1C5E55" />

                    <Items>
                        <asp:MenuItem Text="HOME" Value="HOME"></asp:MenuItem>
                        <asp:MenuItem Text="SIGNATURE LINE" Value="SIGNATURE LINE">
                            <asp:MenuItem Text="Browse All" Value="Browse All"></asp:MenuItem>
                            <asp:MenuItem Text="Ceiling" Value="Ceiling"></asp:MenuItem>
                            <asp:MenuItem Text="Wall" Value="Wall"></asp:MenuItem>
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
                        <asp:MenuItem Text="QUICK SEARCH" Value="QUICK SEARCH">
                            <asp:MenuItem Text="Browse All" Value="Browse All" Target="_parent"></asp:MenuItem>
                            <asp:MenuItem Text="Modern" Value="Modern"></asp:MenuItem>
                            <asp:MenuItem Text="Traditional" Value="Traditional"></asp:MenuItem>
                            <asp:MenuItem Text="Kitchen" Value="Kitchen"></asp:MenuItem>
                            <asp:MenuItem Text="Bathroom" Value="Bathroom"></asp:MenuItem>
                            <asp:MenuItem Text="Dining Room" Value="Dining Room"></asp:MenuItem>
                            <asp:MenuItem Text="Foyer/Hallway" Value="Foyer/Hallway"></asp:MenuItem>
                            <asp:MenuItem Text="Outdoor" Value="Outdoor"></asp:MenuItem>
                            <asp:MenuItem Text="Recent Arrivals" Value="Recent Arrivals"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="SHOWROOMS" Value="SHOWROOMS" NavigateUrl="~/showrooms.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="POLICIES" Value="POLICIES" NavigateUrl="~/policies.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="SOCIAL MEDIA" Value="SOCIAL MEDIA">
                            <asp:MenuItem Text="Facebook" Value="Facebook" NavigateUrl="http://www.facebook.com/chameleonfinelighting"></asp:MenuItem>
                            <asp:MenuItem Text="Pinterest" Value="Pinterest" NavigateUrl="http://www.pinterest.com/chameleonlights/"></asp:MenuItem>
                            <asp:MenuItem Text="Twitter" Value="Twitter" NavigateUrl="http://twitter.com/chameleonlights"></asp:MenuItem>
                        </asp:MenuItem>                        
                        <asp:MenuItem Text="CATALOG" Value="CATALOG" NavigateUrl="~/SSL/chameleon-catalogRequest.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="CUSTOM/<br>HOSPITALITY" Value="CUSTOM/HOSPITALITY" NavigateUrl="~/customHospitality.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="ABOUT US" Value="ABOUT US">
                            <asp:MenuItem Text="Manufacturing" Value="Manufacturing" NavigateUrl="~/manufacturing.aspx" Target="_parent"></asp:MenuItem>
                            <asp:MenuItem Text="Projects" Value="Projects" NavigateUrl="~/chameleon-recentProjects.aspx" Target="_parent"></asp:MenuItem>
                            <asp:MenuItem Text="Contact Us" Value="Contact Us" NavigateUrl="~/contactUs.aspx" Target="_parent"></asp:MenuItem>
                            <asp:MenuItem Text="History" Value="History" NavigateUrl="~/aboutUs.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Sustainability" Value="Sustainability" NavigateUrl="~/sustainability.aspx" Target="_parent"></asp:MenuItem>
                            <asp:MenuItem Text="Policies" Value="Policies" NavigateUrl="~/policies.aspx"></asp:MenuItem>
                        </asp:MenuItem>
                        </Items>
                    
                    </asp:Menu>
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
