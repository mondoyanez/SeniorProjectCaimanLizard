$(document).on('click', '.delete-watchlist-show', function () {
    var showId = $(this).data('show-id');
    $.ajax({
        url: '/Watchlist/DeleteWatchlistShow/' + showId,
        type: 'POST',
        data: {showId : showId},
        success: function (result) {
            console.log("success inside watchList.js delete");
            location.reload();
        },
        error: function (xhr, status, error) {
            // handle error
        }
    });
});

$(document).on('click', '.delete-watchlist-movie', function () {
    var movieId = $(this).data('movie-id');
    $.ajax({
        url: '/Watchlist/DeleteWatchlistMovie/' + movieId,
        type: 'POST',
        data: { movieId: movieId },
        success: function (result) {
            console.log("success inside watchList.js delete");
            location.reload();
        },
        error: function (xhr, status, error) {
            // handle error
        }
    });
});