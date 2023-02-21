console.log("hello from search.js");

// Once the DOM is ready, execute everything in this function to set up the UI
$(document).ready(function () {
    $("#search-bar").submit(function (e) {
        e.preventDefault(); // prevent the form from submitting normally
        var title = $("input[name='search']").val();
        $.when(
            $.ajax({
                type: "GET",
                url: "/api/searchTitle",
                data: { title: title },
                dataType: "json",
                success: function (response) {
                    displayTitles(response);
                },
                error: function () {
                    errorOnAjax();
                }
            })
        ).then(function () {
            $.ajax({
                type: "GET",
                url: "/api/imageConfig",
                dataType: "json",
                success: function (response) {
                    getImageConfig(response);
                },
                error: function () {
                    errorOnAjax();
                }
            });
        });


        console.log(`searching for the title: ${title}`);
    });

    $("#search-btn").click(function () {
        console.log("click occured");
        $("#search-bar").submit(); // submit the form on button click
    });

    $("#search-bar input").keypress(function (e) {
        if (e.which == 13) { // if the enter key is pressed
            $('#search-bar').submit(); // submit the form
            return false; // prevent the form from submitting normally
        }
    });
});

// Search for movies
$(document).ready(function () {
    $("#search-bar-movies").submit(function (e) {
        e.preventDefault(); // prevent the form from submitting normally
        var title = $("input[name='search-movies']").val();
        $.when(
            $.ajax({
                type: "GET",
                url: "/api/searchMovies",
                data: { title: title },
                dataType: "json",
                success: function (response) {
                    displayTitles(response);
                },
                error: function () {
                    errorOnAjax();
                }
            })
        ).then(function () {
            $.ajax({
                type: "GET",
                url: "/api/imageConfig",
                dataType: "json",
                success: function (response) {
                    getImageConfig(response);
                },
                error: function () {
                    errorOnAjax();
                }
            });
        });


        console.log(`searching for the title: ${title}`);
    });

    $("#search-movies-btn").click(function () {
        console.log("click occured");
        $("#search-bar-movies").submit(); // submit the form on button click
    });

    $("#search-movies input").keypress(function (e) {
        if (e.which == 13) { // if the enter key is pressed
            $('#search-bar-movies').submit(); // submit the form
            return false; // prevent the form from submitting normally
        }
    });
});

// Search for tv shows
$(document).ready(function () {
    $("#search-bar-tv").submit(function (e) {
        e.preventDefault(); // prevent the form from submitting normally
        var title = $("input[name='search-tv']").val();
        $.when(
            $.ajax({
                type: "GET",
                url: "/api/searchShows",
                data: { title: title },
                dataType: "json",
                success: function (response) {
                    displayTitles(response);
                },
                error: function () {
                    errorOnAjax();
                }
            })
        ).then(function () {
            $.ajax({
                type: "GET",
                url: "/api/imageConfig",
                dataType: "json",
                success: function (response) {
                    getImageConfig(response);
                },
                error: function () {
                    errorOnAjax();
                }
            });
        });


        console.log(`searching for the title: ${title}`);
    });

    $("#search-tv-btn").click(function () {
        console.log("click occured");
        $("#search").submit(); // submit the form on button click
    });

    $("#search-tv input").keypress(function (e) {
        if (e.which == 13) { // if the enter key is pressed
            $('#search-bar-tv').submit(); // submit the form
            return false; // prevent the form from submitting normally
        }
    });
});

// Callback functions that execute once the AJAX calls return
function displayTitles(data) {
    console.log("populating basic user info with the following data:");
    console.log(data);

    $("#resultCards").empty();
    $.each(data,
        function(index, item) {
            let result =
                `<div class="col cld-bg-light">
                    <div class="card mb-3">
                      <div class="row g-0">
                        <div class="col-sm-2 col-4 align-self-center">
                          <img class="results img-fluid rounded-start" src="" alt="..." data-posterpath="${item.imagePath}" >
                        </div>
                        <div class="col">
                          <div class="card-body text-start">
                            <h4 class="card-title">${item.title} (${item.releaseDate.substr(0,4)})</h4>
                            <p class="card-text truncate-overflow">${item.plotSummary}</p>
                            <p class="card-text"><small class="text-muted">Rated: ${item.popularity}</small></p>
                          </div>
                        </div>
                      </div>
                    </div>
			    </div>`;
            $("#resultCards").append($(result));
        }
    );
}

function getImageConfig() {
    console.log("retrieving image config");

    $.ajax({ 
        type: "GET",
        url: "/api/imageConfig",
        dataType: "json",
        success: function (response) {
            console.log(response),
                displayPosterImages(response),
                displayTextForNoPosters();
        },
        error: function () {
            errorOnAjax();
        }
    });
}

function displayPosterImages(response) {
    console.log("displaying images");

    $("#resultCards img").each(function () {
        var posterPath = $(this).data("posterpath");
        var posterSize = response.posterSizes[2];
        $(this).attr("src", `${response.baseUrl + posterSize}` + posterPath);
    });
}

function displayTextForNoPosters() {
    console.log("fixing missing posters");
    $("#resultCards img").on("error", function () {
        $(this).replaceWith('<p class="fs-3 text-muted bg-secondary bg-gradient bg-opacity-25 text-center py-3 mb-0">No<br>poster<br>found</p>');
    });
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
    // take care of the error, maybe display a message to the user
    // ...
}