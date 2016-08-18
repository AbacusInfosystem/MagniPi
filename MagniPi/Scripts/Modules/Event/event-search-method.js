function Search_Events() {

    var eViewModel =
        {
            Filter:
                {
                    Event_Name: $("#txtName").val(),

                    Month: $("#txtMonth").val(),
                },

            Pager:
                {
                    CurrentPage: $('#hdfCurrent_Page').val(),
                },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/event/get-events/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Event_Grid, "", null);

}

function Bind_Event_Grid(data) {

    var htmlText = "";

    if (data.events.length > 0) {

        for (i = 0; i < data.events.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='" + data.events[i].Event_Id + "' class='iradio-list' />";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.events[i].Event_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.events[i].Description;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.events[i].Event_Type_Str;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.events[i].Location;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.events[i].Is_Stoped == true ? "Yes" : "No";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.events[i].Is_Active == true ? "Yes" : "No";

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
    $("#tblEvent").find("tr:gt(0)").remove();

    $('#tblEvent tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });


    if (data.events.length > 0) {
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

    $("#btnEdit").hide();
    $("#btnSubscribe").hide();
    $("#btnAttendance").hide();
   
}


function PageMore(Id) {

    $("#btnEdit").hide();
    $("#btnSubscribe").hide();
    $("#btnAttendance").hide();
    
    $('#hdfCurrent_Page').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    Search_Events();
}