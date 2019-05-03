function betterAlert(text, alertClass) {
    let alertExists = document.querySelector(".betterAlerts");
    if (alertExists == null) {
        let alert = document.createElement("div");
        alert.classList.add("betterAlerts", alertClass);
        alert.innerText = text;
        let body = document.querySelector("body");
        body.appendChild(alert);
        setTimeout(
            () => {
                body.removeChild(document.querySelector(".betterAlerts"));
            }, 3000);
    }
    else {
        setTimeout(() => { betterAlert(text, alertClass); }, 500);
    }
}

function betterAlertSuccess(text) {
    betterAlert(text, 'successAlert');
}


function betterAlertError(text) {
    betterAlert(text, 'errorAlert')
}