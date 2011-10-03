function send(json){
	json.valid=true;
	socket.emit('data',json);
}