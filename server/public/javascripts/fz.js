function defineFz(){
var fz=readCookies();

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
  json.game=raw[7];
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
    json.game='none';
    json.players=['Ninja','DC','Aaron','Brian','Alex','John'];
    raw=json.username+"<^>"
    raw+=json.numPlayers+"<^>"
    raw+=json.paid+"<^>"
    raw+=json.credits+"<^>"
    raw+=json.phones+"<^>"
    raw+=json.freePlayers+"<^>"
    raw+=json.host+"<^>"
    raw+=json.game;
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

fz.save=function writeCookies(){
//  $('.option').hide();
//  $('.'+json.phones).show();
//  $('.'+json.paid).show();
//  $('.'+json.host).show();
  var raw=fz.username+"<^>"
  raw+=fz.numPlayers+"<^>"
  raw+=fz.paid+"<^>"
  raw+=fz.credits+"<^>"
  raw+=fz.phones+"<^>"
  raw+=fz.freePlayers+"<^>"
  raw+=fz.host+"<^>"
  raw+=fz.game;
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

fz.send=function send(json){
	json.valid=true;
//	if(json.type=='toRoom'){//not finished
//		json.room=fz.room;
//	}
	socket.emit('data',json);
}

function joinRoom(room){//not finished
	json.nickname=fz.nickname;
	json.playerId=fz.id;
	json.type='joinRoom';
	send(json);
}

function leaveRoom(nick){//not finished
	json.nickname=nick;
	json.room=fz.room;
	json.type='leaveRoom';
	send(json);
}

fz.view=function view(pageName){
	$('.page').hide();
	$('#'+pageName).show();
}


return fz;
}
