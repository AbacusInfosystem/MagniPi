$(document).ready(function () {

    InitializeAutoComplete($('#txtEventName'));

    Get_Event_Customers();

    $(document).on('ifChanged', '[name="rCust"]', function (event) {
        if ($(this).prop('checked')) {

            $("#hdntempCust_Id").val(this.id);
            $("#btnViewAttendance").show();

        }
    });

    $("#btnViewAttendance").click(function (event) {

        Get_Event_Members_Attendance();

    });

    $("#hdnEvent_Id").change(function (event) {

        Get_Event_Customers();

        $("#tblEventMemberAttendance").find("tr:gt(0)").remove();
        $("#btnSave").hide();

    });

    $("#btnSave").click(function (event) {

        Save_Event_Member_Attendance();

    });



});