<%@ Page Title="Chameleon Fine Lighting Contact Us" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-contact.aspx.cs" Inherits="IChameleon.chameleon_contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="pagename"><img src="images/chameleon-logo.png"/> Contact Us </div>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <font color="#ffffff"><font class="regularBackground" face="Arial">
        <font class="regular" size="2"><font class="regularBackground" face="Arial">
        <font class="regular" size="2">&nbsp;Welcome to Chameleon Fine Lighting, your design 
        source for quality antique and replica lighting.
        <br />
        <br />
        Use the QUICK LINKS below to speed your search:</font></font></font></font></font></p>
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--bread start-->
<div class="bread">
  <div class="container">
    <ul>
      <li><a href="#">Home</a></li>
      <li>></li>
      <li>Contact Us</li>
    </ul>
  </div>
</div>
<!--bread close-->
    <!--middle text start-->
<div class="contact">
  <div class="container">
       <h1>
Thank you for taking the time to contact us at Chameleon. If you have any comments, opinions, or ideas regarding services, or ways to make this site more valuable to you, please do not hesitate to tell us. We truly appreciate your comments and feedback.</h1>
     
    <div class="row">
      <div class="col-sm-4">
        <div class="box"><img src="images/contact-icon2.png" /><p><strong>Call Us</strong></p><p>PH: 212.355.6300</p><p>FX: 212.355.5390</p></div>
      </div>
      <div class="col-sm-4">
        <div class="box"><img src="images/contact-icon3.png" /><p><strong>Write Us</strong></p><p>mail@chameleon59.com</p></div>
      </div>

     <div class="col-sm-4">
        <div class="box"><img src="images/contact-icon1.png" /><p><strong>Address</strong></p><p>Chameleon Fine Lighting
233 Lafayette Street
New York, NY 10012
Attn: Robert Degiarde</p></div>
      </div>
    </div> 
  </div>

<div class="map">
 <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d387193.30591910525!2d-74.25986432970714!3d40.69714942211302!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89c24fa5d33f083b%3A0xc80b8f06e177fe62!2sNew+York%2C+NY%2C+USA!5e0!3m2!1sen!2sin!4v1504680495757" width="100%" height="100%" frameborder="0" style="border:0" allowfullscreen></iframe>
</div>  
  
</div>
<!--middle text close-->
</asp:Content>
