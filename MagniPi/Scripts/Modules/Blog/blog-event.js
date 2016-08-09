$(document).ready(function () {

    $("#btnSave").click(function (event) {

        //if ($("#frmAddEditBlog").valid()) {

            $('#frmAddEditBlog').attr("action", "/blog/save-blog");
            $('#frmAddEditBlog').attr("method", "POST");
            $('#frmAddEditBlog').submit();
        //}

    });

    $("#BtnBrowse").click(function (event) {

        Bind_Images();

    });

    $('[name="chkIs_Active"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });
    
});