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
    var url = '/SalaryItemNew/GetAll';
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
    var url = '/SalaryItemNew/GetAll';
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
    $("#ui-id-1").html("Delete Salary Item");
    $("#btnSave").hide();
    $("#btnUpdate").hide();
    $("#btnDelete").show();

    LoadSingleData(parameters);
}
function ResetForm() {
    $('#txtSalaryItemName').val('');
    $('#txtPercentage').val('');
}
function LoadSingleData(parameters) {
    $.ajax({
        url: "/SalaryItemNew/Details",
        data: { 'id': parameters },
        success: function (data) {
            debugger;
            $("#id").val(data.id);
            $("#txtSalaryItemName").val(data.SalaryItemName);
            $("#txtPercentage").val(data.Percentage);
        },
        error: function () {
            alert('An error occured try again later');
        }
    });
}
function FormDataAsObject() {
    var object = new Object();
    object.SalaryItemName = $('#txtSalaryItemName').val();
    object.Percentage = $('#txtPercentage').val();
    object.Amount = $('#txtAmount').val();
    //object.Manufacturer = $('#txtColorDes').val();
    return object;
}
function Add() {
    //debugger;
    if ($("#txtSalaryItemName").val() == "") {
        alert('SalaryItem Name Empty');
        return false;
    }
    if ($("#txtPercentage").val() == "") {
        alert('Percentage Empty');
        return false;
    }

    var formObject = FormDataAsObject();

    $.ajax({
        url: '/SalaryItemNew/Create',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            //Id: formObject.Id,
            SalaryItemName: formObject.SalaryItemName,
            Amount: formObject.Amount,
            Percentage: formObject.Percentage,
            //Manufacturer: formObject.Manufacturer,
            create: 1
        },
        success: function (data) {
            ShowNotification("1", "Salary Item Saved!!")
            ResetForm();
            LoadColorList();
        },
        error: function () {

        }
    });

}

$("#btnUpdate").click(function (e) {
    e.preventDefault();

    if ($("#txtSalaryItemName").val() == "") {
        alert('DepartmentName Is Empty.');
        return false;
    }
    if ($("#txtPercentage").val() == "") {
        alert('Percentage Empty');
        return false;
    }

    var ratemaster = {
        "id": $("#id").val(),
        "SalaryItemName": $("#txtSalaryItemName").val(),
        "Percentage": $("#txtPercentage").val()
    };

    JsonData = JSON.stringify(ratemaster);
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/SalaryItemNew/UpdateDepartment',
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
        "id": $("#id").val(),
    };

    JsonData = JSON.stringify(ratemaster);
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/SalaryItemNew/DeleteColor',
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