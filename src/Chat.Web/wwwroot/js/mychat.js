function show(Id, FirstName, LastName, IsOnline) {   
    const div = document.getElementById("rightSide");
    
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
            if (IsOnline === 'True' || IsOnline === 'true') {
                friendOnline.textContent = 'online'
            } else {
                friendOnline.textContent = 'offline'
            }
            var friendName = document.getElementById("friendName");
            var friendId = document.getElementById("friendId");
            var count = document.getElementById(`count(${Id}`);
            count.textContent = '0'
            count.hidden;
            friendId.textContent = Id;
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

            const myDiv = document.getElementById('chatBox');
            setTimeout(function () {
                myDiv.scrollTop = myDiv.scrollHeight;
            }, 10);
        },
        error: function (jqxhr, textstatus, errorthrown) {
            $("#chatBox").empty();
            console.error('error loading users:', textstatus, errorthrown);
        }
    });
}
