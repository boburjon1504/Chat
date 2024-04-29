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

function show(Id, FirstName, LastName, IsOnline) {
    const div = document.getElementById("rightSide");
    const myDiv = document.getElementById('chatBox');
    setTimeout(function () {
        myDiv.scrollTop = myDiv.scrollHeight;
    }, 10);

    myDiv.scrollTop = myDiv.scrollHeight;
    if (div.style.display === "none") {
        div.style.display = "block";
    }
    $.ajax({
        url: `/chat/privatechat`,
        data: {
            userId: Id
        },
        type: 'get',
        success: function (data) {
            var friendOnline = document.getElementById("friendIsOnline");
            console.log(IsOnline)
            console.log(friendOnline.textContent)
            if (IsOnline === 'True' || IsOnline === 'true') {
                console.log(IsOnline)

                friendOnline.textContent = 'online'
            } else {
                friendOnline.textContent = 'offline'
                console.log(IsOnline)
            }
            var friendName = document.getElementById("friendName");
            friendName.textContent = FirstName + '  ' + LastName
            var chatDiv = document.getElementById("chatBox");
            chatDiv.innerHTML = ''
            var html = ''
            for (var i = 0; i < data.length; i++) {
                if (data[i].receiverId === Id) {
                    html += '<div class="message myMessage">';
                    html += '<p>' + data[i].body + '<br /><span>' + data[i].sendAt + '</span></p>';
                    html += '</div>';
                } else {
                    html += '<div class="message friendMessage">';
                    html += '<p>' + data[i].body + '<br /><span>' + data[i].sendAt + '</span></p>';
                    html += '</div>';
                }
            }
            $("#chatBox").append(html);
        },
        error: function (jqxhr, textstatus, errorthrown) {
            $("#chatBox").empty();
            console.error('error loading users:', textstatus, errorthrown);
        }
    });
}
//<div class="message myMessage">
//                        <p>Hi, how are you doing really good right<br /><span>10:15</span></p>
//                    </div>
//                    <div class="message friendMessage">
//                        <p>Hi asdasgdausygdaysgduasgduasygdasgdasydadgs<br /><span>10:15</span></p>
//                    </div>
//document.getElementById("myButton").addEventListener("click", function () {
//    const div = document.getElementById("rightSide");
//    const myDiv = document.getElementById('chatBox');
//    console.log(myDiv.innerHTML)
//    setTimeout(function () {
//        console.log("scrollHeight:", myDiv.scrollHeight);
//        console.log("scrollTop:", myDiv.scrollTop);
//        myDiv.scrollTop = myDiv.scrollHeight;
//    }, 10);
//    myDiv.scrollTop = myDiv.scrollHeight;
//    if (div.style.display === "none") {
//        div.style.display = "block"; // Or any other visible display value like 'inline'
//    }
//});
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
