$(function () {
    addLoading('.grid');
    $.ajax({
        url: '/home/getProjects',
        type: 'GET',
        success: function (data) {
            if (data.Data && data.Success) {
                addAllTab();
                let project = data.Data;
                project.sort((a, b) => (a.Order > b.Order) ? 1 : (a.Order < b.Order) ? -1 : 1);
                $.each(project, function (i, value) {
                    populateProjectsTab(value);
                    populateProjectsImg(value);
                    populateProjectsDescription(value);
                });
                // init Isotope
                var $grid = $(".filterSection");
                $grid.isotope({
                    itemSelector: ".filter-item",
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
    let clon = templ.content.cloneNode(true);
    let button = clon.querySelector('.button');
    button.classList.add('active-text');
    clon.querySelector(".button").innerHTML = (value.Name);
    clon.querySelector(".button").setAttribute("data-filter", '[project="' + value.Name + '"]');
    document.querySelector(".button-group").append(clon);
}
function populateProjectsDescription(value) {
    let templ = document.getElementById('descriptionTemplate');
    let clon = templ.content.cloneNode(true);
    clon.querySelector(".description-proj").innerHTML = value.Description;
    clon.querySelector(".description-proj").setAttribute("project", value.Name);
    document.querySelector(".description-container").append(clon);
}
function populateProjectsImg(value) {
    let temp = document.getElementById("imgTemplate");
    temp.content.querySelector(".filter-item").setAttribute("project", value.Name);
    for (let i = 0, l = value.Images.length; i < l; i++) {
        let img = value.Images[i];
        temp.content.querySelector('img').src = (img.Url);
        let clon = temp.content.cloneNode(true);
        document.querySelector(".images-group").append(clon);
    }
};
let textDescript = document.querySelector(".description-container");
function addAllTab() {
    let templ = document.getElementById('tabTemplate');
    let clone = templ.content.cloneNode(true);
    let button = clone.querySelector(".button");
    button.innerHTML = 'All project';
    button.setAttribute("data-filter", '*');
    button.setAttribute("id", 'all-proj')
    button.classList.add('is-checked');
    document.querySelector(".button-group").append(clone);
}

