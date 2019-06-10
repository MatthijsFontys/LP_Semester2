let available;
function IsUsernameAvailable(inputBox) {
    let username = inputBox.value;
    $.ajax({
        type: "POST",
        url: "/account/IsUsernameAvailable",
        data: { "username": username }
    }).done((data) => {
        let json = JSON.parse(data);
        let usernameValidationField = document.querySelector("#username-validation");
        if (json.result == false && usernameValidationField.innerHTML == "") {
            usernameValidationField.innerHTML += "This username already exists";
            available = false;
        }
        else if (json.result == true && available == false) {
            usernameValidationField.innerHTML = "";
            available = true;
        }
    });
}