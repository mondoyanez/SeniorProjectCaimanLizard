import { validateInput } from "./inputValidation.js";
import { generateHeaders, generateTableBody } from "./manipulateDomUsers.js";

const submitButton: JQuery<HTMLElement> = $("#username-search-btn");
const errorMessageBody: JQuery<HTMLElement> = $("#user-search-input-error-message");
const re: RegExp = /^[A-Za-z]+$/;
const usersTable: JQuery<HTMLElement> = $("#users-found");

submitButton.on("click", (e: JQuery.Event) => {
    e.preventDefault();
    const query: string = $("#username-entered").val()?.toString() ?? "";
    const currentUser: string = $("#currentUser").val()?.toString() ?? "";
    errorMessageBody.empty();
    if (!validateInput(query, currentUser, re, errorMessageBody, usersTable)) {
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

function findUsers(data: any[]) {
    const currentUser: string = $("#currentUser").val()?.toString() ?? "";
    if (data.length > 0) {
        usersTable.empty();
        generateTableBody(usersTable);
        const usersTableBody: JQuery<HTMLElement> = $("#user-tbody");
        generateHeaders(usersTableBody);

        $.each(data, (index, item) => {
            if (currentUser !== item.username) {
                const result: string =
                    `
                <tr>
                    <td><a class="user-profile-link" href="/user/${item.username}">${item.username}</a></td>
                    <td>${item.email ?? ""}</td>
                    <td>${item.firstName ?? ""} ${item.lastName ?? ""}</td>
                </tr>
                `;
                usersTableBody.append(result);
            }
        });
        usersTable.show();
    } else {
        const invalidUser: string = $("#username-entered").val()?.toString() ?? "";
        errorMessageBody.append(`No user was found by the name of ${invalidUser} please try again`);
        errorMessageBody.addClass("user-search-error-rq");
        usersTable.hide();
    }
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
}