const errorMessage = 'An error occurred while processing your request. Please try again later.'
// Add the name of the file appear on select
$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});
function populateTableServices() {
    $.ajax({
        url: '/Admin/getServices',
        type: 'GET',
        success: function (response) {
            if (response.Data && response.Success) {
                let services = response.Data;
                $.each(services, function (i, service) {
                    populateServiceRow(service)
                });
            }
        }
    });
    // Activate tooltip
    $("[data-toggle=tooltip]").tooltip();
}
$(function () {
    populateTableServices();
});

let templ = document.querySelector("template");
let td = templ.content.querySelectorAll("td");
let tbody = document.getElementsByTagName("tbody")[0];
let urlImg = "../../Content/Images/Services/";

function populateServiceRow(service) {
    td[1].textContent = service.Name;
    td[2].textContent = service.Description;
    td[3].querySelector('img').src = urlImg + service.ImgUrl;
    clone = document.importNode(templ.content, true);
    tbody.appendChild(clone);
}


//Ajax request Add and edit  function
function updateService() {
    let formData = new FormData($('.form-service')[0]);
    $.ajax({
        type: 'POST',
        url: '/Admin/UpdateService',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.Data && response.Success) {
                tbody.innerHTML = "";
                populateTableServices();
                $('.modal-dialog form').addClass('d-none');
                $('.addServiceSuccsses').addClass('d-block');
                setInterval(function () {
                    $('#addModal').modal('hide');
                }, 1200);
            } if (response.Data == false || response.Success == false) {
                document.querySelector('.errorMessage').innerHTML = errorMessage;
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            document.querySelector('.errorMessage').innerHTML = errorMessage;
        }
    });
};

///d-none btn edit
$('.add-new').on('click', function () {
    $('.update').addClass('d-none');
})
//Add new service
$('.add').on('click', function () {
    updateService()
});

//Update new service
$('.update').on('click', function () {
    updateService()
});

/// Ajax request to display in edit form modal (input value) to edit details.
$(document).on('click', '.edit-btn', function (e) {
    $('.add').addClass('d-none');
    $('h4').text('Edit services');
    let name = $("input[name='nameServices']").val();
    let description = $("textarea[name='Description']").val();
    $.ajax({
        type: 'POST',
        url: '/Admin/getServices',
        data: { name: name, description: description },
        success: function (response) {
            if (response.Data && response.Success) {
                let services = response.Data;
                $.each(services, function (i, services) {
                    if ($('.edit-btn').index(e.target) === i) {
                        $("input[name='nameServices']").val(services.Name);
                        $("textarea[name='Description']").val(services.Description);
                        populateTableServices();
                        return false;
                    }
                });
            }
        },
    });
});

//Check if checkboks is checked for button delete all
$(document).on('click', '.delete-all', function (e) {
    var checkbox = $('table tbody input[type="checkbox"]');
    if ($(checkbox).is(":checked")) {
        $('#deleteServicesModal').modal('show')
    }
});

$(document).on('click', '.delete-one', function (e) {
    var checkbox = $('table tbody input[type="checkbox"]');
    $.each(checkbox, function (i, checkbox) {
        if ($('.delete-one').index(e.target) === i) {
            $('#deleteServicesModal').modal('show')
        }
    });
});

// Ajax request function Delete services
function deleteServices() {
    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteServiceImage',
        success: function (response) {
            if (response.Data && response.Success) {
                $('.modal-dialog').addClass('d-none');
                $('.addServiceSuccsses').addClass('d-block');
                setInterval(function () {
                    $('#addModal').modal('hide');
                }, 1200);
                populateTableServices();
            } if (response.Data == false || response.Success == false) {
                document.querySelector('.errorMessage').innerHTML = errorMessage;
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            document.querySelector('.errorMessage').innerHTML = errorMessage;
        }
    });
}

//Delete all checkbox wich is checked
$('.delete-all-modal').on('click', function () {
    deleteServices();
})









