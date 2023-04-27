$(document).on('click', '.delete-notification' function () {
    var notificationId = $(this).data('notif-id');
    console.log("Inside notification.js");
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