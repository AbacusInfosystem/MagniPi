$(document).ready(function () {

    $("#txtMonth").datepicker(
        {
            format: "mm-yyyy",
            viewMode: "months",
            minViewMode: "months",
            autoclose: true,
        });


    Search_Events();

    $("#btnSearch").click(function (event) {

        Search_Events();
       
    });

    $(document).on('ifChanged', '[name="r1"]', function (event) {
        if ($(this).prop('checked')) {

            $("#hdnEvent_Id").val(this.id);
            $("#btnEdit").show();
            $("#btnSubscribe").show();
            $("#btnAttendance").show();
            
        }
    });

    $("#btnEdit").click(function (event) {

        $('#frmEventListing').attr("action", "/event/get-event-by-id");
        $('#frmEventListing').attr("method", "POST");
        $('#frmEventListing').submit();

    });


    $("#btnSubscribe").click(function (event) {

        $('#frmEventListing').attr("action", "/event/subscribe-event-details");
        $('#frmEventListing').attr("method", "POST");
        $('#frmEventListing').submit();

    });

    $("#btnAttendance").click(function (event) {

        $('#frmEventListing').attr("action", "/event/get-event-attenance-details");
        $('#frmEventListing').attr("method", "POST");
        $('#frmEventListing').submit();

    });



});