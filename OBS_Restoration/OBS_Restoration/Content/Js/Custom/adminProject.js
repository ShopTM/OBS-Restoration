
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
                    populateTableProjectsImg(projects)
                    populateProjectseRow(projects) 
                   
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
    tdProject[3].textContent = projects.Name;
    templProject.content.querySelector('.td-img').setAttribute('projectId', projects.Id);
    cloneProject = document.importNode(templProject.content, true);
    tbodyProject.appendChild(cloneProject);
    
}

function populateTableProjectsImg(projects) {
    let tdImages = templProject.content.querySelector('.td-img');
    let projectId = tdImages.getAttribute('projectId')
   for (let i = 0, l = projects.Images.length; i < l; i++) {
       projectsImg = projects.Images[i];
       if (projectsImg.projectId)


               $('.td-img').append('<img src="" alt="" class="img-proj" />')
               document.querySelector('.img-proj').src = urlImgProject + projectsImg.Url;
              
      
      

   }
    }
 



