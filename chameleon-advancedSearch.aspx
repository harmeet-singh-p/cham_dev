<%@ Page Title="Chameleon Fine Lighting Advanced Search" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-advancedSearch.aspx.cs" Inherits="IChameleon.chameleon_advancedSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <strong>NSTRUCTIONS:</strong>&nbsp; The tools at the right allow you to tailor your 
        search and repeatedly refine it until you find the specific items you seek.&nbsp;
        <br />
        <br />
        Each box contains a different search category. To select criteria within a 
        category box just Ctrl-Click (hold down the Ctrl key and click the left mouse 
        button) to toggle the selection on or off. You can select multiple criteria from 
        as many category boxes as you like. Remember that multiple selections within a 
        box will function like an &quot;OR&quot; command while selections in seperate boxes 
        function like an &quot;AND&quot; command.
        <br />
        <br />
        Below the category boxes you can add further criteria to your search like 
        Dimensions, Price, etc. These also function like an &quot;AND&quot; command.<br />
        <br />
        The &quot;Search&quot; button at very bottom executes your search and loads the results 
        page. If the results aren&#39;t quite what you&#39;re looking for, click the &quot;Back&quot; 
        button on your browser to reload your search page. Refine your selections and 
        hit &quot;Search&quot; again. The &quot;Reset&quot; button at very bottom will allow you to start 
        again with a fresh search page.</p>
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="Table10" align="center" bgcolor="#f7f4ef" border="0" cellpadding="1" 
    cellspacing="1" width="100%">
    <tr>
        <td colspan="2">
            <p align="center">
                <strong><font class="regulargray_Label" color="#666666" face="Arial" size="2">
                Ctrl-Click to toggle selections on or off.&nbsp; Multiple selections from 
                multiple boxes are permitted.&nbsp; Click &quot;Back&quot; on your browser to refine your 
                search. </font></strong>
            </p>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="HEIGHT: 74px">
            <p align="center">
                <asp:Label ID="Label17" runat="server" CssClass="regulargray_Label" 
                    Width="221px">Please select a Product Line to search</asp:Label>
                <br />
                <asp:DropDownList ID="cboType" runat="server" Width="204px">
                    <asp:ListItem Value="ALL">ALL</asp:ListItem>
                    <asp:ListItem Value="Signature">Signature</asp:ListItem>
                    <asp:ListItem Value="Antique">Antique</asp:ListItem>
                </asp:DropDownList>
            </p>
        </td>
    </tr>
    <tr>
        <td style="HEIGHT: 8px">
            <p align="center">
                &nbsp;</p>
        </td>
        <td style="HEIGHT: 8px">
            <p align="center">
                &nbsp;</p>
        </td>
    </tr>
    <tr>
        <td style="HEIGHT: 8px">
            <p align="center">
                <asp:Label ID="Label1" runat="server" CssClass="regulargray_Label" 
                    Width="142px">Select Main Categories</asp:Label>
                <br />
                <asp:ListBox ID="lbCategories" runat="server" SelectionMode="Multiple" 
                    Width="150px"></asp:ListBox>
                <br />
            </p>
        </td>
        <td style="HEIGHT: 8px">
            <p align="center">
                <asp:Label ID="Label2" runat="server" CssClass="regulargray_Label" 
                    Width="142px">Select Sub Categories</asp:Label>
                <br />
                <asp:ListBox ID="lbSubCategories" runat="server" SelectionMode="Multiple" 
                    Width="150px"></asp:ListBox>
                <br />
            </p>
        </td>
    </tr>
    <tr>
        <td style="HEIGHT: 8px">
            <p align="center">
                <asp:Label ID="Label3" runat="server" CssClass="regulargray_Label" 
                    Width="142px">Select Styles</asp:Label>
                <br />
                <asp:ListBox ID="lbStyles" runat="server" SelectionMode="Multiple" 
                    Width="150px"></asp:ListBox>
                <br />
            </p>
        </td>
        <td style="HEIGHT: 8px">
            <p align="center">
                <asp:Label ID="Label4" runat="server" CssClass="regulargray_Label" 
                    Width="142px">Select Finishes</asp:Label>
                <br />
                <asp:ListBox ID="lbFinishes" runat="server" SelectionMode="Multiple" 
                    Width="150px"></asp:ListBox>
                <br />
            </p>
        </td>
    </tr>
    <tr>
        <td style="HEIGHT: 8px">
            <p align="center">
                <asp:Label ID="Label5" runat="server" CssClass="regulargray_Label" 
                    Width="127px">Select Materials</asp:Label>
                <br />
                <asp:ListBox ID="lbMaterials" runat="server" SelectionMode="Multiple" 
                    Width="150px"></asp:ListBox>
                <br />
            </p>
        </td>
        <td style="HEIGHT: 8px">
            <p align="center">
                <asp:Label ID="Label6" runat="server" CssClass="regulargray_Label" Height="2px" 
                    Width="142px">Select Origins </asp:Label>
                <br />
                <asp:ListBox ID="lbOrigins" runat="server" SelectionMode="Multiple" 
                    Width="150px"></asp:ListBox>
                <br />
            </p>
        </td>
    </tr>
    <tr>
        <td style="HEIGHT: 8px">
            <p align="center">
                <font color="#ff0000" face="Arial" size="2">
                <asp:Label ID="Label7" runat="server" CssClass="regulargray_Label" 
                    Width="150px">Select Years Manufactured</asp:Label>
                <br />
                </font>
                <asp:ListBox ID="lbYearManufactured" runat="server" SelectionMode="Multiple" 
                    Width="150px"></asp:ListBox>
            </p>
        </td>
        <td style="HEIGHT: 8px">
            <p align="center">
                <asp:Label ID="Label8" runat="server" CssClass="regulargray_Label" 
                    Width="142px">Select Manufacturers</asp:Label>
                <br />
                <asp:ListBox ID="lbManufacturer" runat="server" SelectionMode="Multiple" 
                    Width="150px"></asp:ListBox>
            </p>
        </td>
    </tr>
    <tr>
        <td style="HEIGHT: 8px">
        </td>
        <td style="HEIGHT: 8px">
        </td>
    </tr>
    <tr>
        <td colspan="2" style="HEIGHT: 8px">
            <table id="Table3" align="center" border="0" cellpadding="1" cellspacing="1" 
                style="HEIGHT: 82px" width="350">
                <tr>
                    <td align="left">
                        <font color="#ff0000" face="Arial" size="2">
                        <p align="center">
                            &nbsp;</p>
                        <p align="left">
                            <asp:Label ID="Label9" runat="server" CssClass="regulargray_Label" Width="59px">Height (in.)</asp:Label>
                            </font>
                        </p>
                    </td>
                    <td>
                        <p align="center">
                            <asp:DropDownList ID="cboHeightOperator" runat="server" Width="54px">
                                <asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
                                <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHeight" runat="server" Width="90px"></asp:TextBox>
                        <asp:CompareValidator ID="cvHeight" runat="server" 
                            ControlToValidate="txtHeight" ErrorMessage="Height must be Numeric" 
                            Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label10" runat="server" CssClass="regulargray_Label" 
                            Width="55px">Width (in.)</asp:Label>
                    </td>
                    <td>
                        <p align="center">
                            <asp:DropDownList ID="cboWidthOperator" runat="server" Width="54px">
                                <asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
                                <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                    </td>
                    <td>
                        <asp:TextBox ID="txtWidth" runat="server" Width="90px"></asp:TextBox>
                        <asp:CompareValidator ID="cvWidth" runat="server" ControlToValidate="txtWidth" 
                            ErrorMessage="Width must be Numeric" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label11" runat="server" CssClass="regulargray_Label" 
                            Width="58px">Depth (in.)</asp:Label>
                    </td>
                    <td>
                        <p align="center">
                            <asp:DropDownList ID="cboDepthOperator" runat="server" Width="54px">
                                <asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
                                <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepth" runat="server" Width="90px"></asp:TextBox>
                        <asp:CompareValidator ID="cvDepth" runat="server" ControlToValidate="txtDepth" 
                            ErrorMessage="Depth  must be Numeric" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <p align="left">
                            <asp:Label ID="Label15" runat="server" CssClass="regulargray_Label" 
                                Width="62px">Price (US $)</asp:Label>
                        </p>
                    </td>
                    <td>
                        <p align="center">
                            <asp:DropDownList ID="cboPriceOperator" runat="server" Width="54px">
                                <asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
                                <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" Width="90px"></asp:TextBox>
                        <asp:CompareValidator ID="cvPrice" runat="server" ControlToValidate="txtPrice" 
                            ErrorMessage="Invalid Price" Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <p align="left">
                            <asp:Label ID="Label14" runat="server" CssClass="regulargray_Label" 
                                Width="96px">Number of Lights</asp:Label>
                        </p>
                    </td>
                    <td>
                        <p align="center">
                            <asp:DropDownList ID="cboNumLightsOperator" runat="server" Width="54px">
                                <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
                                <asp:ListItem Value="=">=</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumLights" runat="server" Width="90px"></asp:TextBox>
                        <asp:CompareValidator ID="cvNumLights" runat="server" 
                            ControlToValidate="txtNumLights" ErrorMessage="Number ofLights must be Numeric" 
                            Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="Label16" runat="server" CssClass="regulargray_Label" 
                            Width="98px">Quantity Needed</asp:Label>
                    </td>
                    <td>
                        <p align="center">
                            <asp:DropDownList ID="cboQuantityOperator" runat="server" Width="54px">
                                <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
                                <asp:ListItem Value="=">=</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server" Width="90px"></asp:TextBox>
                        <asp:CompareValidator ID="cvQuantity" runat="server" 
                            ControlToValidate="txtQuantity" ErrorMessage="Quantity must be Numeric" 
                            Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="HEIGHT: 25px">
            <br />
            <table id="Table4" align="center" border="0" cellpadding="1" cellspacing="1" 
                width="300">
                <tr>
                    <td>
                        <font color="#ff0000" face="Arial" size="2">
                        <p align="left">
                            <asp:Label ID="Label12" runat="server" CssClass="regulargray_Label" 
                                Width="49px">Keyword</asp:Label>
                        </p>
                        </font>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtKeyword" runat="server" Width="118px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p align="left">
                            <asp:Label ID="Label13" runat="server" CssClass="regulargray_Label" 
                                Visible="False" Width="60px">Sort By</asp:Label>
                        </p>
                    </td>
                    <td>
                        <p align="left">
                            <asp:DropDownList ID="cboOrderBy" runat="server" Visible="False" Width="126px">
                                <asp:ListItem Value="itemNumber Desc">Item Number</asp:ListItem>
                                <asp:ListItem Value="price1 Desc">Price</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="HEIGHT: 8px">
            <p align="center">
                &nbsp;</p>
        </td>
        <td style="HEIGHT: 8px">
            &nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td style="HEIGHT: 27px">
            <p align="center">
                <asp:Button ID="butReset" runat="server" CausesValidation="False" 
                    OnClick="butReset_Click" Text="Reset" />
            </p>
        </td>
        <td style="HEIGHT: 27px">
            <p align="center">
                <asp:Button ID="butSearch" runat="server" OnClick="butSearch_Click" 
                    Text="Search" style="height: 26px" />
            </p>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <p align="center">
                &nbsp;</p>
            <asp:ValidationSummary ID="vsAdvancedSearch" runat="server" 
                ShowMessageBox="True" ShowSummary="False" />
            <p>
                <br />
                &nbsp;</p>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <p align="center">
                &nbsp;</p>
        </td>
    </tr>
</table>
</asp:Content>
