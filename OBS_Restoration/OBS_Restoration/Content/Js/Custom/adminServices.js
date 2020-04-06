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

let templ = document.querySelector("#tableServicesTemplate");
let tbody = document.querySelector(".tableServicesBody");
let urlImg = "../../Content/Images/Services/";

function populateServiceRow(service) {
    let clon = templ.content.cloneNode(true);
    let td = clon.querySelectorAll("td");
    let btnDelete = clon.querySelector(".delete-services");
    btnDelete.setAttribute("id", service.Id);
    td[0].textContent = service.Order;
    td[1].textContent = service.Id;
    td[2].textContent = service.Name;
    td[3].textContent = service.Description;
    td[4].querySelector('img').src = urlImg + service.ImgUrl;
    tbody.appendChild(clon);
}

///////////////////////ADD NEW SERVICES
$('.update').on('click', function () {
    let formData = new FormData($('.form-update-service')[0]);
    $.ajax({
        type: 'POST',
        url: '/Admin/UpdateService',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.Success && response.Success) {
                tbody.innerHTML = "";
                populateTableServices();
                $('.modal-dialog form').addClass('d-none');
                $('.succsses-content').addClass('d-block');
                locationReload();
            } if (response.Success == false || response.Success == false) {
                document.querySelector('.errorMessage').innerHTML = response.ErrorMessage;
                document.querySelector('.requireName').innerHTML = response.ValidationMessages.Name;
                document.querySelector('.imgRequired').innerHTML = response.ValidationMessages.Image;
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            document.querySelector('.thrownerror').innerHTML = thrownerror;
            document.querySelector('.errorMessage').innerHTML = errorMessage;
        }
    });
});
/////////////////EDIT SERVICES
/// Ajax request to display in edit form modal (input value) to edit details.
$(document).on('click', '.edit-btn', function (e) {
    $.ajax({
        type: 'POST',
        url: '/Admin/getServices',
        success: function (response) {
            if (response.Data && response.Success) {
                let services = response.Data;
                $.each(services, function (i, services) {
                    if ($('.edit-btn').index(e.target) === i) {
                        $("input[name='Name']").val(services.Name);
                        $("textarea[name='Description']").val(services.Description);
                        $("input[name='Id']").val(services.Id);
                        $("input[name='Order']").val(services.Order);
                        return false;
                    }
                });
            }
        },
    });
});
$(document).on('click', '.delete-services', function (e) {
    let idDelete = this.id;
    $('.delete-service-modal').data('id', idDelete);
    $('#deleteServicesModal').modal('show');
});
//Ajax request function Delete services
$('.delete-service-modal').on('click', function () {
    let token = $('input[name="__RequestVerificationToken"]').val();
    let id = $(this).data('id');
    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteService/' + id,
        data: {
            '__RequestVerificationToken': token,
            id: id,
        },
        success: function (response) {
            if (response.Data && response.Success) {
                $('.delete-content-modal').addClass('d-none')
                $('.succsses-content').addClass('d-block');
                locationReload();
            }
        },
        error: function (xhr, ajaxoptions, thrownerror) {
            document.querySelector('.thrownerror').innerHTML = thrownerror;
            document.querySelector('.errorMessage').innerHTML = errorMessage;
        }
    });
});


///SEARCH
$(".searchField").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $(".search tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});