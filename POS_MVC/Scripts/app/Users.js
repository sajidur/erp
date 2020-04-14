function GetAllUsers(controlId) {
    $.ajax({
        url: "/Users/Users",
        success: function (data) {
            $("#hdId").val(data.Id);
            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (true) {
                $("#" + controlId).get(0).options[0] = new Option("-Select-", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.UserName, item.Id);
                });
            }
            $("#" + controlId).chosen({ no_results_text: "Oops, nothing found!" });
        },
        error: function () {
            alert('An error occured try again later');
        }
    });
}