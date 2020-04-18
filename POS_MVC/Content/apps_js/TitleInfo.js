﻿$(document).ready(function () {
    var vStatusSaving,//Status Saving data if its new or edit
		vMainGrid,
		vCode;

    function ClearErrorMessage() {
        $('span[class=errormessage]').text('').remove();
    }

    function ReloadGrid() {
        // Clear Search string jqGrid
        //$('input[id*="gs_"]').val("");

        var id = $('#parenttype option:selected').text();
        var value = $('#parenttype').val();

        $("#list").setGridParam({ url: base_url + 'TitleInfo/GetList', postData: { filters: null, ParentId: value }, page: 'first' }).trigger("reloadGrid");
    }

    function ClearData() {
        $('#Description').val('').text('').removeClass('errormessage');
        $('#Name').val('').text('').removeClass('errormessage');
        $('#Code').val('').text('').removeClass('errormessage');
        $('#IsShiftable').val('').text('').removeClass('errormessage');
        $('#IsSalaryAllIn').val('').text('').removeClass('errormessage');
        $('#AccessLevel').val('').text('').removeClass('errormessage');
        $('#form_btn_save').data('kode', '');

        ClearErrorMessage();
    }

    $("#parenttype").live("change", function () {
        ReloadGrid();
    });

    

    //$('#branchofficetype').change(function () {
    //    branchID = $(this).val();
    //    var objList = null;
    //    $.ajax({
    //        dataType: "json",
    //        url: base_url + 'TitleInfo/GetListDepartment?Id=' + branchID,
    //        async: false,
    //        success: function (result) {
    //            objList = result
    //        }
    //    });

    //    var objDropDown = $('#parenttype'); // $(this).parent('td').next().find('select');
    //    $(objDropDown).empty();
    //    //$(objDropDown).unbind("change");
    //    //$(objDropDown).append('<option value="0">--Select Department--</option>');
    //    if (objList != null) {
    //        for (var item in objList) {
    //            $(objDropDown).append('<option value="' + objList[item].Id + '">' + objList[item].Name + '</option>');
    //        }
    //    }
    //    ReloadGrid();
    //});


    $("#form_div").dialog('close');
    $("#delete_confirm_div").dialog('close');
    //$("#lookup_div_companygroup").dialog('close');

    // CheckBox
    function UpdateEnable(objId, isEnabled) {
        //var userId = 0;
        //var id = jQuery("#tbl_users").jqGrid('getGridParam', 'selrow');
        //if (id) {
        //    userId = id;
        //} else {
        //    $.messager.alert('Information', 'Please Select User...!!', 'info');
        //    return;
        //};

        $.ajax({
            contentType: "application/json",
            type: 'POST',
            url: base_url + "TitleInfo/UpdateEnable?isEnabled=" + isEnabled,
            data: JSON.stringify({
                Id: objId
            }),
            success: function (result) {
                if (JSON.stringify(result.Errors) != '{}') {
                    for (var key in result.Errors) {
                        if (key != null && key != undefined && key != 'Generic') {
                            $('input[name=' + key + ']').addClass('errormessage').after('<span class="errormessage">**' + result.Errors[key] + '</span>');
                            $('textarea[name=' + key + ']').addClass('errormessage').after('<span class="errormessage">**' + result.Errors[key] + '</span>');
                        }
                        else {
                            $.messager.alert('Warning', result.Errors[key], 'warning');
                        }
                    }
                }

            }
        });
    }

    $("input[name=cbIsShiftable]").live("click", function () {
        UpdateEnable($(this).attr('rel'), $(this).is(":checked"));
    });

    function cboxIsShiftable(cellvalue, options, rowObject) {
        return '<input name="cbIsEnabled" disabled rel="' + /*rowObject.id*/options.rowId + '" type="checkbox"' + (cellvalue ? ' checked="checked"' : '') +
            '/>';
    }

    function cboxIsSalaryAllIn(cellvalue, options, rowObject) {
        return '<input name="cbIsSalaryAllIn" disabled rel="' + /*rowObject.id*/options.rowId + '" type="checkbox"' + (cellvalue ? ' checked="checked"' : '') +
            '/>';
    }
    // END CheckBox

    //GRID +++++++++++++++
    $("#list").jqGrid({
        url: base_url + 'TitleInfo/GetList',
        postData: { 'ParentId': function () { return $("#parenttype").val(); } },
        datatype: "json",
        colNames: ['ID', 'Code', 'Name', 'Description', 'Shiftable', 'Salary All In', 'Access Level', 'Created At', 'Updated At'],
        colModel: [
    			  { name: 'id', index: 'id', width: 80, align: "center" },
                  { name: 'code', index: 'code', width: 100 },
				  { name: 'name', index: 'name', width: 180 },
                  { name: 'description', index: 'description', width: 250 },
                  {
                      name: 'isshiftable', index: 'isshiftable', width: 80, align: 'center', search: false,
                      editable: true,
                      edittype: 'checkbox', editoptions: { value: "1:0" },
                      formatter: cboxIsShiftable, formatoptions: { disabled: false }
                  },
                  {
                      name: 'issalaryallin', index: 'issalaryallin', width: 80, align: 'center', search: false,
                      editable: true,
                      edittype: 'checkbox', editoptions: { value: "1:0" },
                      formatter: cboxIsSalaryAllIn, formatoptions: { disabled: false }
                  },
                  { name: 'accesslevel', index: 'accesslevel', width: 100 },
				  { name: 'createdat', index: 'createdat', search: false, width: 100, align: "center", formatter: 'date', formatoptions: { srcformat: 'Y-m-d', newformat: 'm/d/Y' } },
				  { name: 'updatedat', index: 'updatedat', search: false, width: 100, align: "center", formatter: 'date', formatoptions: { srcformat: 'Y-m-d', newformat: 'm/d/Y' } },
        ],
        page: '1',
        pager: $('#pager'),
        rowNum: 20,
        rowList: [20, 30, 60],
        sortname: 'id',
        viewrecords: true,
        scrollrows: true,
        shrinkToFit: false,
        sortorder: "DESC",
        width: $("#toolbar").width(),
        height: $(window).height() - 200,
        ondblClickRow: function (rowid) {
            $("#btn_edit").trigger("click");
            //var row_id = $("#list").getGridParam('selrow');
            //jQuery(this).jqGrid('editGridRow', rowid//,
            //                    //{recreateForm:true, closeAfterEdit:true,
            //                    //closeOnEscape: true, reloadAfterSubmit: false}
            //                    );
        },
        gridComplete:
		  function () {
		      //var ids = $(this).jqGrid('getDataIDs');
		      //for (var i = 0; i < ids.length; i++) {
		      //    var cl = ids[i];
		      //    rowDel = $(this).getRowData(cl).deletedimg;
		      //    if (rowDel == 'true') {
		      //        img = "<img src ='" + base_url + "content/assets/images/remove.png' title='Data has been deleted !' width='16px' height='16px'>";

		      //    } else {
		      //        img = "";
		      //    }
		      //    $(this).jqGrid('setRowData', ids[i], { deletedimg: img });
		      //}
		  }

    });//END GRID
    $("#list").jqGrid('navGrid', '#toolbar_cont', { del: false, add: false, edit: false, search: false })
           .jqGrid('filterToolbar', { stringResult: true, searchOnEnter: true });

    //TOOL BAR BUTTON
    $('#btn_reload').click(function () {
        ReloadGrid();
    });

    $('#btn_print').click(function () {
        window.open(base_url + 'Print_Forms/Printmstbank.aspx');
    });

    $('#btn_add_new').click(function () {
        ClearData();
        clearForm('#frm');
        vStatusSaving = 0; //add data mode	
        $('#form_div').dialog('open');
    });

    $('#btn_edit').click(function () {
        ClearData();
        clearForm("#frm");
        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        if (id) {
            vStatusSaving = 1;//edit data mode
            $.ajax({
                dataType: "json",
                url: base_url + "TitleInfo/GetInfo?Id=" + id,
                success: function (result) {
                    if (result.Id == null) {
                        $.messager.alert('Information', 'Data Not Found...!!', 'info');
                    }
                    else {
                        if (JSON.stringify(result.Errors) != '{}') {
                            var error = '';
                            for (var key in result.Errors) {
                                error = error + "<br>" + key + " " + result.Errors[key];
                            }
                            $.messager.alert('Warning', error, 'warning');
                        }
                        else {
                            $("#form_btn_save").data('kode', id);
                            $('#id').val(result.Id);
                            $('#Code').val(result.Code);
                            $('#Name').val(result.Name);
                            $('#Description').val(result.Description);
                            document.getElementById("IsShiftable").checked = result.IsShiftable;
                            document.getElementById("IsSalaryAllIn").checked = result.IsSalaryAllIn;
                            $('#AccessLevel').numberbox('setValue', result.AccessLevel);
                            $("#form_div").dialog("open");
                        }
                    }
                }
            });
        } else {
            $.messager.alert('Information', 'Please Select Data...!!', 'info');
        }
    });

    $('#btn_del').click(function () {
        clearForm("#frm");

        var id = jQuery("#list").jqGrid('getGridParam', 'selrow');
        if (id) {
            var ret = jQuery("#list").jqGrid('getRowData', id);
            $('#delete_confirm_btn_submit').data('Id', ret.id);
            $("#delete_confirm_div").dialog("open");
        } else {
            $.messager.alert('Information', 'Please Select Data...!!', 'info');
        }
    });

    $('#delete_confirm_btn_cancel').click(function () {
        $('#delete_confirm_btn_submit').val('');
        $("#delete_confirm_div").dialog('close');
    });

    $('#delete_confirm_btn_submit').click(function () {

        $.ajax({
            url: base_url + "TitleInfo/Delete",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({
                Id: $('#delete_confirm_btn_submit').data('Id'),
            }),
            success: function (result) {
                if (JSON.stringify(result.Errors) != '{}') {
                    for (var key in result.Errors) {
                        if (key != null && key != undefined && key != 'Generic') {
                            $('input[name=' + key + ']').addClass('errormessage').after('<span class="errormessage">**' + result.Errors[key] + '</span>');
                            $('textarea[name=' + key + ']').addClass('errormessage').after('<span class="errormessage">**' + result.Errors[key] + '</span>');
                        }
                        else {
                            $.messager.alert('Warning', result.Errors[key], 'warning');
                        }
                    }
                    $("#delete_confirm_div").dialog('close');
                }
                else {
                    ReloadGrid();
                    $("#delete_confirm_div").dialog('close');
                }
            }
        });
    });

    $('#form_btn_cancel').click(function () {
        vStatusSaving = 0;
        clearForm('#frm');
        $("#form_div").dialog('close');
    });

    $("#form_btn_save").click(function () {
        ClearErrorMessage();

        var submitURL = '';
        var id = $("#form_btn_save").data('kode');

        // Update
        if (id != undefined && id != '' && !isNaN(id) && id > 0) {
            submitURL = base_url + 'TitleInfo/Update';
        }
            // Insert
        else {
            submitURL = base_url + 'TitleInfo/Insert';
        }

        $.ajax({
            contentType: "application/json",
            type: 'POST',
            url: submitURL,
            data: JSON.stringify({
                Id: id, Code: $("#Code").val(), Name: $("#Name").val(), Description: $("#Description").val(),
                IsShiftable: document.getElementById("IsShiftable").checked ? 'true' : 'false',
                IsSalaryAllIn: document.getElementById("IsSalaryAllIn").checked ? 'true' : 'false',
                AccessLevel: $("#AccessLevel").numberbox('getValue')
            }),
            async: false,
            cache: false,
            timeout: 30000,
            error: function () {
                return false;
            },
            success: function (result) {
                if (JSON.stringify(result.Errors) != '{}') {
                    for (var key in result.Errors) {
                        if (key != null && key != undefined && key != 'Generic') {
                            $('input[name=' + key + ']').addClass('errormessage').after('<span class="errormessage">**' + result.Errors[key] + '</span>');
                            $('textarea[name=' + key + ']').addClass('errormessage').after('<span class="errormessage">**' + result.Errors[key] + '</span>');
                        }
                        else {
                            $.messager.alert('Warning', result.Errors[key], 'warning');
                        }
                    }
                }
                else {
                    ReloadGrid();
                    $("#form_div").dialog('close')
                }
            }
        });
    });

    function clearForm(form) {

        $(':input', form).each(function () {
            var type = this.type;
            var tag = this.tagName.toLowerCase(); // normalize case
            if (type == 'text' || type == 'password' || tag == 'textarea')
                this.value = "";
            else if (type == 'checkbox' || type == 'radio')
                this.checked = false;
            else if (tag == 'select')
                this.selectedIndex = 0;
        });
    }


    
}); //END DOCUMENT READY