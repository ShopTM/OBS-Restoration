$(function () {
    $("#contact").submit(function (event) {
        ///event.preventDefault();
        $.ajax({
            method: "POST",
            url: "",
            processData: false,
            success: function () {
               alert("thanks")
            },
        })
    })
})