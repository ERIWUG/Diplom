function AddQuestion() {
    var i = document.getElementById("QuestionAmount").value; i = Number(i);
    document.getElementById("QuestionAmount").value = i + 1;

    var Module = document.createDocumentFragment();

    var divQuestionBlock = document.createElement("div");
    divQuestionBlock.setAttribute("class", "questionBlock");

    var hiddenValue = document.createElement("input");
    hiddenValue.setAttribute("type", "hidden");
    hiddenValue.setAttribute("id", "AnswerCount-" + i);
    hiddenValue.setAttribute("value", "1");
    hiddenValue.setAttribute("name", "AmountQuestion");

    var divQuestion = document.createElement("div");
    divQuestion.setAttribute("class", "question");

   

   


    var divExtendButton = document.createElement("div");

    
    divExtendButton.setAttribute("class", "extend-button");

    var ulExtend1 = document.createElement("ul");
    var liExtend1 = document.createElement("li");
    var spandot = document.createElement("span");
    spandot.innerText = "•••";

    var ulExtend2 = document.createElement("ul");
    var liExtend21 = document.createElement("li");

    var span1 = document.createElement("span");
    span1.innerText = "Radio";

    span1.setAttribute("onclick", "AddRadio(" + i + ")");

    var liExtend22 = document.createElement("li");
    var span2 = document.createElement("span");
    span2.innerText = "CheckBox";

    span2.setAttribute("onclick", "AddCheckBox(" + i + ")");

    var liExtend23 = document.createElement("li");
    var span3 = document.createElement("span");
    span3.innerText = "Input"

    span3.setAttribute("onclick", "AddInput(" + i + ")");

    var liExtend24 = document.createElement("li");
    var span4 = document.createElement("span");
    span4.innerText = "Select";
    span4.setAttribute("onclick", "AddSelect(" + i + ")");

    liExtend21.appendChild(span1);
    liExtend22.appendChild(span2);
    liExtend23.appendChild(span3);
    liExtend24.appendChild(span4);

    ulExtend2.appendChild(liExtend21);
    ulExtend2.appendChild(liExtend22);
    ulExtend2.appendChild(liExtend23);
    ulExtend2.appendChild(liExtend24);

    liExtend1.appendChild(spandot);
    liExtend1.appendChild(ulExtend2);

    ulExtend1.appendChild(liExtend1);

    divExtendButton.appendChild(ulExtend1);



    var label = document.createElement("label")
    label.textContent = i + ".";

    var divAnswer = document.createElement("div");
    divAnswer.setAttribute("class", "Answers");
    divAnswer.setAttribute("id", "Answers-" + i);

    var inputName = document.createElement("input");
    inputName.setAttribute("type", "text");
    inputName.setAttribute("name", "QuestionText");
    inputName.setAttribute("placeholder", "Текст Вопроса");

    var inputImage = document.createElement("input");
    inputImage.setAttribute("type", "file");
    inputImage.setAttribute("id", "ImageQuestion-" + i);
    inputImage.setAttribute("placeholder", "Ссылка на изображение")
    inputImage.setAttribute("accept", "image/*");
    inputImage.setAttribute("onchange", "GetImageQuest(" + i + ")");
    inputImage.setAttribute("name", "QuestionImage");

  
    
    var Image = document.createElement("img");
    Image.setAttribute("id", "ImageTest-" + i);
    Image.setAttribute("height", "200px");
    Image.setAttribute("width", "400px");
    Image.style.display = "none";


    var inputRoll = document.createElement("input");
    inputRoll.setAttribute("type", "button");
    inputRoll.setAttribute("value", "⯅");
    inputRoll.setAttribute("id", "RollInput" + i);
    inputRoll.setAttribute("onclick", "RollDown(" + i + ")");


    divQuestion.appendChild(label);
    divQuestion.appendChild(inputName);
    divQuestion.appendChild(inputImage);
    divQuestion.appendChild(divExtendButton);
    divQuestion.appendChild(inputRoll);
    divQuestion.appendChild(hiddenValue);
    divQuestion.appendChild(Image);
    divQuestionBlock.appendChild(divQuestion);
    divQuestionBlock.appendChild(divAnswer);

    Module.appendChild(divQuestionBlock);

    document.getElementById("testModule-div").appendChild(Module);
}

