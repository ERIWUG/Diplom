function GetQuestion(j) {
    var val = document.getElementById("ShowQuestionId").value;
    document.getElementById("ShowQuestionId").value = j;
    document.getElementById("question-" + val).setAttribute("style", "display:none");
    document.getElementById("question-" + j).setAttribute("style", "display:flex");


    document.getElementById("questionButton-" + val).style.backgroundColor = "white";
    document.getElementById("questionButton-" + j).style.backgroundColor = "#e9e9ed"



}