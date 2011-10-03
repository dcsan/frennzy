var rotMax;    // initial difficulty
var rot;
var accel;
var difficultySpeedUp = 0.01;
var countup = 0;
var CHANGE_SPEED = 100;
var frameRate = 30;     // fps
var updateSpeed = (1000/frameRate);  // millis per update
var slideSpeed = 0.1;
var orient;
var tipSpeed = 0.5; // bigger is faster

var beerx;
var MAX_BEERX = 100;    // falling area
//FIXME try not to use hard pixel sizes
var beerx_offset = 120; // pixel offset

function init() {
    intro();

    $("#replay").animate({
        transform: "translateY(-250)"
    })

    accel = 0;
    rot = 0;
    rotMax = 3;
    countup = 0;
    beerx = 0;
}

function playAgain() {
    init();
}


function tip(rot) {
    trans = 'rotate( ' + rot + ' )';
    $('#tray').css({transform: trans });
}

function intro() {
    $('#tray').
        animate({transform: "rotate( 0.3)" }).
        animate({transform: "rotate(-0.4) scale(1.5)" }).
        animate({transform: "rotate( 0.5)" }).
        animate({transform: "rotate(   0) scale(1) " }); 

    setTimeout(update, 2000);
    setTimeout(showBeer, 2500);

}

function showBeer() {
    $("#beer1").animate({transform: "translateY(140)"})
}

function dropBeer() {
    gameover = true;
    $("#beer1").animate({transform: "translateY(800)"});
    log("gameover!");
    $("#replay").css("visibility", "visible");
    $("#replay").css("top", -200);
    $("#replay").animate({
        transform: "translateY(50%)"
    })

}


function update() {
    if (countup++ > CHANGE_SPEED) {
        // new accel
        accel = randomInt(rotMax) * randomSign();
        rotMax += difficultySpeedUp;
        dbg2("rotMax:" + rotMax + "  difficultySpeedUp: " + difficultySpeedUp);
    }

    rot += accel;
    tip(rot + "deg");

    beerx += rot * slideSpeed;
    $('#beer1').css("left", beerx + beerx_offset);

    if (countup % 10 == 0) {
        dbg1("rot:" + rot + "  accel:" + accel + "  beerx:" + beerx );
    }

    if (orient) { // undefined on chrome
        rot += (orient.x) * tipSpeed;
    }

    if (beerx > MAX_BEERX || beerx < -MAX_BEERX) {
        dropBeer();
    } else {
        setTimeout(update, updateSpeed);
    }
    // dbg1("rot: " + rot + "  rotMax: " + rotMax)
}


window.ondevicemotion = function(event) {
    var x = event.accelerationIncludingGravity.x * 100;
    var y = event.accelerationIncludingGravity.y * 100;
    var z = event.accelerationIncludingGravity.z * 100;

    x = Math.round(x);
    y = Math.round(y);
    z = Math.round(z);

    dbg("x:" + x + "   y:" + y + "  z:" + z, 3);

    orient = event.accelerationIncludingGravity;
    
}

window.ondeviceorientation = function(event) {
    var a = event.alpha;
    var b = event.beta;
    var g = event.gamma;
    dbg("a:" + a + " b:" + b + " g:" + g, 4);
}



