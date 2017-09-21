<%@ Page Title="Chameleon Fine Lighting Member Add Item" Language="C#" MasterPageFile="~/mContent.Master" AutoEventWireup="true" CodeBehind="chameleon-memberAddItem.aspx.cs" Inherits="IChameleon.chameleon_memberAddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table2" align="center" bgcolor="#f7f4ef" border="1" cellpadding="0" 
        cellspacing="0" width="525">
        <tr>
            <td align="center" colspan="3" valign="top">
                <br />
                <table id="Table3" align="center" border="0" cellpadding="1" cellspacing="1" 
                    width="500">
                    <tr>
                        <td align="center">
                            <img alt="" src="Images/lbAddPortfolioItem.gif" /><br />
                            <br />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server">
                    <table ID="Table4" align="center" bgColor="#f7f4ef" border="0" cellPadding="1" 
                        cellSpacing="1" width="525">
                        <tr>
                            <td align="center" style="WIDTH: 112px" valign="bottom">
                                <br/>
                                    <asp:Image ID="iItem" runat="server" BorderColor="Red" BorderWidth="1px" />
                                    <br/>
                                        <asp:Label ID="lbItemCode" runat="server" CssClass="regulargray">Label</asp:Label>
                                    <br/>                              
                            </td>
                            <td align="center" colspan="1" valign="bottom">
                                <font color="#666666" face="Arial" size="2">
                                    <br/>                                
                                </font>
                                <table id="Table6" border="0" cellpadding="1" cellspacing="1" width="300">
                                    <tr>
                                        <td>
                                            <font class="regularGray" color="#666666" face="Arial" size="2">&nbsp;&nbsp;&nbsp; Note</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom">
                                            <asp:TextBox ID="txtNotes" runat="server" CssClass="regularGray" Height="25px" 
                                                Rows="2" TextMode="MultiLine" Width="125px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <font class="regulargray" face="Arial" size="2">
                                    <br/>
                                        <br/>
                                            &nbsp;&nbsp;&nbsp;&nbsp; Select Portfolio to Add Item To<br>
                                <br></br>
                                <br/>
                                </br>
                                </font>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="HEIGHT: 17px">
                                <div align="center" 
                                    style="DISPLAY: inline; VISIBILITY: visible; OVERFLOW: auto; WIDTH: 520px; HEIGHT: 100px">
                                    <asp:DataGrid ID="dgPortfolio" runat="server" AllowSorting="True" 
                                        AutoGenerateColumns="False" BackColor="#F7F4EF" DataKeyField="portfolioID" 
                                        Font-Names="Arial" Font-Size="X-Small" ForeColor="#376080" 
                                        OnItemCommand="dgPortfolio_selectItemEventHandler" 
                                        onselectedindexchanged="dgPortfolio_SelectedIndexChanged" Width="480px">
                                        <SelectedItemStyle BackColor="LightSteelBlue" ForeColor="White" />
                                        <EditItemStyle HorizontalAlign="Center" />
                                        <AlternatingItemStyle BackColor="#F7F4EF" />
                                        <HeaderStyle BackColor="#ADBECC" Font-Bold="True" ForeColor="#465B87" 
                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateColumn Visible="False"></asp:TemplateColumn>
                                            <asp:ButtonColumn CommandName="Select" HeaderText="select portfolio" Text="add">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:ButtonColumn>
                                            <asp:BoundColumn DataField="portfolioID" HeaderText="Portfolio ID" 
                                                Visible="False">
                                                <HeaderStyle Width="75px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="portfolioName" HeaderText="portfolio name">
                                                <HeaderStyle Width="400px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="dateCreated" HeaderText="Date Created" 
                                                Visible="False">
                                                <HeaderStyle Width="100px" />
                                            </asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle BackColor="#ADBECC" Font-Bold="True" Font-Size="X-Small" 
                                            ForeColor="Blue" HorizontalAlign="Right" NextPageText="Next &gt;&gt;" 
                                            Position="TopAndBottom" PrevPageText="&lt;&lt; Prev       " 
                                            VerticalAlign="Bottom" />
                                    </asp:DataGrid>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="lbInfo" runat="server" CssClass="regularGray" Font-Names="Arial" 
                                    Font-Size="Smaller" Height="32px" Width="525px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <table id="Table1" align="center" border="0" cellpadding="1" cellspacing="1" 
                                    width="300">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="butReturn" runat="server" CausesValidation="False" 
                                                CssClass="regulargray" onclick="butReturn_Click" Visible="False">Back To 
                                            Portfolio</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="butContinue" runat="server" CausesValidation="False" 
                                                CssClass="regulargray" onclick="butContinue_Click">Continue Browsing</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <table id="Table5" align="center" border="0" cellpadding="1" cellspacing="1" 
                    width="500">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbInfo2" runat="server" CssClass="regularGray" 
                                Font-Names="Arial" Font-Size="Smaller" Height="32px" Width="423px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:LinkButton ID="butMyWorkshop" runat="server" CausesValidation="False" 
                                CssClass="regulargray" onclick="butMyWorkshop_Click" Visible="False">My Workshop</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
