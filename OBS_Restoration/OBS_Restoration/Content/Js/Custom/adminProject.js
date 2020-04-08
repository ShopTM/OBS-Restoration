
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
let tbodyProject = document.querySelector(".tableProjectsBody");
let urlImgProject = "../../Content/Images/Projects/";

function populateProjectseRow(projects) {
    let clone = templProject.content.cloneNode(true);
    let td = clone.querySelectorAll('td');
    let deleteBtn = clone.querySelector('.delete-project')
    td[2].textContent = projects.Name;
    deleteBtn.setAttribute('id', projects.Id);

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
$(document).on('click', '.editProject', function (e) {
    $.ajax({
        type: 'GET',
        url: '/Admin/getProjects',
        success: function (response) {
            if (response.Data && response.Success) {
                let project = response.Data;
                $.each(project, function (i, project) {
                    if ($('.editProject').index(e.target) === i) {
                        $("input[name='Name']").val(project.Name);
                        $("input[name='Id']").val(project.Id);
                        for (let i = 0; i < project.Images.length; i++) {
                            let projectImage = project.Images[i];
                            let section = document.createElement('section');
                            section.setAttribute('class', 'img-container');
                            section.innerHTML = '<img src ="' + urlImgProject + projectImage.Url + '" class = "preview-img" alt="project" > <input type="button" value = "x" class="deletePriview"> <input type="hidden" value="' + projectImage.Id + '"name="ImgId">';
                            document.querySelector('.img-preview').append(section);
                        }
                    }
                });
                $('.deletePriview').on('click', function (e) {
                    $(this).closest('.img-container').remove();
                });
            }
        },
    });
});
//ADD and EDIT 
$('.updateProject').on('click', function () {
    let projectName = $('[name="Name"]').val();
    let projectId = $('[name="Id"]').val();
    let token = $('input[name="__RequestVerificationToken"]').val();
    let idImg = $('[name="ImgId"]');
    let formData = new FormData();
    formData.append('Name', projectName);
    formData.append('Id', projectId);
    formData.append('__RequestVerificationToken', token);
    let count = 0;
    for (i = 0; i < idImg.length; i++) {
        let id = idImg[i].value;
        formData.append('Images[' + count++ + '].Id', id);
    }
    $('.form-update-project').find("input.projectFile").each(function (i, field) {
        let file = field.files[0];
        if (file) {
            formData.append('Images[' + count + '].Id', 0);
            formData.append('Images[' + count + '].Image', file);
            count += 1;
        }
    });
    $.ajax({
        type: 'POST',
        url: '/Admin/UpdateProject',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            tbodyProject.innerHTML = "";
            populateTableProjects();
            if (response.Success && response.Success) {
                $('.modal-dialog form').addClass('d-none');
                $('.succsses-content').addClass('d-block');
          ///      locationReload();
            } if (response.Success == false || response.Success == false) {
                document.querySelector('.errorMessage').innerHTML = response.ErrorMessage;
                document.querySelector('.nameRequire').innerHTML = response.ValidationMessages.Name;
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            document.querySelector('.errorMessage').innerHTML = errorMessage;
            document.querySelector('.thrownerror').innerHTML = thrownError;
        }
    });
});

///////////////////DELETE SERVICES
$(document).on('click', '.delete-project', function (e) {
    let idDeleteProj = this.id;
    $('.delete-project-modal').data('id', idDeleteProj);
    $('#deleteProjectModal').modal('show')
});
//Ajax request function Delete services
$('.delete-project-modal').on('click', function () {
    let token = $('input[name="__RequestVerificationToken"]').val();
    let id = $(this).data('id');
    $.ajax({
        type: 'POST',
        url: '/Admin/DeleteProject/' + id,
        data: {
            '__RequestVerificationToken': token,
            'projectId': id,
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

function locationReload() {
    if ($('.modal').on('hidden.bs.modal')) {
        window.setTimeout(function () {
            location.reload()
        }, 1200);
    }
}