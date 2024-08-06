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


function Find(a) {
    



    switch (a) {
        case 1:
            
            if (document.getElementById("search-country").value.length == 0) {
                for (let element of document.getElementsByClassName("visual-label-country")) {
                    element.style.display = "none";
                    element.checked = false;
                }
                for (let element of document.getElementsByClassName("always-visual-label-country")) {
                    element.style.display = "flex"
                }
                
                document.getElementById("extend-country-button").style.display = "flex";
                break;
            }

            document.getElementById("extend-country-button").style.display = "none";

            for (let element of document.getElementsByClassName("always-visual-label-country")) {
                if (element.innerHTML.toLowerCase().indexOf(document.getElementById("search-country").value.toLowerCase()) == -1) {
                    element.checked = false;
                    element.style.display = "none";
                }
                else {
                    element.style.display = "flex";
                }
            }
            for (let element of document.getElementsByClassName("visual-label-country")) {
                if (element.innerHTML.toLowerCase().indexOf(document.getElementById("search-country").value.toLowerCase()) == -1) {
                    element.checked = false;
                    element.style.display = "none";
                }
                else {
                    element.style.display = "flex";
                }
            }

            break;
        case 2:
            if (document.getElementById("search-town").value.length == 0) {
                alert("TWO");
                for (let element of document.getElementsByClassName("visual-label-town")) {
                    alert(element.innerHTML);
                    element.style.display = "none";
                    element.checked = false;
                }
                alert("one");
                for (let element of document.getElementsByClassName("always-visual-label-town")) {
                    alert(element.innerHTML);
                    element.style.display = "flex"
                }
                
                document.getElementById("extend-town-button").style.display = "flex";
                break;
            }

            document.getElementById("extend-town-button").style.display = "none";


            for (let element of document.getElementsByClassName("always-visual-label-town")) {
                if (element.innerHTML.toLowerCase().indexOf(document.getElementById("search-town").value.toLowerCase()) == -1) {
                    element.checked = false;
                    element.style.display = "none";
                }
                else {
                    element.style.display = "flex";
                }
            }
            for (let element of document.getElementsByClassName("visual-label-town")) {
                if (element.innerHTML.toLowerCase().indexOf(document.getElementById("search-town").value.toLowerCase()) == -1) {
                    element.checked = false;
                    element.style.display = "none";
                }
                else {
                    element.style.display = "flex";
                }
            }
            break;
    }
}