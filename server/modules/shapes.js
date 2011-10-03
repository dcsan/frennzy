exports.draw = function(shape, color) {

    id = "circle"

    if (shape=="circle") {
        svg = "<circle id='" + id + "' cx='50' cy='50' r='50' fill='" + color + "' />";
    } else if (shape == "rect") {
        svg = "<rect id='" + id + "' cx='50' cy='50' r='50' fill='" + color + "' />";
    }

    str = '<svg id="svgelem" height="200" xmlns="http://www.w3.org/2000/svg">'
    str += svg
    str += '</svg>'
    console.log("circle here! r=" + str);
    return str;
}
