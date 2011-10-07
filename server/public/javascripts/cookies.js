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
  var raw = [];
  cookieValue=getCookie("options");
if (cookieValue!=null && cookieValue!="")
  {
  raw=cookieValue.split("<^>");
  json.username=raw[0];
  json.players=raw[1];
  json.paid=raw[2];
  json.credits=raw[3];
  json.phones=raw[4];
  json.freePlayers=raw[5];
  json.host=raw[6];
  }
else
  {
  var json={};
  json.username=prompt("Enter a nickname:","");
  if (json.username!=null && json.username!="")
    {
    json.players='1';
    json.paid='notPaid';
    json.credits='0';
    json.phones='single';
    json.freePlayers='1';
    json.host='host';
    raw=json.username+"<^>"+json.players+"<^>"+json.paid+"<^>"+json.credits+"<^>"+json.phones+"<^>"+json.freePlayers+"<^>"+json.host;
    setCookie("options",raw,365);
    window.location.assign('/top');
    }
  }
  return json;
}

function setOption(optionToSet,value){
  options[optionToSet]=value;
  writeCookies(options);
}

function writeCookies(json){
  $('.option').hide();
  $('.'+json.phones).show();
  $('.'+json.paid).show();
  $('.'+json.host).show();
  raw=json.username+"<^>"+json.players+"<^>"+json.paid+"<^>"+json.credits+"<^>"+json.phones+"<^>"+json.freePlayers+"<^>"+json.host;
  setCookie("options",raw,365);
}
