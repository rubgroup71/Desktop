    $(document).ready(function () {
        Navbar();
    ajaxCall("GET", "../api/City", "", successGetCity, errorGetCity);


    $("#CForm").submit(f1);
});
        function Navbar() {
            var user = JSON.parse(localStorage.getItem('data'));


            if (user.ISAdmin == 1) {

        $("#navbaritem").show();
    $("#navuser").show();
}
}


        function Addfirebase() {
        UserName = $("#username").val();
    Password = $("#password").val();
            firebase.auth().createUserWithEmailAndPassword(UserName, Password).catch(function (error) {
        console.log(error.code);
    console.log(error.message)

            }).then(function (resp) {
        AddCustomer(resp.user.email)


    });


}
        function AddCustomer(email) {

        Address = { // Note that the name of the fields must be identical to the names of the properties of the object in the server

            Email: email,
            FirstName: $("#firstname").val(),
            LastName: $("#lastname").val(),
            Adress: $("#address").val(),
            PhoneNumber: $("#phonenumber").val(),
            CompanyName: $("#companyname").val(),
            City: $("#city option:selected").text(),

        };



    ajaxCall("POST", "../api/Address", JSON.stringify(Address), success, error);
    ajaxCall("POST", "../api/Customer", JSON.stringify(email) , successCustomer, errorCustomer);

}


        function success(data) {
        swal("Added Successfuly!", "Customer created", "success")
    }

    function error(err) {
        alert("error");
    }

        function f1() {
        Addfirebase();
    return false; // the return false will prevent the form from being submitted
    // hence the page will not reload
}
        function successGetCity(citydata) {
            for (var i = 0; i < citydata.length; i++) {
        $("#city").append($("<option></option>").val(citydata[i].ID).html(citydata[i].Name));

    }
}

// this function is activated in case of a failure
        function errorGetCity(err) {
        err = JSON.parse(err.responseText);
    swal("Error!", err.ExceptionMessage, "error");
}
        function successCustomer() {
        swal("Added Successfuly!", "Customer created", "success")
    }

    // this function is activated in case of a failure
    function errorCustomer(err) {
        err = JSON.parse(err.responseText);
    swal("Error!", err.ExceptionMessage, "error");
}
        function validateForm() {
            var x = document.forms["myForm"]["fname"].value;
            if (x == "") {
        alert("All field must be filled out");
    return false;
}
}

 