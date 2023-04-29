$(document).on('click', '.delete-notification', function () {
    var notificationId = $(this).data('notif-id');
    console.log("Inside notification.js");
    console.log("Notification id: " + notificationId);
    $.ajax({
        url: '/Notification/DeleteNotification',
        type: 'POST',
        data: {
            notificationId: notificationId
        },
        success: function (result) {
            console.log("success inside watchList.js delete");
            location.reload();
        },
        error: function (xhr, status, error) {
            console.log("Error inside watchlist.js");
        }
    });
});

$(document).on('click', '.read-item', function () {
    var notificationId = $(this).data('notif-id');
    console.log("Inside notification.js");
    console.log("Notification id: " + notificationId);
    $.ajax({
        url: '/Notification/ReadItem',
        type: 'POST',
        data: {
            notificationId: notificationId
        },
        success: function (result) {
            console.log("success inside watchList.js delete");
            location.reload();
        },
        error: function (xhr, status, error) {
            console.log("Error inside watchlist.js");
        }
    });
});