$(document).ready(function () {

    $("#btnSave").click(function (event) {

        $('#frmUpdateAboutUs').attr("action", "/about-us/save-about-us");
        $('#frmUpdateAboutUs').attr("method", "POST");
        $('#frmUpdateAboutUs').submit();
        
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