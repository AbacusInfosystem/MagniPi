$(document).ready(function () {

    $("#txtDate").datepicker({
        autoclose: true,
    });

    $(".timepicker").timepicker({
        
        showInputs: false
    });

   
    Get_Event_Dates();

    $("#btnSave").click(function (event) {

        $('#frmAddEditEvent').attr("action", "/event/save-event");
        $('#frmAddEditEvent').attr("method", "POST");
        $('#frmAddEditEvent').submit();

    });

    $("#btnAddDate").click(function (event) {
        
        Reset_Event_Date();
        $("#AddEventDateModal").modal('show');

    });

    $("#btnSaveDate").click(function (event) {

        Save_Event_Date();

        Get_Event_Dates();
    });

    $("#btnEditDate").click(function (event) {

        Get_Event_Date();

        $("#AddEventDateModal").modal('show');

    });

    $('[name="chkIs_Active"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

    $('[name="chkIs_Stoped"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Stoped").val(true);
        }
        else {
            $("#hdnIs_Stoped").val(false);
        }
    });

    $('[name="chkIs_Active1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active1").val(true);
        }
        else {
            $("#hdnIs_Active1").val(false);
        }
    });

    $(document).on('ifChanged', '[name="r1"]', function (event) {
        if ($(this).prop('checked')) {

            $("#hdnEvent_Date_Id").val(this.id);
            $("#btnEditDate").show();

        }
    });

    $("#BtnBrowse").click(function (event) {
       
        Bind_Images();

    });


});