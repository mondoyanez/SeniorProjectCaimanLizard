$(document).on('click', '.delete-watchlist-show-0', function () {
    var showId = $(this).data('show-id');
    var listType = 0;

    console.log("Inside watchList.js, information that is here:");
    console.log("Show id: " + showId);
    console.log("List Type: " + listType);
    $.ajax({
        url: '/Watchlist/DeleteWatchlistShow',
        type: 'POST',
        data: {
            showId: showId,
            listType: listType
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

$(document).on('click', '.delete-watchlist-show-one', function () {
    var showId = $(this).data('show-id');
    var listType = 1;

    console.log("Inside watchList.js, information that is here:");
    console.log("Show id: " + showId);
    console.log("List Type: " + listType);
    $.ajax({
        url: '/Watchlist/DeleteWatchlistShow',
        type: 'POST',
        data: {
            showId: showId,
            listType: listType
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

$(document).on('click', '.delete-watchlist-movie-0', function () {
    var movieId = $(this).data('movie-id');
    var listType = 0;
    $.ajax({
        url: '/Watchlist/DeleteWatchlistShow',
        type: 'POST',
        data: {
            movieId: movieId,
            listType: listType
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

$(document).on('click', '.delete-watchlist-movie-1', function () {
    var movieId = $(this).data('movie-id');
    var listType = 0;
    $.ajax({
        url: '/Watchlist/DeleteWatchlistShow',
        type: 'POST',
        data: {
            movieId: movieId,
            listType: listType
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