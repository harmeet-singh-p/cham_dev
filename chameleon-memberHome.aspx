<%@ Page Title="Chameleon Fine Lighting Member Home" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-memberHome.aspx.cs" Inherits="IChameleon.chameleon_memberHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    .style1
    {
        height: 17px;
    }
    </style>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <font color="#ffffff"><font class="regularBackground" face="Arial">
        <font class="regular" size="2">Designed with the busy decorator in mind but 
        available to anyone, <strong>MY WORKSHOP</strong> is your own private work space 
        where you can save, organize and email your items and save your searches for 
        future use.&nbsp;
        <br />
        <br />
        <br />
        Use the QUICK LINKS below to speed your search:</font></font></font></p>
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        
    <table id="Table4" align="center" bgcolor="#f7f4ef" border="0" cellpadding="1" 
        cellspacing="1" width="592">
        <tr>
            <td align="center" colspan="2">
                <img alt="" src="Images/lbMyWorkshop.gif" /></td>
        </tr>
        <tr>
            <td align="left" class="regularGray" colspan="2">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbName" runat="server" CssClass="regulargray"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <br />
                <asp:Panel ID="pnlPortfolio" runat="server" Width="500px">
                    <font color="#ff0000" face="Arial" size="2">
                        <div align="center" 
                            style="DISPLAY: inline; VISIBILITY: visible; OVERFLOW: auto; WIDTH: 540px; HEIGHT: 100px">
                            
                            <asp:DataGrid ID="dgPortfolio" runat="server" AllowSorting="True" 
                                AutoGenerateColumns="False" BackColor="#F7F4EF" CssClass="row" 
                                DataKeyField="portfolioID" Font-Names="Arial" Font-Size="X-Small" 
                                ForeColor="#376080" 
                                onselectedindexchanged="dgPortfolio_SelectedIndexChanged" Width="500px" OnCancelCommand="dgPortfolio_CancelCommand" OnDeleteCommand="dgPortfolio_DeleteCommand" OnEditCommand="dgPortfolio_EditCommand" OnUpdateCommand="dgPortfolio_UpdateCommand" OnSortCommand="dgPortfolio_SortCommand" OnItemCommand="dgPortfolio_selectItemEventHandler">
                                <SelectedItemStyle BackColor="LightSteelBlue" ForeColor="White" />
                                <EditItemStyle HorizontalAlign="Center" />
                                <AlternatingItemStyle CssClass="row" />
                                <ItemStyle CssClass="row" />
                                <HeaderStyle BackColor="#ADBECC" Font-Bold="True" ForeColor="#465B87" 
                                    Height="15px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <Columns>
                                    <asp:TemplateColumn Visible="False"></asp:TemplateColumn>
                                    <asp:ButtonColumn CommandName="Select" HeaderText="select portfolio" 
                                        Text="view">
                                        <HeaderStyle HorizontalAlign="Center" Width="125px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:ButtonColumn>
                                    <asp:BoundColumn DataField="portfolioID" HeaderText="Portfolio ID" 
                                        Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="portfolioName" HeaderText="portfolio name">
                                        <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:EditCommandColumn ButtonType="LinkButton" CancelText="cancel" 
                                        EditText="edit" UpdateText="update">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:EditCommandColumn>
                                    <asp:ButtonColumn CommandName="Delete" Text="delete">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:ButtonColumn>
                                </Columns>
                                <PagerStyle BackColor="#ADBECC" Font-Bold="True" Font-Size="X-Small" 
                                    ForeColor="Blue" HorizontalAlign="Right" NextPageText="Next &gt;&gt;" 
                                    Position="TopAndBottom" PrevPageText="&lt;&lt; Prev       " 
                                    VerticalAlign="Bottom" />
                            </asp:DataGrid>

                            
                        </div>
                    </font>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:LinkButton ID="butNewPortfolio" runat="server" CausesValidation="False" 
                    CssClass="regulargray" onclick="butNewPortfolio_Click">Create New Portfolio</asp:LinkButton>
                <table id="Table10" align="center" border="0" cellpadding="1" cellspacing="1" 
                    width="475">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbPortfolioName" runat="server" CssClass="regulargray" 
                                Font-Names="Arial" Font-Size="Smaller" Visible="False"> Enter Portfolio Name</asp:Label>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtPortfolioName" runat="server" Visible="False"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="butSavePortfolio" runat="server" CssClass="regulargray" 
                                onclick="butSavePortfolio_Click" Visible="False">Save Portfolio</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lbInfo" runat="server" CssClass="regulargray" Height="32px" 
                    Width="374px"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table3" align="center" bgcolor="#f7f4ef" border="0" cellpadding="1" 
        cellspacing="1" width="592">
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="pnlQuery" runat="server" Width="500px">
                    <div align="center" 
                        style="DISPLAY: inline; VISIBILITY: visible; OVERFLOW: auto; WIDTH: 540px; HEIGHT: 100px">
                        
                        <asp:DataGrid ID="dgQueries" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" BackColor="#F7F4EF" CssClass="row" 
                            DataKeyField="queryID" Font-Names="Arial" Font-Size="X-Small" 
                            ForeColor="#376080" OnItemCommand="dgQueries_selectItemEventHandler" 
                            onselectedindexchanged="dgQueries_SelectedIndexChanged" Width="500px" OnCancelCommand="dgQueries_CancelCommand" OnDeleteCommand="dgQueries_DeleteCommand" OnEditCommand="dgQueries_EditCommand" OnSortCommand="dgQueries_SortCommand" OnUpdateCommand="dgQueries_UpdateCommand">
                            <SelectedItemStyle BackColor="LightSteelBlue" ForeColor="White" />
                            <EditItemStyle HorizontalAlign="Center" />
                            <AlternatingItemStyle CssClass="row" />
                            <HeaderStyle BackColor="#ADBECC" Font-Bold="True" ForeColor="#465B87" 
                                Height="15px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateColumn Visible="False"></asp:TemplateColumn>
                                <asp:ButtonColumn CommandName="Select" HeaderText="select search" 
                                    Text="execute">
                                    <HeaderStyle HorizontalAlign="Center" Width="125px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ButtonColumn>
                                <asp:BoundColumn DataField="queryID" HeaderText="Query ID" Visible="False">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="queryName" HeaderText="saved search">
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" CancelText="cancel" 
                                    EditText="edit" UpdateText="update">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:EditCommandColumn>
                                <asp:ButtonColumn CommandName="Delete" Text="delete">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ButtonColumn>
                            </Columns>
                            <PagerStyle BackColor="#ADBECC" Font-Bold="True" Font-Size="X-Small" 
                                ForeColor="Blue" HorizontalAlign="Right" NextPageText="Next &gt;&gt;" 
                                Position="TopAndBottom" PrevPageText="&lt;&lt; Prev       " 
                                VerticalAlign="Bottom" />
                        </asp:DataGrid>
                                               </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center" class="style1" colspan="2">
                <asp:LinkButton ID="butNewQuery" runat="server" CssClass="regulargray" 
                    onclick="butNewQuery_Click">Create New Search</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lbInfo2" runat="server" CssClass="regulargray" Height="32px" 
                    Width="374px"></asp:Label>
            </td>
        </tr>
    </table>
 
    </form>
     <script type = "text/javascript">         

       function validatePortfolioName()
          {
             var textbox = document.getElementById("<%=txtPortfolioName.ClientID%>");
             if (textbox.value == '') {
                 alert('search name is required')
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
