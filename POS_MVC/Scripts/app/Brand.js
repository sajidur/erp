
function GenerateProductGroupId() {
    $.ajax({
        url: '@Url.Action("GenerateProductGroupId", "ProductGroup")',
        type: 'Get',
        async: false,
        success: function (responseData) {
            $("#txtGroupCode").val(responseData);

        },
        error: function () { }
    });
}

function LoadBrandGrid() {
    var url = '/Brand/GetAll';

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
    var url = '/Brand/GetAll';
    $.ajax({
        url: url,
        method: 'POST',
        success: function (data) {
            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.BrandName, item.Id);
                });
            }
            $("#" + controlId).chosen({ no_results_text: "Oops, nothing found!" });

        },
        error: function () {

        }
    });
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
function Save() {
    //debugger;
    if ($("#txtCode").val() == "") {
        alert('Code Name Empty');
        return false;
    }

    if ($("#txtCategoryName").val() == "") {
        alert(' Name Empty');
        return false;
    }

    var formObject = FormDataAsObject();

    $.ajax({
        url: '/Brand/Create',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            Id: formObject.Id,
            BrandName: formObject.BrandName,
            BrandNameInBangla: formObject.BrandNameInBangla,
            create: 1
        },
        success: function (data) {
            ShowNotification("0", "Brand Saved!!")
            ResetForm();
            LoadBrandGrid();
        },
        error: function () {


        }
    });

}