var sec = Math.floor(7201 % 60);   // set the seconds
var min = Math.floor(7201 / 60) % 60;   // set the minutes
var hour = Math.floor(7201 / 3600) % 24;


function countDown() {
    sec--;
    if (sec == -01) {
        sec = 59;
        min = min - 1;

    } else {
        min = min;
    }

    if (hour > 00 && min == 00) {
        if (sec == 00) {
            min = 60;
            hour = hour - 1;
        }
    }
    else {

        hour = hour;

    }


    if (sec <= 9) { sec = "0" + sec; }
    time = (hour <= 9 ? "0" + hour : hour) + " hours " + (min <= 9 ? "0" + min : min) + " min and " + sec + " sec ";
    if (document.getElementById) { theTime.innerHTML = time; }
    SD = window.setTimeout("countDown();", 1000);
    if (min == '00' && sec == '00') { sec = "00"; window.clearTimeout(SD); alert("Time's up!"); document.getElementById('submit').click(); }
}

function addLoadEvent(func) {
    var oldonload = window.onload;
    if (typeof window.onload != 'function') {
        window.onload = func;
    } else {
        window.onload = function () {
            if (oldonload) {
                oldonload();
            }
            func();
        }
    }
}

addLoadEvent(function () {
    countDown();
});