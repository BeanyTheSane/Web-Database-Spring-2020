 function change_tab(id)
 {
   document.getElementById("page_content").innerHTML=document.getElementById(id+"ContentPage").innerHTML;
   document.getElementById("webforms").className="notselected";
   document.getElementById("mvc").className="notselected";
   document.getElementById("core").className="notselected";
   document.getElementById(id).className="selected";
 }