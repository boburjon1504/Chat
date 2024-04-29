"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/mychat").build();


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

function show() {
    //console.log("friend press");
    //const div = document.getElementById("rightSide");
    //const chatBox = document.getElementById("chatBox");

    //if (div.style.display === "none") {
    //    div.style.display = "block"; // Or any other visible display value like 'inline'
    //}
}
document.getElementById("myButton").addEventListener("click", function () {
    console.log("friend press");
    const div = document.getElementById("rightSide");
    const myDiv = document.getElementById('chatBox');
    console.log(myDiv.innerHTML)
    setTimeout(function () {
        console.log("scrollHeight:", myDiv.scrollHeight);
        console.log("scrollTop:", myDiv.scrollTop);
        myDiv.scrollTop = myDiv.scrollHeight;
    }, 10);
    myDiv.scrollTop = myDiv.scrollHeight;
    if (div.style.display === "none") {
        div.style.display = "block"; // Or any other visible display value like 'inline'
    }
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    //var user = document.getElementById("userName").value;
    //var message = document.getElementById("message").value;
    //var id = connection.connectionId
    //console.log(id);
    //connection.invoke("SendMessage", user, message).catch(function (error) {
    //    console.log(error)
    //});
    event.preventDefault();
})
