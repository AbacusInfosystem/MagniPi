$(document).ready(function () {

    $("#btnSave").click(function (event) {
       
        if ($("#frmUploadFile").valid()) {

            $('#frmUploadFile').attr("action", "/upload-file/save-file");
            $('#frmUploadFile').attr("method", "POST");
            $('#frmUploadFile').submit();
        }

    });

    $('[name="r1"]').on('ifChecked', function (event) {

        $("#hdnAttachmentId").val(this.id);

        var UniqueName = $("#Unique_" + this.id).text();
        var Type = $("#Type_" + this.id).text();

        $("#hdnUnique_Id").val(Type + "\\" + UniqueName);
        
        $("#btnView").show();
        $("#btnDelete").show();
        
    });

    $("#btnView").click(function (event) {

        $.ajax({
            type: "POST",
            url: '/upload-file/view-attachment',
            data: { Attachment_Id: $("#hdnAttachmentId").val()},
            success: function (attachment) {

                $("#imgName").text(attachment.File_Name);
                $("#imgPreview").attr("src", attachment.Unique_Id);
                $("#ViewImageModal").modal("show");

            }
        });

    });

    $("#btnDelete").click(function (event) {

        $("#frmUploadFile").validate().cancelSubmit = true;

        $('#frmUploadFile').attr("action", "/upload-file/delete-attachment");
        $('#frmUploadFile').attr("method", "POST");
        $('#frmUploadFile').submit();

    });


});

function PageMore(Id)
{

    $("#hdfCurrentPage").val(parseInt(Id) - 1);

    $("#frmUploadFile").validate().cancelSubmit = true;

    $('#frmUploadFile').attr("action", '/upload-file/index');
    $('#frmUploadFile').attr("method", "POST");
    $('#frmUploadFile').submit();
}

