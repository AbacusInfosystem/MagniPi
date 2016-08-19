function Get_Event_Customers() {
    var eViewModel =
        {
            Event:
                {
                    Event_Id: $("#hdnEvent_Id").val(),

                }

        }

    CallAjax("/event/get-customers-by-event-id/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Event_Customers, "", null);

}

function Bind_Event_Customers(data) {

    $("#dvEventCustomers").html("");

    //bind date dropdown
    var drpHTML = "";
    $("#drpDate").html('');

    for (i = 0; i < data.eventdates.length; i++) {

        var date = ToJavaScriptDate(data.eventdates[i].Day);
        var values = date.split("/");
        var newDate = values[1] + "/" + values[0] + "/" + values[2];

        drpHTML += "<option value='" + newDate + "' >" + ToJavaScriptDate(data.eventdates[i].Day) + "</option>";
    }
    //

    var htmlText = "";

    if (data.Event.customer_event_mappings.length > 0) {

        for (i = 0; i < data.Event.customer_event_mappings.length; i++) {

            htmlText += "<div class='col-md-12'>";

            htmlText += "<div class='form-group'>";

            htmlText += "<input type='radio' name='rCust' id='" + data.Event.customer_event_mappings[i].Customer_Id + "' class='iradio-list' data-customer='" + data.Event.customer_event_mappings[i].Customer_Event_Mapping_Id + "'/>";

            htmlText += "&nbsp;&nbsp;&nbsp;&nbsp;";

            htmlText += "<span class='label label-success time-label'>" + data.Event.customer_event_mappings[i].Customer_Name + " </span>";

            htmlText += "</div>";

            htmlText += "</div>";

        }

    }

    $("#drpDate").append(drpHTML);
    $('#dvEventCustomers').append(htmlText);

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });

    $("#btnViewAttendance").hide();
    Friendly_Message(data);

}


function Get_Event_Members_Attendance() {
    var eViewModel =
        {
            Event:
                {
                    event_attendance: {

                        Event_Id: $('#hdnEvent_Id').val(),

                        Customer_Id: $('#hdntempCust_Id').val(),

                        Date: $('#drpDate').val(),

                    }

                },
            Pager:
                {
                    CurrentPage: $('#hdfCurrent_Page').val(),
                },

        }

    CallAjax("/event/get-members-attendance/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Event_Members_Attendance, "", null);
}

function Bind_Event_Members_Attendance(data) {

    var htmlText = "";
    var count = $("#tblEventMemberAttendance").find(".tr-attendance").length;
    
    if (data.Event.event_attendances.length > 0) {

        for (i = 0; i < data.Event.event_attendances.length; i++) {

            htmlText += "<tr class='tr-attendance'>";

            htmlText += "<td>";

            htmlText += data.Event.event_attendances[i].Member_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += ToJavaScriptDate(data.Event.event_attendances[i].Date);

            htmlText += "</td>";

            htmlText += "<td>";

            var date = ToJavaScriptDate(data.Event.event_attendances[i].Date);
            var values = date.split("/");
            var newDate = values[1] + "/" + values[0] + "/" + values[2];

            if (data.Event.event_attendances[i].Event_Attendance_Id != 0)
            {
                htmlText += "<input type='radio' name='Attendance_" + count + "' id='rAttended' class='iradio-list' value='" + data.Event.event_attendances[i].Member_Id + "' data-date='" + newDate + "' data-atte-id='" + data.Event.event_attendances[i].Event_Attendance_Id + "' checked/>";
            }
            else {
                htmlText += "<input type='radio' name='Attendance_" + count + "' id='rAttended' class='iradio-list' value='" + data.Event.event_attendances[i].Member_Id + "' data-date='" + newDate + "' data-atte-id='" + data.Event.event_attendances[i].Event_Attendance_Id + "' />";
            }

            htmlText += "</td>";

            htmlText += "<td>";

            if (data.Event.event_attendances[i].Event_Attendance_Id != 0)
            {
                htmlText += "<input type='radio' name='Attendance_" + count + "' id='rUnattended' class='iradio-list' value='" + data.Event.event_attendances[i].Member_Id + "' data-date='" + newDate + "' data-atte-id='" + data.Event.event_attendances[i].Event_Attendance_Id + "'/>";
            }
            else {
                htmlText += "<input type='radio' name='Attendance_" + count + "' id='rUnattended' class='iradio-list' value='" + data.Event.event_attendances[i].Member_Id + "' data-date='" + newDate + "' data-atte-id='" + data.Event.event_attendances[i].Event_Attendance_Id + "' checked/>";
            }

            htmlText += "</td>";

            htmlText += "</tr>";

            count++;
        }

        $("#btnSave").show();
        
        if ($('#hdfCurrent_Page').val() == 0)
        {
            $('#dvScroll').addClass('scroll-bar');
        }

        var pageNo = $('#hdfCurrent_Page').val();
        pageNo = parseInt(pageNo) + 1;
        $('#hdfCurrent_Page').val(pageNo);
    }
    //else {

    //    htmlText += "<tr>";

    //    htmlText += "<td colspan='4'> No members found.";

    //    htmlText += "</td>";

    //    htmlText += "</tr>";

    //    $("#btnSave").hide();
    //}
    //$("#tblEventMemberAttendance").find("tr:gt(0)").remove();

    $('#tblEventMemberAttendance tr:last').after(htmlText);
    $('#loading').hide();

    if ($("#tblEventMemberAttendance").find(".tr-attendance").length == 0) {
        var blankHTML = "";

        blankHTML += "<tr>";
        blankHTML += "<td colspan='4'> No members found.";
        blankHTML += "</td>";
        blankHTML += "</tr>";

        $('#tblEventMemberAttendance tr:first').after(blankHTML);
        $('#dvScroll').removeClass('scroll-bar');
        $("#btnSave").hide();
    }

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });

    Friendly_Message(data);

    
}


function Save_Event_Member_Attendance()
{
    
    var eViewModel =
        {
            Event:
                {
                    event_attendances: Get_Values_Of_Attendance_List(),

                }
        }

    //alert(eViewModel.Event.event_attendances[1].Event_Attendance_Id);

    if ($("#frmEventAttendance").valid()) {
        CallAjax("/event/save-event-attendance/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Event_Attendance_CallBack, "", null);
    }
}

function Get_Values_Of_Attendance_List()
{
    var memberList = [];

    $('.tr-attendance').each(function () {

        if ($(this).find('#rAttended').prop('checked')) {

            var flg = true;
        }
        else {
            var flg = false;
        }
        
        memberList.push({
            Event_Attendance_Id: $(this).find('#rAttended').attr('data-atte-id'),
            Event_Id: $('#hdnEvent_Id').val(),
            Member_Id: $(this).find('#rAttended').val(),
            Date: $(this).find('#rAttended').attr('data-date'),
            Flag: flg,
        });

    });

    return memberList;
}

function Event_Attendance_CallBack(data)
{
    Friendly_Message(data);
}