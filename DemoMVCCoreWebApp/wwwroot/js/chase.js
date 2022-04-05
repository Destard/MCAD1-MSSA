"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chaseHub").build();

//Disable the send button until connection is established.
let btnJoinChaseGame = document.getElementById("btnJoinChaseGame");
let btnStartChaseGame = document.getElementById("btnStartChaseGame");
//let svgChaseGame = document.getElementById("svgChaseGame");
let chaseGame = document.getElementById("canvasChaseGame");
let chaseGamePlayerOne = document.getElementById("chaseGamePlayerOne");
let chaseGamePlayerTwo = document.getElementById("chaseGamePlayerTwo");


connection.on("PlayerJoined", function (gameState) {
    updatePlayerPositions(gameState);
});
connection.on("GameProgress", function (gameState) {
    updatePlayerPositions(gameState);
});
connection.on("GameOver", function (gameState) {
    updatePlayerPositions(gameState);
});
connection.on("ClientConnected", function (gameState) {
    //console.log("ClientConnected: GameState is " + JSON.stringify(gameState));
    updatePlayerPositions(gameState);
});
function updatePlayerPositions(gameState){
    let ctx = chaseGame.getContext("2d");
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
chaseGame.addEventListener("mousemove", function (event) {
    let newPosition = { X: event.offsetX, Y: event.offsetY };
    connection.invoke("SetPlayerPosition", newPosition);
});