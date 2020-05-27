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
    return object;
}

function ResetForm() {
    $('#txtBrandName').val('');
}
function BrandSave() {
    //debugger;
    if ($("#txtBrandName").val() == "") {
        alert('Brand Name Empty');
        return false;
    }
    $.ajax({
        url: '/Brand/Create',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            BrandName: $('#txtBrandName').val(),
            BrandNameInBangla: $('#txtDescriptions').val(),
            create: 1
        },
        success: function (data) {
            ShowNotification("1", "Brand Saved!!");
            ResetForm();
            LoadBrandGrid();
        },
        error: function () {

        }
    });

}
