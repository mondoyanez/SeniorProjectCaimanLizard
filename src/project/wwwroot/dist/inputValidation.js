export function validateInput(input, currentUser, re, errorMessageBody, usersTable) {
    let validInput = true;
    if (input === "") {
        errorMessageBody.append("<p>This is a required field, please enter a username</p>");
        validInput = false;
    }
    if (input === currentUser && validInput) {
        errorMessageBody.append("<p>You cannot search for yourself, please enter another username</p>");
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
//# sourceMappingURL=inputValidation.js.map