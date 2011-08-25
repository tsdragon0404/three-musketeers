function myImageUpload(editor)
{
  var imageFileName = null;
  var imageFileTitle = null;

  function postback(doc,popup_iframe)
  {
    if(doc != null) // Upload clicked
    {
      if(doc.getElementById("path").value != "")
      {
        var frm = doc.getElementById("fraExecute");

        function onLoad()
        {
          setTimeout(function()
                    {
                     if(frm.detachEvent)
                        frm.detachEvent("onload", onLoad);
                     else
                     if(frm.removeEventListener)
                        frm.removeEventListener("load", onLoad, true);

                     imageFileName = frm.contentWindow.imageFileName;
                     imageFileTitle = frm.contentWindow.imageFileTitle;

                     if(imageFileName == null)
                        alert(frm.contentWindow.imageSaved);

                     popup_iframe.contentWindow.document.getElementById("cancel").onclick();  // emulate Cancel pressed
                    },0);
        }

        if(frm.attachEvent)
           frm.attachEvent("onload", onLoad);
        else
        if(frm.addEventListener)
           frm.addEventListener("load", onLoad, true);

        try{doc.getElementById("frmFile").submit();}
        catch(e)
        {
          alert(e.message);

          if(frm.detachEvent)
             frm.detachEvent("onload", onLoad);
          else
          if(frm.removeEventListener)
             frm.removeEventListener("load", onLoad, true);

         popup_iframe.contentWindow.document.getElementById("cancel").onclick();
        }
        return false;
      }
    }
    else  // Cancel clicked or emulated
    {
      if(imageFileName != null)
      {
        editor.focusEditor();
        editor.InsertHTML("<img src=\""+imageFileName+"\" alt=\""+imageFileTitle+"\" title=\""+imageFileTitle+"\" />");
      }
    }
  }

  function init(doc,popup_iframe)
  {
    if(doc != null)
    {
        doc.getElementById("title").value = "";
        if(document.all)
        {
          popup_iframe.style.display = "none";
          doc.getElementById("path").click();
          popup_iframe.style.display = "";
          if(doc.getElementById("path").value == "")
            popup_iframe.contentWindow.document.getElementById("cancel").onclick();
        }
    }
  }

  editor.customPopup("popup_image_upload","image-upload","__cs_myImageUpload.aspx",postback,init, false, false);
}