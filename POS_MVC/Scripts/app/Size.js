

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

function LoadAllSize(controlId) {
    var url = '/SizeSetup/GetAll';

    $.ajax({
        url: url,
        method: 'POST',
        success: function (data) {
            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            $("#" + controlId).get(0).options[0] = new Option("---- Select -----", "");
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Name, item.Id);
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