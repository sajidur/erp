function PayHead(controlId,IsControllBind,IsGridBind) {
    var url = '/SalaryItem/GetAll';
    $.ajax({
        url: url,
        method: 'GET',
        success: function (res) {
            var data = res;
            //alert('Success');
            if (IsControllBind==true) {
                $("#" + controlId).empty();
                $("#" + controlId).get(0).options.length = 0;
                if (true) {
                    $("#" + controlId).get(0).options[0] = new Option("-Select-", "");
                }
                if (data != null) {
                    $.each(data, function (index, item) {
                        $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option('' + item.Name + '(' + intime + ' To ' + outTime + ')', item.Id);
                    });
                }
                $("#" + controlId).chosen({ no_results_text: "Oops, nothing found!", search_contains: true });
            }
            if (IsGridBind) {
                var templateWithData = Mustache.to_html($("#templateGroupModal").html(), { GroupSearch: res });
                $("#divInfo").empty().html(templateWithData);
                MakePagination('groupTableModal');
            }

        },
        error: function () {
        }
    });
}
function LoadPackage(controlId, IsControllBind, IsGridBind) {
    var url = '/SalaryItem/GetAllPackage';
    $.ajax({
        url: url,
        method: 'GET',
        success: function (res) {
            var data = res;
            //alert('Success');
            if (IsControllBind == true) {
                $("#" + controlId).empty();
                $("#" + controlId).get(0).options.length = 0;
                if (true) {
                    $("#" + controlId).get(0).options[0] = new Option("-Select-", "");
                }
                if (data != null) {
                    $.each(data, function (index, item) {
                        $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.SalaryPackageName + '(Total ' + item.TotalAmount +')', item.Id);
                    });
                }
                $("#" + controlId).chosen({ no_results_text: "Oops, nothing found!", search_contains: true });
            }
            if (IsGridBind) {
                var templateWithData = Mustache.to_html($("#templatePackageGroupModal").html(), { GroupPackageSearch: res });
                $("#div-packageInfo").empty().html(templateWithData);
                MakePagination('groupPackageTableModal');
            }

        },
        error: function () {
        }
    });
}
