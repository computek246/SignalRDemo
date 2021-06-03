"use strict";

var connection = new signalR.HubConnectionBuilder()
  .withUrl("/notify")
  .build();


connection.on("ReceiveMessage", function (data) {
  $(".messageList").append(data);
});



connection.on("PushUserNotification", function (data) {

  alert("you have (" + data.unreadCount + ") Unreaded Message");
  $(".messageList").html("");
  $.each(data.notificationList,
    function (i, obj) {

      $(".messageList").append(obj.notificationContent);


    });

  $("a.float-left").css('color', 'blue');

});


connection.start().then(function () {
  console.log("signalR is Started");

  $.ajax({
    url: "/Home/GetUserNotifications",
    success: function (e) { }
  });

}).catch(function (err) {
  return console.error(err.toString());
});

//=============================================
// walid wrdany: for test

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
  //
});

function BackToServer(eventId) {
  var pathname = window.location.pathname; // Returns path only (/path/example.html)
  var url = window.location.href;     // Returns full URL (https://example.com/path/example.html)
  var origin = window.location.origin;   // Returns base URL (https://example.com)


  $.ajax({
    url: "/Home/SaveDate",
    data: {
      userId: $("#UserId").val(),
      eventId: eventId, url: url
    },
    success: function (e) { }
  });
}

//=============================================




$(document).on("click", "a.float-left", function (e) {

  e.preventDefault();
  var _url = $(e.target).attr("href");
  $.ajax({
    url: "/Home/ReadStatus",
    data: {
      notificationId: $(this).attr("data-notification-id"),
      userId: $("#UserId").val()
    },
    success: function (e) {
      //window.location.href = _url
    }
  });
});