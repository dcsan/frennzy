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

function readCookies(){
  var json={};
  json.username=getCookie("username");
  json.players=getCookie("players");
  json.platform=getCookie("platform");
  return json;
}

function writeCookies(json){
if (json.username!=null && json.username!="")
  {
    setCookie("username",json.username,365);
    setCookie("players",json.players,365);
    setCookie("platform",json.platform,365);
  }
else
  {
  var json={};
  json.username=prompt("Please enter a nickname:","");
  if (json.username!=null && json.username!="")
    {
    setCookie("username",json.username,365);
    send({'type':'toDb','action':json.username});
    setCookie("players","",365);
    setCookie("platform","",365);
    window.location.assign('/top');
    }
  }
}
