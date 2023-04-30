const groupId = $("#watch-group-id").val();
const listUsers = $("#watch-group-users")[0];

$(".add-user").on("click", function (e) {
    e.preventDefault();
    const userId = e.target.value;

    addUserToTable(e);
    removeButton(e);
});

function addUserToTable(e) {
    const username = e.target.innerHTML;

    const element = document.createElement("p");
    element.innerHTML = username;

    listUsers.append(element);
}

function removeButton(e) {
    e.target.parentNode.remove();
}