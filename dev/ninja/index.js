var express = require('express')
, stylus = require('stylus')
, nib = require('nib')
, server = require('./server')
, sio = require('socket.io');

app=server.init();

var io=sio.listen(app);

var count=0
,title="Guess the Picture"
,role='guesser'
,sockets=[];

io.sockets.on('connection',function(socket){
	socket.on('initial',function(){
		sockets.push(socket.id);
		if(socket.id==sockets[0]){
			role='drawer';
		}
		else{
			role='guesser';
		}
		io.sockets.emit('setup',title,socket.id,role);
		console.log(sockets);
	});

	socket.on('draw',function(x,y){
		io.sockets.emit('drawit',x,y);
	});
	
	socket.on('clear',function(){
		io.sockets.emit('clear');
	})

	socket.on('disconnect',function(){
		delete sockets[sockets.indexOf(socket.id)];
		console.log('disconnect');
	});
});
