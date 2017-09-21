
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
function openWindow(theURL) {
	   	w = screen.availWidth;
	   	h = screen.availHeight;
		var popW = 815, popH = 676;
		var leftPos = (w-popW)/2, topPos = (h-popH)/2;
		OpenWin = this.open(theURL, 'CtrlWindow', 'resizable=yes,scrollbars=no,width=' + popW + ',height=' + popH + ',top=' + topPos + ',left=' + leftPos);
}
function openWindow2(theURL) {
	   	w = screen.availWidth;
	   	h = screen.availHeight;
		var popW = 901, popH = 676;
		var leftPos = (w-popW)/2, topPos = (h-popH)/2;
		OpenWin = this.open(theURL, 'CtrlWindow', 'resizable=yes,scrollbars=no,width=' + popW + ',height=' + popH + ',top=' + topPos + ',left=' + leftPos);
}


function refresh()
{	
	document.all('cboCeiling').selectedIndex = 0;
	document.all('cboWall').selectedIndex = 0;
	document.all('cboLamps').selectedIndex = 0;
	document.all('cboDate').selectedIndex = 0;
	//alert('shit');
}

// open large window
function viewItemWin(doc) {
    var mRef = window.open(doc, "Test", "toolbar=1, location=0, title=help, directories=0, status=1, resizable=1, menubar=1, scrollbars=1, left=150, top=0");
    mRef.focus();
} 

function addItemWin(doc)
{
window.open(doc,"name","width=550,height=500,directories=0,toolbar=0,resizable=0,menubar=0,scrollbars=1, alwaysRaised, left=250, top=150");
}

function infoWin(doc)
{
window.open(doc, name ,"width=300,height=300,directories=0,toolbar=0,resizable=0,menubar=0,scrollbars=1, alwaysRaised, left=250, top=150");
}

function largeWin(doc)
{
window.open(doc,"name","width=700,height=800,directories=0,toolbar=0,resizable=0,menubar=0,scrollbars=1, alwaysRaised, left=250, top=150");
}

function openMediumWin(doc)
{
	window.open(doc,"name","width=450,height=500,directories=0,toolbar=0,resizable=0,menubar=0,scrollbars=1, alwaysRaised, left=250, top=150");	
	//return true;
}

function startHighlight(gridName)
  {
	//alert('in');
    if (document.all && document.getElementById)
    { 
		
      navRoot = document.getElementById(gridName);
	if(navRoot == null)
	{		
		return;
	}     
     // Get a reference to the TBODY element 
     tbody = navRoot.childNodes[0];
      
      for (i = 1; i < tbody.childNodes.length; i++)
      {
        node = tbody.childNodes[i];
        if (node.nodeName == "TR")
        {			
          node.onmouseover=function()
          {
            this.className = "over";                
          }
          
          node.onmouseout=function()
          {
            this.className = this.className.replace("over", "");
          }
        }
      }
    }
  }

function goBack()
{
	history.go(-1);
}

function validateLogin()
{
	if(document.all('txtUserName').value == '')
	{	
		alert('username is required')
		Form1.txtUserName.focus();
		//Form1.txtUserName.select();
		return false;
	}
	else if(document.all('txtPassword').value == '')
	{	
		alert('password is required')
		Form1.txtPassword.focus();
		//Form1.txtPassword.select();
		return false;
	}	
	else
	{
		return true;
	}
} 

function validateQuery()
{

	if(document.all('txtQueryName').value == '')
	{
		alert('search name is required')
		Form1.txtQueryName.focus();
		return false;
	}	
	else
	{
		return true;
	}			

}

function validatePortfolioName()
{	
	if(document.all('txtPortfolioName').value == '')
	{
		alert('portfolio name is required')
		Form1.txtPortfolioName.focus();
		return false;
	}	
	else
	{
		return true;
	}
}

function validateItem()
 {

	if(document.all('txtItemCode').value == '')  
    if(clientID == '') 
	{
		alert('item is required')
		Form1.txtItemCode.focus();
		return false;
	}	
	else
	{
		return true;
	}
}

function pwLength()
{
	if(document.all('txtPassword').value.length < 6)
	{	
		alert('password must be at least 6 characters long')
		Form1.txtPassword.focus();
		Form1.txtPassword.select();
		return false;
	}
	else
	{
		return true;
	}
}

function setFocus(controlName)
{
	if(controlName == "txtUserName")
		Form1.txtUserName.focus();
}

function getVars()
{
	self.focus();
	var item;
	var itemNumber;
	varArray = document.location.href.split('?')[1].split('&');

	for(var x=0; x < varArray.length; x++)
	{
		var tmp = varArray[x].split('=');
		eval(unescape(tmp[0]) + '="' + unescape(tmp[1]) + '"');

		if(tmp[0] == "item")
		{
			item =  tmp[1];
		}

		if(tmp[0] == "itemID")
		{
			itemNumber =  tmp[1];	
		}
	} 
	
		document.title = item + " - " + itemID;
		
}

// define image variables & preload images
if(document.images)
{
	butAdvancedSearch2 = new Image();
	butAdvancedSearch2.src = "images/butAdvancedSearch2.gif";

	butAllInventory2 = new Image();
	butAllInventory2.src = "images/butAllInventory2.gif";	

	butAllAntiques2 = new Image();
	butAllAntiques2.src = "images/butAllAntiques2.gif";	

	butAllSignature2 = new Image();
	butAllSignature2.src = "images/butAllSignature2.gif";

	butAllAccessories2 = new Image();
	butAllAccessories2.src = "images/butAllAccessories2.gif";

	butRegister2 = new Image();
	butRegister2.src = "images/butRegister2.gif";

	butLogin2 = new Image();
	butLogin2.src = "images/butLogin2.gif";

	butRequestCatalog2 = new Image();
	butRequestCatalog2.src = "images/butRequestCatalog2.gif"	

	butMyHomepage2 = new Image();
	butMyHomepage2.src = "images/butMyHomepage2.gif";

	butMyAccount2 = new Image();
	butMyAccount2.src = "images/butMyAccount2.gif";

	lbAllAntiques2 = new Image();
	lbAllAntiques2.src = "images/lbAllAntiques2.gif";	

	lbAllSignature2 = new Image();
	lbAllSignature2.src = "images/lbAllSignature2.gif";
	
	lbbutSubmit2 = new Image();
	lbbutSubmit2.src = "images/butSubmit2.gif";
	
	lbbutReset2 = new Image();
	lbbutReset2.src = "images/butReset2.gif";	
		

	// display rollover images
	var name;
	var origName;
	
	function display(name)
	{	
		origName=document[name].src;
		document[name].src= eval(name + "2.src");
	}
	// return rollover images to original state
	function fix(name)
	{		
		document[name].src=origName;
	}

}	

