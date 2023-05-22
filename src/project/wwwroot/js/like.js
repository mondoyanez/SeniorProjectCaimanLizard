// increment/decrement like count

// update like count
$(".bi-heart, .bi-heart-fill").on("click", function (e) {
    e.preventDefault();
    let postId = $(this).data("post-id");
    let userId = $(this).data("user-id");
    let $likeIcon = $(this);
    let controllerAction = "";

    if ($(this).hasClass("bi-heart")) {
        controllerAction = `/like/AddLikePost/?userId=${userId}&postId=${postId}`;
    } else if ($(this).hasClass("bi-heart-fill")) {
        controllerAction = `/like/RemoveLikePost/?userId=${userId}&postId=${postId}`;
    }

    $.ajax({
        type: "POST",
        dataType: "json",
        url: controllerAction,
        success: function() {
            toggleLikeIcon($likeIcon);
            updateLikeCount($likeIcon);
        },
        error: errorOnAjax
    });
});

function toggleLikeIcon(likeIcon) {
    if (likeIcon.hasClass("bi-heart")) {
        likeIcon.removeClass("bi-heart").addClass("bi-heart-fill");
        console.log("like icon filled");
    } else if (likeIcon.hasClass("bi-heart-fill")) {
        likeIcon.removeClass("bi-heart-fill").addClass("bi-heart");
        console.log("like icon emptied");
    }
}

function updateLikeCount(likeIcon) {
    let likeCountElement = likeIcon.next("p");
    let likeCount = parseInt(likeCountElement.text());
    

    if (likeIcon.hasClass("bi-heart")) {
        likeCount--;
        console.log(`like count decreased to ${likeCount}`);
    } else if (likeIcon.hasClass("bi-heart-fill")) {
        likeCount++;
        console.log(`like count increased to ${likeCount}`);
    }

    likeCountElement.text(likeCount);
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
    alert("error has occurred please try again, if issue persists contact an admin thank you.");
}