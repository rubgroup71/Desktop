
    $(document).ready(function () {
        Navbar();

    ajaxCall("GET", "../api/Categories", "", successGettype, errorGettype);
    ajaxCall("GET", "../api/City", "", successGetCity, errorGetCity);

    $("#OForm").submit(f1);
$("#selectstages").submit(f2);


  
});



        function Navbar() {
            var user = JSON.parse(localStorage.getItem('data'));


            if (user.ISAdmin == 1) {

        $("#navbaritem").show();
    $("#navuser").show();
}
}
        function successGetstage(data) {
            var result = Object.keys(data);
            for (var i = 1; i <= result.length; i++) {
                for (var j = 0; j < data[i].length; j++) {
        $('#stage' + i).append($("<option></option>").val(data[i][j].ID).html(data[i][j].Description));

    }


};
}
var categories = [];
        function successGettype(data) {
        categories = data;
    for (var i = 0; i < data.length; i++) {
        $("#type").append($("<option></option>").val(data[i].Type).html(data[i].Type));

    }
}

        function errorGettype(err) {
        err = JSON.parse(err.responseText);
    swal("Error!", err.ExceptionMessage, "error");
}


        function successGetCity(citydata) {
            for (var i = 0; i < citydata.length; i++) {
        $("#city").append($("<option></option>").val(citydata[i].ID).html(citydata[i].Name));

    }
}

        function errorGetCity(err) {
        err = JSON.parse(err.responseText);
    swal("Error!", err.ExceptionMessage, "error");
}

        function successGetAD(address) {
            for (var i = 0; i < address.length; i++) {
        $("#adress").append($("<option></option>").val(address[i].ID).html(address[i].address));

    }
}

        function errorGetAD(err) {
        err = JSON.parse(err.responseText);
    swal("Error!", err.ExceptionMessage, "error");
}
        function errorGetstage(err) {
        swal("Error!", err.ExceptionMessage, "error");
    }
 
        function additem() {

        $("#email").prop("disabled", false)
            $("#email").show()
    $("#address").prop("disabled", false)
    $("#address").show()
    $("#table").prop("disabled", false)
    $("#table").show()
 
    var str = "";

            for (var i = 1; i <= parseInt(stage[0].Stages); i++) {
        str += $('#stage' + i).val();
    //count++;


    }
    item = str;
    quantity = $("#quantity").val();

            document.getElementById("table").innerHTML += '<tr><td class="part">' + item + '</td><td class="qu">' + quantity + '</td></tr>';
    ajaxCall("GET", "../api/Address", "", successGetEmail, errorGetEmail);

}
        function clean() {
            for (var i = 1; i <= parseInt(stage[0].Stages); i++) {
        $('#stage' + i).val("");
    }
    $("#quantity").val("");

}

var click = false;
        function AddOrder(data) {
            var parts = []
    var quantity = []

            $("td.part").map(function (x, y) {parts.push(y.textContent)});
            $("td.qu").map(function (x, y) {quantity.push(y.textContent)});

    var address = addresses.filter(a => a.ID == $("#address").val())

            Order = { // Note that the name of the fields must be identical to the names of the properties of the object in the server

        Part: parts,
    Quantity: quantity,
    Address: address[0]

};

ajaxCall("POST", "../api/Order", JSON.stringify(Order), successOrder, errorOrder)

}

        function successOrder() {
        swal("Added Successfuly!", "Order created", "success")


    }



    function errorOrder(err) {
        err = JSON.parse(err.responseText);
    swal("Error!", err.ExceptionMessage, "error");
}


        function f2() {
        additem();
    return false;
}

        function f1() {
        AddOrder();
    return false; // the return false will prevent the form from being submitted
    // hence the page will not reload
}

        function successGetEmail(email) {
            for (var i = 0; i < email.length; i++) {
        $("#email").append($("<option></option>").val(email[i]).html(email[i]));

    }
}

        function errorGetEmail(err) {
        err = JSON.parse(err.responseText);
    swal("Error!", err.ExceptionMessage, "error");
}
        function ShowDetails(data) {

            var adr = addresses.filter(a => data = a.ID)

    Email = "'" + adr[0].Email + "'";
            $("#table2").append("<div>First Name : " + adr[0].FirstName + " </div>" + "<div>Last Name : " + adr[0].LastName + " </div>" +
                "<div>Phone : " + adr[0].PhoneNumber + " </div>" + "<div>Company Name : " + adr[0].CompanyName + " </div>" +
                "<div>Adress : " + adr[0].Adress + " </div>" + "<div>City : " + adr[0].City + " </div>" + '<input type="button" onClick="Javacsript:AddOrder(' + Email + ')" value="Submit" />');

}
        function address(data) {
        uri = "../api/Address/5?Email=" + data;
    ajaxCall("GET", uri, "", successGetaddress, errorGetaddress);

}
var addresses
        function successGetaddress(data) {
        $("#address").empty();
    $("#address").append($("<option></option>").val('').html('Choose Address'));
    addresses = data
            for (var i = 0; i < data.length; i++) {
        $("#address").append($("<option></option>").val(data[i].ID).html(data[i].Adress));


    }
    $("#table2").empty();
}

        function errorGetaddress(err) {
        err = JSON.parse(err.responseText);
    swal("Error!", err.ExceptionMessage, "error");
}
var stage;
var count = 0;
        function chooseType(data) {
        $("#selectstages").empty();
    stage = categories.filter(t => data == t.Type)
    //count++
            //if (count != 1) {
        //    return false;
        //}

        ajaxCall("GET", "../api/Question?type=" + stage[0].Type, "", setselection, errorGetstage)
            ajaxCall("GET", "../api/AllItem?type=" + stage[0].Type + "&stages=" + stage[0].Stages, "", successGetstage, errorGetstage)



}
        function setselection(data) {

        data.map(stage => {

            $("#selectstages").append(
                "<label><span class='fname'>" + stage.Name + "<span class='required'>*</span></span><select id='stage" + stage.QID + "' name='selection" + stage.QID + "' required><option class='required'></option></select>"
            )
        })
            $("#selectstages").append(
                "<label><span class='fname'>Quantity<span class='required'>*</span ></span ><input type='text' id='quantity' name='qun' /> </label ><input type='submit' value='Add' />"
)

}
