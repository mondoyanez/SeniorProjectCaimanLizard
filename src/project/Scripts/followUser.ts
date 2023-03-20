const submitButton: JQuery<HTMLElement> = $("#user-profile-btn-follow");

submitButton.on("click", (e: JQuery.Event) => {
    e.preventDefault();
    const values = getUserValues();

    $(() => {
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            url: `/followingList/addFollower`,
            data: JSON.stringify(values),
            success: addFollower,
            error: errorOnAjax
        });
    });
});

function getUserValues() {
    const userId = $("#user-profile-id").val();

    return {
        //status: true,
        "UserId": Number(userId)
    }
}

function addFollower(): void {
    $("#user-profile-btn-follow").hide();
    $("#user-profile-following-icon").show();
    // Get current amount of followers, convert that into a number add 1 more follower and save the new result into user-amount-followers
    $("#user-amount-followers").html(String(Number($("#user-amount-followers").html()) + 1));
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
}