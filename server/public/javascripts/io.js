function send(json){
	json.valid=true;
	if(json.type=='toRoom'){//not finished
		json.room=fz.room;
	}
	socket.emit('data',json);
}

function joinRoom(room){//not finished
	json.nickname=fz.nickname;
	json.playerId=fz.id;
	json.type='joinRoom';
	send(json);
}

function leaveroom(nick){//not finished
	json.nickname=nick;
	json.room=fz.room;
	json.type='leaveRoom';
	send(json);
}
