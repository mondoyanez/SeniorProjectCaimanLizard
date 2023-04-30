const groupId = $("#watch-group-id").val();
const listUsers = $("#watch-group-users")[0];

$(".add-user").on("click", function (e) {
    e.preventDefault();
    const userId = e.target.value;
    const data = { groupId: groupId, userId: userId };

    $.ajax({
        type: "POST",
        url: "/partyGroup/AddUser",
        data: JSON.stringify(data),
        dataType: "json",
        success: addUserToTable(e),
        error: errorOnAjax
    });
    
});

function addUserToTable(e) {
    const username = e.target.innerHTML;

    const element = document.createElement("p");
    element.innerHTML = username;

    listUsers.append(element);
    removeButton(e);
}

function removeButton(e) {
    e.target.parentNode.remove();
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
    // take care of the error, maybe display a message to the user
    // ...
}