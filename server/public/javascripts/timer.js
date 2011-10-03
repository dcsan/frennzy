// timer.js

GAME_SPEED = 1000;  // smaller is faster
GAME_FULL_TIME = 30;   // seconds for whole game

//// nextGame page

var countNum;

function startCountdown() {
    loadPanel("timer.html");
    countNum = 3;
    window.setTimeout(countDown, 1000);
}

var nextGameTimeout;
function countDown() {
    countNum--;
    console.log("count:" + countNum);
    if (countNum <= 0) {
        nextGame();
    } else {
        $("#counter").html(countNum);
        nextGameTimeout = window.setTimeout(countDown, 1000);
    }
}

function nextGame() {
    clearTimeout(nextGameTimeout); // can be set from clicking also
    // var n = randomInt(3);
    var n = "X";
    loadPanel("game" + n + ".html");
}



//////////////////////////////////////////////////////

// the main timer which stays across minigames
var mainTime;
var totalPlayers = 3;

function resetGame() {
    startMainTimer();
    startCountdown();
}

function newRound() {
    startMainTimer();
}


function startMainTimer() {
    mainTime = GAME_FULL_TIME;
    mainTick();
}

function mainTick() {
    mainTime--;
    $("#mainTimer").html("time: " + mainTime + " | totalPlayers: " + totalPlayers);
    if (mainTime <= 0) {
        killPlayer();
    } else {
        var mainTickTimeout = window.setTimeout(mainTick, GAME_SPEED);
    }

}

function killPlayer() {
    loadPanel("out.html");
    totalPlayers--;
    if (totalPlayers<=1) {
        endGame();
    } else {
        newRound();
    }
}


function endGame() {
    loadPanel("endGame");
}


