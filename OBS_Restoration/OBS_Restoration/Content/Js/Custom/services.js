$(document).ready(function () {
    $.ajax({
        url: '/home/getServices',
        type: 'GET',
        success: function (data) {
            data.sort((a, b) => (a.Order > b.Order) ? 1 : (a.Order < b.Order) ? -1 : 1);

            $.each(data, function (i, item) {
                populateService(item)

            });
        }
    });
});
function populateService(item) {
    var temp, col, row;
    temp = document.getElementsByTagName("template")[0];
    temp.content.querySelector('img').src = (item.ImgUrl);
    temp.content.querySelector('img').alt = (item.Name);
    temp.content.querySelector('h2').innerHTML = (item.Name);
    temp.content.querySelector('p').innerHTML = (item.Description);
    col = temp.content.querySelector(".col-lg-4");
    row = temp.content.querySelectorAll(".row");
    row = document.importNode(col, true);
    document.querySelectorAll('.row')[6].append(row);

}
