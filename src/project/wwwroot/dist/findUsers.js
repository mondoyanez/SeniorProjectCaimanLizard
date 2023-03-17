"use strict";
const submitButton = $("#username-search-btn");
const errorMessageBody = $("#user-search-input-error-message");
const re = /^[A-Za-z]+$/;
const usersTable = $("#users-found");
submitButton.on("click", (e) => {
    var _a, _b;
    e.preventDefault();
    const query = (_b = (_a = $("#username-entered").val()) === null || _a === void 0 ? void 0 : _a.toString()) !== null && _b !== void 0 ? _b : "";
    errorMessageBody.empty();
    if (!validateInput(query)) {
        return;
    }
    $(() => {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: `/watcher/findByUsername?username=${query}`,
            success: findUsers,
            error: errorOnAjax
        });
    });
});
function validateInput(input) {
    let validInput = true;
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
        const usersTableBody = $("#user-tbody");
        generateHeaders(usersTableBody);
        $.each(data, (index, item) => {
            var _a, _b, _c, _d, _e;
            const result = `
                <tr>
                    <td>${item.username}</td>
                    <td>${(_a = item.email) !== null && _a !== void 0 ? _a : ""}</td>
                    <td>${(_b = item.firstName) !== null && _b !== void 0 ? _b : ""} ${(_c = item.lastName) !== null && _c !== void 0 ? _c : ""}</td>
                    <td>${(_d = item.followingCount) !== null && _d !== void 0 ? _d : 0}</td>
                    <td>${(_e = item.followerCount) !== null && _e !== void 0 ? _e : 0}</td>
                </tr>
            `;
            usersTableBody.append(result);
        });
        usersTable.show();
    }
    else {
        const invalidUser = (_b = (_a = $("#username-entered").val()) === null || _a === void 0 ? void 0 : _a.toString()) !== null && _b !== void 0 ? _b : "";
        errorMessageBody.append(`No user was found by the name of ${invalidUser} please try again`);
        errorMessageBody.addClass("user-search-error-rq");
        usersTable.hide();
    }
}
function generateHeaders(usersTableBody) {
    const headers = `
        <tr>
            <th>Username </th>
            <th> Email </th>
            <th> First and Last Name </th>
            <th> Amount Following </th>
            <th> Amount of Followers </th>
        </tr>
    `;
    usersTableBody.append(headers);
}
function generateTableBody() {
    const tBody = "<tbody id=\"user-tbody\"></tbody>";
    usersTable.append(tBody);
}
function errorOnAjax() {
    console.log("ERROR in ajax request");
}
//# sourceMappingURL=findUsers.js.map