
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

$(document).on('click', '.editProject', function (e) {
    $.ajax({
        type: 'POST',
        url: '/Admin/getProjects',
        success: function (response) {
            if (response.Data && response.Success) {
                let project = response.Data;
                $.each(project, function (i, project) {
                    if ($('.editProject').index(e.target) === i) {
                        $("input[name='Name']").val(project.Name);
                        $("input[name='Id']").val(project.Id);
                        $("input[name='Order']").val(project.Order);
                        for (let i = 0; i < project.Images.length; i++) {
                            let projectImage = project.Images[i];
                            let img = document.createElement('img');
                            img.setAttribute('alt', 'ProjectImg');
                            img.setAttribute('class', 'preview-img');
                            img.setAttribute('src', urlImgProject + projectImage.Url);
                            document.querySelector('.img-preview').appendChild(img);
                        }
                        
                        return false;
                    }
                });
            }
        },
    });
});

$('input.projectFile').on('change', function () {
    let img = document.createElement('img');

})
//ADD and EDIT 

$('.updateProject').on('click', function () {
    let projectName = $('[name="Name"]').val();
    let projectId = $('[name="Id"]').val();
    let projectOrder = $('[name="Order"]').val();
    let token = $('input[name="__RequestVerificationToken"]').val();
    let formData = new FormData();
    formData.append('Name', projectName);
    formData.append('Id', 16);
    formData.append('Order', +projectOrder);
    formData.append('__RequestVerificationToken', token);
    formData.append('Images[0].ProjectId', 1);
    formData.append('Images[0].Order', 1);
    formData.append('Images[0].Url', "url");
    formData.append('Images[0].Image', $(".projectFile")[0].files[0]);
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
                //document.querySelector('.errorMessage').innerHTML = response.ErrorMessage;
                //document.queryselector('.nameRequired').innerHTML = response.ValidationMessages.Name;
                //document.queryselector('.imgRequired').innerHTML = response.ValidationMessages.Image;
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            document.querySelector('.errorMessage').innerHTML = errorMessage;
            document.querySelector('.thrownerror').innerHTML = thrownError;
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


