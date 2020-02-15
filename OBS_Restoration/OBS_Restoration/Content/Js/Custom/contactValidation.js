$(function () {
    $('.contact-form').validate({
        rules: {
            Email: {
                required: true,
                email: true,
            },
            PhoneNumber: {
                required: false,
                digits: true,

            },
            Message: {
                required: true,

            },
        },
        message: {
            Email: {
                email: "Please! Enter a valid email address",
            },
            PhoneNumber: {

                digits: "Please enter a valid phone number",
            },

        },

        submitHandler: function (form) {
            $.ajax({
                url: "/home/ContactUs",
                type: 'POST',
                data: $(form).serialize(),
                success: function (response) {
                    document.querySelector(".alert-success").style.display = "block";
                    //  window.setTimeout(function () { location.reload() }, 2000);
                }
            });
        }
    });
}); ////////// document.ready