function AddRadio(i) {
    document.getElementById("AllAnswerCount").value = Number(document.getElementById("AllAnswerCount").value) + 1; 
    var ImageVal = Number(document.getElementById("AllAnswerCount").value);

    var val = Number(document.getElementById("AnswerCount-" + i).value);
    document.getElementById("AnswerCount-" + i).value = val + 1;

    var Module = document.createDocumentFragment();

    var div = document.createElement("div")
    div.setAttribute("class", "answerModule");

    var inputRadio = document.createElement("input");
    inputRadio.setAttribute("type", "radio");
    inputRadio.setAttribute("name", "CorrectAnswer-" + i);
    inputRadio.setAttribute("value", val);

    var inputName = document.createElement("input");
    inputName.setAttribute("type", "text");
    inputName.setAttribute("name", "AnswerText-"+i);
    inputName.setAttribute("placeholder", "Текст Ответа");

    var inputHidden = document.createElement("input");
    inputHidden.setAttribute("type", "hidden");
    inputHidden.setAttribute("value", "1");
    inputHidden.setAttribute("name", "AnswerType-" + i);

    var inputImage = document.createElement("input");
    inputImage.setAttribute("type", "file");
    inputImage.setAttribute("placeholder", "Ссылка на изображение");
    inputImage.setAttribute("accept", "image/*");
    inputImage.setAttribute("onchange", "GetImage(" + ImageVal + ")");
    inputImage.setAttribute("name", "AnswerImage");
    inputImage.setAttribute("id", "AnswerImage-" + ImageVal);

   
    var Image = document.createElement("img");
    Image.setAttribute("id", "Image-" + ImageVal);
    Image.setAttribute("height", "200px");
    Image.setAttribute("width", "400px");
    Image.style.display = "none";

    div.appendChild(inputRadio);
    div.appendChild(inputName);
    div.appendChild(inputHidden);
    div.appendChild(inputImage);
  
    div.appendChild(Image);
    Module.appendChild(div);

    document.getElementById("Answers-" + i).appendChild(div);
}
function AddCheckBox(i) {
    document.getElementById("AllAnswerCount").value = Number(document.getElementById("AllAnswerCount").value) + 1;
    var ImageVal = Number(document.getElementById("AllAnswerCount").value);
    var val = Number(document.getElementById("AnswerCount-" + i).value);
    document.getElementById("AnswerCount-" + i).value = val + 1;

    var Module = document.createDocumentFragment();

    var div = document.createElement("div")
    div.setAttribute("class", "answerModule");

    var inputRadio = document.createElement("input");
    inputRadio.setAttribute("type", "CheckBox");
    inputRadio.setAttribute("name", "CorrectAnswer-" + i);
    inputRadio.setAttribute("value", val);

    var inputName = document.createElement("input");
    inputName.setAttribute("type", "text");
    inputName.setAttribute("name", "AnswerText-" + i);
    inputName.setAttribute("placeholder", "Текст Ответа");

    var inputHidden = document.createElement("input");
    inputHidden.setAttribute("type", "hidden");
    inputHidden.setAttribute("value", "2");
    inputHidden.setAttribute("name", "AnswerType-" + i);

    var inputImage = document.createElement("input");
    inputImage.setAttribute("type", "file");
    inputImage.setAttribute("placeholder", "Ссылка на изображение")
    inputImage.setAttribute("accept", "image/*")
    inputImage.setAttribute("onchange", "GetImage(" + ImageVal + ")")
    inputImage.setAttribute("name", "AnswerImage");
    inputImage.setAttribute("id", "AnswerImage-" + ImageVal);

   

    var Image = document.createElement("img")
    Image.setAttribute("id", "Image-" + ImageVal);
    Image.setAttribute("height", "200px");
    Image.setAttribute("width", "400px");
    Image.style.display = "none";

    div.appendChild(inputRadio);
    div.appendChild(inputName);
    div.appendChild(inputHidden);
    div.appendChild(inputImage);
   
    div.appendChild(Image);
    Module.appendChild(div);

    document.getElementById("Answers-" + i).appendChild(div);
}

function AddInput(i) {
    document.getElementById("AllAnswerCount").value = Number(document.getElementById("AllAnswerCount").value) + 1;
    var ImageVal = Number(document.getElementById("AllAnswerCount").value);

    var val = Number(document.getElementById("AnswerCount-" + i).value);
    document.getElementById("AnswerCount-" + i).value = val + 1;

    var Module = document.createDocumentFragment();

    var div = document.createElement("div")
    div.setAttribute("class", "answerModule");

    var inputHidden = document.createElement("input");
    inputHidden.setAttribute("type", "hidden");
    inputHidden.setAttribute("value", "3");
    inputHidden.setAttribute("name", "AnswerType-" + i);

   

    var inputName = document.createElement("input");
    inputName.setAttribute("type", "text");
    inputName.setAttribute("name", "AnswerText-" + i);
    inputName.setAttribute("placeholder", "Текст указанный в поле");



    

   

   
    div.appendChild(inputName);
    div.appendChild(inputHidden);
   
    Module.appendChild(div);

    document.getElementById("Answers-" + i).appendChild(div);
}

