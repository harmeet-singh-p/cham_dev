<%@ Page Title="Chameleon Fine Lighting Accessories" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-accessories.aspx.cs" Inherits="IChameleon.chameleon_accessories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <font color="#ffffff"><font class="regularBackground" face="Arial">
        <font class="regular" size="2">se the QUICK LINKS below to speed your search:</font></font></font></p>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="pagename"><img src="images/chameleon-logo.png"/> Accessories </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--bread start-->
<div class="bread">
  <div class="container">
    <ul>
      <li><a href="#">Home</a></li>
      <li>></li>
      <li>Accessories</li>
    </ul>
  </div>
</div>
<!--bread close-->
    <!--middle text start-->
<div class="container">
  <div class="showroom">
     
     <div class="col-sm-3">
       <div class="signature-box">
         <h3>Accessories</h3>
         <p>Browse our inventory by category with these search tools</p>
         <form runat="server">
         <ul>
          <li><label>Accessories</label>
          <asp:DropDownList ID="cboAccessories" runat="server" AutoPostBack="True" class="text" 
                                onselectedindexchanged="cboAccessories_SelectedIndexChanged" >
              <asp:ListItem Value="All">All</asp:ListItem>
                            </asp:DropDownList>          
          </li>
          
         </ul>
             </form>
       </div>
     </div>
     
     <div class="col-sm-9">
     
      <div class="row middle">
         <div class="col-sm-8">
           <div class="result"><p><strong>
               <asp:Label ID="lbSearchHeading" runat="server"></asp:Label>
                                  </strong>
               <asp:Label ID="lbInfo" runat="server">Click Image below to Display Details </asp:Label>
                               </p></div>
         </div>
         <div class="col-sm-4">
          <div class="search">
              <asp:Label ID="lbSortBy" runat="server">Sort By</asp:Label>
              <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="True" class="text">
                            </asp:DropDownList>
          </div>
         </div>
      </div>
      
           <asp:PlaceHolder ID="phTopNav" runat="server"></asp:PlaceHolder>
      
           <div id="imageDisplay" class="row" runat="server"></div>
               
          <asp:PlaceHolder ID="phBottomNav" runat="server"></asp:PlaceHolder>

        
        

 
        
      
      
      </div>
      
  </div>
</div>
       
<!--middle text close-->
</asp:Content>
