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
        //$("#tblEventMemberAttendance").find("tr:gt(0)").remove();
        $("#tblEventMemberAttendance").html("");
        
        console.log($("#tblEventMemberAttendance").html());
        Get_Event_Members_Attendance();


    });

    $("#hdnEvent_Id").change(function (event) {

        Get_Event_Customers();

        //$("#tblEventMemberAttendance").find("tr:gt(0)").remove();
        $("#tblEventMemberAttendance").html("");
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
    //$('#dvScroll').scroll(function () {
    
    //	alert($(this).scrollTop());
    //    if ($(this).scrollTop() == 1) {

    //        $('#loading').show();
    //        Get_Event_Members_Attendance();

    //    }
    //});

    
    	//	alert($(this).scrollTop());
    	//    if ($(this).scrollTop() == 1) {

    	//        $('#loading').show();
    	//        Get_Event_Members_Attendance();

    	//    }
    	//});





    $('#dvScroll').scroll(function () {

        //if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
        if ($(this).scrollTop() == 1) {
            if (parseInt($("#hdfTotal_Pages").val()) > parseInt($("#hdfCurrent_Page").val())) {

                //console.log("Total pages : " + $("#hdfTotal_Pages").val());
                //console.log("Current Page : " + $("#hdfCurrent_Page").val());
                $('#loading').show();

                Get_Event_Members_Attendance();
            }
        }

    });
});

