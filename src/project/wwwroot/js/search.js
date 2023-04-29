console.log("hello from search.js");

$(document).ready(function () {
    // Parse the query string to retrieve the values of the parameters
    var query = ""; // the value of the query
    var by = "";    // what to search by (title, movie, tv show, actor) - default is title
    const params = new URLSearchParams(window.location.search);

    if (params.has("query")) {
        query = params.get("query");
        query = decodeURIComponent(query);
    }
    if (params.has("by")) {
        by = params.get("by");
        by = decodeURIComponent(by);
    }

    // update search bar with the query value
    $("#search-form input").val(query);
    $.when(
        $.ajax({
            type: "GET",
            url: "/api/searchTitle",
            data: { title: query },
            dataType: "json",
            success: function (response) {
                if (document.getElementById('multiCheck').checked) {
                    displayTitles(response);
                }
                if (document.getElementById('moviesCheck').checked) {
                    displayMovies(response);
                }
                if (document.getElementById('showsCheck').checked) {
                    displayShows(response);
                }
            },
            error: function() {
                errorOnAjax();
            }
        })
    ).then(function() {
        $.ajax({
            type: "GET",
            url: "/api/imageConfig",
            dataType: "json",
            success: function(response) {
                getImageConfig(response);
            },
            error: function() {
                errorOnAjax();
            }
        });
    });
});


/* TODO: commented out for now, when below functionality is replaced by ability to search by filters then this can be removed
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
                url: "/api/searchMovie",
                data: { movieTitle: title },
                dataType: "json",
                success: function(response) {
                    displayTitles(response);
                },
                error: function() {
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
                url: "/api/searchShow",
                data: { showTitle: title },
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
*/

// Callback functions that execute once the AJAX calls return
function displayTitles(data) {
    console.log("populating basic user info with the following data:");
    console.log(data);

    if (data.length == 0) {
        alert("Your search query returned no results");
    }

    $("#resultCards").empty();
    $.each(data,
        function (index, item) {
            let result =
                `<div class="col bg-light-subtle">
                    <div class="card mb-3">
                      <div class="row g-0">
                        <div class="col-sm-2 col-4 align-self-center">
                          <img class="results img-fluid rounded-start" src="" alt="..." data-posterpath="${item.imagePath}" >
                        </div>
                        <div class="col">
                          <div class="card-body text-start">
                            <h4 class="card-title">${item.title} (${item.releaseDate.substr(0, 4)})</h4>
                            <p class="card-text truncate-overflow">${item.plotSummary}</p>
                            <p class="card-text"><small class="text-muted">Rated: ${item.popularity}</small></p>      
                                        <button id="card-button" class="btn cld-btn-secondary text-light text-right add-watchlist-item" onclick='addTitleToWatchList("${title}", "${0}", "${item.mediaType}")'>Add To Currently Watching</button>
                                        <button id="card-button" class="btn cld-btn-secondary text-light text-right add-watchlist-item" onclick='addTitleToWatchList("${title}", "${1}", "${item.mediaType}")'>Add To Want To Watch</button>
                        </div>
                        </div>
                      </div>
                    </div>
			    </div>`;
            $("#resultCards").append($(result));
        }
    );
}

function displayMovies(data) {
    console.log("populating basic user info with the following data:");
    console.log(data);

    $("#resultCards").empty();
    $.each(data,
        function (index, item) {
            const movieTitle = item.title.replace("'", "&apos;");
            let result =
                `<div class="col bg-light-subtle">
                    <div class="card mb-3">
                      <div class="row g-0">
                        <div class="col-sm-2 col-4 align-self-center">
                          <img class="results img-fluid rounded-start" src="" alt="..." data-posterpath="${item.imagePath}" >
                        </div>
                        <div class="col">
                          <div class="card-body text-start">
                            <h4 class="card-title">${item.title} (${item.releaseDate.substr(0, 4)})</h4>
                            <p class="card-text truncate-overflow">${item.plotSummary}</p>
                            <p class="card-text"><small class="text-muted">Rated: ${item.popularity}</small></p>
                                        <button id="card-button" class="btn cld-btn-secondary text-light text-right add-watchlist-item" onclick='addTitleToWatchList("${title}", "${0}", "${item.mediaType}")'>Add To Currently Watching</button>
                                        <button id="card-button" class="btn cld-btn-secondary text-light text-right add-watchlist-item" onclick='addTitleToWatchList("${title}", "${1}", "${item.mediaType}")'>Add To Want To Watch</button>
                        </div>
                      </div>
                    </div>
			    </div>`;
            if (item.mediaType == "movie") {
                $("#resultCards").append($(result));
            }
        }
    );
}

function displayShows(data) {
    console.log("populating basic user info with the following data:");
    console.log(data);

    $("#resultCards").empty();
    $.each(data,
        function (index, item) {
            const title = item.title.replace("'", "&apos;");
            console.log("mediatype: " + item.mediaType)
                let result =
                    `<div class="col bg-light-subtle">
                        <div class="card mb-3" id="${index}">
                          <div class="row g-0">
                            <div class="col-sm-2 col-4 align-self-center">
                              <img class="results img-fluid rounded-start" src="" alt="..." data-posterpath="${item.imagePath}" >
                            </div>
                            <div class="col">
                              <div class="card-body text-start">
                                <h4 class="card-title">${item.title} (${item.releaseDate.substr(0, 4)})</h4> 
                                <p class="card-text truncate-overflow">${item.plotSummary}</p>
                                <p class="card-text"><small class="text-muted">Rated: ${item.popularity}</small></p>
                                    <div class="dropdown">
                                        <button id="card-button" class="btn cld-btn-secondary text-light text-right add-watchlist-item" onclick='addTitleToWatchList("${title}", "${0}", "${item.mediaType}")'>Add To Currently Watching</button>
                                        <button id="card-button" class="btn cld-btn-secondary text-light text-right add-watchlist-item" onclick='addTitleToWatchList("${title}", "${1}", "${item.mediaType}")'>Add To Want To Watch</button>
                                    </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
			        </div>`;            
            if (item.mediaType == "tv") {
                $("#resultCards").append($(result));
            }
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


function addTitleToWatchList(Title, listType, mediaType) {
    if (mediaType == "movie") {
        $.ajax({
            url: "/WatchList/addMovieToWatchList",
            method: "POST",
            data: {
                movieTitle: Title,
                listType: listType
            },
            success: function (result) {
                console.log("Added to watch list successfully");
            },
            error: function (error) {
                console.error("Error updating database:" + error.responseText);
            }
        });
    } else {
        $.ajax({
            url: "/WatchList/addShowToWatchList",
            method: "POST",
            data: {
                showTitle: Title,
                listType: listType
            },
            success: function (result) {
                console.log("Added to watch list successfully");
            },
            error: function (error) {
                console.error("Error updating database:" + error.responseText);
            }
        });
    }
    
}


const escapeHTML = str => str.replace(/[&<>'"]/g,
    tag => ({
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        "'": '&apos;',
        '"': '&quot;'
    }[tag]));