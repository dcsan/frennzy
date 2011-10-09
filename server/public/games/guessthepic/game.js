var role="drawer";
var drawx=[];
var drawy=[];
var mydrawx=[];
var mydrawy=[];
var pointx;
var pointy;
var mousedown=false;
var emit = {};

socket.on('clear',function(){
	drawx=[];
	drawy=[];
});

socket.on('endround',function(json){
	window.location.assign("/games/guessthepic/gameover");
});

function init(){
        var kin = new Kinetic_2d("drawing");
        var canvas = kin.getCanvas();
        var context = kin.getContext();
    if(role=='drawer'){
	socket.on('draw',function(json){
		drawx.push(json.x);
		drawy.push(json.y);
		if(drawx.length>1){
			var i=drawx.length-1;
 			context.moveTo(drawx[i-1],drawy[i-1]);
        	context.lineTo(drawx[i],drawy[i]);
        	context.stroke();
    };
	})};
	if(role=='drawer'){
	document.onmousedown=function(event){
		mousedown=true;
	};
	document.onmousemove= function(event){
		if(mousedown==true){
			emit = {'type':'toRoom','action':'draw','x':event.pageX,'y':event.pageY}
			fz.send(emit);
			mydrawx.push(event.pageX);
			mydrawy.push(event.pageY);
		if(mydrawx.length>1){
			var i=mydrawx.length-1;
 			context.moveTo(mydrawx[i-1],mydrawy[i-1]);
        	context.lineTo(mydrawx[i],mydrawy[i]);
        	context.stroke();
    };
		}}
	document.onmouseup= function(event){
		mousedown=false;
		fz.send({'type':'toRoom','action':'clear'});
		mydrawx=[];
		mydrawy=[];
	};
	document.ontouchmove= function(event){
			event.preventDefault();
			emit = {'type':'toRoom','action':'draw','x':event.touches[0].pageX,'y':event.touches[0].pageY};
			fz.send(emit);
			mydrawx.push(event.touches[0].pageX);
			mydrawy.push(event.touches[0].pageY);
		if(mydrawx.length>1){
			var i=mydrawx.length-1;
 			context.moveTo(mydrawx[i-1],mydrawy[i-1]);
        	context.lineTo(mydrawx[i],mydrawy[i]);
        	context.stroke();
    };
	}
	document.ontouchend= function(event){
		fz.send({'type':'toRoom','action':'clear'});
		mydrawx=[];
		mydrawy=[];
	};

	};
};