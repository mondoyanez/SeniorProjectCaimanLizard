const submitButton = $("#username-search-btn");
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
    usersTable.css("display", "inline");
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
