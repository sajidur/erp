﻿var details = [];
var detailsExpense = [];
function Calculation()
{
    var qty = $("#txtQty").val();
    var amount = $("#txtAmount").val();
    if (qty=='') {
        qty = 0;
    }
    if (amount == '') {
        amount = 0;
    }
    var totalAmount = parseFloat(qty * amount);
    $("#txtTotalAmount").val(totalAmount.toFixed(2));
}

function CalculationExpense() {
    var ExpenseRate = $("#txtExpenseRate").val();
    var ExpenseAmount = $("#txtExpenseAmount").val();
    if (ExpenseRate == '') {
        ExpenseRate = 0;
        $("#txtExpenseRate").val('0');
    }
    if (ExpenseAmount == '') {
        ExpenseAmount = 0;
        $("#txtExpenseAmount").val('0');
    }
    var totalExpenseAmount = ExpenseRate * ExpenseAmount;
    $("#txtExpenseTotalAmount").val(totalExpenseAmount);
}

$("#txtAmount").on("propertychange change keyup paste input", function () {
    // do stuff;
    Calculation();
});

$("#txtExpenseRate").on("propertychange change keyup paste input", function () {
    // do stuff;
    CalculationExpense();
});
$("#txtExpenseAmount").on("propertychange change keyup paste input", function () {
    // do stuff;
    CalculationExpense();
});
$("#txtDiscount").on("propertychange change keyup paste input", function () {
    GrandTotal();
});
var countAddedProduct = 1;
$("#btnAdd").click(function () {
    var countAddedProductCount = countAddedProduct++;
    var item = $("#ddlItem option:selected").text();
    var ProductId = $("#ddlItem option:selected").val();
    //var ProductId = 6;
    var WarehouseId = $("#ddlWareHouse option:selected").val();
    //var WarehouseId = 1;
    var sizeId = $("#ddlSize option:selected").val();
    var size = $("#ddlSize option:selected").text();

    var brandId = $("#ddlBrand option:selected").val();
    var brand = $("#ddlBrand option:selected").text();

    var apiId = $("#ddlAPI option:selected").val();
    var api = $("#ddlAPI option:selected").text();

    var qty = $("#txtQty").val();
    var Amount = $("#txtAmount").val();
    var TotalAmount = $("#txtTotalAmount").val();
    if (WarehouseId <= 0) {
        ShowNotification("3", "Select a godown!!");
        return;
    }
    if (ProductId <= 0) {
        ShowNotification("3", "Select a product!!");
        return;
    }
 
    if (Amount <= 0) {
        ShowNotification("3", "amount Emplty!!");
        return;
    }
    //var object = {Id:Id, Item: item, BaleQty: BaleQty, QtyPerBale: QtyPerBale, UnitStyle: UnitStyle, Amount: Amount, TotalKg: TotalKg, TotalQty: TotalQty, TotalAmount: TotalAmount };
    var object = { countAddedProductCount: countAddedProductCount, Id: ProductId, Item: item, ProductId: ProductId, WarehouseId: WarehouseId, SizeId: sizeId, Size: size, BrandId: brandId, Brand: brand, API: api, APIId: apiId, QTY: qty, Amount: Amount, TotalAmount: TotalAmount };
    details.push(object);
    var templateWithData = Mustache.to_html($("#templateProductModalAdd").html(), { ProductSearchAdd: details });
    $("#div-product-add").empty().html(templateWithData);
    CalculateSum();
    GrandTotal();
    $("#txtQty").val("0");
    $("#txtAmount").val("0");
    $("#txtTotalAmount").val("0");
});

var countAddedExpense = 1;
$("#btnAddExpense").click(function () {
    var countAddedExpenseCount = countAddedExpense++;
    var Id = $("#ddlExpenseHead option:selected").val();
    var item = $("#ddlExpenseHead option:selected").text();
    var ledgerId = $("#ddlExpenseHead option:selected").val();
    var ExpenseRate = $("#txtExpenseRate").val();
    var ExpenseAmount = $("#txtExpenseAmount").val();
    var TotalAmount = ExpenseRate * ExpenseAmount;
    $("#txtExpenseTotalAmount").val(TotalAmount);
    var object = { countAddedExpenseCount: countAddedExpenseCount, Id: Id, Item: item, ExpenseRate: ExpenseRate, ExpenseAmount: ExpenseAmount, TotalAmount: TotalAmount, Debit: TotalAmount, LedgerId: ledgerId };
    detailsExpense.push(object);
    //expense box

    var templateWithExpense = Mustache.to_html($("#templateExpenseModalAdd").html(), { ExpenseSearchAdd: detailsExpense });
    $("#div-expense-add").empty().html(templateWithExpense);
    CalculateExpenseSum();
    GrandTotal();
    $("#txtExpenseRate").val("0");
    $("#txtExpenseAmount").val("0");
    $("#txtExpenseTotalAmount").val("0");
});


