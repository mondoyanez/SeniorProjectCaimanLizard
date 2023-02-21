﻿// Once the DOM is ready, execute everything in this function to set up the UI
$(document).ready(function () {
    $("#search-bar").submit(function (e) {
        e.preventDefault(); // prevent the form from submitting normally
        var actor = $("input[name='search']").val();

        $.when(
            $.ajax({
                type: "GET",
                url: "/api/searchPerson",
                data: { personName: actor },
                dataType: "json",
                success: function(response) {
                    displayTitles(response);
                },
                error: function() {
                    errorOnAjax();
                }
            }));

        /*
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
        */

    });

    $("#search-btn").click(function () {
        $("#search-bar").submit(); // submit the form on button click
    });

    $("#search-bar input").keypress(function (e) {
        if (e.which == 13) { // if the enter key is pressed
            $('#search-bar').submit(); // submit the form
            return false; // prevent the form from submitting normally
        }
    });
});

function displayTitles(data) {
    console.log("populating actor info with the following data");
    console.log(data);

    $("#resultCards").empty();
    $.each(data, function (actorIndex, actorItem) {
            $.each(actorItem.knownFor, function (knownForIndex, knownForItem) {
                console.log(knownForItem);
                let result =
                    `<div class="col cld-bg-light">
                    <div class="card mb-3">
                      <div class="row g-0">
                        <div class="col-sm-2 col-4 align-self-center">
                          <img class="results img-fluid rounded-start" src="" alt="..." data-posterpath="${knownForItem.imagePath}" >
                        </div>
                        <div class="col">
                          <div class="card-body text-start">
                            <h4 class="card-title">${knownForItem.title} (${knownForItem.releaseDate.substr(0, 4)})</h4>
                            <p class="card-text truncate-overflow">${knownForItem.plotSummary}</p>
                            <p class="card-text"><small class="text-muted">Rated: ${knownForItem.popularity}</small></p>
                          </div>
                        </div>
                      </div>
                    </div>
			    </div>`;
                $("#resultCards").append($(result));
            });
        }
    );
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
    // take care of the error, maybe display a message to the user
    // ...
}