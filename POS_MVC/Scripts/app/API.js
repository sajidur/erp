﻿function ClearAddBox() {
    $("#ColorId").val('0');
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
    var url = '/Color/GetAll';
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
function LoadAllAPI(controlId) {
    var url = '/APISetup/GetAll';
    $.ajax({
        url: url,
        method: 'GET',
        success: function (data) {
            $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.APIName, item.Id);
                });
            }
            $("#" + controlId).chosen({ no_results_text: "Oops, nothing found!" });
        },
        error: function () {

        }
    });
}
function LoadSingleData(parameters) {
    $.ajax({
        url: "/Setup/FindByColorID",
        data: { 'btID': parameters },
        success: function (data) {
            $("#ColorId").val(data.data.ColorId);
            $("#txtColor").val(data.data.ColorName);
        },
        error: function () {
            alert('An error occured try again later');
        }
    });
}
function FormDataAsObject() {
    var object = new Object();
    object.Name = $('#txtColorName').val();
    //object.GroupName = $('#txtGroupName').val();
    object.Manufacturer = $('#txtColorDes').val();
    return object;
}
function Save() {
    //debugger;
    if ($("#txtColor").val() == "") {
        alert('Color Name Empty');
        return false;
    }

    var formObject = FormDataAsObject();
  
    $.ajax({
        url: '/Color/Create',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            Id: formObject.Id,
            Name: formObject.Name,
            Descriptions: formObject.GroupDescription,
            Manufacturer: formObject.Manufacturer,
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

    if ($("#txtColor").val() == "") {
        alert('ColorName Is Empty.');
        return false;
    }

    var ratemaster = {
        "ColorId": $("#ColorId").val(),
        "ColorName": $("#txtColor").val(),
    };

    JsonData = JSON.stringify(ratemaster);
    $.ajax({
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        url: '/Setup/UpdateColor',
        data: JsonData,
        async: false,
        cache: false,
        success: function (data) {
            if (data.result == false) {
                $("#lblMessage").html(data.Error);
            }
            alert('Update Successfully.');
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

