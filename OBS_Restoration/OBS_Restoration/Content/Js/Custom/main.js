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

function locationReload() {
    if ($('.modal').on('hidden.bs.modal')) {
        window.setTimeout(function () {
            location.reload()
        }, 1200);
    }
}
//REST INPUT 
$('.add').on('click', function () {
    let valueAdd = $('.form-update-service input, textarea');
    valueAdd.value = " ";
})

///SEARCH
$(".searchField").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $(".search tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});
