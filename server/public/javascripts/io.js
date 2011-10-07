function send(json){
	json.valid=true;
	if(json.type=='toRoom'){//not finished
		json.room=options.room;
	}
	socket.emit('data',json);
}

function joinRoom(room){//not finished
	json.nickname=options.nickname;
	json.playerId=options.id;
	json.type='joinRoom';
	send(json);
}

function leaveroom(nick){//not finished
	json.nickname=nick;
	json.room=options.room;
	json.type='leaveRoom';
	send(json);
}
