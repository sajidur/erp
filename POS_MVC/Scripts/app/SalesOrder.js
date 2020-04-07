var detailsSalesOrder = [];
var inventoryList = [];
$(document).ready(function () {
    LoadInvoiceNo("txtPoNo");
    LoadCustomerCombo("ddlCustomer");
    LoadProductList();
    Expression();
});

function Expression() {
    var BaleWight = $("#txtBaleWeight");
    BaleWight.keyup(function () {
        CalculationFirst();
    });
}
function CalculationFirst() {
    var BaleQty = $("#txtBaleQty").val();
    var BaleWight = $("#txtBaleWeight").val();
    var totalKG = parseFloat(BaleQty * BaleWight);
    var Mon = parseFloat(totalKG / 40);
    $("txtWeightInMon").html(Mon.toFixed(2));
}

function Calculation() {
    var totalBaleQty = 0;
    var totalQtyKG = 0
    var totalAmount = 0;
    for (var i = 0; i < detailsSalesOrder.length; i++) {
        totalBaleQty += detailsSalesOrder[i].BaleQty;
        totalQtyKG += detailsSalesOrder[i].TotalQtyInKG;
        totalAmount += detailsSalesOrder[i].Amount;
    }
    
    $("#lblTotalQty").html(totalBaleQty);
    $("#lblTotalAmount").html(totalAmount);
}
function LoadInvoiceNo(controlId) {
    var url = "/Sales/GetInvoiceNumberSalesOrder";
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

function LoadProductList() {
    var url = '/Sales/GetAllInventoryforSales';
    $.ajax({
        url: url,
        method: 'POST',
        success: function (res) {
            inventoryList = res;
            var templateWithData = Mustache.to_html($("#templateSalesOrderGroupModal").html(), { SalesOrderGroupSearch: res });
            $("#div-salesOrderGroup").empty().html(templateWithData);
            MakePagination('salesOrderGroupTableModal');
        },
        error: function (error, r) {
            ShowNotification("3", "Something Wrong!!");
        }
    });
}

var count = 0;
function LoadForAdd(parameters) {
    count++;
    var WareHouse = "";
    var Qty = '0';
    var ProductId = '0';
    $('#salesOrderGroupTableModal tr').each(function (i) {
        if ($(this).find('td').eq(0).text() == parameters) {
            Qty = $(this).find('td').eq(7).find('input').val();
        }
    });
    var newArray = inventoryList.filter(function (el) {
        if (el.Id == parameters) {
            return el;
        }
    });
    var salesOrder = {
        Inventory:newArray[0],
        Qty: Qty,
        Count: count,
        
    }
    //var object = {
    //    Count: count,
    //    ProductName: newArray.Product.ProductName,
    //    InventoryId: newArray.Id,
    //    SizeId: newArray.SizeId,
    //    BrandId: newArray.BrandId,
    //    Qty: Qty,
    //    SizeName: newArray.Size.Name,
    //    BrandName: newArray.Brand.BrandName,
    //    WareHouse: WareHouse
    //};
    detailsSalesOrder.push(salesOrder);
    var templateWithData = Mustache.to_html($("#templateSalesOrderGroupModalGrid").html(), { SalesOrderGroupSearchGrid: detailsSalesOrder });
    $("#div-salesOrderGroupGrid").empty().html(templateWithData);
    Calculation();
}


function Save() {
    var url = '/Sales/SaveSalesOrder';
    $("#btnSave").prop("disabled", true);
    $.ajax({
        url: url,
        method: 'POST',
        data: {
            salesOrders: detailsSalesOrder,
            Notes: $("#txtDescriptions").val(),
            CustomerID: $("#ddlCustomer option:selected").val(),
            SalesOrderId:$("#txtPoNo").val(),
            isSendSMS: $('#chkSendSMS').is(':checked')
        },
        success: function (data) {
            setTimeout(location.reload.bind(location), 10000);
            ShowNotification("1", "Sales Order Saved!!");
            detailsSalesOrder=[];
            var templateWithData = Mustache.to_html($("#templateSalesOrderGroupModalGrid").html(), { SalesOrderGroupSearchGrid: detailsSalesOrder });
            $("#div-salesOrderGroupGrid").empty().html(templateWithData);
        },
        error: function () {
        }
    });

}
function OnDeleteSalesOrder(Id) {
    for (var i = 0; i < detailsSalesOrder.length; i++) {
        if (detailsSalesOrder[i].countCount == Id) {
            detailsSalesOrder.splice(i, 1);
        }
    }
    var templateWithData = Mustache.to_html($("#templateSalesOrderGroupModalGrid").html(), { SalesOrderGroupSearchGrid: detailsSalesOrder });
    $("#div-salesOrderGroupGrid").empty().html(templateWithData);
    Calculation();
}