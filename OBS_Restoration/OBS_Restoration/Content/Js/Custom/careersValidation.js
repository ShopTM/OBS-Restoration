$(function () {
    // The name of the file appear on select
    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });

    $('#сareers-form').validate({
        rules: {
            Email: {
                required: true,
                email: true,
            },
            PhoneNumber: {
                required: false,
                digits: true,

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
            let formData = new FormData($('#сareers-form')[0])
            $.ajax({
                url: "/home/Careers",
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    document.querySelector(".alert-success").style.display = "block";
                    //  window.setTimeout(function () { location.reload() }, 2000);
                }
            });
        }
    });
    //validate file extension custom  method.
    $.validator.addMethod("extension", function (value, element, param) {
        param = typeof param === "string" ? param.replace(/,/g, "|") : "doc|docx|pdf";
        return (this.optional(element) || value.match(new RegExp("\\.(" + param + ")$", "i"))
        );
    },
        $.validator.format(
            "Please enter a value with a valid extension (doc, docx, pdf)."
        )
    );
}); ////////// document.ready














