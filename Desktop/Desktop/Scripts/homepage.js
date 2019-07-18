
    $(document).ready(function () {
        // wire all the buttons
        $("#login").click(Login);

    });
 
        function Login() {

        uri = "../api/SalesPerson?UserName=" + $("#username").val() + "&password=" + $("#password").val();
    ajaxCall("GET", uri, "", successGetperson, errorGetperson);

}
        function successGetperson(data) {
            
           
            if (data.UserName == $("#username").val() && data.Password == $("#password").val()) {

        window.location.href = 'OrderList.html';
    }
    else
            {
                return false;
}
localStorage.setItem('data', JSON.stringify(data));

}
        function errorGetperson(err) {
        swal("error");

    }
