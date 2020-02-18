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












