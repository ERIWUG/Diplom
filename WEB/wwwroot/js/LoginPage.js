function ChangePassVisibility() {
    var x = document.getElementById("PasswordField");
    if (x.getAttribute("type") == "text") {
        x.setAttribute("type", "password");
    }
    else {
        x.setAttribute("type", "text");
    }
}