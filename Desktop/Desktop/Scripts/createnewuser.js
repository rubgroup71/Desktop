    $(document).ready(function () {

        $("#Sform").submit(f1);

    });

function AddSalesPerson() {



    SalesPerson = { // Note that the name of the fields must be identical to the names of the properties of the object in the server
        UserName: $("#UserName").val(),
        Password: $("#Password").val(),
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        PhoneNumber: $("#Phone").val(),
        Area: $("#Area").val(),
        Email: $("#Email").val()

    };

    ajaxCall("POST", "../api/SalesPerson", JSON.stringify(SalesPerson), success, error);

}


function success(data) {
    swal("Added Successfuly!", "User created", "success")
}

function getSuccessexist(datatest) {
    test = $("#UserName").val();
    if (datatest.UserName == test) {
        swal("This user alerady exist", "Please try agin", "success");
    }
    else {
        AddSalesPerson();
    }
}
function errorexist() {
    alert("connection problem");
}
function error(err) {
    alert("error");
}

function f1() {
    uri = "../api/SalesPerson?UserName=" + $("#UserName").val();
    ajaxCall("GET", uri, "", getSuccessexist, errorexist);

    //AddSalesPerson();

    return false; // the return false will prevent the form from being submitted
    // hence the page will not reload
}
        

