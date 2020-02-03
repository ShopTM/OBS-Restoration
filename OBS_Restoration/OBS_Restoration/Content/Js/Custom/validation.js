$(function () {
    let email = $("form input[type=email]");
    let phone = $("form input[type=tel]");
    let invalidEmail;
    let invalidPhone;
       email.on("blur", function () {
        let email = $(this).val();
           if (email.length > 0 && (email.match(/^[\w-\.]+@[\w-]+[\./]+[a-z]{2,4}$/g) || []).length !== 1) {
           invalidEmail = document.querySelector(".Email").innerHTML = "Please! Enter a valid email address";
     } 
       });
    
    phone.on("blur", function () {
        let phone = $(this).val();
        if (phone.length > 0 && (phone.match(/\d+/g) || []).length !== 1)
            invalidEmail = document.querySelector(".PhoneNumber").innerHTML = "Please! Enter a valid phone number";
    });
});
