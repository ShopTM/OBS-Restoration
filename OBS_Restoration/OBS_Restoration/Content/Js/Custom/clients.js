$(function () {
    const input = document.querySelector("#ClientType");
    const h3 = document.querySelector("h3#clints");
    const val = input.value;
  
    switch (val) {
        case "Enginner":
            h3.innerHTML = "Enginners / Architecs";
            break;
        case "Manager":
            h3.innerHTML = "Propperty / Managers";
            break;
        case "Owner":
            h3.innerHTML = "Owner";
            break;
    }

});






