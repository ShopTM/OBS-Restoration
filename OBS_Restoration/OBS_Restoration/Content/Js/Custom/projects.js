$(function () {
    $.ajax({
        url: '/home/getProjects',
        type: 'GET',
        success: function (data) {
            if (data.Data && data.Success) {
                let project = data.Data;
                project.sort((a, b) => (a.Order > b.Order) ? 1 : (a.Order < b.Order) ? -1 : 1);
                $.each(project, function (i, value) {
                    populateProjectsTab(value);
                    populateProjectsImg(value);
                });
                // init Isotope
                var $grid = $(".images-group");
                $grid.isotope({
                    itemSelector: ".element-item",
                    layoutMode: "fitRows"
                });
                // bind filter button click
                $(".filters-button-group").on("click", "button", function () {
                    var filterValue = $(this).attr("data-filter");
                    $grid.isotope({ filter: filterValue });
                });
                // change is-checked class on buttons
                $(".button-group button").click(function () {
                    $('.button-group').find("button.is-checked").removeClass("is-checked");
                    $(this).addClass("is-checked");
                });
            }
            else if (data.Data === null || data.Success === false) {
                let errorProjectMessage = data.ErrorMessage;
                document.querySelector('.errorProjectMessage').innerHTML = errorProjectMessage;
                document.querySelector('.errorProject').style.display = 'block';
                document.querySelector('.project-filter ').style.display = 'none';
            }
        },
    });
});

function populateProjectsTab(value) {
    let templ = document.getElementById('tabTemplate');
    templ.content.querySelector(".button").innerHTML = (value.Name);
    templ.content.querySelector(".button").setAttribute("data-filter", 'img[project="' + value.Name + '"]');
    var clon = templ.content.cloneNode(true);
    document.querySelector(".button-group").append(clon);
}
function populateProjectsImg(value) {
    let temp = document.getElementById("imgTemplate");
    temp.content.querySelector(".element-item").setAttribute("project", value.Name);
    for (let i = 0, l = value.Images.length; i < l; i++) {
        let obj = value.Images[i];
        temp.content.querySelector('img').src = (obj.Url);
        var clon = temp.content.cloneNode(true);
        document.querySelector(".images-group").append(clon);
    }
};