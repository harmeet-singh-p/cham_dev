<%@ Page Title="Chameleon Fine Lighting Fixture Search Results" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-searchResults.aspx.cs" Inherits="IChameleon.chameleon_searchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <font color="#ffffff"><font color="#ffffff">
        <font class="regularBackground" face="Arial"><font class="regular" size="2">
        <font class="regularBackground" face="Arial"><font class="regular" size="2">Welcome to Chameleon Fine Lighting, your national 
        design source for quality antique and replica lighting.
        <br />
        <br />
        <br />Use the QUICK LINKS below to speed your search:<br />
        </font></font></font></font></font></font>
    </p>
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--bread start-->
    <div class="bread">
        <div class="container">
            <ul>
                <li><a href="#">Home</a></li>
                <li>></li>
                <li>
                    <asp:Label ID="lbSearchHeading" runat="server" CssClass="regulargray_Label"></asp:Label>

                </li>
            </ul>
        </div>
    </div>
    <!--bread close-->
    <div class="container">
        <div class="showroom">

            <div class="col-sm-3">
                <div class="signature-box">
                    <h3>Browse all signature</h3>
                    <p>Browse our inventory by category with these search tools</p>
                    <ul>
                        <li>
                            <label>Celling Mounted</label>
                            <select class="text">
                                <option>All</option>
                                <option>Flush Mount</option>
                                <option>Pendant</option>
                                <option>Flush Mount</option>
                                <option>Chandelier</option>
                                <option>Hanging Bowl</option>
                                <option>Lantern</option>
                                <option>Shaded</option>
                            </select>
                        </li>
                        <li>
                            <label>Wall Mounted</label>
                            <select class="text">
                                <option selected="selected">Select</option>
                                <option value="All">All</option>
                                <option value="1-Light Sconce">1-Light Sconce</option>
                                <option value="2-Light Sconce">2-Light Sconce</option>
                                <option value="3 (or more)-Light Sconce">3 (or more)-Light Sconce</option>
                                <option value="Glass Shade">Glass Shade</option>
                                <option value="Swing-Arm">Swing-Arm</option>
                                <option value="Shaded">Shaded</option>
                            </select>

                        </li>
                        <li>
                            <label>Table/Floor Lamps</label>
                            <select class="text">
                                <option>All</option>
                                <option>Table Lamp</option>
                                <option>Floor Lamp</option>
                            </select>
                        </li>
                        <li>
                            <label>By Date</label>
                            <select class="text">
                                <option selected="selected">Select</option>
                                <option value="This Week">This Week</option>
                                <option value="Last Week">Last Week</option>
                                <option value="Last Month">Last Month</option>
                                <option value="Last 2 Months">Last 2 Months</option>
                            </select>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="col-sm-9">

                <div class="row middle">
                    <div class="col-sm-8">
                        <div class="result">
                            <p><strong>Result</strong> </p> <p><asp:Label ID="lbInfo" runat="server" CssClass="largeGray_Label" 
                    Font-Names="Arial">Click Image below to Display Details </asp:Label> </p>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="search">
                           <form id="Form1" runat="server">
                            <asp:label Id="lbSortBy" runat="server">Short By</asp:label>
                              <asp:DropDownList  class="text" ID="ddlSort" runat="server" AutoPostBack="True" Width="200px">
                            </asp:DropDownList>
                            </form>
                              <%-- <select class="text"><option selected="selected">Date Added</option>
                                <option>Item Number</option>
                            </select>--%>
                        </div>
                    </div>
                </div>
                
                <div> <asp:PlaceHolder  ID="phTopNav" runat="server"></asp:PlaceHolder></div>
                <div class="row">
                    <asp:Repeater ID="dItems" runat="server">
                        <ItemTemplate>

                            <div class="col-sm-3">
                                <div class="box">
                                    <a title="Click on Image to View Details" href='javascript:viewItemWin("chameleon-viewItem.aspx?item=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "item").ToString())%>&amp;itemID=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "itemCode").ToString())%>")'>
                                        <div class="img">
                                            <div class="overlay">&nbsp;</div>
                                            <asp:Image ID="Image1" runat="server" CssClass="thumbnailimage" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "image1Thumb") %>'></asp:Image>
                                        </div>
                                        <div class="text">
                                            <p><strong><%# DataBinder.Eval(Container.DataItem, "itemCode") %></p>
                                            <p></strong><%# DataBinder.Eval(Container.DataItem, "item") %></p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>



                </div>
                <div> <asp:PlaceHolder ID="phBottomNav" runat="server"></asp:PlaceHolder></div>

            </div>

        </div>
    </div>
</asp:Content>
