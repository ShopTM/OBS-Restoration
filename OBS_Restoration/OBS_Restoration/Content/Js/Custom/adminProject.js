
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
                    populateProjectseRow(projects)
                    populateProjectsImg(projects) 
          
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
let templProj = document.querySelector("#tableProjectsTemplate");
let tdProj = templProj.content.querySelectorAll("td");
let tbodyProj = document.querySelector(".tableProjectsBody");
let urlImgProj = "../../Content/Images/Projects/";
let tdImg = templProj.content.querySelector("td")[4];
 
function populateProjectseRow(projects) {
    tdProj[3].textContent = projects.Name;
    cloneProj = document.importNode(templProj.content, true);
    tbodyProj.appendChild(cloneProj);
}


function populateProjectsImg(projects) {
    templProj.content.querySelector(".img-proj").setAttribute("projectId", projects.projectId);
        for (let i = 0, l = projects.Images.length; i < l; i++) {
            let projectsImg = projects.Images[i];
            templProj.content.querySelector('img').src = (projectsImg.Url);
            var clon = templProj.content.cloneNode(true);
            tdImg.appendChild(clon);

          
        }
    }

