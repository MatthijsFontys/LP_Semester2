InitReplyEventListeners();


function InitReplyEventListeners() {
    document.querySelectorAll(".BtnReply").forEach((val) => val.addEventListener("click", () => CreateReplyInsertBox(val.parentElement), false));
}



function CreateReplyInsertBox(commentReplyingTo) {
    DeleteExistingReplyBoxes();
    let replyBox = PrepareReplyBox(commentReplyingTo);
    AddReplyBoxToPage(commentReplyingTo, replyBox);
}

function DeleteExistingReplyBoxes() {
    document.querySelectorAll("#ReplyCommentBox").forEach(
        function (val) {
            val.parentNode.removeChild(val);
        }
    );
}
function PrepareReplyBox(commentReplyingTo) {
    // Preparing the wrapper
    let replyInputBox = document.querySelector("#CommentField").cloneNode(true);
    replyInputBox.id = "ReplyCommentBox";
    // Preparing text area
    let textarea = replyInputBox.getElementsByTagName("textarea")[0];
    textarea.value = '';
    textarea.removeAttribute("id");
    textarea.placeholder = "Your reply";
    // Add event handler to post btn
    let postBtn = replyInputBox.querySelector("#BtnSubmit");
    postBtn.removeAttribute("id");
    postBtn.addEventListener("click", () => PostReply(textarea, commentReplyingTo.dataset.commentid), false);
    
    return replyInputBox;
}

function AddReplyBoxToPage(insertAfter, replyBox) {
    let commentList = document.getElementById("CommentList");
    commentList.insertBefore(replyBox, insertAfter.nextSibling);
}


function PostReply(replyArea, replyId) {
    let text = replyArea.value;
    $.ajax({
        type: "POST",
        url: "/comment/postcomment/",
        data: { releaseId: releaseId, commentText: text, replyId: replyId }
    }).done(function () {
        replyArea.parentNode.parentNode.removeChild(replyArea.parentNode);
    });
}

function AppendReply() {
}



