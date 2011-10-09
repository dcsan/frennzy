var mongoose = require('mongoose'),
    Schema = mongoose.Schema;

var User = new Schema({
	id: {type: Schema.ObjectId, index: true},
	nick: {type: String, index: true},
	facebookId: {type: Number, index: true},
	join: Date,
	lastOn: Date,
	password: String,
	passwordSalt: String,
});

var Game = new Schema({
	id: {type: Schema.ObjectId, index: true},
	name: {type: String, index: true},
	dir: String,
	name: String,
	played: Date,
	players: [players]
});

var Group = new Schema({
	id: {type: Schema.ObjectId, index: true},
	name: {type: String, index: true},
	type: String,
	players: [players],
});




exports.toDb=toDb;
exports.fromDb=fromDb;