function CalculateSum()
{
    var TotalAmount = 0.0, TotalQty = 0.0;
    try {

        for (var i = 0; i < details.length; i++) {
            console.log(details[i].QTY);
            TotalAmount += parseFloat(details[i].TotalAmount);
            TotalQty += parseFloat(details[i].QTY);
        }
        $("#lblTotalQty").html(TotalQty.toFixed(2));
        $("#lblTotalAmount").html(TotalAmount.toFixed(2));

    } catch (e) {
        console.log(e);

    }
}

function OnDeleteProduct(productId)
{
    
    for (var i = 0; i < details.length; i++) {
        if (details[i].countAddedProductCount == productId)
        {
            details.splice(i, 1);
        }
    }
    var templateWithData = Mustache.to_html($("#templateProductModalAdd").html(), { ProductSearchAdd: details });
    $("#div-product-add").empty().html(templateWithData);
    CalculateSum();
    GrandTotal();//update Grand Total
}

//Calculate Total of Aditional Expense
function CalculateExpenseSum() {
    var TotalAmount = 0.0;
    try {

        for (var i = 0; i < detailsExpense.length; i++) {
            console.log(detailsExpense[i].TotalAmount);
            TotalAmount += parseFloat(detailsExpense[i].TotalAmount);
            }
        $("#lblTotalExpenseAmount").html(TotalAmount.toFixed(2));

    } catch (e) {
        console.log(e);

    }
}

function OnDeleteExpense(expenseId) {
    for (var i = 0; i < detailsExpense.length; i++) {
        if (detailsExpense[i].countAddedExpenseCount == expenseId) {
            detailsExpense.splice(i, 1);
        }
    }
    var templateWithExpense = Mustache.to_html($("#templateExpenseModalAdd").html(), { ExpenseSearchAdd: detailsExpense });
    $("#div-expense-add").empty().html(templateWithExpense);
    CalculateExpenseSum();// update total aditional expense
    GrandTotal();// update total grand total
}

// Calculating Grand Total
function GrandTotal(){
    try {
        var GTotal = 0.0;
        $("#lblGrandTotal").html(GTotal.toFixed(2));
        var TotalAdded = parseFloat($('#lblTotalAmount').text());
        var TotalExpense = parseFloat($('#lblTotalExpenseAmount').text());
        var discount = $("#txtDiscount").val();
        GTotal = TotalAdded + TotalExpense-discount;
        console.log(GTotal);
        $("#lblGrandTotal").html(GTotal.toFixed(2));
        } catch (e) {
        console.log(e);
    }
}

function GoodReceiveSave()
{
    console.log($("#ddlWareHouse").val());
    var supplierId = $("#ddlSupplier").val();
    var godown = $("#ddlWareHouse").val();
    if (details.length <= 0) {
        ShowNotification("3", "Not added any Item!!");
        return;
    }
    if (supplierId <= 0) {
        ShowNotification("3", "Select a Supplier!!");
        return;
    }
    if (godown <= 0) {
        ShowNotification("3", "select a godown!!");
        return;
    }
    //debugger;
    $("#btnSave").prop("disabled", true);
    var url = '/GoodsReceive/Save';
    $.ajax({
        url: url,
        method: 'POST',
        data: {          
            PONo: $("#txtPoNo").val(),
            totalAmount: $("#lblTotalAmount").text(),
            supplierId: supplierId,
            descriptions: $("#txtDescriptions").val(),
            LcNo: $("#txtLCNo").val(),
            WarehouseId: godown,
            dates: $("#txtDates").val(),
            Discount: $("#txtDiscount").val(),
            response: details,
            additionalCosts: detailsExpense
        },
        success: function (data) {
            //debugger;
            //var GRNo = data.ID;
            //var param = "ReportName=GrChallanReport&GRNo=" + GRNo;
            //window.open("../Report/Viewer/ReportViewer.aspx?" + param, "_blank");
            setTimeout(location.reload.bind(location), 10000);
            ShowNotification("1", "Item Recived Saved!!");
            window.location.href = "/Report/Viewer/ReportViewer.aspx?ReportName=PurchaseInvoice&invoiceId=" + $("#txtPoNo").val();

            //details = [];
            //detailsExpense = [];
            //var templateWithData = Mustache.to_html($("#templateProductModalAdd").html(), { ProductSearchAdd: details });
            //$("#div-product-add").empty().html(templateWithData);
            //var templateWithExpense2 = Mustache.to_html($("#templateExpenseModalAdd").html(), { ExpenseSearchAdd: detailsExpense });
            //$("#div-expense-add").empty().html(templateWithExpense2);
            //LoadInvoiceNo("txtPoNo");
            //location.reload();
        },
        error: function () {
        }
    });
}
function LoadInvoiceNo(controlId) {
    var url = "/GoodsReceive/GetInvoiceNumber";
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

function LoadSupplier(controlId) {
    var url = '/Suppliers/GetAll';
    $.ajax({
        url: url,
        method: 'POST',
        success: function (res) {
            var data = res;
            //alert('Success');
            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (true) {
                $("#" + controlId).get(0).options[0] = new Option("-Select-", "");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option('' + item.Code + '-' + item.Name, item.Id);
                });
            }
            $("#" + controlId).chosen({ no_results_text: "Oops, nothing found!", search_contains: true });
        },
        error: function () {
        }
    });
}
