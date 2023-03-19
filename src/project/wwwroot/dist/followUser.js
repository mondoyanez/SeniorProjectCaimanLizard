"use strict";
const submitButton = $("#user-profile-btn-follow");
submitButton.on("click", (e) => {
    e.preventDefault();
    changeButtonToFollowing();
});
function changeButtonToFollowing() {
    $("#user-profile-btn-follow").hide();
    $("#user-profile-following-icon").show();
}
//# sourceMappingURL=followUser.js.map