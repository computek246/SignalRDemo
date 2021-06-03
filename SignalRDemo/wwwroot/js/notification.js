"use strict";

var connection = new signalR.HubConnectionBuilder()
  .withUrl("/notify")
  .build();


connection.on("ReceiveMessage", function (data) {
  console.log(data);
  $(".messageList").append(data);
});



connection.on("PushUserNotification", function (data) {
  console.log(data);

  alert("you have (" + data.unreadCount + ") Unreaded Message");
  $.each(data.notificationList, function (i, obj) {
    $(".messageList").append(obj.notificationContent);
  })

});


connection.start().then(function () {
  console.log("signalR is Started");
}).catch(function (err) {
  return console.error(err.toString());
});


$("#addAction01").on("click", function (e) {
  BackToServer(1);
});

$("#addAction02").on("click", function (e) {
  BackToServer(2);
});

$("#addAction03").on("click", function (e) {
  BackToServer(3);
});


$(function () {
  $.ajax({
    url: "/Home/GetUserNotifications",
    success: function (e) { }
  });
})

function BackToServer(eventId) {
  var pathname = window.location.pathname; // Returns path only (/path/example.html)
  var url = window.location.href;     // Returns full URL (https://example.com/path/example.html)
  var origin = window.location.origin;   // Returns base URL (https://example.com)


  $.ajax({
    url: "/Home/SaveDate",
    data: { userId: $("#UserId").val(), eventId: eventId, url: url },
    success: function (e) { }
  });
}


function ReadStatus(notificationId) {
  $.ajax({
    url: "/Home/ReadStatus",
    data: { notificationId: notificationId, userId: $("#UserId").val() },
    success: function (e) { }
  });
}