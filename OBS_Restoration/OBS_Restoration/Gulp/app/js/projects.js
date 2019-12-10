$(document).ready(function () {
    $('#but').on('click', function () {
        $.ajax({
            url: '/home/getProjects',
            type: 'GET',
            success: function (data) {
                data.sort((a, b) => (a.Order > b.Order) ? 1 : (a.Order < b.Order) ? -1 : 1);
                $.each(data, function (i, value) {

                    populateProjectsImg(value)
                    populateProjectsTab(value)
                })
            }
        })

    });
});

function populateProjectsTab(value) {
    let templ;
    templ = document.getElementById('templateTab');
    templ.content.querySelector('.tab').innerHTML = (value.Name);
    templ.content.querySelector(".tab").setAttribute("data-filter", '#' + value.Id);
    var clon = templ.content.cloneNode(true);
    document.querySelector('.project-filter-links').append(clon);
}


function populateProjectsImg(value) {
    let temp, img;
    temp = document.getElementById('templateImg');
    temp.content.querySelector(".project-container-img").setAttribute("id", value.Id);
    for (let i = 0, l = value.Images.length; i < l; i++) {
        let obj = value.Images[i];
        temp.content.querySelector('img').src = (obj.Url);

        var clon = temp.content.cloneNode(true);
        document.querySelector('.project-container').append(clon);
    }




}
