$(function () {

    $.validator.methods.email = function (value, element) {
        return this.optional(element) || /[a-z]+@[a-z]+\.[a-z]+/.test(value);
    }
    $('.formcontact-form').validate({
        rules: {
            Email: {
                required: true,
                email: true,
            },
            Message: {
                required: true,
                minlength: 250,
            },
        },
        message: {
            Email: {
                email: "Please! Enter a valid email address",
            },
            Message: {
                minlength: "Please enter message at least 250 characters",
            },
    
        },

        submitHandler: function (form) {
            $.ajax({
                url: "/home/ContactUs",
                type: 'POST',
                data: $(form).serialize(),
                success: function (response) {
                    document.querySelector(".alert-success").style.display = "block";
                   window.setTimeout(function () { location.reload() }, 2000);
                }
            });
               
        }
     
       });

}); ////////// document.ready













