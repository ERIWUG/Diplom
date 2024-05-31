function AddNewItem() {
    var lastIndex = Number(document.getElementById("LastId").value)+1;
    document.getElementById("LastId").value = lastIndex ;

    var Module = document.getElementById("mainTable");

    var tr = document.createElement("tr");

    var tdDiv = document.createElement("td");
    var MDiv = document.createElement("div");
    MDiv.setAttribute("id", "CheckDiv-" + lastIndex);
    MDiv.setAttribute("class", "CheckDiv");
    MDiv.style.backgroundColor = "#00ff00";
    tdDiv.appendChild(MDiv);

    var hidInput = document.createElement("input")
    hidInput.setAttribute("type", "hidden");
    hidInput.setAttribute("name", "StateID");
    hidInput.setAttribute("id", "StateID-" + lastIndex);
    hidInput.setAttribute("value", "2");
    tdDiv.appendChild(hidInput);
    tr.appendChild(tdDiv);

    var tdId = document.createElement("td");
    var InputId = document.createElement("input");
    InputId.setAttribute("type", "text");
    InputId.setAttribute("size", "4");
    InputId.setAttribute("name", "id");
    InputId.setAttribute("readonly", "readonly");
    InputId.setAttribute("value", lastIndex);
    tdId.appendChild(InputId);
    tr.appendChild(tdId);

    var tdLogin = document.createElement("td");
    var InputLogin = document.createElement("input");
    InputLogin.setAttribute("type", "text");
    InputLogin.setAttribute("name", "login");
    InputLogin.setAttribute("required", "required");
    tdLogin.appendChild(InputLogin);
    tr.appendChild(tdLogin);
              
    var tdPhone = document.createElement("td");
    var InputPhone = document.createElement("input");
    InputPhone.setAttribute("type", "text");
    InputPhone.setAttribute("size", "14");
    InputPhone.setAttribute("name", "phone");
    tdPhone.appendChild(InputPhone);
    tr.appendChild(tdPhone);
                
    var tdName = document.createElement("td");
    var InputName = document.createElement("input");
    InputName.setAttribute("type", "text");
    InputName.setAttribute("name", "name");
    tdName.appendChild(InputName);
    tr.appendChild(tdName);
               
    var tdSurname = document.createElement("td");
    var InputSurname = document.createElement("input");
    InputSurname.setAttribute("type", "text");
    InputSurname.setAttribute("name", "surname");
    tdSurname.appendChild(InputSurname);
    tr.appendChild(tdSurname);

    var tdAge = document.createElement("td");
    var InputAge = document.createElement("input");
    InputAge.setAttribute("type", "number");
    InputAge.setAttribute("size", "4");
    InputAge.setAttribute("name", "age");
    InputAge.setAttribute("value", "0");
    tdAge.appendChild(InputAge);
    tr.appendChild(tdAge);

    var tdCountry = document.createElement("td");
    var InputCountry = document.createElement("input");
    InputCountry.setAttribute("type", "text");
    InputCountry.setAttribute("size", "15");
    InputCountry.setAttribute("name", "country");
    tdCountry.appendChild(InputCountry)
    tr.appendChild(tdCountry);
               
    var tdTown = document.createElement("td");
    var InputTown = document.createElement("input");
    InputTown.setAttribute("type", "text");
    InputTown.setAttribute("size", "15");
    InputTown.setAttribute("name", "town");
    tdTown.appendChild(InputTown);
    tr.appendChild(tdTown);

    var tdHref = document.createElement("td");
    tdHref.setAttribute("class","href-td")
    var Href = document.createElement("a");
    Href.textContent="Page";
    tdHref.appendChild(Href);
    tr.appendChild(tdHref);

    var tdHref1 = document.createElement("td");
    var Href1 = document.createElement("a");
    tdHref1.setAttribute("class", "href-td");
    Href1.textContent = "Role";
    tdHref1.appendChild(Href1);
    tr.appendChild(tdHref1);

    var tdCheck2 = document.createElement("td");
    var Checkthis2 = document.createElement("input");
    Checkthis2.setAttribute("type", "checkbox");
    Checkthis2.setAttribute("name", "Verify");
    Checkthis2.setAttribute("value", lastIndex);
    Checkthis2.setAttribute("id", "Verification-" + lastIndex);
    Checkthis2.setAttribute("onchange", "ChangeState(" + lastIndex + ")");
    tdCheck2.appendChild(Checkthis2);
    tr.appendChild(tdCheck2);

    var tdCheck = document.createElement("td");
    var Checkthis = document.createElement("input");
    Checkthis.setAttribute("type", "checkbox");
    Checkthis.setAttribute("name", "Deleting");
    Checkthis.setAttribute("value", lastIndex);
    Checkthis.setAttribute("id", "CheckBox-" + lastIndex);
    Checkthis.setAttribute("onchange", "ChangeState(" + lastIndex + ")");
    tdCheck.appendChild(Checkthis);
    tr.appendChild(tdCheck);

    var tdPass = document.createElement("td");
    var Pass = document.createElement("input");
    Pass.setAttribute("type", "text");
    Pass.setAttribute("name", "password-" + lastIndex);
    Pass.setAttribute("size", "10");
    Pass.setAttribute("placeholder","Пароль")
    Pass.setAttribute("required", "required");
    tdPass.appendChild(Pass);
    tr.appendChild(tdPass);
    Module.appendChild(tr);
}

function ChangeState(i) {
    if (document.getElementById("CheckBox-" + i).checked) {
        document.getElementById("CheckDiv-" + i).style.backgroundColor = "#ff0000";
        document.getElementById("StateID-" + i).value = 4;
    }
    else {
        document.getElementById("CheckDiv-" + i).style.backgroundColor = "#ffff00";
        document.getElementById("StateID-" + i).value = 3;
    }
}