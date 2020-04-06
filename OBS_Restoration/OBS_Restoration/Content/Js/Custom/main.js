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
    $('form').trigger('reset');
});


$(document).ready(function () {
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
        localStorage.setItem('activeTab', $(e.target).attr('href'));
    });
    var activeTab = localStorage.getItem('activeTab');
    if (activeTab) {
        $('#tableTabs a[href="' + activeTab + '"]').tab('show');
    }
});