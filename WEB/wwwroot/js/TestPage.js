function HidePopUp() {
    document.getElementById("ModuleDiv").style.display = "none";


    var q = document.querySelectorAll("div").forEach(c => {
        if (c.getAttribute("class") == "extend-button") {
            c.style.display = "block";
        }
    });

}

function ShowReportSubmit() {
    if (!document.querySelector('#ModuleReportConfirm')) {
        var Module = document.createElement("div");
        Module.setAttribute("id", "ModuleReportConfirm");
        Module.style.width = "100%";
        Module.style.height = "100%";
        Module.style.background = "rgba(102, 102, 102, 0.5)";
        Module.style.position = "fixed";
        Module.style.top = "0";
        Module.style.left = "0";
        Module.style.display = "block";

        var ModuleDiv = document.createElement("div");

        ModuleDiv.style.position = "absolute";
        ModuleDiv.style.top = "0";
        ModuleDiv.style.right = "0";
        ModuleDiv.style.bottom = "0";
        ModuleDiv.style.left = "0";
        ModuleDiv.style.display = "flex";
        ModuleDiv.style.alignItems = "center";
        ModuleDiv.style.justifyContent = "center";

        var PopupDiv = document.createElement("div");
        PopupDiv.style.marginBottom = "8%";
        PopupDiv.style.background = "white";
        PopupDiv.style.padding = "30px";
        PopupDiv.style.border = "2px solid";
        PopupDiv.style.borderRadius = "20px";

        var text1 = document.createElement("h1");
        text1.innerHTML = "Вы уверены, что хотите пожаловаться на этот тест?";
        text1.style.marginTop = "0px";

        var text2 = document.createElement("p");
        text2.innerHTML = "После подтверждения вам будет необходимо еще раз нажать на кнопку пожаловаться";


        var ButtonDiv = document.createElement("div");
        ButtonDiv.style.display = "flex";
        ButtonDiv.style.flexDirection = "row";
        ButtonDiv.style.justifyContent = "space-between";

        var buttonYes = document.createElement("input");
        buttonYes.setAttribute("type", "button");
        buttonYes.setAttribute("onclick", "ChangeStatement()");
        buttonYes.setAttribute("value", "Да");


        var buttonNo = document.createElement("input");
        buttonNo.setAttribute("type", "button");
        buttonNo.setAttribute("onclick", "HideConfirmModule()");
        buttonNo.setAttribute("value", "Нет");

        ButtonDiv.appendChild(buttonYes); ButtonDiv.appendChild(buttonNo);

        PopupDiv.appendChild(text1); PopupDiv.appendChild(text2); PopupDiv.appendChild(ButtonDiv);
        ModuleDiv.appendChild(PopupDiv);
        Module.appendChild(ModuleDiv);

        document.getElementsByClassName("pageContent")[0].appendChild(Module);
    }
    else {
        document.getElementById("ModuleReportConfirm").style.display = "block";
    }



}


function HideConfirmModule() {
    document.getElementById("ModuleReportConfirm").style.display = "none";
}

function ChangeStatement() {
    document.getElementById("ModuleReportConfirm").style.display = "none";
    document.getElementById("ButtonReportSubmit").style.display = "none";
    document.getElementById("ButtonReportSubmitConfirmed").style.display = "flex";
}


function HideConfirmModuleComment() {
    document.getElementById("ModuleReportConfirmComment").style.display = "none";
}

function ShowSubmitComment(a) {
    if (!document.querySelector('#ModuleReportConfirmComment')) {
        var Module = document.createElement("div");
        Module.setAttribute("id", "ModuleReportConfirmComment");
        Module.style.width = "100%";
        Module.style.height = "100%";
        Module.style.background = "rgba(102, 102, 102, 0.5)";
        Module.style.position = "fixed";
        Module.style.top = "0";
        Module.style.left = "0";
        Module.style.display = "block";
        Module.style.transform = "translate(-50 %, -50 %)";




        var ModuleDiv = document.createElement("div");

        ModuleDiv.style.position = "absolute";
        ModuleDiv.style.top = "0";
        ModuleDiv.style.right = "0";
        ModuleDiv.style.bottom = "0";
        ModuleDiv.style.left = "0";
        ModuleDiv.style.display = "flex";
        ModuleDiv.style.alignItems = "center";
        ModuleDiv.style.justifyContent = "center";

        var PopupDiv = document.createElement("div");
        PopupDiv.style.marginBottom = "8%";
        PopupDiv.style.background = "white";
        PopupDiv.style.padding = "30px";
        PopupDiv.style.border = "2px solid";
        PopupDiv.style.borderRadius = "20px";

        var text1 = document.createElement("h1");
        text1.innerHTML = "Вы уверены, что хотите пожаловаться на этот комментарий?";
        text1.style.marginTop = "0px";

        var ButtonDiv = document.createElement("div");
        ButtonDiv.style.display = "flex";
        ButtonDiv.style.flexDirection = "row";
        ButtonDiv.style.justifyContent = "space-between";

        var buttonYes = document.createElement("input");
        buttonYes.setAttribute("type", "button");
        buttonYes.setAttribute("onclick", "location.href='/Home/ReportComment/" + a + "';");
        buttonYes.setAttribute("value", "Да");



        var buttonNo = document.createElement("input");
        buttonNo.setAttribute("type", "button");
        buttonNo.setAttribute("onclick", "HideConfirmModuleComment()");
        buttonNo.setAttribute("value", "Нет");

        ButtonDiv.appendChild(buttonYes); ButtonDiv.appendChild(buttonNo);

        PopupDiv.appendChild(text1); PopupDiv.appendChild(ButtonDiv);
        ModuleDiv.appendChild(PopupDiv);
        Module.appendChild(ModuleDiv);

        document.getElementsByClassName("body-block")[0].appendChild(Module);
    }
    else {
        document.getElementById("ModuleReportConfirm").style.display = "block";
    }
}