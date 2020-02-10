$(function () {
    const validationMessageTemplate = "Please! Enter a valid ",
        emailValidationMessage = validationMessageTemplate + "email address",
        phoneValidationMessage = validationMessageTemplate + "phone number",
        fileValidationMessage= "Only file with the following extensions are allowed: jpg, jpeg, png, gif, doc, pdf, docx, txt, rar, zip";
    fileSizeValidationMessage = "Sorry! Maximum upload file size: 25 MB. Your file size is:"
    let email = $("form input[type=email]"),
        phone = $("form input[type=tel]"),
        inputFile = document.querySelector('.file');
    invalidTextSize = document.querySelector(".invalidTextSize"),
        invalidTextFile = document.querySelector(".invalidTextFile"),
        phoneTextMessage = document.querySelector(".phoneTextMessage"),
        emailTextMessage = document.querySelector(".emailTextMessage"),
        patternMail = /^[\w-\.]+@[\w-]+[\./]+[a-z]{2,4}$/g,
        allowedExtensions = /(\.jpg|\.jpeg|\.png|\.docx|\.pdf|\.doc|\.rar|\zip|\.txt)$/i,
        patternPhone = /^\d{11}$/g,
        btnCleanTextMessage = $(".btnForm");

     ////Validation email
    email.on("blur", function () {
        let email = $(this).val();
        if (email.length > 0 && (email.match(patternMail) || []).length !== 1) {
            emailTextMessage.innerHTML = emailValidationMessage;
        }
    });

    ////Validation phone number
    phone.on("blur", function () {
        let phone = $(this).val();
        if (phone.length > 0 && (phone.match(patternPhone) || []).length !== 1)
            phoneTextMessage.innerHTML = phoneValidationMessage;
    });

    ///Clear validationMassegeTemplate 
    btnCleanTextMessage.on("click", function () {
        let emailValue = email.val();
        let phoneValue = phone.val();
        if (emailValue == 0 || (emailValue.match(patternMail)) || phoneValue == 0 || (phoneValue.match(patternPhone))) {
          phoneTextMessage.innerHTML = " ";
          emailTextMessage.innerHTML = " ";

        }
    });

    //Validation file extensions
    $(".file").on("change", function () {
        let customFileInputValue = $(this).val();
        if (!allowedExtensions.exec(customFileInputValue)) {
            invalidTextFile.innerHTML = fileValidationMessage;
        } else if (allowedExtensions.exec(customFileInputValue)) {
            invalidTextFile.innerHTML = " ";
        }
    });
    //Valiadtion file size
    $(".file").on("change", function () {
        let files = inputFile.files;
        let fileSize = 0;
        let fileSizeSum;
        for (let i = 0; i < files.length; i++) {
            fileSize += files[i].size;
            let file = fileSize / 1024 / 1024;
            fileSizeSum = file.toFixed(2);
        } if (fileSizeSum > 25) {
            invalidTextSize.innerHTML = fileSizeValidationMessage + " " + fileSizeSum + " MB";
        } else if (fileSizeSum <= 25) {
            invalidTextSize.innerHTML = " ";
        }

    });

    $(".custom-file-input").on("change", function () {
        let fileName = $(this).val().split("\\").pop();
        let files = inputFile.files;
        let filesLength = files.length;
        if (filesLength === 1) {
            $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        } else if (filesLength > 1) {
            $(this).siblings(".custom-file-label").addClass("selected").html(filesLength + " " + "files selected");
        }

    });
  });