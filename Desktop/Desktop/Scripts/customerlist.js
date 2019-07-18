
    $(document).ready(function () {
        Navbar();
    ajaxCall("GET", "../api/Customer", "", getSuccess, error);
});
        function Navbar() {
            var user = JSON.parse(localStorage.getItem('data'));


            if (user.ISAdmin == 1) {

        $("#navbaritem").show();
    $("#navuser").show();
}
}

        function getSuccess(CustomerData) {
        console.log(CustomerData)


            try {

        tbl = $('#customertable').DataTable({
            data: CustomerData,
            pageLength: 5,
            dom: 'Bfrtip',
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ],
            columns: [

                { data: "Email" },

                {
                    data: "Address",
                    render: function (data, type, row, meta) {
                        str = "";
                        for (var i = 0; i < data.length; i++) {

                            str += "<p>" + data[i].FirstName + "</p>";

                        }
                        return str;
                    }

                },

                {
                    data: "Address",
                    render: function (data, type, row, meta) {
                        str = "";
                        for (var i = 0; i < data.length; i++) {

                            str += "<p>" + data[i].LastName + "</p>";

                        }
                        return str;
                    }
                },
                {
                    data: "Address",
                    render: function (data, type, row, meta) {
                        str = "";
                        for (var i = 0; i < data.length; i++) {

                            str += "<p>" + data[i].City + "</p>";

                        }
                        return str;
                    }
                },
                {
                    data: "Address",
                    render: function (data, type, row, meta) {
                        str = "";
                        for (var i = 0; i < data.length; i++) {

                            str += "<p>" + data[i].Adress + "</p>";

                        }
                        return str;
                    }
                },
                {
                    data: "Address",
                    render: function (data, type, row, meta) {
                        str = "";
                        for (var i = 0; i < data.length; i++) {

                            str += "<p>" + data[i].PhoneNumber + "</p>";

                        }
                        return str;
                    }
                },
                {
                    data: "Address",
                    render: function (data, type, row, meta) {
                        str = "";
                        for (var i = 0; i < data.length; i++) {

                            str += "<p>" + data[i].CompanyName + "</p>";

                        }
                        return str;
                    }
                },







            ],
        });

    }

            catch (err) {
        alert(err);
    }

}

// this function is activated in case of a failure
        function error(err) {
        swal("Error: " + err);
    }

