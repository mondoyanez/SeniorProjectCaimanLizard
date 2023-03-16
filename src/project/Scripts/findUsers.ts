﻿const submitButton = $("#username-search-btn");
const errorMessageBody = $("#user-search-input-error-message");
const re = new RegExp("^[A-Za-z]+$");
const usersTable = $("#users-found");

submitButton.on("click", (e) => {
    e.preventDefault();
    const query = $("#username-entered").val().toString();
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

function validateInput(input: string): boolean {
    let validInput = true;

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
    $.each(data, (index, item) => {
        let result =
            `
                <tr>
                    <td>${item.username}</td>
                    <td>${item.email ? item.email : ""}</td>
                    <td>${item.firstName ? item.firstName : ""} ${item.lastName ? item.lastName : ""}</td>
                    <td>${item.followingCount ? item.followingCount : 0}</td>
                    <td>${item.followerCount ? item.followerCount : 0}</td>
                </tr>
            `;
        usersTable.append(result);
    });
    usersTable.css("display", "inline");
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
}