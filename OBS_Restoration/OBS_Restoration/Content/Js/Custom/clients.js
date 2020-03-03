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
    inputFile = document.querySelector('.custom-file-input');
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
            extension: "docx|rtf|doc|txt|xlsx|pdf|rar|zip|jpg|jpeg|png|aae|pages",
            filesize: 25,

        },
    });
    $('#сlients-form').validate({
        rules: {
            Email: {
                required: true,
                email: true,
            },

            Files: {
                required: false,
                extension: "docx|rtf|doc|txt|xlsx|pdf|rar|zip|jpg|jpeg|png|aae|pages",
                filesize: 25,
            },
        },
        message: {
            Email: {
                email: "Please! Enter a valid email address",
            },

            Files: {
                extension: "Please upload valid file formats (docx|rtf|doc|txt|xlsx|pdf|rar|zip|jpg|jpeg|png|aae|pages).",
                filesize: "Sorry! Maximum upload file size: 25 MB.",
            }
        },
        submitHandler: function (form) {
            let formData = new FormData($('#сlients-form')[0])
            $.ajax({
                url: "/home/JobEstimation",
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    if (response.Data && response.Success) {
                        let dataMessage = response.Data;
                        document.querySelector('.messageSuccessfully').innerHTML = dataMessage + '!';
                        $('#myModal').modal('show');
                        $('#myModal').on('hidden.bs.modal', function (e) {
                            window.setTimeout(function () { location.reload() }, 0);
                        })
                    } else {
                        document.querySelector('.errorMessage').innerHTML = errorMessage;
                        scrollToUp();
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    console.log(ajaxOptions)
                    document.querySelector('.errorMessage').innerHTML = errorMessage;
                    scrollToUp();
                }

            });
        }
    });
    //// Method jquery validator sizefile
    $.validator.addMethod('filesize', function (value, element, param) {
        let totalSize = 0;
        $(".file").each(function () {
            for (var i = 0; i < this.files.length; i++) {
                totalSize += this.files[i].size;
            }
        });
        totalSize = totalSize / 1024 / 1024;
        totalSize = totalSize.toFixed(2);
        return this.optional(element) || totalSize <= param;

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





