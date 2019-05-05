let followBtn = document.querySelector("[data-releaseid]");
followBtn.addEventListener("click", () => UpdateFollowState(followBtn, UpdateGui));

function UpdateGui(release, newFollowCount) {
    release.classList.toggle("error-button");
    release.classList.toggle("correct-button");
    document.querySelector("#followCounter").innerText = newFollowCount;
}