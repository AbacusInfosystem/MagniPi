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

        }
    });

    $("#btnShowMembers").click(function (event) {

        Get_Event_Members();

    });

    $("#btnSave").click(function (event) {

        Save_Event_Members();

    });

    $("#hdnEvent_Id").change(function (event) {

        Get_Event_Customers();

        $("#tblEventMember").find("tr:gt(0)").remove();
        $("#btnSave").hide();

    });


});