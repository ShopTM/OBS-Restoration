

$(document).ready(function () {
    $("#but1").click(function (url) {
        $.ajax({
            url: '/home/getServices',
            type: 'GET',
            success: function (data) {
                $.each(data, function (index, service) {
                    addService(service);
                   
                });
            }
        });

         function addService(service) {
             var serviceName = '<img src="' + service.ImgUrl + '"/>';
             console.log(serviceName)
        }
       
     })

 });



