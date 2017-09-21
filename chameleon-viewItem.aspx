<%@ Page Title="Chameleon Fine Lighting View Item" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-viewItem.aspx.cs" Inherits="IChameleon.chameleon_viewItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 88px;
        }
        .auto-style2 {
            width: 500px;
            height: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="pagename"><img src="images/chameleon-logo.png"/> Project Detail </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--bread start-->
<div class="bread">
  <div class="container">
    <ul>
      <li><a href="#">Home</a></li>
      <li>></li>
      <li><a href="#">Project</a></li>
      <li>></li>
      <li><asp:Label id="lbItem1" runat="server" /></li>
    </ul>
  </div>
</div>
<!--bread close-->

<!--middle text start-->
  <div class="container">
     <div class="product-detail">
       <div class="row">

         <div class="col-sm-1">
           <div class="thumb" id="thumbDiv" runat="server">             
           </div>
         </div>

         <div class="col-sm-6">
           <div class="big-image"><asp:Image id="Image1" runat="server" /></div>
         </div>

         <div class="col-sm-5">
           <div class="detail">
             <h1><asp:Label id="lbItem" runat="server" /></h1>
             <h2><asp:Label id="lbItemNo" runat="server" /> </h2>
             <h3><asp:Label id="lbItemClass" runat="server" /></h3>
             <p><asp:Label id="lbShownFinish" runat="server" /> </p> 
             <p><asp:Label id="lbDescription" runat="server" /> </p>
             <p>Lead Time:  <strong><asp:Label id="lbAvailability" runat="server" /></strong> </p>
               <div id="retailPricingTable" runat="server">                 
           
               </div>
             

           </div>
         </div>

         
       </div>
     </div> 
  </div>
<!--middle text close-->
</asp:Content>
