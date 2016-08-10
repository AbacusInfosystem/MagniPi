$(document).ready(function () {

    Search_Services();

    $("#btnSearch").click(function (event) {

        Search_Services();
        
    });

    $("#btnEdit").click(function (event) {

        $("#frmServiceListing").attr("target", "_self");

        $('#frmServiceListing').attr("action", "/service/get-service-by-id");
        $('#frmServiceListing').attr("method", "POST");
        $('#frmServiceListing').submit();

    });

    $("#btnPreview").click(function (event) {

        $("#frmServiceListing").attr("target", "_blank");

        $('#frmServiceListing').attr("action", "/home/view-service-details-by-id");
        $('#frmServiceListing').attr("method", "POST");
        $('#frmServiceListing').submit();

    });


});