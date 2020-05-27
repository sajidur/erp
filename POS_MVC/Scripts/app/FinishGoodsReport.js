$(document).ready(function () {
  //  LoadSupplierCombo("ddlSupplier");
   // LoadAllWareHouse("ddlWarehouse");
    GetDataTable();

});

function GetDataTable() {
    $('#inventoryPaddyReportTableModal').DataTable({
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
            "url": "/Inventory/GetAllInventory",
            "dataSrc": function (json) {
                return json;
            }
        },
        "columns": [
            { "data": "Product.ProductType" },
            { "data": "Product.Category.CategoryName" },
            { "data": "Product.ProductName" },
            { "data": "Brand.BrandName","defaultContent": ""  },
            { "data": "API.APIName", "defaultContent": ""  },
            { "data": "Size.Name", "defaultContent": ""  },
            { "data": "WareHouse.WareHouseName" },
            { "data": "OpeningQty", "defaultContent": "0" },
            { "data": "ReceiveQty", "defaultContent": "0" },
            { "data": "ProductionOut", "defaultContent": "0" },
            { "data": "ProductionIn", "defaultContent": "0" },
            { "data": "ReturnQty", "defaultContent": "0" },
            { "data": "SalesQty", "defaultContent": "0"},
            { "data": "Faulty", "defaultContent": "0" },
            { "data": "BalanceQty", "defaultContent": "0" }
        ],

        "bDestroy": true,
        "dom": 'Bfrtip',
        "buttons": [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });
}

function GetDataForSupplier() {
    console.log($("#ddlSupplier option:selected").val());
    if ($("#ddlSupplier option:selected").val() == '') {
        GetDataTable();
    }
    else {
        GetDataTableForSupplier();
    }

}

function GetDataForWarehouse() {
    console.log($("#ddlWarehouse option:selected").val());
    if ($("#ddlWarehouse option:selected").val() == '') {
        GetDataTable();
    }
    else {
        GetDataTableForWarehouse();
    }

}

function GetDataTableForSupplier() {
    $('#inventoryPaddyReportTableModal').DataTable({
        "ajax": {
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "type": "POST",
            "url": "/Inventory/GetAllFinishGoodsFilteredBySupplier?id=" + $("#ddlSupplier option:selected").val(),
            "dataSrc": function (json) {
                console.log(json);
                return json;
            }
        },
        "columns": [
            { "data": "Product.ProductName" },
            { "data": "WareHouse.WareHouseName" },
            { "data": "BalanceQty" },
            { "data": "QtyInBale" },
            { "data": "BalanceQtyInKG" }

        ],
        "bDestroy": true,
        "dom": 'Bfrtip',
        "buttons": [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });
}

function GetDataTableForWarehouse() {
    $('#inventoryPaddyReportTableModal').DataTable({
        "ajax": {
            "dataType": 'json',
            "contentType": "application/json; charset=utf-8",
            "type": "POST",
            "url": "/Inventory/GetAllFinishGoodsFilteredByWarehouse?id=" + $("#ddlWarehouse option:selected").val(),
            "dataSrc": function (json) {
                console.log(json);
                return json;
            }
        },
        "columns": [
            { "data": "Product.ProductName" },
            { "data": "WareHouse.WareHouseName" },
            { "data": "BalanceQty" },
            { "data": "QtyInBale" },
            { "data": "BalanceQtyInKG" }

        ],
        "bDestroy": true,
        "dom": 'Bfrtip',
        "buttons": [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });
}