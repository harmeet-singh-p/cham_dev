<%@ Page Title="Chameleon Fine Lighting Recent Projects" Language="C#" MasterPageFile="~/Icham.Master" AutoEventWireup="true" CodeBehind="chameleon-recentProjects.aspx.cs" Inherits="IChameleon.chameleon_recentProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="pagename"><img src="images/chameleon-logo.png"/> Our Projects </div>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
    <!--pop up start-->

<div class="backoverlay" style="display:none;">
  <div class="popup">
    <div class="cut">X</div>
    
    <div class="showroom-pop">
      <div class="text">
       <h3>Book Antiqua</h3>
       <p>Custom wrought iron chandelier conceptualized by Barry Dixon and realized by Chameleon craftsmen.</p>
       <ul>
           <li><a href="projects-list.html">Traditional</a></li>
           <li><a href="projects-list.html">Contemporary</a></li>
           <li><a href="projects-list.html">Entire Inventory</a></li>
           <li><a href="projects-list.html">All Signature</a></li>
           <li><a href="projects-list.html">Recent Arrivals</a></li>
       </ul>
       <p>To search by item number or keyword enter it below and click 'Submit'.</p>
       <div class="search"><input type="text" value="Search Here" class="text" /><input name="" type="button" value="Search" class="btn" /></div>
       <div class="likes">
           <div><a href="https://www.pinterest.com/chameleonlights/pins/follow/?guid=2ehhT8FH_eSo"><img src="images/pintrest.jpg" /></a></div>
           <div><iframe src="https://www.facebook.com/plugins/like.php?href=http://www.facebook.com/pages/Chameleon-Fine-Lighting/306133766072222"></iframe></div>
      </div>
      </div>
      <div class="img"><img src="images/project-image1.jpg" /></div>
    </div>
    
  </div>
</div>

<!--pop up close-->

    <!--bread start-->
<div class="bread">
  <div class="container">
    <ul>
      <li><a href="#">Home</a></li>
      <li>></li>
      <li>Our Projects</li>
    </ul>
  </div>
</div>
<!--bread close-->

<!--middle text start-->
<div class="container">
  <div class="showroom">
    <h1>Here are just a few past projects which Chameleon Fine Lighting has realized in conjunction with some of the most prominent Architects, Designers, and Hospitality/Contract firms in the world. Click thumbnail to view</h1>  
      <div class="row">
           <asp:Repeater ID="dlProjects" runat="server" >
               <ItemTemplate>
                   <div class="col-sm-3">
                       <div class="box">
                         <div class="img"><div class="overlay">&nbsp;</div>
                              <a title="Click on Image to View Details" href='javascript:viewItemWin("chameleon-viewProject.aspx?projectID=<%# Server.UrlEncode(DataBinder.Eval(Container.DataItem, "projectID").ToString())%>")'>
                          <asp:Image title="Click on Image to View Details"  id="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "projectThumbnail") %>' cssclass="thumbnailimage">

                          </asp:Image>
                        </a>
                         </div>
                         <div class="text"><div class="title">
                             <%# DataBinder.Eval(Container.DataItem, "projectTitle") %></div>
                             <p><%# DataBinder.Eval(Container.DataItem, "projectSummary") %></p></div>
                       </div>
                    </div>
               </ItemTemplate>
           </asp:Repeater>
        

        
 
        
      </div>
  </div>
</div>
       
<!--middle text close-->

    
</asp:Content>
