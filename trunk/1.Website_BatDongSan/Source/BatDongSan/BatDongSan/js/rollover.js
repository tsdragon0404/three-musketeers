(
function()
{
	function a()
	{
		if(document.getElementsByTagName)
		{
			var b=document.getElementsByTagName("img");
			for(var d=0; d<b.length; d++)
			{
				var e=b[d].getAttribute("src");
				if(e)
				{
					if(e.match("_off\."))
					{
						var c=new Image();
						c.src=e.replace("_off\.","_on.");
						b[d].onmouseover=function()
						{
							this.setAttribute("src",this.getAttribute("src").replace("_off\.","_on."))
						};
						b[d].onmouseout=function(){
							this.setAttribute("src",this.getAttribute("src").replace("_on\.","_off."))
						};
						b[d].onmouseup=function()
						{
							this.setAttribute("src",this.getAttribute("src").replace("_on\.","_off."))
						}
					}
				}
			}
		}
	}
	if(window.addEventListener)
	{
		window.addEventListener("load",a,false)
	}
	else
	{
		if(window.attachEvent)
		{
			window.attachEvent("onload",a)
		}
	}
})();