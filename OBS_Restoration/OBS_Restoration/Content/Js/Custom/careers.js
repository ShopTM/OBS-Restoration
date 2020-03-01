const errorMessage = 'An error occurred while processing your request. Please try again later.'
$(function () {
    // The name of the file appear on select
    $('.custom-file-input').on('change', function () {
        let fileName = $(this).val().split("\\").pop();
        $(this).siblings('.custom-file-label').addClass('selected').html(fileName);
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
            Resume: {
                required: true,
                extension: 'docx|rtf|doc|pdf|',
                filesize: 25,
            },
        },
        message: {
            Email: {
                email: 'Please! Enter a valid email address',
            },
            PhoneNumber: {
                digits: 'Please enter a valid phone number',
            },
            Resume: {
                required: 'Please upload resume',
                extension: 'Please upload valid file formats (docx, rtf, doc, pdf).',
                filesize: 'Sorry! Maximum upload file size: 25 MB.',
            }
        },
        submitHandler: function (form) {
            let formData = new FormData($('#сareers-form')[0])
            $.ajax({
                url: '/home/Careers',
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
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    document.querySelector('.errorMessage').innerHTML = errorMessage + '!';
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

}); ////////// document.ready

///scrollToUp error
function scrollToUp() {
    window.scrollTo(0, 1300);
    window.scrollTo({
        top: 1300,
        behavior: 'smooth'
    });
    return false;
}

///////test function for form value 
function testSeed() {
    $('[name="FirstName"]').val("Vasya");
    $('[name="LastName"]').val("Ivanov");
    $('[name="Email"]').val("test@gmail.com");
    $('[name="PhoneNumber"]').val("123456789");
    $('[name="Message"]').val("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
}













