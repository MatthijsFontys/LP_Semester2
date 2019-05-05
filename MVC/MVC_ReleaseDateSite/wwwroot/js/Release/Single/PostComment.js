let releaseId = document.querySelector("[data-releaseid]").dataset.releaseid;
InitEventListeners();


function InitEventListeners() {
    document.querySelector("#BtnSubmit").addEventListener("click", () => { PostComment(); });
}

/* ################## Regular comments ######################*/
function PostComment() {
    let text = document.querySelector("#CommentBox").value;
    document.querySelector("#CommentBox").value = "";
    // Post:
    $.ajax({
        type: "POST",
        url: "/comment/postcomment/",
        data: { releaseId: releaseId, commentText: text },
        success: AppendComment
    })
}

function AppendComment(data) {
    let div = document.createElement("div");
    div.classList.add("w-100");
    div.innerHTML = data;
    let commentList = document.getElementById("CommentList");
    let insertAfter = document.getElementById("CommentField");
    commentList.insertBefore(div, insertAfter.nextSibling);
}



