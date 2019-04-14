let releases = document.querySelectorAll("[data-releaseId]");
releases.forEach((release) => {
    release.addEventListener("click", () => UpdateFollowState(release, UpdateGui));
})

function UpdateGui(release, newFollowCount, newFollowState) {
    let releasefollow = release.getElementsByClassName("release-follow-small")[0];
    releasefollow.classList.toggle("releaseUnfollowStyle");
    releasefollow.classList.toggle("releaseFollowStyle");
    let releaseWrapper = release.parentElement.parentElement;
    releaseWrapper.getElementsByClassName("followcounter")[0].innerText = newFollowCount;
    if(newFollowState == "unfollow")
        prodSuccess("Now following " + releaseWrapper.querySelector(".title-link").innerText + "." );
    else
        prodError("No longer following " + releaseWrapper.querySelector(".title-link").innerText + "." );
}
