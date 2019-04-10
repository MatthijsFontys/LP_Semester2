function UpdateFollowState(release, RefreshGuiFunction) {
    $.post("/release/" + release.dataset.followstate + "/" + release.dataset.releaseid, (data) => {
        let json = JSON.parse(data);
        release.dataset.followstate = json.followState;
        RefreshGuiFunction(release, json.followCount, json.followState);
    });
}