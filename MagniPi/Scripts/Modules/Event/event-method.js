function Save_Event_Date()
{

var eViewModel =
        {
            Event:
                {
                    event_date: {

                        Event_Date_Id: $('#hdnEvent_Date_Id').val(),

                        Event_Id: $('#hdnEvent_Id').val(),

                        Date: $('#txtDate').val(),

                        Start_Time: $('#txtStartTime').val(),

                        End_Time: $('#txtEndTime').val(),

                        Is_Active: $('#hdnIs_Active1').val(),

                    }

                }
        }

    if ($("#frmEventDate").valid())
    {
        CallAjax("/event/save-event-date/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Event_Date_CallBack, "", null);
    }

}

function Event_Date_CallBack(data) {

    Reset_Event_Date();

    $("#btnEditDate").hide();
    $("#AddEventDateModal").modal('hide');

    Friendly_Message(data);

}

function Reset_Event_Date() {
    
    $('#hdnEvent_Date_Id').val("");

    $('#txtDate').val("");

    $('#txtStartTime').val("");

    $('#txtEndTime').val("");

    $('#hdnIs_Active1').val("");
    $("#chkIsActive1").iCheck('uncheck');

}

function Get_Event_Date()
{
    var eViewModel =
       {
           Event:
               {
                   event_date: {

                       Event_Date_Id: $('#hdnEvent_Date_Id').val(),

                       Event_Id: $('#hdnEvent_Id').val(),

                   }
               },
       }

    CallAjax("/event/get-event-date-by-id/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Set_Event_Date_Values, "", null);
}

function Set_Event_Date_Values(data)
{
    $('#hdnEvent_Date_Id').val(data.Event.event_date.Event_Date_Id);

    var date = ToJavaScriptDate(data.Event.event_date.Date);
    var values = date.split("/");
    var newDate = values[1] + "/" + values[0] + "/" + values[2];

    $('#txtDate').val(newDate);

    $('#txtStartTime').val(data.Event.event_date.Start_Time);

    $('#txtEndTime').val(data.Event.event_date.End_Time);

    $('#hdnIs_Active1').val(data.Event.event_date.Is_Active);
    
    if (data.Event.event_date.Is_Active) {
        
        $("#chkIsActive1").iCheck('check');
    }
    else {
        $("#chkIsActive1").iCheck('uncheck');
    }
    alert($('#hdnIs_Active1').val());

}

function Get_Event_Dates() {

    var eViewModel =
        {
            Event:
                {
                    Event_Id: $("#hdnEvent_Id").val(),
                },

            Pager:
                {
                    CurrentPage: $('#hdfCurrent_Page').val(),
                },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/event/get-event-dates-by-event-id/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Event_Date_Grid, "", null);

}

function Bind_Event_Date_Grid(data) {

    var htmlText = "";

    if (data.Event.Event_Dates.length > 0) {

        for (i = 0; i < data.Event.Event_Dates.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='" + data.Event.Event_Dates[i].Event_Date_Id + "' class='iradio-list' />";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += ToJavaScriptDate(data.Event.Event_Dates[i].Date);

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Event.Event_Dates[i].Start_Time;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Event.Event_Dates[i].End_Time;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Event.Event_Dates[i].Is_Active == true ? "Yes" : "No";

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='7'> No Record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblEventDates").find("tr:gt(0)").remove();

    $('#tblEventDates tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });


    if (data.Event.Event_Dates.length > 0) {
        $('#hdfCurrent_Page').val(data.Pager.CurrentPage);

        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else {
        $('.pagination').html("");
    }

    Friendly_Message(data);

    $("#divSearchGridOverlay").hide();

    $("#btnEditDate").hide();

}

function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdfCurrent_Page').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    Bind_Event_Dates();
}