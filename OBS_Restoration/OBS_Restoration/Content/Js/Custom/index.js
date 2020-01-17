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

