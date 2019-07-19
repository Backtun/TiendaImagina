"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").AddMessagePackProtocol.build();

connection.on("RecibirMensaje", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var fecha = new Date().toLocaleTimeString();
    var mensajeAmostrar = fecha + "--" + user + " dice: " + msg;
    var li = document.createElement("li");
    li.textContent = mensajeAmostrar;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("EnviarMensaje", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});