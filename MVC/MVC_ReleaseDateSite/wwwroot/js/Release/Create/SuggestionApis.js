let gotSuggestion = false;
function GetSuggestion() {
    let title = document.querySelector("#title").value;
    let dropdown = document.querySelector("#category-selector");
    if (title != "") {
        if (dropdown.value == 3)
            $.get("/Api/MovieSuggestion?title=" + title, GetMovieData);
        else if (dropdown.value == 2)
            $.get("/Api/GameSuggestion?title=" + title, GetGameData);
    }
}

function GetMovieData(data) {
    if (data.Response == "True") {
        FillSuggestionFields(data.Title, data.Poster, data.Plot);
        gotSuggestion = true;
    }
}

function GetGameData(data) {
    if (data.name != null) {
        let imageUrl = data.cover.url.replace("thumb", "720p");
        FillSuggestionFields(data.name, imageUrl, data.summary);
        gotSuggestion = true;
    }
}

function FillSuggestionFields(title, image, summary) {
    let descriptionBox = document.querySelector("div.suggestion");
    document.querySelector("span.suggestion").innerText = title; //+ " " + data.Year;
    document.querySelector("img.suggestion").src = image;
    descriptionBox.innerText = summary;
    document.querySelectorAll(".d-none").forEach(
        (val) => val.classList.remove("d-none"));
    InitReadMoreBtn();
    document.querySelector("#image").value = image;
    document.querySelector("#description").value = summary;
}

// Let the user clear the suggested input easily
function ClearSuggestionInput(inputBox) {
    if (gotSuggestion)
        inputBox.value = "";
}