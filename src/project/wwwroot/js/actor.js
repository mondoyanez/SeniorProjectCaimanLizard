// Once the DOM is ready, execute everything in this function to set up the UI
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
                    displayActors(response);
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

function displayActors(data) {
    console.log("populating actor info with the following data");
    console.log(data);
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
    // take care of the error, maybe display a message to the user
    // ...
}