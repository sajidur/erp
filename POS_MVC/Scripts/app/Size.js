
$(document).ready(function () {
    LoadSizeGrid();

});

function LoadSizeGrid() {
    var url = '/SizeSetup/GetAll';

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

function LoadAllCombo() {
    GetAllActiveLine("ddllineNumber", true);
}

function FormDataAsObject() {
    var object = new Object();
    object.BrandName = $('#txtBrandName').val();
    object.BrandNameInBangla = $('#txtBrandNameBang').val();
    return object;
}

function ResetForm() {
    $('#txtBrandName').val('');
    $('#txtBrandNameBang').val('');
}


function FormDataAsObject() {
    var object = new Object();
    object.Name = $('#txtSizeName').val();
    return object;
}

function Save() {
    if ($("#txtSizeName").val() == "") {
        alert('SizeName Is Empty.');
        return false;
    }
    var formObject = FormDataAsObject();

    $.ajax({
        url: '/SizeSetup/Create',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            Id: formObject.Id,
            Name: $('#txtSizeName').val(),
            create: 1
        },
        success: function (data) {
            ShowNotification("1", "Size Saved!!")
            ClearAddBox();
            LoadDesignList();
        },
        error: function () {

        }
    });

}


function Update() {
    var formObject = FormDataAsObject();

    if (productGroupInfoValidation(formObject)) {


        $.ajax({
            url: '@Url.Action("CreateOrUpdate", "ProductGroup")',
            method: 'post',
            dataType: 'json',
            async: false,
            data: {
                GroupId: formObject.GroupId,
                GroupName: formObject.GroupName,
                GroupDescription: formObject.GroupDescription,
                LineNumber: formObject.LineNumber,
                create: 2,
            },
            success: function (data) {
                var vmMsg = data;
                if (vmMsg.MessageType == 1) {
                    ShowNotification(1, vmMsg.ReturnMessage);
                    ResetForm();
                    LoadProductGroupGrid();
                    GenerateProductGroupId();

                } else {
                    ShowNotification(3, vmMsg.ReturnMessage);
                    // HideLoader();
                }
            },
            error: function () {
                //HideLoader();
            }
        });
    }
}

function Delete() {
    var formObject = FormDataAsObject();

    $.ajax({
        url: '@Url.Action("Delete", "ProductGroup")',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            GroupId: formObject.GroupId,
            GroupName: formObject.GroupName,
            GroupDescription: formObject.GroupDescription,
            LineNumber: formObject.LineNumber,
        },
        success: function (data) {
            var vmMsg = data;
            if (vmMsg.MessageType == 1) {
                ShowNotification(1, vmMsg.ReturnMessage);
                ResetForm();
                LoadProductGroupGrid();
                GenerateProductGroupId();
                //$('#BtnSave').prop('disabled', true);
                //HideLoader();
            } else {
                ShowNotification(3, vmMsg.ReturnMessage);
                // HideLoader();
            }
        },
        error: function () {
            //HideLoader();
        }
    });

}