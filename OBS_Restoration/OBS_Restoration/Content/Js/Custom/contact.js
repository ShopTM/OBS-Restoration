$(function () {

    $.validator.methods.email = function (value, element) {
        return this.optional(element) || /[a-z]+@[a-z]+\.[a-z]+/.test(value);
    }
    $.validator.addMethod("checkMask", function (value, element) {
        return /^\d{11}$/.test(value);
    });

    $("form").validate({
        rules: {
            FirstName: {
                required: true,
            },
            Email: {
                required: true,
                email: true,
                regexp: /^[\w-\.]+@[\w-]+[\./]+[a-z]{2,4}$/g,
            },
            PhoneNumber: {
                required: false,
                checkMask: true,
                digits: true,
            },

            Message: {
                required: true,
                maxlength: 255,
                minlength: 255,
            },
        },
        messages: {
            FirstName: {
                required: "Please enter your first name",
            },
            Email: {
                email: "Please! Enter a valid email address",

            },
            PhoneNumber: {
                checkMask: true,

            },
            Message: {
                minlength: "Please enter message at least 255 characters"
            },
            PhoneNumber: {
                checkMask: "Please! Enter a valid phone number"
            }

        },
        submitHandler: function (form) {
            $.ajax({
                type: 'POST',
                url: "/home/ContactUs",
                data: $(form).serialize(),
                success: function (response) {
                    alert("coll")
                }
            });
        }

    });

    });

 
 















