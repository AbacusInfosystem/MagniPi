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
        
        $('#hdfCurrent_Page').val(0);
        $("#tblEventMemberAttendance").find("tr:gt(0)").remove();

        Get_Event_Members_Attendance();


    });

    $("#hdnEvent_Id").change(function (event) {

        Get_Event_Customers();

        $("#tblEventMemberAttendance").find("tr:gt(0)").remove();
        $('#dvScroll').removeClass('scroll-bar');
        $("#btnSave").hide();

    });

    $("#btnSave").click(function (event) {

        Save_Event_Member_Attendance();

    });

    //for scrolling
    //var win = $(window);
    
    //win.scroll(function () {
        
    //    if ($(document).height() - win.height() == win.scrollTop()) {

    //        $('#loading').show();

    //        Get_Event_Members_Attendance();

    //    }
    //});

    //$('.scroll-bar').scroll(function () {
    $('#dvScroll').scroll(function () {
    
        if ($(this).scrollTop() == 1) {

            $('#loading').show();
            Get_Event_Members_Attendance();

        }
    });


});

