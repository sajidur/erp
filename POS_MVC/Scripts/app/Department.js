function ClearAddBox() {
    $("#txtDepartmentName").val('');
    $("#txtColor").val('');
}
function InsertSuccess(response) {
    // debugger;
    if (response.result == false) {
        $("#lblMessage").html(response.Error);
        $("#modalpopupMessage").dialog();
    } else {
        ClearAddBox();
        if (response.Error == 'Deleted') {
            LoadListData();
            $("#lblMessage").html('Data Deleted Successfully');
            $("#modalpopupMessage").dialog();
            $("#modalpopupAdd").dialog('close');
        }
        if (response.Error == 'Saved') {
            LoadListData();
            //$("#lblMessage").html('Data Saved Successfully');
            //$("#modalpopupMessage").dialog();
            $("#modalpopupAdd").dialog('close');
        }
        if (response.Error == 'Updated') {
            LoadListData();
            $("#lblMessage").html('Data Updated Successfully');
            $("#modalpopupMessage").dialog();
            $("#modalpopupAdd").dialog('close');
        }
    }
}
function LoadColorList() {
    var url = '/Department/GetAll';
    $.ajax({
        url: url,
        method: 'POST',
        success: function (res) {
            var templateWithData = Mustache.to_html($("#templateProductGroupModal").html(), { ProductGroupSearch: res });
            $("#div-productGroup").empty().html(templateWithData);
            MakePagination('productGroupTableModal');
        },
        error: function () {
        }
    });
}
function LoadAllBrand(controlId) {
    var url = '/Department/GetAll';
    $.ajax({
        url: url,
        method: 'POST',
        success: function (data) {
            $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Name, item.Id);
                });
            }
        },
        error: function () {

        }
    });
}

$(document).ready(function () {
    LoadColorList();
});
function LoadForEdit(parameters) {
    ResetForm();
    LoadSingleData(parameters);
}
function LoadForDelete(parameters) {
    ClearAddBox();
    //e.preventDefault();
    $("#modalpopupAdd").dialog({ width: 650, minHeight: 300, modal: true });
    $("#ui-id-1").html("Delete Category");
    $("#btnSave").hide();
    $("#btnUpdate").hide();
    $("#btnDelete").show();

    LoadSingleData(parameters);
}
function ResetForm() {
    $('#txtDepartmentName').val('');
}
function LoadSingleData(parameters) {
    $.ajax({
        url: "/Department/Details",
        data: { 'id': parameters },
        success: function (data) {
            debugger;
            $("#DEPTID").val(data.DEPTID);
            $("#txtDepartmentName").val(data.DEPTNAME);
        },
        error: function () {
            alert('An error occured try again later');
        }
    });
}
function FormDataAsObject() {
    var object = new Object();
    object.DEPTNAME = $('#txtDepartmentName').val();
    object.Description = $('#txtDescription').val();

    //object.GroupName = $('#txtGroupName').val();
    //object.Manufacturer = $('#txtColorDes').val();
    return object;
}
function Save() {
    debugger;
    if ($("#txtDepartmentName").val() == "") {
        alert('Department Name Empty');
        return false;
    }

    var formObject = FormDataAsObject();

    $.ajax({
        url: '/Department/Create',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            //Id: formObject.Id,
            Name: formObject.DEPTNAME,
            Descriptions: formObject.Description,
            //Manufacturer: formObject.Manufacturer,
            create: 1
        },
        success: function (data) {
            ShowNotification("1", "Color Saved!!")
            ResetForm();
            LoadColorList();
        },
        error: function () {

        }
    });

}
$("#btnUpdate").click(function (e) {
    e.preventDefault();

    if ($("#txtDepartmentName").val() == "") {
        alert('DepartmentName Is Empty.');
        return false;
    }

    var ratemaster = {
        "DEPTID": $("#DEPTID").val(),
        "DEPTNAME": $("#txtDepartmentName").val(),
    };

    JsonData = JSON.stringify(ratemaster);
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/Department/UpdateDepartment',
        data: JsonData,
        async: false,
        cache: false,
        success: function (data) {
            if (data.result == false) {
                $("#lblMessage").html(data.Error);
            }
            alert('Update Successfully.');
            ResetForm();
            LoadColorList();
            //ClearAddBox();
            //$("#btnSave").show();
            //$("#btnDelete").hide();
            //$("#btnUpdate").hide();
            //LoadListData();
        },
        error: function () {
            alert('An error occured try again later');
        }
    });
});
$("#btnDelete").click(function (e) {
    e.preventDefault();
    var ratemaster = {
        "ColorId": $("#ColorId").val(),
    };

    JsonData = JSON.stringify(ratemaster);
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/Setup/DeleteColor',
        data: JsonData,
        async: false,
        cache: false,
        success: function (data) {
            if (data.result == false) {
                $("#lblMessage").html(data.Error);
            }
            alert('Delete Successfully.');
            LoadListData();
            ClearAddBox();
            $("#btnSave").show();
            $("#btnDelete").hide();
            $("#btnUpdate").hide();
            //LoadListData();
        },
        error: function () {
            alert('An error occured try again later');
        }
    });
});