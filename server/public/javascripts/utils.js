function log(str) {
    console.log(str);
}

function randomInt(n) {
    return (Math.floor(Math.random()*n));
}

function randomSign() {
    s = ( randomInt(2)==1 ? -1 : 1);
    return(s);
}

function dbg1(str) {
    $('#dbg1').text(str);
}

function dbg2(str) {
    $('#dbg2').text(str);
}

function dbg3(str) {
    $('#dbg3').text(str);
}

function dbg(str, dbgid) {
    tag = "#dbg" + dbgid;
    $(tag).text(str);
}

var dbgFlag = true;
function toggleDebug() {
    dbgFlag = !dbgFlag;
    visFlag = (dbgFlag ? "visible" : "hidden"); // stupidest values ever
    $(".dbg").css("visibility", visFlag);
}

// alert("loaded utils");