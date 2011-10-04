var express = require('express')
, stylus = require('stylus')
, nib = require('nib')
, sio = require('socket.io');

function init(){
	var app = express.createServer();
	
	app.configure(function() {
		app.use(stylus.middleware({src:'./ninja/css/',compile:compile}))
		app.use(express.static('./ninja/public'));
		app.set('views','./ninja/views');
		app.set('view engine', 'ejs');
		
	function compile(str,path){
		return stylus(str)
			.set('filename', path)
			.use(nib());
	};
	});
	
	app.get('/', function(req,res){
		res.render('landing',{layout:false});
	});

	app.listen(80,function(){
		var addr=app.address();
		console.log('listening on'+addr.port);
	});
	return app;
}

exports.init=init;