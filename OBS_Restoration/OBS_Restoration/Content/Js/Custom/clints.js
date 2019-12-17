$(document).ready(function () {
    document.getElementById("manager").onclick = dispalayManage;
    document.getElementById("owner").onclick = dispalayOwner;

    function dispalayManage() {
        document.getElementById("clints").innerHTML = "Propperty / Managers";
        return false;
    }
    function dispalayOwner() {
        document.getElementById("clints").innerHTML = "Owners";
        return false;
    }
});




