$(document).ready(function () {

    $("#btnSave").click(function (event) {

        $('#frmAddEditTestimonial').attr("action", "/testimonial/save-testimonial");
        $('#frmAddEditTestimonial').attr("method", "POST");
        $('#frmAddEditTestimonial').submit();

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