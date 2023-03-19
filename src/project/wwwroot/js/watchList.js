//$(document).ready(function () {
//    $("#card-button").click(function () {
//        var cardId = $(this).data("card-id");
//        var apiUrl = "api/getShowDetails/" + cardId

//        console.log("Button click, inside watchLIst.js")

//        //$.ajax({
//        //    type: "GET",
//        //    url: apiUrl,
//        //    success: function (data) {
//        //        var dataToSend = {
//        //            "TMDBID": cardId,
//        //            "Title": data.title,
//        //            "Overview": data.overview,
//        //            "FirstAirDate": data.FirstAirDate
//        //        };

//        //        $.ajax({
//        //            type: "POST",
//        //            url: "/WatchList/AddToDatabase",
//        //            data: dataToSend,
//        //            success: function (response) {
//        //                console.log(response);
//        //            },
//        //            error: function (xhr, status, error) {
//        //                console.log(xhr.responseText);
//        //            }
//        //        });
//        //    },
//        //    error: function (xhr, status, error) {
//        //        console.log(xhr.responseText);
//        //    }
//        //});
//    });
//});

$(document).on('click', '.delete-watchlist-item', function () {
    var showId = $(this).data('show-id');
    $.ajax({
        url: '/Watchlist/DeleteWatchlistItem/' + showId,
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
