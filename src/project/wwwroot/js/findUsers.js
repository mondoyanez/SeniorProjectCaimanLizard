var submitButton = $("#username-search-btn");
var errorMessageBody = $("#user-search-input-error-message");
var re = /^[A-Za-z]+$/;
var usersTable = $("#users-found");
submitButton.on("click", function (e) {
    var _a, _b;
    e.preventDefault();
    var query = (_b = (_a = $("#username-entered").val()) === null || _a === void 0 ? void 0 : _a.toString()) !== null && _b !== void 0 ? _b : "";
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
    if (!input && validInput) {
        errorMessageBody.append("<p>Something went wrong please try again</p>");
        validInput = false;
    }
    if (!validInput) {
        errorMessageBody.addClass("user-search-error-rq");
        usersTable.hide();
    }
    return validInput;
}
function findUsers(data) {
    var _a, _b;
    console.log(data);
    if (data.length > 0) {
        usersTable.empty();
        generateTableBody();
        var usersTableBody_1 = $("#user-tbody");
        generateHeaders(usersTableBody_1);
        $.each(data, function (index, item) {
            var _a, _b, _c, _d, _e;
            var result = "\n                <tr>\n                    <td>".concat(item.username, "</td>\n                    <td>").concat((_a = item.email) !== null && _a !== void 0 ? _a : "", "</td>\n                    <td>").concat((_b = item.firstName) !== null && _b !== void 0 ? _b : "", " ").concat((_c = item.lastName) !== null && _c !== void 0 ? _c : "", "</td>\n                    <td>").concat((_d = item.followingCount) !== null && _d !== void 0 ? _d : 0, "</td>\n                    <td>").concat((_e = item.followerCount) !== null && _e !== void 0 ? _e : 0, "</td>\n                </tr>\n            ");
            usersTableBody_1.append(result);
        });
        usersTable.show();
    }
    else {
        var invalidUser = (_b = (_a = $("#username-entered").val()) === null || _a === void 0 ? void 0 : _a.toString()) !== null && _b !== void 0 ? _b : "";
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