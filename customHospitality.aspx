<%@ Page Title="" Language="C#" MasterPageFile="~/chameleonMaster.Master" AutoEventWireup="true" CodeBehind="customHospitality.aspx.cs" Inherits="IChameleon.customHospitality" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Start WOWSlider.com HEAD section -->
<link rel="stylesheet" type="text/css" href="engine1/style.css" />
<script type="text/javascript" src="engine1/jquery.js"></script>
<!-- End WOWSlider.com HEAD section -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    

    <div>
        
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" CssClass="infoTable">
            <asp:TableRow>
                <asp:TableCell>
                    <p>Chameleon Fine Lighting is often asked to create new custom lighting from 
                    original designs, or based on items either from our antique or signature line.&nbsp; 
                    We work with some of the most prominent architects and hospitality/contract 
                    firms in the world, including the Rockwell Group, Wilson Associates, and 
                    Alexandra Champalimaud.&nbsp; We also continue to work with some of America’s 
                    top residential designers, such as Barry Dixon and Associates, Holmes Newman and 
                    Partners, Mcmillen, Inc, and numerous others in helping their clients realize 
                    highly specific visions that can only be achieved by customization.&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#666666" 
                        PostBackUrl="~/RobProjects.aspx">CLICK HERE</asp:LinkButton>
                    &nbsp;to see some examples of these projects.
                </p>                
                    
                    <p>Chameleon Fine Lighting works in a full range of materials, including cast 
                    brass, iron, wrought iron, sheet metal, aluminum, molded and hand blown glass, 
                    cut crystal, rock crystal, alabaster and other natural stone.&nbsp; This range 
                    enables us to be able to provide clients multiple options on how to achieve 
                    their particular vision, and to choose the materials suitable in terms of scale 
                    and affordability.&nbsp;&nbsp; We are fully UL listed and can work with UL on 
                    special projects which fall outside general coverage.&nbsp; We also have full 
                    time CAD design personnel, critical to insuring that vision and reality match 
                    for both client and manufacturer.
                </p>                
                    
                <p>    Chameleon has a fully equipped, state of the art factory in Long Island City, 
                    New York, with highly experienced technicians able to execute a wide range of 
                    designs.&nbsp; We also have partnerships with highly skilled factories in Europe 
                    and the Far East which we can use depending on the scale of the job and 
                    materials used.&nbsp; We are happy to discuss any and all proposals regardless 
                    of size or complexity.&nbsp; We will always try to help you achieve the 
                    particular vision you are aiming for, be it elaborate, or a simple modification 
                    of a current design, and will discuss quantities large and small.
                </p>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <br />
    <br />

    <div>
    
    <!-- Start WOWSlider.com BODY section -->
<div id="wowslider-container1" style="text-align: center">
<div class="ws_images"><ul>
		<li><img src="data1/images/img_5503.jpg" alt="IMG_5503" title="IMG_5503" id="wows1_0"/></li>
		<li><img src="data1/images/img_5547.jpg" alt="IMG_5547" title="IMG_5547" id="wows1_1"/></li>
		<li><a href="http://wowslider.net"><img src="data1/images/img_5745.jpg" alt="http://wowslider.net/" title="IMG_5745" id="wows1_2"/></a></li>
		<li><img src="data1/images/img_5753.jpg" alt="IMG_5753" title="IMG_5753" id="wows1_3"/></li>
	</ul></div>
<div class="ws_script" style="position:absolute;left:-99%"><a href="http://wowslider.net">jquery carousel</a> by WOWSlider.com v8.7</div>
<div class="ws_shadow"></div>
</div>	
<script type="text/javascript" src="engine1/wowslider.js"></script>
<script type="text/javascript" src="engine1/script.js"></script>
<!-- End WOWSlider.com BODY section -->
    </div>
</asp:Content>
