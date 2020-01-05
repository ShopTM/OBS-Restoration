$(document).ready(function () {
    const input = document.querySelector("#ClientType");
    const h3 = document.querySelector("h3#clints");
    const val = input.value;
    switch (val) {
        case "1":
            h3.innerHTML = "Enginners / Architecs";
            break;
        case "2":
            h3.innerHTML = "Propperty / Managers";
            break;
        case "3":
            h3.innerHTML = "Owner";
            break;
    }
});






