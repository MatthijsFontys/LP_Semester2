function InitExpandContainer(expandBtn, expandContainer, maxHeight) {
    HideReadMoreIfNotOverflown(expandBtn, expandContainer);
    expandBtn.onclick = () => ToggleContainerExpansion(expandBtn, expandContainer, maxHeight);
}

function HideReadMoreIfNotOverflown(expandBtn, expandContainer) {
    if (expandContainer.scrollHeight <= expandContainer.clientHeight)
        expandBtn.classList.add("d-none");
}


function ToggleContainerExpansion(expandBtn, expandContainer, maxHeight) {
    if (expandBtn.innerText.toLowerCase().includes("more")) {
        expandBtn.innerText = "show less";
        expandContainer.style.maxHeight = "unset";
    }
    else {
        expandBtn.innerText = "read more";
        expandContainer.style.maxHeight = maxHeight;
    }
}