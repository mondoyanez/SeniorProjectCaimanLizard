"use strict";
const followButton = $("#user-profile-btn-follow");
const unfollowButton = $("#user-profile-following-icon");
followButton.on("click", (e) => {
    e.preventDefault();
    const followerUsername = $("#user-profile-username").val();
    $(() => {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: `/followingList/addFollower/?followerUsername=${followerUsername}`,
            success: addFollower,
            error: errorOnAjax
        });
    });
});
unfollowButton.on("click", (e) => {
    e.preventDefault();
    const followerUsername = $("#user-profile-username").val();
    $(() => {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: `/followingList/removeFollower/?followerUsername=${followerUsername}`,
            success: removeFollower,
            error: errorOnAjax
        });
    });
});
function addFollower() {
    $("#user-profile-btn-follow").hide();
    $("#user-profile-following-icon").show();
    // Get current amount of followers, convert that into a number add 1 more follower and save the new result into user-amount-followers
    $("#user-amount-followers").html(String(Number($("#user-amount-followers").html()) + 1));
}
function removeFollower() {
    $("#user-profile-following-icon").hide();
    $("#user-profile-btn-follow").show();
    // Get current amount of followers, convert that into a number subtract 1 follower and save the new result into user-amount-followers
    $("#user-amount-followers").html(String(Number($("#user-amount-followers").html()) - 1));
}
function errorOnAjax() {
    console.log("ERROR in ajax request");
}
//# sourceMappingURL=followUser.js.map