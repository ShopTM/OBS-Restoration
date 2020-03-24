
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






