function ResetForm() {
    $('#txtHolidayName').val('');
    $('#ddlYear').val('0');
    $('#ddlMonth').val('0');
    $('#ddlDay').val(0);
    $('#txtStartTime').val('');
    $('#txtDuration').val('');
    $('#txtHolidayType').val('');
}
function SaveHoliday() {
    $.ajax({
        url: '/Holidays/Create',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            
            HOLIDAYNAME: $('#txtHolidayName').val(),
            HOLIDAYYEAR: $('#ddlYear').val(),
            HOLIDAYMONTH: $('#ddlMonth').val(),
            HOLIDAYDAY: $('#ddlDay').val(),
            STARTTIME: $('#txtStartTime').val(),
            DURATION: $('#txtDuration').val(),
            HOLIDAYTYPE: $('#txtHolidayType').val(),
            create: 1
        },
        success: function (data) {
            //setTimeout(location.reload.bind(location), 10000);
            //ShowNotification("1", "Ledger Saved!!");
            ResetForm();
            LoadHoliDayList();
        },
        error: function (err) {
            console.log(err);

        }
    });

}

function LoadHoliDayList() {
    var url = '/Holidays/GetAll';
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