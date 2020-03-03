$(".nav-tabs a").click(function () {
    $(this).tab('show');
});
// Add the name of the file appear on select
$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});
$(function () {
    $.ajax({
        url: '/home/getServices',
        type: 'GET',
        success: function (data) {
            if (data.Data && data.Success) {
                let services = data.Data;
                $.each(services, function (i, value) {
                    populateTableServices(value)
               

                });
            }
        }
    });
    $("[data-toggle=tooltip]").tooltip();
});

function populateTableServices(value) {
    let templ, td, tbody, clone;
    templ = document.querySelector("template");
    td = templ.content.querySelectorAll("td");
    td[1].textContent = value.Name;
    td[2].textContent = value.Description;
    td[3].querySelector('img').src = value.ImgUrl;
    tbody = document.getElementsByTagName("tbody");
    clone = document.importNode(templ.content, true);
    tbody[0].appendChild(clone);
}

let edit = document.querySelector('button');


////Open modal window by edit btn

function showModal(value) {
    $('#tableModal').modal('show');
}

////get value form

let namSservices = $(".modal-body input").val();
let descriptionServices = $(".modal-body textarea").val();
let imageServices = $('input[type=file]').val();

// Edit row on edit button click
function getCurrentElementEdit() {
  $('tr')

}


edit.addEventListener("click", showModal); 
edit.addEventListener("click", getCurrentElementEdit);


