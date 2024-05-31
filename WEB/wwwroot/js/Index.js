function Hide(a) {
    switch (a) {
        case 1:
            document.getElementById("country-item-div").style.display = "none";
            document.getElementById("country-button").value = "⯆";
            document.getElementById("country-button").setAttribute("onclick", "Show(1)");
            break;
        case 2:
            document.getElementById("town-item-div").style.display ="none";
            document.getElementById("town-button").value = "⯆";
            document.getElementById("town-button").setAttribute("onclick", "Show(2)");
            break;

    }
}

function Show(a) {
    switch (a) {
        case 1:
            document.getElementById("country-item-div").style.display = "flex";
            document.getElementById("country-button").value = "⯅";
            document.getElementById("country-button").setAttribute("onclick", "Hide(1)");
            break;
        case 2:
            document.getElementById("town-item-div").style.display = "flex";
            document.getElementById("town-button").value = "⯅";
            document.getElementById("town-button").setAttribute("onclick", "Hide(2)");
            break;

    }
}

function ExtendFilter(a) {
    switch (a) {
        case 1:

            for (let element of document.getElementsByClassName("visual-label-country")) {
                element.style.display = "flex";
            }
            document.getElementById("extend-country-button").style.display = "none";
            document.getElementById("hide-country-button").style.display = "flex";

            break;
        case 2:

            for (let element of document.getElementsByClassName("visual-label-town")) {
                element.style.display = "flex";
            }
            document.getElementById("extend-town-button").style.display = "none";
            document.getElementById("hide-town-button").style.display = "flex";

            break;
    }
}

function HideFilter(a) {
    switch (a) {
        case 1:

            for (let element of document.getElementsByClassName("visual-label-country")) {
                element.style.display = "none";
            }

            document.getElementById("extend-country-button").style.display = "flex";
            document.getElementById("hide-country-button").style.display = "none";

            break;
        case 2:

            for (let element of document.getElementsByClassName("visual-label-town")) {
                element.style.display = "none";
            }
            document.getElementById("extend-town-button").style.display = "flex";
            document.getElementById("hide-town-button").style.display = "none";

            break;
    }
}