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
  var players=[];
  optionsCookie=getCookie("fz");
  playersCookie=getCookie("players");
if (optionsCookie!=null && optionsCookie!="")
  {
  raw=optionsCookie.split("<^>");
  players=playersCookie.split("<^>");
  json.username=raw[0];
  json.numPlayers=raw[1];
  json.paid=raw[2];
  json.credits=raw[3];
  json.phones=raw[4];
  json.freePlayers=raw[5];
  json.host=raw[6];
  json.players=players;
  }
else
  {
  var json={};
    json.username='alphaman';
    json.numPlayers='1';
    json.paid='notPaid';
    json.credits='0';
    json.phones='single';
    json.freePlayers='1';
    json.host='host';
    json.players=['alphaman','player2','player3','player4','player5','player6'];
    raw=json.username+"<^>"+json.numPlayers+"<^>"+json.paid+"<^>"+json.credits+"<^>"+json.phones+"<^>"+json.freePlayers+"<^>"+json.host;
    setCookie("fz",raw,365);
    raw='';
    for(i=1;i<=json.players.length;i++){
    raw+=json.players[i-1];
    if(i!=json.players.length){
    raw+='<^>';
    }
        setCookie("players",raw,365);
    }
  }
  return json;
}

function setOption(optionToSet,value){
  fz[optionToSet]=value;
  writeCookies(fz);
}

function writeCookies(json){
//  $('.option').hide();
//  $('.'+json.phones).show();
//  $('.'+json.paid).show();
//  $('.'+json.host).show();
  var raw=json.username+"<^>"+json.numPlayers+"<^>"+json.paid+"<^>"+json.credits+"<^>"+json.phones+"<^>"+json.freePlayers+"<^>"+json.host;
  setCookie("fz",raw,365);
  raw='';
  for(i=1;i<=fz.players.length;i++){
    raw+=fz.players[i-1];
    if(i!=fz.players.length){
    raw+='<^>';
    }
  }
  setCookie("players",raw,365);
}