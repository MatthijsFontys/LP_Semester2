let releaseId = document.querySelector("[data-releaseid]").dataset.releaseid;
let replyId;

document.querySelector("#BtnSubmit").addEventListener("click", () => { PostComment(); });
document.querySelectorAll(".BtnReply").forEach((val) => val.addEventListener("click", () => AppendReply(val.parentElement), false));


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


function PostReply(replyArea) {
    let text = replyArea.value;
    $.ajax({
        type: "POST",
        url: "/comment/postcomment/",
        data: { releaseId: releaseId, commentText: text, replyId: replyId }
    }).done(function () {
        replyArea.parentNode.parentNode.removeChild(replyArea.parentNode);
    });
}


function AppendReply(insertAfter) {
    document.querySelectorAll("#ReplyCommentBox").forEach(
        function (val) {
            val.parentNode.removeChild(val);
        }
    );
    // Set the parent comment id for the database
    replyId = insertAfter.dataset.commentid;
    // Preparing the reply box
    let replyInputBox = document.querySelector("#CommentField").cloneNode(true);
    let postBtn = replyInputBox.querySelector("#BtnSubmit");
    postBtn.removeAttribute("id");
    replyInputBox.id = "ReplyCommentBox";
    // Preparing text area
    let textarea = replyInputBox.getElementsByTagName("textarea")[0];
    textarea.value = '';
    textarea.removeAttribute("id");
    textarea.placeholder = "Your reply";

    // Insert into html
    let commentList = document.getElementById("CommentList");
    commentList.insertBefore(replyInputBox, insertAfter.nextSibling);

    // Adding event listener
    postBtn.addEventListener("click", () => PostReply(textarea), false);
}

function AppendComment(data) {
    let div = document.createElement("div");
    div.classList.add("w-100");
    div.innerHTML = data;
    let commentList = document.getElementById("CommentList");
    let insertAfter = document.getElementById("CommentField");
    commentList.insertBefore(div, insertAfter.nextSibling);
}

