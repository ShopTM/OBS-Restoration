const errorMessage = 'An error occurred while processing your request. Please try again later.'
////Add headers to each clint
const input = document.querySelector("#ClientType");
const h3 = document.querySelector("h3#clients");
const val = input.value;
switch (val) {
    case "Enginner":
        h3.innerHTML = "Enginners / Architecs";
        break;
    case "Manager":
        h3.innerHTML = "Propperty / Managers";
        break;
    case "Owner":
        h3.innerHTML = "Owner";
        break;
}
// The name of the file appear on select
$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    inputFile = document.querySelector('.file');
    let files = inputFile.files;
    let filesLength = files.length;
    if (filesLength === 1) {
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    } else if (filesLength > 1) {
        $(this).siblings(".custom-file-label").addClass("selected").html(filesLength + " " + "files selected");
    }
});
///////////Validation form
$(function () {
   //// addClass rule
    $.validator.addClassRules({
        file: {
            required: true,
            extension: "docx|rtf|doc|txt|xlsx|pdf|rar|zip|jpg|jpeg|png|",
            filesize: 25,
            
        },
     });
       $('#сlients-form').validate({
        rules: {
            Email: {
                required: true,
                email: true,
            },
            PhoneNumber: {
                required: false,
                digits: true,

            },
            file: {
                required: true,
                extension: "docx|rtf|doc|txt|xlsx|pdf|rar|zip|jpg|jpeg|png|",
                filesize: 25,
            },
        },
        message: {
            Email: {
                email: "Please! Enter a valid email address",
            },
            PhoneNumber: {
                digits: "Please enter a valid phone number",
            },
            file: {
                required: "Please upload resume",
                extension: "Please upload valid file formats (docx, rtf, doc, pdf).",
                filesize: "Sorry! Maximum upload file size: 25 MB.",
            }
        },
        submitHandler: function (form) {
            let formData = new FormData($('#сlients-form')[0])
            $.ajax({
                url: "/home/Clients",
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    if (response.Data && response.Success) {
                        $('#myModal').modal('show');
                        $('#myModal').on('hidden.bs.modal', function (e) {
                            window.setTimeout(function () { location.reload() }, 0);
                        })
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    document.querySelector('.errorMessage').innerHTML = errorMessage;
                    scrollToUp();
                }

            });
        }
    });
    //// Method jquery validator sizefile
    $.validator.addMethod('filesize', function (value, element, param) {
        let size = element.files[0].size;
        size = size / 1024 / 1024;
        size = size.toFixed(2);
        return this.optional(element) || size <= param;

    }, 'Sorry! Maximum upload file size: {0}');
}); ///ready document

///scrollToUp error
function scrollToUp() {
    window.scrollTo(0, 800);

    window.scrollTo({
        top: 800,
        behavior: "smooth"
    });
    return false;
}





