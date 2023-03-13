const submitButton = $("#username-search-btn");
const re = new RegExp("^[A-Za-z]+$");
//const query = $("#username-entered").val();

submitButton.on("click", () => {
    $("#user-search-input-error-message").empty();

    if ($("#username-entered").val().toString() === "") {
        $("#user-search-input-error-message").addClass("user-search-error-rq");
        $("#user-search-input-error-message").append("<p>This is a required field, please enter a username</p>");
        return;
    }

    if (!re.test($("#username-entered").val().toString())) {
        $("#user-search-input-error-message").addClass("user-search-error-rq");
        $("#user-search-input-error-message").append("<p>Input can only contain alphabetic characters</p>");
        return;
    }
    $("#user-search-input-error-message").append("<p>VALID INPUT</p>");
});