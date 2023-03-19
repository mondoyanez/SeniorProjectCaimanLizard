const submitButton: JQuery<HTMLElement> = $("#user-profile-btn-follow");

submitButton.on("click", (e: JQuery.Event) => {
    e.preventDefault();
    changeButtonToFollowing();
});

function changeButtonToFollowing() {
    $("#user-profile-btn-follow").hide();
    $("#user-profile-following-icon").show();
}