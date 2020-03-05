// Add the name of the file appear on select
$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});
function populateTableServices() {
    $.ajax({
        url: '/Admin/getServices',
        type: 'GET',
        success: function (data) {
            if (data.Data && data.Success) {
                let services = data.Data;
                 $.each(services, function (i, service) {
                    populateServiceRow(service)
                });
            }
        }
    });
    $("[data-toggle=tooltip]").tooltip();
}
$(function () {
    populateTableServices();
});


let templ = document.querySelector("template");
let td = templ.content.querySelectorAll("td");
let tbody = document.getElementsByTagName("tbody");
let urlImg = "../../Content/Images/Services/";

function populateServiceRow(service) {
    td[1].textContent = service.Name;
    td[2].textContent = service.Description;
    td[3].querySelector('img').src = urlImg + service.ImgUrl;
    let clone = document.importNode(templ.content, true);
    tbody[0].appendChild(clone);
}



//Add Data Function  
$('.add').on('click', function (form) {
    var serializeFormData = $('form').serialize();
    console.log(serializeFormData)
    $.ajax({
        data: serializeFormData,
        processData: false,
        contentType: false,
         success: function (result) {
            console.log(result)
            
        }
    });
  
})

