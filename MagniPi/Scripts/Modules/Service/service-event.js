$(document).ready(function () {

    $("#btnSave").click(function (event) {

        $('#frmAddEditService').attr("action", "/service/save-service");
        $('#frmAddEditService').attr("method", "POST");
        $('#frmAddEditService').submit();
        
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