function getCookie(c_name){
var i,x,y,ARRcookies=document.cookie.split(";");
for (i=0;i<ARRcookies.length;i++)
  {
  x=ARRcookies[i].substr(0,ARRcookies[i].indexOf("="));
  y=ARRcookies[i].substr(ARRcookies[i].indexOf("=")+1);
  x=x.replace(/^\s+|\s+$/g,"");
  if (x==c_name)
    {
    return unescape(y);
    }
  }
}

function setCookie(c_name,value,exdays){
var exdate=new Date();
exdate.setDate(exdate.getDate() + exdays);
var c_value=escape(value) + ((exdays==null) ? "" : "; expires="+exdate.toUTCString());
document.cookie=c_name + "=" + c_value;
}

function checkUser(){
var username=getCookie("username");
if (username!=null && username!="")
  {
  alert("Welcome again " + username);
  send({'type':'toDb','action':username});
  window.location.assign('/top');
  }
else 
  {
  username=prompt("Please enter a nickname:","");
  if (username!=null && username!="")
    {
    setCookie("username",username,365);
    send({'type':'toDb','action':username});
    window.location.assign('/top');
    }
  }
}