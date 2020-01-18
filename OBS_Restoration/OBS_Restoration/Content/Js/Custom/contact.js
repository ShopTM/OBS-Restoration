$(function () {
    $("form.contact-form").submit(function (event) {
        event.preventDefault();
        let formData = $(this).serialize();
  
        $.ajax({
            method: "POST",
            url: "/home/ContactUs",
            data: formData ,
            success: function (response) {
                $('.popup-link').magnificPopup();
            },
        })
    })

})