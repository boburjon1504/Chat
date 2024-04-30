"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/mychat").build();

connection.on("ReceiveMessage", function (id, firstName, lastName, isOnline, message) {
    if (document.getElementById("friendId").textContent === id) {
        var data = new Date();
        var html = '';
        html += '<div class="message friendMessage">';
        html += '<p>' + message + '<br /><span>' + data.toLocaleTimeString() + '</span></p>';
        html += '</div>';
        const myDiv = document.getElementById('chatBox');
        console.log("receive ishladi")
        $("#chatBox").append(html);
        setTimeout(function () {
            myDiv.scrollTop = myDiv.scrollHeight;
        }, 10);
    } else {
        var count = document.getElementById(`count(${id}`)
        var name = document.getElementById(`name(${id}`)
        var m = document.getElementById(`message(${id}`)
        var time = document.getElementById(`time(${id}`)
        var h = ''
        if (count === null) {

            h += '<button class="block active gap-2" id="myButton" onclick="show(' + `'${id}','${firstName}','${lastName}','${isOnline}'` + ')">';
            h += '<div class="imgBx">' + '<img src="/css/account.jpg" class="cover" />' + '</div>';
            h += '<div class="details">' + '<div class="listHead mt-1">' + `<h5 id="name(${id}"` + 'class="m-0">';
            h += firstName + lastName;
            h += '</h5>' + `<p id="time(${id}" class="time m-0">${new Date().toLocaleTimeString()}</p>` + '</div>'
            h += '<div class="message_p">';
            h += `<p id="message(${id}" class="mb-1">${message}</p>`;
            h += `<b id="count(${id}">1</b>` + '</div>' + '</div>' + '</button>';
            $("#chatList").append(h);
        } else {
            count.textContent = (parseInt(count.textContent) + 1).toString();
            m.textContent = message;
            name.textContent = user;
            time.textContent = new Date().toLocaleTimeString();
        }
    }
});

connection.start().then(function () {
}).catch(function (error) {
    console.log(error)
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("friendId").textContent;
    var message = document.getElementById("inputMessage").value;
    //console.log(document.getElementById(`count(${user}`).textContent)
    console.log(user);
    console.log("ishladi shekili")
    var data = new Date();
    var html = '';
    html += '<div class="message myMessage">';
    html += '<p>' + message + '<br /><span>' + data.toLocaleTimeString() + '</span></p>';
    html += '</div>';
    const myDiv = document.getElementById('chatBox');
    setTimeout(function () {
        myDiv.scrollTop = myDiv.scrollHeight;
    }, 10);
    $("#chatBox").append(html);
    connection.invoke("SendToUserMessage", user, message).catch(function (error) {
        console.log(error)
    });
    document.getElementById("inputMessage").value = ""
    event.preventDefault();
})