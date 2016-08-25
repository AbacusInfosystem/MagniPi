function Get_Events() {
    var homeViewModel =
      {

          Pager:
              {
                  CurrentPage: $('#hdfCurrent_Page').val(),
              },
      }

    CallAjax("/home/get-events/", "json", JSON.stringify(homeViewModel), "POST", "application/json", false, Bind_Events, "", null);
}

function Bind_Events(data) {

    var htmlText = "";

    if (data.events.length > 0) {
        var j = 0;

        for (i = 0; i < data.events.length; i++) {

            if (j == 0 || j % 3 == 0) {
                htmlText += "<div class='row'>";
            }

            htmlText += "<div class='col-md-4 col-sm-12 blog-padding-right'>";

            htmlText += "<div class='single-blog two-column'>";

            htmlText += "<div class='post-thumb'>";

            htmlText += "<a href='/home/view-event-details-by-id/" + data.events[i].Event_Id + "'>";

            htmlText += "<img alt='' class='img-responsive' src='" + data.events[i].Attachment_Url + "' style='border: 1px solid; border-color:black; height:200px; width:380px' />";

            htmlText += "</a>";

            htmlText += "<div class='post-overlay'>";

            var date = ToJavaScriptDate(data.events[i].Created_On);
            var values = date.split("/");

            htmlText += "<span class='uppercase'><a href='/home/view-event-details-by-id/" + data.events[i].Event_Id + "'>" + values[0] + " <br><small>" + Get_Date_Month_Name(values[1]) + "</small></a></span>";

            htmlText += "</div>";

            htmlText += "</div>";

            htmlText += "<div class='post-content overflow'>";

            htmlText += "<h2 class='post-title bold'><a href='/home/view-event-details-by-id/" + data.events[i].Event_Id + "'>" + data.events[i].Event_Name + "</a></h2>";

            //htmlText += "<h3 class='post-author'><a href='#' onclick='ViewEventDetails(" + data.events[i].Event_Id + ")'>Posted by " + data.events[i].User_Name + "</a></h3>";

            htmlText += "<p>" + data.events[i].Description + "</p>";

            htmlText += "<a class='read-more' href='/home/view-event-details-by-id/" + data.events[i].Event_Id + "' >View More</a>";

            htmlText += "</div>";

            htmlText += "</div>";

            htmlText += "</div>";

            j++;

            if (j % 3 == 0) {
                htmlText += "</div>";
            }

        }
    }

    if ($('#hdfCurrent_Page').val() == 0) {
        $("#dvEventList").append(htmlText);
    }
    else {
        $('.blog-padding-right:last').after(htmlText);
    }

    var pageNo = $('#hdfCurrent_Page').val();
    pageNo = parseInt(pageNo) + 1;
    $('#hdfCurrent_Page').val(pageNo);

    Friendly_Message(data);
    $('#loading').hide();

}

//function ViewEventDetails(Id)
//{
//    $("#hdnEvent_Id").val(Id);

//    $('#frmEventList').attr("action", "/home/view-event-details-by-id");
//    $('#frmEventList').attr("method", "POST");
//    $('#frmEventList').submit();
//}