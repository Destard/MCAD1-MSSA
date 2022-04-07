"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chaseHub").build();

//These are also configured within the web application.
const framesPerSecond = 10;
const refreshRate = 1000 / framesPerSecond;

//Disable the send button until connection is established.
let btnJoinChaseGame = document.getElementById("btnJoinChaseGame");
let btnStartChaseGame = document.getElementById("btnStartChaseGame");
//let svgChaseGame = document.getElementById("svgChaseGame");
let chaseGame = document.getElementById("canvasChaseGame");
let chaseGamePlayerOne = document.getElementById("chaseGamePlayerOne");
let chaseGamePlayerTwo = document.getElementById("chaseGamePlayerTwo");
let ctx = chaseGame.getContext("2d");


connection.on("PlayerJoined", function (gameState) {
    chaseGame.addEventListener("mousemove", function (event) {
        throttle(setPlayerPosition, refreshRate)(event);
    });
});
connection.on("GameProgress", function (gameState) {
    updatePlayerPositions(gameState);
});
//connection.on("GameOver", function (gameState) {
//    updatePlayerPositions(gameState);
//});
connection.on("ClientConnected", function (gameState) {
    //console.log("ClientConnected: GameState is " + JSON.stringify(gameState));
    updatePlayerPositions(gameState);
});
function updatePlayerPositions(gameState){
    ctx.clearRect(0,0,500,500);
    ctx.fillStyle = "red";
    ctx.fillRect(gameState.players[0].playerPosition.x-10, gameState.players[0].playerPosition.y-10, 20, 20);
    ctx.fillStyle = "blue";
    ctx.fillRect(gameState.players[1].playerPosition.x-10, gameState.players[1].playerPosition.y-10, 20, 20);
}
// function updatePlayerPositions(gameState){
//     chaseGamePlayerOne.style.top = gameState.players[0].playerPosition.x+43+"px";
//     chaseGamePlayerOne.style.left = gameState.players[0].playerPosition.y+154+"px";
//     chaseGamePlayerTwo.style.top = gameState.players[1].playerPosition.x+43+"px";
//     chaseGamePlayerTwo.style.left = gameState.players[1].playerPosition.y+154+"px";
// }
// function updatePlayerPositions(gameState){
//     chaseGamePlayerOne.x.baseVal.value = gameState.players[0].playerPosition.x-10;
//     chaseGamePlayerOne.y.baseVal.value = gameState.players[0].playerPosition.y-10;
//     chaseGamePlayerTwo.x.baseVal.value = gameState.players[1].playerPosition.x-10;
//     chaseGamePlayerTwo.y.baseVal.value = gameState.players[1].playerPosition.y-10;
// }


connection.start().then(function () {
    btnJoinChaseGame.disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

btnJoinChaseGame.addEventListener("click", function (event) {
    connection.invoke("JoinGame").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
btnStartChaseGame.addEventListener("click", function (event) {
    connection.invoke("StartGame").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

const setPlayerPosition = function (event) {
    let newPosition = { X: event.offsetX, Y: event.offsetY };
    connection.invoke("SetPlayerPosition", newPosition);
}

function throttle(callback, limit) {
    var waiting = false;                      
    return function () {                      
        if (!waiting) {                       
            callback.apply(this, arguments);  
            waiting = true;                   
            setTimeout(function () {          
                waiting = false;              
            }, limit);
        }
    }
}
//const throttle = (func, limit) => {
//    let lastFunc;
//    let lastRan;
//    return function () {
//        const context = this;
//        const args = arguments;
//        if (!lastRan) {
//            func.apply(context, args)
//            lastRan = Date.now();
//        } else {
//            clearTimeout(lastFunc);
//            lastFunc = setTimeout(function () {
//                if ((Date.now() - lastRan) >= limit) {
//                    func.apply(context, args);
//                    lastRan = Date.now();
//                }
//            }, limit - (Date.now() - lastRan));
//        }
//    }
//}