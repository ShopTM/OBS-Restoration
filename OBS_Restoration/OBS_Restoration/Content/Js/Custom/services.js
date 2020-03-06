$(function () {
    addLoading('.services-img');
    $.ajax({
        url: '/home/getServices',
        type: 'GET',
        success: function (data) {
            if (data.Data && data.Success) {
                let services = data.Data;
                services.sort((a, b) => (a.Order > b.Order) ? 1 : (a.Order < b.Order) ? -1 : 1);
                $.each(services, function (i, value) {
                    populateService(value);
                });
            }
            else if (data.Data === null || data.Success === false) {
                let errorProjectMessage = data.ErrorMessage;
                document.querySelector('.errorProjectMessage').innerHTML = errorProjectMessage;
                document.querySelector('.errorProject').style.display = 'block';
                document.querySelector('.project-filter-links').style.display = 'none';
            }
        }
    });
});
function populateService (item) {
    var temp, col, row;
    temp = document.getElementsByTagName("template")[0];
    temp.content.querySelector('img').src = item.ImgUrl;
    temp.content.querySelector('img').alt = item.Name;
    temp.content.querySelector('h2').innerHTML = (item.Name);
    temp.content.querySelector('p').innerHTML = (item.Description);
    col = temp.content.querySelector(".col-lg-4");
    row = temp.content.querySelectorAll(".row");
    row = document.importNode(col, true);
    document.querySelectorAll('.row')[6].append(row);
};

