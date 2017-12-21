


var sec = Math.floor(60 % 60);   // set the seconds
var min = Math.floor(60 / 60);

    




    function countDown() {
        //var examTimer = document.getElementById("TimeLimit").value;
        //var sec = Math.floor(examTimer % 60);   // set the seconds
        //var min = Math.floor(examTimer / 60);   // set the minutes


        sec--;
        if (sec == -01) {
            sec = 59;
            min = min - 1;
        } else {
            min = min;
        }
        if (sec <= 9) { sec = "0" + sec; }
        time = (min <= 9 ? "0" + min : min) + " min and " + sec + " sec ";
        if (document.getElementById) { theTime.innerHTML = time; }
        SD = window.setTimeout("countDown();", 1000);
        if (min == '00' && sec == '00') {
            sec = "00"; window.clearTimeout(SD);
            alert("Time's up!"); document.getElementById('Submit').click();
        }

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




//function startTimer(duration, display) {
//    var start = Date.now(),
//        diff,
//        minutes,
//        seconds;
//    function timer() {
//        // get the number of seconds that have elapsed since 
//        // startTimer() was called
//        examTimer = duration - (((Date.now() - start) / 1000) | 0);
//        //examTimer = document.getElementById("TimeLimit").value;

//        // does the same job as parseInt truncates the float
//        minutes = (examTimer / 60) | 0;
//        seconds = (examTimer % 60) | 0;

//        minutes = minutes < 10 ? "0" + minutes : minutes;
//        seconds = seconds < 10 ? "0" + seconds : seconds;

//        display.textContent = minutes + ":" + seconds;

//        if (diff <= 0) {
//            // add one second so that the count down starts at the full duration
//            // example 05:00 not 04:59
//            start = Date.now() + 1000;
//        }
//    };
//    // we don't want to wait a full second before the timer starts
//    timer();
//    setInterval(timer, 1000);
//}

//window.onload = function () {
//    var fiveMinutes = 60 * 5,
//        display = document.querySelector('#time');
//    startTimer(fiveMinutes, display);
//};


//var sTime = new Date().getTime();
//var countDown = document.getElementById("TimeLimit").value;

//function UpdateTime() {
//    var cTime = new Date().getTime();
//    var diff = cTime - sTime;
//    var seconds = countDown - Math.floor(diff / 1000);
//    if (seconds >= 0) {
//        var minutes = Math.floor(seconds / 60);
//        seconds -= minutes * 60;
//        $("#minutes").text(minutes < 10 ? "0" + minutes : minutes);
//        $("#seconds").text(seconds < 10 ? "0" + seconds : seconds);
//    } else {
//        $("#countdown").hide();
//        $("#aftercount").show();
//        clearInterval(counter);
//    }
//}
//UpdateTime();
//var counter = setInterval(UpdateTime, 500);
