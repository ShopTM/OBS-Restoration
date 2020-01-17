$(function () {
    // ACTIVE DROPDOWN_MENU
    $(".navbar .dropdown").hover(
        function () {
            $(this)
                .find(".dropdown-menu")
                .stop(true, true)
                .delay(300)
                .fadeIn(-2000);
        },
        function () {
            $(this)
                .find(".dropdown-menu")
                .stop(true, true)
                .delay(300)
                .fadeOut(-2000);
        }
    );


})