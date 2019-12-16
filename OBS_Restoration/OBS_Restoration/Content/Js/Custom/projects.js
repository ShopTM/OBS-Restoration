$(document).ready(function () {
    $.ajax({
        url: '/home/getProjects',
        type: 'GET',
        success: function (data) {
            data.sort((a, b) => (a.Order > b.Order) ? 1 : (a.Order < b.Order) ? -1 : 1);
            $.each(data, function (i, value) {

                populateProjectsImg(value)
                populateProjectsTab(value)
            })
            /////////////////////PROJECT ISOTOP
            var $container = $(".project-container");
            $container.isotope({
                filter: "*",
                animationOptions: {
                    duration: 750,
                    easing: "linear",
                    queue: false
                }
            });

            $(".project-filter a").click(function () {
                $(".project-filter .current").removeClass("current");
                $(this).addClass("current");

                var selector = $(this).attr("data-filter");
                $container.isotope({
                    filter: selector,
                    animationOptions: {
                        duration: 750,
                        easing: "linear",
                        queue: false
                    }
                });
                return false;
            });
        }
    });

});

function populateProjectsTab(value) {
    let templ;
    templ = document.getElementById('templateTab');
    templ.content.querySelector(".tab").innerHTML = (value.Name);
    templ.content.querySelector(".tab").setAttribute("data-filter", 'section' + '[project=' + '"' + value.Name + '"' + ']');
    templ.content.querySelector("a.tab").setAttribute("href", value.Name);
    var clon = templ.content.cloneNode(true);
    document.querySelector(".project-filter-links").append(clon);
}


function populateProjectsImg(value) {
    let temp;
    temp = document.getElementById("templateImg");
    temp.content.querySelector(".project-container-img").setAttribute("project", value.Name);
    for (let i = 0, l = value.Images.length; i < l; i++) {
        let obj = value.Images[i];
        temp.content.querySelector('img').src = (obj.Url);
        var clon = temp.content.cloneNode(true);
        document.querySelector(".project-container").append(clon);
    }
}
