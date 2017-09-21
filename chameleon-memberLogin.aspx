<%@ Page Title="Chameleon Fine Lighting Member Login" Language="C#" MasterPageFile="~/ICham.Master" AutoEventWireup="true" CodeBehind="chameleon-memberLogin.aspx.cs" Inherits="IChameleon.chameleon_memberLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       
        
    </style>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>--%>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--bread start-->
<div class="bread">
  <div class="container">
    <ul>
      <li><a href="#">Home</a></li>
      <li>></li>
      <li>Login</li>
    </ul>
  </div>
</div>
<!--bread close-->

<!--middle text start-->
<div class="login">
  <div class="container">
    <div class="row flex1">

      <div class="col-sm-6">
        <div class="box">
          <h2>Login</h2>
          <p>Already a registered member?Login below.</p>
            <form runat="server">
          <ul>
           <li>
               <asp:TextBox ID="txtUserName" runat="server" class="text" placeholder="Username"></asp:TextBox>
           </li>
           <li>
               <asp:TextBox ID="txtPassword" class="text" placeholder="Password" runat="server" TabIndex="2" TextMode="Password"></asp:TextBox>
           </li>
           <li>
               <asp:Button ID="butLogin" value="submit" class="btn" runat="server" OnClick="butLogin_Click" TabIndex="3"
                        Text="Login" />
               <a href="#">forgot password?</a></li>
          </ul>
                </form>
        </div>
      </div>

      <div class="col-sm-6">
        <div class="box">
          <h2>Signup</h2>
          <p>Not yet a registered member?  Register below.</p>
          <ul>
           <li><a href="#">Create an account</a></li>
          </ul>
        </div>
      </div>

      
    </div>
  </div>
</div>
<!--middle text close-->

</asp:Content>
