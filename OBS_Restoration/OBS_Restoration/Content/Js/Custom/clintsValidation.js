$(function () {

    var data = new FormData();

    //Form data
    var form_data = $('.сareers-form').serializeArray();
    $.each(form_data, function (key, input) {
        data.append(input.name, input.value);
    });

    //File data
    var file_data = $('input[name="Resume"]')[0].files;
    for (var i = 0; i < file_data.length; i++) {
        data.append("Resume[]", file_data[i]);
    }

    //Custom data
    data.append('key', 'value');


    // The name of the file appear on select
    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });


    $('.сareers-form').validate({
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
                required: false,
            },
            Resume: {
                required: true,
                extension: "doc|docx|pdf",
            },

        },
        message: {
            Email: {
                email: "Please! Enter a valid email address",
            },
            PhoneNumber: {
                digits: "Please enter a valid phone number",
            },

            Resume: {
                extension: "Please enter a value with a valid extension (doc, docx, pdf).",
            },
        },

        submitHandler: function (form) {
             $.ajax({
                url: "/home/Clients",
                type: 'POST',
                 processData: false,
                 contentType: false,
                 data: data,
                success: function (data) {
                 ///   document.querySelector(".alert-success").style.display = "block";
                   /// window.setTimeout(function () { location.reload() }, 2000);
                }
            });
        }
    });
    //validate file extension custom  method.
    $.validator.addMethod("extension", function (value, element, param) {
        param = typeof param === "string" ? param.replace(/,/g, "|") : "doc|docx|pdf";
        return this.optional(element) || value.match(new RegExp("\\.(" + param + ")$", "i"));
    }, $.validator.format("Please enter a value with a valid extension (doc, docx, pdf)."));

}); ////////// document.ready



