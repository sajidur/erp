var detailsStockOut = [];
var datatableRowCount = 0;

$(document).ready(function () {
    LoadInvoiceNo("txtPoNo");  
    LoadInventoryList();
    var templateWithData = Mustache.to_html($("#templateStockOutModal").html(), { StockTableAdd: detailsStockOut });
    $("#div-stockOut-add").empty().html(templateWithData);
});


$("#btnAdd").click(function () {
    var msg = '';
    $(this).closest('tr').find('input').each(function () {
        msg += $(this).val() + '\n';
    });
    console.log(msg);
});

function OnDeleteStockOut(Id) {
    for (var i = 0; i < detailsStockOut.length; i++) {
        if (detailsStockOut[i].inventoryCountCount == Id) {
            detailsStockOut.splice(i, 1);
        }
    }
    var templateWithData = Mustache.to_html($("#templateStockOutModal").html(), { StockTableAdd: detailsStockOut });
    $("#div-stockOut-add").empty().html(templateWithData);
}

function GetStockOutReport() {
    $('#salesReportTableModal').DataTable({
        "jQueryUI": true,
        'ordering': true,
        'searching': true,
        'paging': false,
        //'order': [[0, 'desc']],
        'order': [[0, 'asc']],
        "ajax": {
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "type": "POST",
            "url": "/ProductionProcessing/GetAllStockOut",
            "dataSrc": function (json) {
                return json;
            }
        },
        "columns": [
            {
                "data": "ProductionDate",
                'render': function (jsonDate) {
                    var date = new Date(parseInt(jsonDate.substr(6)));
                    var month = date.getMonth() + 1;
                    return month + "/" + date.getDate() + "/" + date.getFullYear();
                }
            },
            { "data": "InvoiceNo" },
            { "data": "Product.ProductName" },
            { "data": "BaleQty" },
            { "data": "WareHouse.WareHouseName" },
            { "data": "Notes" }

        ],

        "bDestroy": true,
        "dom": 'Bfrtip',
        "buttons": [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });
}


function LoadInvoiceNo(controlId) {
    var url = "/ProductionProcessing/GetInvoiceNumber";
    $.ajax({
        url: url,
        method: "POST",
        success: function (res) {
            var data = res;
            console.log(data);
            $("#" + controlId).val(data);
        },
        error: function () {
        }
    });
}


function Save() {
    var url = '/ProductionProcessing/Save';
    $.ajax({
        url: url,
        method: 'POST',
        data: {
            InvoiceNo: $("#txtPoNo").val(),            
            //SupplierId: $("#ddlSupplier option:selected").val(),
            Notes: $("#txtDescriptions").val(),
            stockOuts: detailsStockOut
        },
        success: function (data) {
            ShowNotification("1", "Stock Out Saved!!");
            detailsStockOut = [];
            var templateWithData = Mustache.to_html($("#templateStockOutModal").html(), { StockTableAdd: detailsStockOut });
            $("#div-stockOut-add").empty().html(templateWithData);


            window.location.href = "/Report/Viewer/ReportViewer.aspx?ReportName=StockOutForProcessing&invoiceId=" + $("#txtPoNo").val();
           // window.open("/Report/Viewer/ReportViewer.aspx?ReportName=StockOutForProcessing&invoiceId=" + $("#txtPoNo").val(), "_blank");
        },
        error: function () {
        }
    });

}


function LoadInventoryList() {
    var url = '/Sales/GetAllInventoryforSales';
    $.ajax({
        url: url,
        method: 'POST',
        success: function (res) {
            var templateWithData = Mustache.to_html($("#templateInventoryGroupModal").html(), { InventoryGroupSearch: res });
            $("#div-inventoryGroup").empty().html(templateWithData);
            MakePagination('inventoryGroupTableModal');
        },
        error: function (error, r) {
            console.log(error);
            console.log(r.responseText);
            ShowNotification("3", "Something Wrong!!");
        }
    });
}

var count = 0;
function LoadForAdd(parameters) {
    count++;
    var Id = "0";
    var ProductName = "";
    var SizeName = "";
    var BrandName = "";
    var WareHouse = "";
    var Qty = '0';
    var ProductId = '0';
    $('#inventoryGroupTableModal tr').each(function (i) {
        if ($(this).find('td').eq(0).text() == parameters) {
            Id = $(this).find('td').eq(0).html();
            ProductName = $(this).find('td').eq(1).html();
            SizeName = $(this).find('td').eq(2).html();
            BrandName = $(this).find('td').eq(3).html();
            WareHouse = $(this).find('td').eq(5).html();
            ProductId = Id;
            Qty = $(this).find('td').eq(7).find('input').val();
          }
        });         
            var object = {
                Count: count,
                ProductName: ProductName,
                InventoryId: Id,
                Qty: Qty,
                SizeName: SizeName,
                BrandName: BrandName,
                WareHouse: WareHouse
            };
            detailsStockOut.push(object);
            var templateWithData = Mustache.to_html($("#templateStockOutModal").html(), { StockTableAdd: detailsStockOut });
            $("#div-stockOut-add").empty().html(templateWithData);
}