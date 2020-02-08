$(function () {
    const validationMassegeTemplate = "Please! Enter a valid ",
          emailValidationMassege = validationMassegeTemplate + "email address",
          phoneValidationMassege = validationMassegeTemplate + "phone number",
          fileValidationMassege = "Only file with the following extensions are allowed: jpg, jpeg, png, gif, doc, pdf, docx, txt, rar, zip";
          fileSizeValidationMassege = "Sorry! Maximum upload file size: 25 MB. Your file size is:"
    let email = $("form input[type=email]"),
        phone = $("form input[type=tel]"),
        invalidTextSize = document.querySelector(".invalidTextSize"),
        invalidTextFile = document.querySelector(".invalidTextFile"),
        phoneTextMassege = document.querySelector(".phoneTextMassege"),
        emailTextMassege = document.querySelector(".emailTextMassege"),
        patternMail = /^[\w-\.]+@[\w-]+[\./]+[a-z]{2,4}$/g,
        allowedExtensions = /(\.jpg|\.jpeg|\.png|\.docx|\.pdf|\.doc|\.rar|\zip|\.txt)$/i,
        patternPhone = /^\d{11}$/g,
        btnCleanTextMassege = $(".btnForm");

    ////Validation email
    email.on("blur", function () {
        let email = $(this).val();
        if (email.length > 0 && (email.match(patternMail) || []).length !== 1) {
            emailTextMassege.innerHTML = emailValidationMassege;
        }
    });

    ////Validation phone number
    phone.on("blur", function () {
        let phone = $(this).val();
        if (phone.length > 0 && (phone.match(patternPhone) || []).length !== 1)
            phoneTextMassege.innerHTML = phoneValidationMassege;
    });

    ///Clear validationMassegeTemplate 
    btnCleanTextMassege.on("click", function () {
        let emailValue = email.val();
        let phoneValue = phone.val();
        if (emailValue == 0 || (emailValue.match(patternMail)) || phoneValue == 0 || (phoneValue.match(patternPhone))) {
            phoneTextMassege.innerHTML = " ";
            emailTextMassege.innerHTML = " ";

        }
    });
    //Validation file extensions
    $(".file").on("change", function () {
        let customFileInputValue = $(this).val();
        if (!allowedExtensions.exec(customFileInputValue)) {
            invalidTextFile.innerHTML = fileValidationMassege;
        } else if (allowedExtensions.exec(customFileInputValue)) {
            invalidTextFile.innerHTML = " ";
        }
    });
    //Valiadtion file size
    $(".file").on("change", function () {
        let inputFile = document.querySelector('.file');
        const files = inputFile.files;
        let fileSize = 0;
        let fileSizeSum;
            for (let i = 0; i < files.length; i++) {
            fileSize += files[i].size;
           let file = fileSize / 1024 / 1024;
            fileSizeSum = file.toFixed(2);
        } if (fileSizeSum > 25) {
            invalidTextSize.innerHTML = fileSizeValidationMassege + " " + fileSizeSum + " MB";
        } else if (fileSizeSum <= 25) {
            invalidTextSize.innerHTML = " ";
        }
 
});


});