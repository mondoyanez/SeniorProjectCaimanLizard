const groupId = $("#watch-group-id").val();
const listUsers = $("#watch-group-users")[0];
const maxUsers = $("#watch-group-total-users")[0];
const currentUsers = $("#watch-group-current-users")[0];
const modalBody = $(".modal-body")[0];

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

    if (currentUsers.value === maxUsers.value) {
        displayNoUsers();
    }
});

function addUserToTable(e) {
    const username = e.target.innerHTML;

    const element = document.createElement("p");
    element.innerHTML = username;

    listUsers.append(element);
    updateCurrentUsers();
    removeButton(e);
}

function updateCurrentUsers() {
    currentUsers.value = Number(currentUsers.value) + 1;
}

function displayNoUsers() {
    const div = document.createElement("div");
    div.setAttribute("class", "col-4");

    const element = document.createElement("p");
    element.innerHTML = "No users to add";

    div.append(element);
    modalBody.append(div);

}

function removeButton(e) {
    e.target.parentNode.remove();
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
    alert("error has occurred please try again, if issue persists contact on admin thank you.");
}