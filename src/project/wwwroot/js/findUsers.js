var submitButton = $("#username-search-btn");
var errorMessageBody = $("#user-search-input-error-message");
var re = new RegExp("^[A-Za-z]+$");
var usersTable = $("#users-found");
submitButton.on("click", function (e) {
    e.preventDefault();
    var query = $("#username-entered").val().toString();
    errorMessageBody.empty();
    if (!validateInput(query)) {
        return;
    }
    $(function () {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/watcher/findByUsername?username=".concat(query),
            success: findUsers,
            error: errorOnAjax
        });
    });
});
function validateInput(input) {
    var validInput = true;
    if (input === "") {
        errorMessageBody.append("<p>This is a required field, please enter a username</p>");
        validInput = false;
    }
    if (!re.test(input) && validInput) {
        errorMessageBody.append("<p>Input can only contain alphabetic characters</p>");
        validInput = false;
    }
    if ((input === undefined || input === null) && validInput) {
        errorMessageBody.append("<p>Something went wrong please try again</p>");
        validInput = false;
    }
    if (validInput === false) {
        errorMessageBody.addClass("user-search-error-rq");
        usersTable.css("display", "none");
    }
    return validInput;
}
function findUsers(data) {
    usersTable.empty();
    $.each(data, function (index, item) {
        var result = "\n                <tr>\n                    <td>".concat(item.username, "</td>\n                    <td>").concat(item.email ? item.email : "", "</td>\n                    <td>").concat(item.firstName ? item.firstName : "", " ").concat(item.lastName ? item.lastName : "", "</td>\n                    <td>").concat(item.followingCount ? item.followingCount : 0, "</td>\n                    <td>").concat(item.followerCount ? item.followerCount : 0, "</td>\n                </tr>\n            ");
        usersTable.append(result);
    });
    usersTable.css("display", "inline");
}
function errorOnAjax() {
    console.log("ERROR in ajax request");
}
//# sourceMappingURL=findUsers.js.map