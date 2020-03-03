const errorMessage = 'An error occurred while processing your request. Please try again later.'
$(function () {
    // The name of the file appear on select
    $('.custom-file-input').on('change', function () {
        let fileName = $(this).val().split("\\").pop();
        $(this).siblings('.custom-file-label').addClass('selected').html(fileName);
    });
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
            File: {
                required: true,
                extension: "docx|rtf|doc|txt|xlsx|pdf|rar|zip|jpg|jpeg|png|aae|pages",
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
            File: {
                required: "Please upload resume",
                extension: "Please upload valid file formats (docx|rtf|doc|txt|xlsx|pdf|rar|zip|jpg|jpeg|png|aae|pages).",
                filesize: "Sorry! Maximum upload file size: 25 MB.",
            }

        },

        submitHandler: function (form) {
            let formData = new FormData($('#contactus-form')[0])
            $.ajax({
                url: "/home/ContactUs",
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
}); ////////// document.ready
///scrollToUp error
function scrollToUp() {
    window.scrollTo(0, 1300);
    window.scrollTo({
        top: 800,
        behavior: 'smooth'
    });
    return false;
}












