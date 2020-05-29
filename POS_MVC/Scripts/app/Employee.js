
function LoadEmployeeList() {
    var url = '/Employee/GetAll';
    $.ajax({
        url: url,
        method: 'POST',
        success: function (res) {
            var templateWithData = Mustache.to_html($("#templateEmployeeGroupModal").html(), { EmployeeGroupSearch: res });
            $("#div-employeeGroup").empty().html(templateWithData);
            MakePagination('employeeGroupTableModal');
        },
        error: function (error, r) {
            ShowNotification("3", "Something Wrong!!");
        }
    });
}
function LoadEmployeeCombo(controlId) {
    var url = '/Employee/GetAll';
    $.ajax({
        url: url,
        method: 'POST',
        success: function (res) {
            var data = res;
            //alert('Success');
            $("#" + controlId).empty();
            $("#" + controlId).get(0).options.length = 0;
            if (true) {
                $("#" + controlId).get(0).options[0] = new Option("-Select-", "0");
            }
            if (data != null) {
                $.each(data, function (index, item) {
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Code + '-' + item.FirstName, item.Id);
                });
            }
            $("#" + controlId).chosen({ no_results_text: "Oops, nothing found!" });
        },
        error: function (error, r) {
            ShowNotification("3", "Something Wrong!!");
        }
    });
}
function LoadSalesMan(controlId) {
    var url = '/Employee/GetAllByDesignation';
    $.ajax({
        url: url,
        method: 'GET',
        data: {'designationId':'1'},
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
                    $("#" + controlId).get(0).options[$("#" + controlId).get(0).options.length] = new Option(item.Code + '-' + item.FirstName, item.Id);
                });
            }
            $("#" + controlId).chosen({ no_results_text: "Oops, nothing found!" });
        },
        error: function (error, r) {
            ShowNotification("3", "Something Wrong!!");
        }
    });
}

function LoadForEdit(parameters) {
    $("#btnSave").hide();
    $("#btnUpdate").show();
    $("#btnDelete").show();

    LoadSingleData(parameters);
}

function LoadSingleData(parameters) {
    $.ajax({
        url: '/Employee/Details',
        data: { 'id': parameters },
        success: function (data) {
            $("#hdId").val(data.Id);
            $("#txtCode").val(data.Code);
            $('#txtDesignation').val(data.Designation);
            $("#txtFirstName").val(data.FirstName);
            $("#txtLastName").val(data.LastName);
            $("#txtFatherName").val(data.FatherName);
            $("#txtMotherName").val(data.MotherName);
            $("#txtAddress").val(data.Address);
            $("#txtCity").val(data.City);
            $("#txtPhone").val(data.Phone);
            $("#txtEmail").val(data.Email);
            $("#txtZipCode").val(data.ZipCode);
            $('#txtSalary').val(data.Salary);
            $("#txtRemarks").val(data.Remarks);

        },
        error: function () {
            alert('An error occured try again later');
        }
    });
}

function Save() {
    if ($("#txtCode").val() == "") {
        alert('Emloyee Code can not be empty.');
        return false;
    }
    var object = new Object();  
    object.Code = $('#txtCode').val();
    object.Designation = $('#txtDesignation').val();
    object.FirstName = $('#txtFirstName').val();
    object.LastName = $('#txtLastName').val();
    object.FatherName = $('#txtFatherName').val();
    object.MotherName = $('#txtMotherName').val();
    object.Address = $('#txtAddress').val();
    object.City = $('#txtCity').val();
    object.Phone = $('#txtPhone').val();
    object.Email = $('#txtEmail').val();
    object.ZipCode = $('#txtZipCode').val();
    object.DepartmentID = $("#txtDepartment option:selected").val();
    object.DesignationId = $("#txtDesignation option:selected").val();
    object.DOB = $('#txtDOB').val();
    object.JoiningDate = $('#txtJoiningDate').val();
    object.TerminationDate = $('#txtTerminationDate').val();
    object.Qualification = $('#txtQualification').val();
    object.BloodGroup = $('#ddlBloodGroup option:selected').val();
    object.SalaryPackage = $('#ddlSalaryPackage option:selected').val();
    object.EmployeeType = $('#ddlEmployeeType option:selected').val();
    object.SalaryType = $('#ddlSalaryType option:selected').val();    
    object.Gender = $('#ddlGender option:selected').val();    
    object.ShiftId = $('#ddlShift option:selected').val();
    object.Salary = $('#txtSalary').val();
    object.Remarks = $('#txtRemarks').val();
    object.Photo = photoContent;
    object.MimeType = MimeType;
    $.ajax({
        url: '/Employee/Create',
        method: 'post',
        dataType: 'json',
        async: false,
        data: {
            request: object
        },
        success: function (data) {
            $("#hdId").val(data.Id);
            ShowNotification("1", "Employee Saved!!");
            location.reload();            
        },
        error: function () {
            ShowNotification("3", "Something Wrong!!");
        }
    });
    
}

