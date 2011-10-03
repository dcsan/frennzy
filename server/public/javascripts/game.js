// main js code

function loadPanel(url) {
    $("#game").load(url);
}

function right() {
    // alert("right");
    loadPanel("right.html");
}

function wrong() {
    // alert("wrong");
    loadPanel("wrong.html");
}


