let releaseId = document.querySelector("[data-releaseid]").dataset.releaseid;

document.querySelector("#BtnSubmit").addEventListener("click", () => { PostComment(releaseId); });
        function PostComment(id) {
            let text = document.querySelector("#CommentBox").value;
            // Post:
            $.ajax({
                type: "POST",
                url: "/comment/postcomment/",
                data: { releaseId: id, commentText: text },
                success: AppendComment
            })
        }

        function AppendComment(data) {
            document.querySelector("#CommentBox").value = "";
            let div = document.createElement("div");
            div.classList.add("w-100")
            div.innerHTML = data;
            let commentList = document.getElementById("CommentList");
            let insertAfter = document.getElementById("CommentField");
            commentList.insertBefore(div, insertAfter.nextSibling);
        }