$("#btnUpdate").click(function () {
    if ($("#txtCode").val() == "") {
        alert('Emloyee Code can not be empty.');
        return false;
    }
    var object = new Object();
    object.Id = $('#hdId').val();
    object.Code = $('#txtCode').val();
    object.Designation = $('#txtDesignation').val();
    object.FirstName = $('#txtFirstName').val();
    object.LastName = $('#txtLastName').val();
    object.FatherName = $('#txtFatherName').val();
    object.MotherName = $('#txtMotherName').val();
    object.Address = $('#txtAddress').val();
    object.City = $('#txtCity').val();
    object.Phone = $('#txtPhone').val();
    object.Email = $('#txtEmail').val();
    object.ZipCode = $('#txtZipCode').val();
    object.Salary = $('#txtSalary').val();
    object.Remarks = $('#txtRemarks').val();
    var file = $('#photoEmployeePhoto').get(0).files;
    var data = new FormData;
    data.append("ImageFile", file[0]);
    object.imageView = data;
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Employee/Edit',        
        data: {
            model: object,
            create: 1
        },
        async: false,
        success: function (data) {
            ShowNotification("1", "Employee Updated!!");
            LoadEmployeeList();
            $("#btnSave").show();
            $("#btnDelete").show();
            $("#btnUpdate").show();

            ResetForm();
            
        },
        error: function () {
            ShowNotification("3", "Something Wrong!!");
        }
    });
});

$("#btnDelete").click(function (e) {
    $.ajax({
        type: 'POST',
        url: '/Employee/Delete',
        dataType: 'json',
        data: {
            Id: $("#hdId").val(),
            create: 1
        },
        async: false,
        success: function (data) {
            ShowNotification("1", "Employee Deleted!!");
            LoadEmployeeList();
            $("#btnSave").show();
            $("#btnDelete").show();
            $("#btnUpdate").show();

            ResetForm();
        },
        error: function () {
            ShowNotification("3", "Something Wrong!!");
        }
    });
});

function ResetForm() {
    $('#txtCode').val("");
    $('#txtDesignation').val("");
    $('#txtFirstName').val("");
    $('#txtLastName').val("");
    $('#txtFatherName').val("");
    $('#txtMotherName').val("");
    $('#txtAddress').val("");
    $('#txtCity').val("");
    $('#txtPhone').val("");
    $('#txtEmail').val("");
    $('#txtZipCode').val("");
    $('#txtSalary').val("");
    $('#photoEmployeePhoto').val("");
    $('#txtRemarks').val("");
}

function FormDataAsObject() {
    var object = new Object();
    object.Code = $('#txtCode').val();
    object.Salary = $('#txtDesignation').val();
    object.FirstName = $('#txtFirstName').val();
    object.LastName = $('#txtLastName').val();
    object.FatherName = $('#txtFatherName').val();
    object.MotherName = $('#txtMotherName').val();
    object.Address = $('#txtAddress').val();
    object.City = $('#txtCity').val();
    object.Phone = $('#txtPhone').val();
    object.Email = $('#txtEmail').val();
    object.ZipCode = $('#txtZipCode').val();
    object.Salary = $('#txtSalary').val();
    object.Photo = photoContent;
    return object;
}

function UploadImage() {
    var file = $('#photoEmployeePhoto').get(0).files;
    var data = new FormData;
    data.append("EmpId", $("#hdId").val());
    data.append("ImageFile", file[0]);
    $.ajax({
        url: '/Employee/ImageUpload',
        method: 'post',
        data: data,
        contentType : false,
        processData : false,
        success: function (imgId) {
            ShowNotification("1", "Employee Deleted!!");
        },
        error: function () {
            ShowNotification("3", "Something Wrong!!");
        }
    });
}