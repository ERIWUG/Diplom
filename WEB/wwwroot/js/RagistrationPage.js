
function ChangePassVisibility() {
    
    var x = document.getElementById("PasswordField");
    if (x.getAttribute("type") == "text") {
        x.setAttribute("type", "password");
    }
    else {
        x.setAttribute("type", "text");
    }
}

function TryValidate(arr) {
    var NewLogin = document.getElementById("loginField").value;
    if (NewLogin.length < 3) { }
    else { 
    document.getElementById("LoginP").innerHTML = "*Логин занят";

    var c = arr.indexOf(NewLogin);



    if (c == -1 && document.getElementById("RepeatPasswordField").value == document.getElementById("PasswordField").value) {
        document.getElementById("ChangeField").style.backgroundColor = "#00ff00";
        document.getElementById("submitButton").removeAttribute("disabled");
        document.getElementById("PasswordP").style.display = "none";
        document.getElementById("LoginP").style.display = "none";
    }
    else {
        if (c != -1) {
            
            document.getElementById("ChangeField").style.backgroundColor = "#ff0000";
            document.getElementById("submitButton").setAttribute("disabled", "true");
            document.getElementById("PasswordP").style.display = "none"; document.getElementById("LoginP").style.display = "flex";
        }
        else {
            document.getElementById("ChangeField").style.backgroundColor = "#00ff00";
            document.getElementById("PasswordP").style.display = "flex";
            document.getElementById("submitButton").setAttribute("disabled", "true");
            document.getElementById("LoginP").style.display = "none";
        }
        }
    }
}