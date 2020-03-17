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
    td[0].textContent = service.Order;
    td[1].textContent = service.Id;
    td[3].textContent = service.Name;
    td[4].textContent = service.Description;
    td[5].querySelector('img').src = urlImg + service.ImgUrl;
    clone = document.importNode(templ.content, true);
    tbody.appendChild(clone);
}
/////////////////////////ADD NEW SERVICES
//$('.update').on('click', function () {
//    let formData = new FormData($('.form-add-service')[0]);
//    $.ajax({
//        type: 'POST',
//        url: '/Admin/UpdateService',
//        data: formData,
//        processData: false,
//        contentType: false,
//        success: function (response) {
//            if (response.Data && response.Success) {
//                tbody.innerHTML = "";
//                populateTableServices();
//                  $('.modal-dialog form').addClass('d-none');
//                $('.updateServiceSuccsses').addClass('d-block');
//                //need to add modal hide after msg succsses
//             } if (response.Data == false || response.Success == false) {
//                document.querySelector('.errorMessage').innerHTML = response.ErrorMessage;
//                document.queryselector('.namerequired').innerhtml = response.validationmessages.name;
//                document.queryselector('.imgrequired').innerhtml = response.validationmessages.image;
//            }
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            document.querySelector('.errorMessage').innerHTML = errorMessage;
//        }
//    });
//});

///////////////////EDIT SERVICES

//DECLARED VARIABLES FOR EDITING AND DELETE 


////Update new service
//$('.update').on('click', function () {

//    $.ajax({
//        type: 'POST',
//        url: '/Admin/UpdateService',
//        data: formData,
//        processData: false,
//        contentType: false,
//        success: function (response) {
//            if (response.Data && response.Success) {
//                populateTableServices();
//                //$('.modal-dialog form').addClass('d-none');
//                //$('.addServiceSuccsses').addClass('d-block');
//                setInterval(function () {
//                    $('#editModal').modal('hide');
//                }, 1200);
//            } if (response.Data == false || response.Success == false) {
//                document.querySelector('.errorMessage').innerHTML = errorMessage;
//            }
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            document.querySelector('.errorMessage').innerHTML = errorMessage;
//        }
//    });


//});






$(document).on('click', '.delete-services', function (e) {
    let checkbox = $('input[type="checkbox"]');
    $.each(checkbox, function (i, checkbox) {
        if ($(checkbox).is(":checked") && ($('.delete-services').index(e.target)) === i) {
            $('#deleteServicesModal').modal('show')
        }
    });

});

///Ajax request function Delete services
$('.delete-service-modal').on('click', function () {
    let formData = new FormData($('.form-add-service')[0]);
    let name = $("input[name='Name']").val();
    let description = $("textarea[name='Description']").val();
    let id = $("input[name='Id']").val();
    let order = $("input[name='Order']").val();
    let token = $('input[name="__RequestVerificationToken"]').val();
    $.ajax({
        type: 'DELETE',
        url: '/Admin/DeleteService/' + id,
        data: {
            __RequestVerificationToken: token,
            Name: name,
            Description: description,
            Id: id,
            Order: order,
            FormData: formData
        },
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.Data && response.Success) {
                populateTableServices();
            }
        },

    });
})
