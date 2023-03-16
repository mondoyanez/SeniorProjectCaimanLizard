const submitButton: JQuery<HTMLElement> = $("#username-search-btn");
const errorMessageBody: JQuery<HTMLElement> = $("#user-search-input-error-message");
const re: RegExp = /^[A-Za-z]+$/;
const usersTable: JQuery<HTMLElement> = $("#users-found");

submitButton.on("click", (e: JQuery.Event) => {
    e.preventDefault();
    const query: string = $("#username-entered").val()?.toString() ?? "";
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
    let validInput: boolean = true;

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

function findUsers(data: any[]) {
    console.log(data);
    if (data.length > 0) {
        usersTable.empty();
        generateTableBody();
        const usersTableBody: JQuery<HTMLElement> = $("#user-tbody");
        generateHeaders(usersTableBody);

        $.each(data, (index, item) => {
            const result: string =
                `
                <tr>
                    <td>${item.username}</td>
                    <td>${item.email ?? ""}</td>
                    <td>${item.firstName ?? ""} ${item.lastName ?? ""}</td>
                    <td>${item.followingCount ?? 0}</td>
                    <td>${item.followerCount ?? 0}</td>
                </tr>
            `;
            usersTableBody.append(result);
        });
        usersTable.show();
    } else {
        const invalidUser: string = $("#username-entered").val()?.toString() ?? "";
        errorMessageBody.append(`No user was found by the name of ${invalidUser} please try again`);
        errorMessageBody.addClass("user-search-error-rq");
        usersTable.hide();
    }
}

function generateHeaders(usersTableBody: JQuery<HTMLElement>) {
    const headers: string =
        `
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
    const tBody: string = "<tbody id=\"user-tbody\"></tbody>";
    usersTable.append(tBody);
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
}