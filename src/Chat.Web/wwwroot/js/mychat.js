"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/mychat").build();

document.getElementById("sendButton");

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    console.log(`${user} says ${message}`);
    li.textContent = `${user} says ${message}`;
    document.getElementById("messageList").append(li);
});

connection.start().then(function () {
}).catch(function (error) {
    console.log(error)
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userName").value;
    var message = document.getElementById("message").value;
    var id = connection.connectionId
    console.log(id);
    connection.invoke("SendMessage", user, message).catch(function (error) {
        console.log(error)
    });
    event.preventDefault();
})
