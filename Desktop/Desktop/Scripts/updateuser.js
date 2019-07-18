

    $(document).ready(function () {
        User();
    $("#Sform").submit(f1);
   
});

        function AddSalesPerson() {



        SalesPerson = { // Note that the name of the fields must be identical to the names of the properties of the object in the server
            UserName: $("#UserName").val(),
            Password: $("#Password").val(),
            FirstName: $("#FirstName").val(),
            LastName: $("#LastName").val(),
            PhoneNumber:$("#Phone").val(),
            Area: $("#Area").val(),
            Email: $("#Email").val()

        };

    ajaxCall("PUT", "../api/SalesPerson", JSON.stringify(SalesPerson), success, error);

}


        function success(data) {
        swal("Added Successfuly!", "User created", "success")
    }

    function error(err) {
        alert("error");
    }

        function f1() {
        AddSalesPerson();
    return false; // the return false will prevent the form from being submitted
    // hence the page will not reload
}

        function User() {
        user = JSON.parse(localStorage.getItem('data'));
    $("#UserName").val(user.UserName),
        $("#Password").val(user.Password),
        $("#FirstName").val(user.FirstName),
        $("#LastName").val(user.LastName),
        $("#Phone").val(user.PhoneNumber),
        $("#Area").val(user.Area),
        $("#Email").val(user.Email)


}
