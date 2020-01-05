$(function () {
    var nextSlider = function () {
        var currentSlide = $(".curry");
        var nextSlide = currentSlide.next();

        if (nextSlide.length == 0) {
            nextSlide = $(".slider").first();
        }

        currentSlide.fadeOut(200).removeClass("curry");
        nextSlide.fadeIn(200).addClass("curry");
    };
    var prevSlider = function () {
        var currentSlide = $(".curry");
        var prevSlide = currentSlide.prev();

        if (prevSlide.length == 0) {
            prevSlide = $(".slider").last();
        }

        currentSlide.fadeOut(200).removeClass("curry");
        prevSlide.fadeIn(200).addClass("curry");
    };

    setInterval(nextSlider, 5000);
});

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

          /////////////////////CAREERSR
// Name of the file appear on select
$(".custom-file-input").on("change", function() {
  var fileName = $(this).val().split("\\").pop();
  $(this).siblings(".custom-file-label").addClass("selected").html(fileName);



   
  
});