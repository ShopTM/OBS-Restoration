$(function () {
    const input = document.querySelector("#ClientType");
    const h3 = document.querySelector("h3#clints");
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

    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
    });
////////////////////////Validation form clients
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
            File: {
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
            File: {
                extension: "Please enter a value with a valid extension (doc, docx, pdf).",
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
                        document.querySelector(".sentMessage").style.display = "block";
                        window.setTimeout(function () { location.reload() }, 2000);
                    }

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    let errorMessage = "Error" + " " + xhr.status + ":" + " " + "An error occurred while processing your request. Please try again later.";
                    document.querySelector('.errorMessage').innerHTML = errorMessage;
                    scrollToUp();
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

    ///scrollToUp error
    function scrollToUp() {
        window.scrollTo(0, 800);

        window.scrollTo({
            top: 800,
            behavior: "smooth"
        });
        return false;
    }

    function testSeed() {
        $('[name="FirstName"]').val("Vasya");
        $('[name="LastName"]').val("Ivanov");
        $('[name="Email"]').val("test@gmail.com");
        $('[name="PhoneNumber"]').val("123456789");
        $('[name="Message"]').val("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
    }

});
