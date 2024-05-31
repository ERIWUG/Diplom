function ValidateLogin(arr) {
    var NewLogin = document.getElementById("loginField").value;
    var c = arr.indexOf(NewLogin);
    if (c == -1) {
        document.getElementById("ChangeField").style.backgroundColor = "#00ff00";
        document.getElementById("submitButton").removeAttribute("disabled");
    }
    else {
        document.getElementById("ChangeField").style.backgroundColor = "#ff0000";
        document.getElementById("submitButton").setAttribute("disabled", "true")
    }
}
function ChangePassVisibility() {
    
    var x = document.getElementById("PasswordField");
    if (x.getAttribute("type") == "text") {
        x.setAttribute("type", "password");
    }
    else {
        x.setAttribute("type", "text");
    }
}