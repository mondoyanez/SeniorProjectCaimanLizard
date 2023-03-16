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
        usersTable.hide();
    }
    return validInput;
}
function findUsers(data) {
    console.log(data);
    if (data.length > 0) {
        usersTable.empty();
        generateTableBody();
        var usersTableBody_1 = $("#user-tbody");
        generateHeaders(usersTableBody_1);
        $.each(data, function (index, item) {
            var result = "\n                <tr>\n                    <td>".concat(item.username, "</td>\n                    <td>").concat(item.email ? item.email : "", "</td>\n                    <td>").concat(item.firstName ? item.firstName : "", " ").concat(item.lastName ? item.lastName : "", "</td>\n                    <td>").concat(item.followingCount ? item.followingCount : 0, "</td>\n                    <td>").concat(item.followerCount ? item.followerCount : 0, "</td>\n                </tr>\n            ");
            usersTableBody_1.append(result);
        });
        usersTable.show();
    }
    else {
        var invalidUser = $("#username-entered").val().toString();
        errorMessageBody.append("No user was found by the name of ".concat(invalidUser, " please try again"));
        errorMessageBody.addClass("user-search-error-rq");
        usersTable.hide();
    }
}
function generateHeaders(usersTableBody) {
    var headers = "\n        <tr>\n            <th>Username </th>\n            <th> Email </th>\n            <th> First and Last Name </th>\n            <th> Amount Following </th>\n            <th> Amount of Followers </th>\n        </tr>\n    ";
    usersTableBody.append(headers);
}
function generateTableBody() {
    var tBody = "<tbody id=\"user-tbody\"></tbody>";
    usersTable.append(tBody);
}
function errorOnAjax() {
    console.log("ERROR in ajax request");
}
//# sourceMappingURL=findUsers.js.map