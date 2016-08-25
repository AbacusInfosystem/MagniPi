$(document).ready(function () {

    InitializeAutoComplete($('#txtEventName'));

    InitializeAutoComplete($('#txtCustomer_Name'));

    Get_Event_Customers();

    $("#btnAdd").click(function (event) {

        Save_Event_Customer();
        Get_Event_Customers();

    });

    $(document).on('ifChanged', '[name="rCust"]', function (event) {
        if ($(this).prop('checked')) {

            $("#hdntempCust_Id").val(this.id);
            $("#btnShowMembers").show();
            $("#btnRemoveCustomer").show();

            $("#hdnCust_Event_Id").val($(this).attr("data-customer"));
            //alert($("#hdnCust_Event_Id").val());

        }
    });

    $("#btnShowMembers").click(function (event) {

        $('#hdfCurrent_Page').val(0);
        //$("#tblEventMember").find("tr:gt(0)").remove();
        $("#tblEventMember").html("");

        Get_Event_Members();

    });

    $("#btnSave").click(function (event) {

        Save_Event_Members();

    });

    $("#hdnEvent_Id").change(function (event) {

        Get_Event_Customers();

        //$("#tblEventMember").find("tr:gt(0)").remove();
        $("#tblEventMember").html("");
        $('#dvScroll').removeClass('scroll-bar');
        $("#btnSave").hide();

    });

    //$('#dvScroll').scroll(function () {

    //    if ($(this).scrollTop() == 1) {

    //        $('#loading').show();
    //        Get_Event_Members();

    //    }
    //});

    $('#dvScroll').scroll(function () {
        //if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
        if ($(this).scrollTop() == 1) { 
            if (parseInt($("#hdfTotal_Pages").val()) > parseInt($("#hdfCurrent_Page").val())) {

                $('#loading').show();
                Get_Event_Members();
            }

        }
    });

    $("#btnRemoveCustomer").click(function (event) {

        Remove_Event_Customer();
        
    });


});