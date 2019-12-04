
window.addEventListener("load", function (event) {
    function getImg(url, jsonData) {
        let xhttp = new XMLHttpRequest();
        xhttp.open("GET", "/home/Services");
        xhttp.send(null);

        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status == 200) callback(xhttp);
        };
    }
});
