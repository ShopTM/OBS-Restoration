function addLoading(containerClass) {
    $(containerClass).append('<p class="text-center loader-text">Please wait...</p><section id="loader"></section>');
    $('#loader').hide();
}

$(document)
    .ajaxStart(function () {
        $('#loader, .loader-text').show();
    })
    .ajaxStop(function () {
        $('#loader, .loader-text').hide();
    });