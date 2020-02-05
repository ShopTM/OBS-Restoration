$(function () {
    const validationMassegeTemplate = "Please! Enter a valid ";
    const emailValidationMassege = validationMassegeTemplate + "email address";
    const phoneValidationMassege = validationMassegeTemplate + "phone number";
    const fileValidationMassege = "Only file with the following extensions are allowed: jpg, jpeg, png, gif, doc, pdf, docx, txt";
    const fileSizeValidationMassege = "Sorry! Maximum upload file size: 25 MB. Your file size is:"
    let email = $("form input[type=email]");
    let phone = $("form input[type=tel]");
    let file = $("form, [type=file]");
    const input = document.querySelector('.file');
    let patternMail = /^[\w-\.]+@[\w-]+[\./]+[a-z]{2,4}$/g; 
    let allowedExtensions = /(\.jpg|\.jpeg|\.png|\.docx|\.pdf|\.doc|\.rar|\.txt)$/i;
    let patternPhone = /^\d{11}$/g;
    let btnForm = $(".btnForm");

    ////Valid email
    email.on("blur", function () {
        let email = $(this).val();
        if (email.length > 0 && (email.match(patternMail) || []).length !== 1) {
            document.querySelector(".email").innerHTML = emailValidationMassege;
        }
    });
    ////Valid phone number
    phone.on("blur", function () {
        let phone = $(this).val();
        if (phone.length > 0 && (phone.match(patternPhone) || []).length !== 1)
            document.querySelector(".phone").innerHTML = phoneValidationMassege;
    });

    ///Clear validationMassegeTemplate 
    btnForm.on("click", function () {
        let emailValue = email.val();
        let phoneValue = phone.val();
           if (emailValue == 0 || (emailValue.match(patternMail)) || phoneValue == 0 || (phoneValue.match(patternPhone))) {
            $("p.email, p.phone").remove();

        }
    });

    ////Valid file extensions

    $(".file").on("change", function () {
        let customFileInputValue = $(this).val();
        if (!allowedExtensions.exec(customFileInputValue)) {
            document.querySelector(".invalidTextMassege").innerHTML = fileValidationMassege;
            customFileInputValue.value = '';
            //  return false;
        } else if (allowedExtensions.exec(customFileInputValue)) {
            $("p.invalidTextMassege").remove();
        }
     });
 
       ////Valid file extensions 

    input.addEventListener('change', e => {
        const files = input.files;
        let fileSize = 0;
        let output = [];
        let fileSizeSum;
        let fileName;
        for (let i = 0; i < files.length; i++) {
            fileSize += files[i].size;
            fileName = files[i].name;
            let file = fileSize / 1024 / 1024;
            fileSizeSum = file.toFixed(2);
            output.push('<li>' + fileName + " " + '</li>');
        }
        if (fileSizeSum > 25) {
            document.querySelector(".invalidTextSize").innerHTML = fileSizeValidationMassege + " " + fileSizeSum + " MB";
        } else if (fileSizeSum < 25 || fileSizeSum == 25) {
            $("p.invalidTextSize").remove();
            return false;
        } 
        
          document.querySelector('.listFiles').innerHTML = '<ul>' + output.join('')  + "Your file size is:" + " " + fileSizeSum + " " + "MB" + '</ul>';



    });


});
 
