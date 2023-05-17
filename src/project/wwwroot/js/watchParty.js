const groupId = $("#watch-group-id").val();
const listUsers = $("#watch-group-users")[0];
const maxUsers = $("#watch-group-total-users")[0];
const minUsers = 1;
const currentUsers = $("#watch-group-current-users")[0];
const modalAdd = $("#add-modal")[0];
const modalRemove = $("#remove-modal")[0];

$(".add-user").on("click", function (e) {
    e.preventDefault();
    const userId = e.target.value;

    $.ajax({
        type: "POST",
        dataType: "json",
        url: `/partyGroup/AddUser/?groupId=${groupId}&userId=${userId}`,
        success: addUserToTable(e),
        error: errorOnAjax
    });

    if (Number(currentUsers.value) === Number(maxUsers.value)) {
        displayNoUsers("add");
    }
});

$(".remove-user").on("click", function(e) {
    e.preventDefault();
    const userId = e.target.value;

    $.ajax({
        type: "DELETE",
        dataType: "json",
        url: `/partyGroup/RemoveUser/?groupId=${groupId}&userId=${userId}`,
        success: removeUserFromTable(e),
        error: errorOnAjax
    });

    if (Number(currentUsers.value) === minUsers) {
        displayNoUsers("remove");
    }
});

function addUserToTable(e) {
    const username = e.target.innerHTML;

    const element = document.createElement("p");
    element.innerHTML = username;

    listUsers.append(element);
    updateCurrentUsers("add");
    removeButton(e);
}

function removeUserFromTable(e) {
    const username = e.target.innerHTML;
    const userInTable = $(`#remove-user-${username}`)[0];

    userInTable.remove();
    updateCurrentUsers("remove");
    removeButton(e);
}

function updateCurrentUsers(operation) {

    switch (operation) {
        case "add":
            currentUsers.value = Number(currentUsers.value) + 1;
            break;
        case "remove":
            currentUsers.value = Number(currentUsers.value) - 1;
            break;
    }

}

function displayNoUsers(operation) {
    const div = document.createElement("div");
    div.setAttribute("class", "col-4");

    const element = document.createElement("p");

    switch (operation) {
        case "add":
            element.innerHTML = "No users to add";
            div.append(element);
            modalAdd.append(div);
            break;
        case "remove":
            element.innerHTML = "No users to remove";
            div.append(element);
            modalRemove.append(div);
            break;
    }

}

function removeButton(e) {
    e.target.parentNode.remove();
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
    alert("error has occurred please try again, if issue persists contact on admin thank you.");
}