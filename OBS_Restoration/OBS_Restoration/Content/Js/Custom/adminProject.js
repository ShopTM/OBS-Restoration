
// Add the name of the file appear on select
$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});
function populateTableProjects() {
    $.ajax({
        url: '/Admin/getProjects',
        type: 'GET',
        success: function (response) {
            if (response.Data && response.Success) {
                let projects = response.Data;
                $.each(projects, function (i, projects) {
                    populateProjectseRow(projects);
                 });
            }
        }
    });
    // Activate tooltip
    $("[data-toggle=tooltip]").tooltip();
}
$(function () {
    populateTableProjects();
});
let templProject = document.querySelector("#tableProjectsTemplate");
let tdProject = templProject.content.querySelectorAll("td");
let tbodyProject = document.querySelector(".tableProjectsBody");
let urlImgProject = "../../Content/Images/Projects/";

function populateProjectseRow(projects) {
    let clone = templProject.content.cloneNode(true);
    let td = clone.querySelectorAll('td');
    td[3].textContent = projects.Name;
   

    for (let i = 0; i < projects.Images.length; i++) {
        let projectImage = projects.Images[i];
        let img = document.createElement('img');
        img.setAttribute('alt', 'ProjectImg');
        img.setAttribute('class', 'img-proj');
        img.setAttribute('src', urlImgProject + projectImage.Url);
        td[4].appendChild(img);
    }
     tbodyProject.appendChild(clone);
}

///////////////////////ADD NEW PROJECT

$('.updateProject').on('click', function () {
    let formData = new FormData($('.form-update-project')[0]);
    formData.append('ProjectId', 'ProjectId');
    formData.append('Ordrer', 'Ordrer');
    formData.append('Url', files);
    $.ajax({
        type: 'POST',
        url: '/Admin/UpdateProject',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.Success && response.Success) {
                tbody.innerHTML = "";
                populateTableProjects();
              //  $('.modal-dialog form').addClass('d-none');
               // $('.succsses-content').addClass('d-block');
                ///locationReload();
            } if (response.Success == false || response.Success == false) {
                document.querySelector('.errorMessage').innerHTML = response.ErrorMessage;
                document.queryselector('.nameRequired').innerHTML = response.ValidationMessages.Name;
                document.queryselector('.imgRequired').innerHTML = response.ValidationMessages.Image;
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            document.querySelector('.thrownerror').innerHTML = thrownerror;
            document.querySelector('.errorMessage').innerHTML = errorMessage;
        }
    });
});

/////////////////////DELETE SERVICES
$(document).on('click', '.delete-project', function (e) {
    let idDelete = this.id;
    $('.delete-project-modal').data('id', idDelete);
    let checkbox = $('input[type="checkbox"]');
    $.each(checkbox, function (i, checkbox) {
        if ($(checkbox).is(":checked") && ($('.delete-project').index(e.target)) === i) {
            $('#deleteProjectModal').modal('show')
        }
    });
});
//Ajax request function Delete services
$('.delete-project-modal').on('click', function () {
    let token = $('input[name="__RequestVerificationToken"]').val();
    let id = $(this).data('id');
    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteProjectImage/' + id,
        data: {
            '__RequestVerificationToken': token,
            id: id,
        },
        success: function (response) {
            if (response.Data && response.Success) {
               // $('.delete-content-modal').addClass('d-none')
               // $('.succsses-content').addClass('d-block');
               
            }
        },
        error: function (xhr, ajaxoptions, thrownerror) {
            document.querySelector('.thrownerror').innerHTML = thrownerror;
            document.querySelector('.errorMessage').innerHTML = errorMessage;
        }
    });
});


