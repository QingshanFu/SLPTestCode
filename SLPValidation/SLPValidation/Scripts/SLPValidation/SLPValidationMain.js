$(document).ready(function () {
})

function CreateNewRequest() {
    $("#DIV_NewRequest").dialog({
        modal: true,
        minWidth: 650,
        minHeight: 300,
        open: function (event, ui) {
        }
    });
}

function SelectScannedFile() {
    $("#Input_SelectFile").click();
}

// 处理用户选择的文件
function HandleScannedFile() {
    var filePath = $("#Input_SelectFile").val();
    if (filePath == "") {
        return;
    }

    $("#Input_FilePath").val(filePath);
}

function SubmitNewRequest() {
    if ($('#Input_FilePath').val() == '') {
        alert('Please select scanned file to be uploaded.');
        return;
    }

    if ($('#Input_OPPID').val() == '') {
        alert('Please input the OPPID for the new request.');
        return;
    }

    // 上传用户选择的文件
    var formData = new FormData($("#Form_UploadScannedFile").get(0));
    var uploadedFile = '';
    $.ajax({
        url: '/SLPValidationMain/UploadScannedFile',
        type: 'post',
        cache: false,
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        async: false,
        success: function (data) {
            if (data.Status == 0) {
                uploadedFile = data.Message; // 保存上传后的文件名
            }
            else {
                alert(data.Message);
            }
        },
        error: function () {
            alert('Upload Scanned file fail.');
        }
    });

    if (uploadedFile == '') {
        return;
    }

    // 提交数据 New Request
    $.ajax({
        url: '/SLPValidationMain/SubmitNewRequest',
        data: {
            ScannedFile: uploadedFile,
            OPPID: $('#Input_OPPID').val()
        },
        type: 'post',
        cache: false,
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data == "Success") {
                window.location.reload();
            }
            else {
                alert('Submit SLP validation request fail.');
            }
        },
        error: function () {
            alert('Submit SLP validation request fail.');
        }
    });
}

function CancelNewRequest() {
    $('#DIV_NewRequest').dialog('close');

    $('#Input_OPPID').val('');
    $('#Input_FilePath').val('');
    $('#Input_SelectFile').val('');
}