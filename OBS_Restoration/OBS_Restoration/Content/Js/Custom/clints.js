$(document).ready(function () {
    let input = document.querySelector("#ClientType");
    let h2 = document.querySelector("h2#clints");
    let val = input.value;
    if (val == 1) {
        h2.innerHTML = "Enginners / Architecs";
    } else if (val == 2) {
        h2.innerHTML = "Propperty / Managers";
    } else {
        h2.innerHTML = "Owner";
    }
})







   










