document.querySelector("#day-toggle").addEventListener("click", function () {
    let releases = document.querySelectorAll("[data-releaseId]");
    let dates = [];
    for (let i = 0; i < releases.length; i++) {
        dates[i] =
            {
                "Id": releases[i].dataset.releaseid,
                "Date": releases[i].parentElement.parentElement.querySelector("[data-releasedate]").innerText
            }
    }


    $.ajax({
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        url: "/release/ChangeDate",
        traditional: "true",
        data: JSON.stringify(dates),
        success: (data) => {
            data.forEach(function(val) {
                let release = document.querySelector("[data-releaseid='" + val.id + "']");
                release.parentElement.parentElement.querySelector("[data-releasedate]").innerText = val.date;
            });

        }
    })
});

document.querySelector("#releaseday-toggle").addEventListener("click", function () {
    let dates = document.querySelectorAll("[data-releasedate]");
    dates.forEach(function (val) {
        val.innerText = val.dataset.releasedate;
    })
});

document.querySelector("#clock-toggle").addEventListener("click", function () {
});