function AddSelect(i) {
    document.getElementById("AllAnswerCount").value = Number(document.getElementById("AllAnswerCount").value) + 1;
    var ImageVal = Number(document.getElementById("AllAnswerCount").value);

    var val = Number(document.getElementById("AnswerCount-" + i).value);
    document.getElementById("AnswerCount-" + i).value = val + 1;

    var Module = document.createDocumentFragment();

    var div = document.createElement("div")
    div.setAttribute("class", "answerModule");

    var inputHidden = document.createElement("input");
    inputHidden.setAttribute("type", "hidden");
    inputHidden.setAttribute("value", "4");
    inputHidden.setAttribute("name", "AnswerType-" + i);



    var inputName = document.createElement("input");
    inputName.setAttribute("type", "text");
    inputName.setAttribute("name", "AnswerText-" + i);
    inputName.setAttribute("placeholder", "Текст опции");



    var inputImage = document.createElement("input");
    inputImage.setAttribute("type", "file");
    inputImage.setAttribute("placeholder", "Ссылка на изображение")
    inputImage.setAttribute("accept", "image/*")
    inputImage.setAttribute("onchange", "GetImage(" + ImageVal + ")")
    inputImage.setAttribute("name", "AnswerImage");
    inputImage.setAttribute("id", "AnswerImage-" + ImageVal);

    
      

    var Image = document.createElement("img")
    Image.setAttribute("id", "Image-" + ImageVal);
    Image.setAttribute("height", "200px");
    Image.setAttribute("width", "400px");
    Image.style.display = "none";

    div.appendChild(inputName);
    div.appendChild(inputHidden);
    div.appendChild(inputImage);
   
    div.appendChild(Image);
    Module.appendChild(div);

    document.getElementById("Answers-" + i).appendChild(div);
}

function RollDown(i) {
    document.getElementById("Answers-" + i).style = "display:none";
    document.getElementById("RollInput" + i).value = "⯆";
    document.getElementById("RollInput"+i).setAttribute("onclick", "RollUp(" + i + ")");
    
}

function RollUp(i) {
    document.getElementById("Answers-" + i).style = "display:flex";
    document.getElementById("RollInput" + i).value = "⯅";
    document.getElementById("RollInput"+i).setAttribute("onclick", "RollDown(" + i + ")");
}



function GetImageQuest(i) {
    
    var preview = document.getElementById("ImageTest-" + i);
    var file = document.getElementById("ImageQuestion-" + i).files[0];

    

    


    var reader = new FileReader();

    reader.onloadend = function () {
        if (!document.querySelector('#QuestionHiddenValue-' + i)) {
            var hiddenValue = document.createElement("input");
            hiddenValue.setAttribute("type", "hidden");
            hiddenValue.setAttribute("value", i);
            hiddenValue.setAttribute("name", "QuestionImageID");
            hiddenValue.setAttribute("id", "QuestionHiddenValue-" + i);
            document.getElementById("ImageQuestion-" + i).parentElement.appendChild(hiddenValue)
        }
        

        preview.src = reader.result;
        preview.style.display = "flex";
    }

    if (file) {
        
        reader.readAsDataURL(file);
    } else {
        if (document.querySelector('#QuestionHiddenValue-' + i)) {
            delete document.getElementById("QuestionHiddenValue-" + i);
        }
        preview.src = "";
    }
    

   
}

function GetImage(i) {
    
    var preview = document.getElementById("Image-" + i);
    var file = document.getElementById("AnswerImage-" + i).files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        if (!document.querySelector('#AnswerHiddenValue-' + i)) {
            var hiddenValue = document.createElement("input");
            hiddenValue.setAttribute("type", "hidden");
            hiddenValue.setAttribute("value", i);
            hiddenValue.setAttribute("name", "AnswerImageID");
            hiddenValue.setAttribute("id", "AnswerHiddenValue-" + i);
            document.getElementById("AnswerImage-" + i).parentElement.appendChild(hiddenValue)
        }

        preview.src = reader.result;
        preview.style.display = "flex";
    }

    if (file) {

        reader.readAsDataURL(file);
    } else {
        if (document.querySelector('#AnswerHiddenValue-' + i)) {
            delete document.getElementById("AnswerHiddenValue-" + i);
        }
        preview.src = "";
    }
}



function AgeShow() {
   
    if (document.getElementById("AgeCheck").checked) {
        document.getElementById("MinAge").style.display = "flex";
        document.getElementById("MaxAge").style.display = "flex";
    }
    else {
        document.getElementById("MinAge").style.display = "none";
        document.getElementById("MaxAge").style.display = "none";
        document.getElementById("MaxAge").value = 0;
        document.getElementById("MinAge").value = 0;
    }
}

function TownShow() {
    if (document.getElementById("TownCheck").checked) {
        document.getElementById("TownInput").style.display = "flex";
        
    }
    else {
        document.getElementById("TownInput").style.display = "none";
        document.getElementById("TownInput").value = "";
    }
}

function CountryShow() {
    if (document.getElementById("CountryCheck").checked) {
        document.getElementById("CountryInput").style.display = "flex";

    }
    else {
        document.getElementById("CountryInput").style.display = "none";
        document.getElementById("CountryInput").value = "";
    }
}