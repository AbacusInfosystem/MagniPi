$(document).ready(function () {

    $("#txtMonth").datepicker(
        {
            format: "mm-yyyy",
            viewMode: "months", 
            minViewMode: "months",
            autoclose: true,
        });


    Search_Blogs();

    $("#btnSearch").click(function (event) {

        //$("#txtMonth").rules("add", { DatePattern: true });

        //if ($("#frmUploadFile").valid()) {

            Search_Blogs();
        //}
        
    });


    $("#btnEdit").click(function (event) {

        $("#frmBlogListing").attr("target", "_self");

        $('#frmBlogListing').attr("action", "/blog/get-blog-by-id");
        $('#frmBlogListing').attr("method", "POST");
        $('#frmBlogListing').submit();

    });

    $("#btnPreview").click(function (event) {

        $("#frmBlogListing").attr("target", "_blank");

        $('#frmBlogListing').attr("action", "/home/view-blog-details-by-id");
        $('#frmBlogListing').attr("method", "POST");
        $('#frmBlogListing').submit();

    });


    //validation

    //jQuery.validator.addMethod("DatePattern", function (value, element) {

    //    if (value != "") {

    //        return validateDatePattern(value, element);
    //    }
    //    else {

    //        return true;
    //    }

    //}, "Enter valid month.");

    //function validateDatePattern(value, element) {
    //    var result = true;
    //    if ($('#' + element.id).val() != "") {
    //        var reg = new RegExp("^(1|2|3|4|5|6|7|8|9|01|02|03|04|05|06|07|08|09|10|11|12)-([0-9]{4}|[0-9]{2})$");
    //        if (!reg.test($('#' + element.id).val())) {
    //            result = false;
    //        }
    //    }
    //    return result;
    //}


});