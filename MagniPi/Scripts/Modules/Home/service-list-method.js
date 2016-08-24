function Get_Services() {
    var homeViewModel =
      {
          Filter:
              {
                  Service_Title: $("#txtTitle").val(),
              },

          Pager:
              {
                  CurrentPage: $('#hdfCurrent_Page').val(),
              },
      }
    
    CallAjax("/home/get-services/", "json", JSON.stringify(homeViewModel), "POST", "application/json", false, Bind_Services, "", null);
}

function Bind_Services(data) {

    var htmlText = "";

    if (data.services.length > 0) {
        var j = 0;

        for (i = 0; i < data.services.length; i++) {

            if (j == 0 || j % 3 == 0) {
                htmlText += "<div class='row'>";
            }

            htmlText += "<div class='col-md-4 col-sm-12 blog-padding-right'>";

            htmlText += "<div class='single-blog two-column'>";

            htmlText += "<div class='post-thumb'>";

            htmlText += "<a href='#' onclick='ViewServiceDwtails(" + data.services[i].Service_Id + ")'>";

            htmlText += "<img alt='' class='img-responsive' src='" + data.services[i].Header_Image_Url + "' style='border: 1px solid; border-color:black; height:200px; width:380px' />";

            htmlText += "</a>";

            htmlText += "<div class='post-overlay'>";

            var date = ToJavaScriptDate(data.services[i].Created_On);
            var values = date.split("/");

            htmlText += "<span class='uppercase'><a href='#' onclick='ViewBlogDwtails(" + data.services[i].Service_Id + ")'>" + values[0] + " <br><small>" + values[1] + "</small></a></span>";

            htmlText += "</div>";

            htmlText += "</div>";

            htmlText += "<div class='post-content overflow'>";

            htmlText += "<h2 class='post-title bold'><a href='#'>" + data.services[i].Title + "</a></h2>";

            htmlText += "<h3 class='post-author'><a href='#' onclick='ViewServiceDwtails(" + data.services[i].Service_Id + ")'>Posted by " + data.services[i].User_Name + "</a></h3>";
            
            htmlText += "<p>" + data.services[i].Service_Template + "</p>";

            htmlText += "<a class='read-more' href='#' onclick='ViewServiceDwtails(" + data.services[i].Service_Id + ")'>View More</a>";

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
        $("#dvServiceList").append(htmlText);
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


function ViewServiceDwtails(Id) {

    $("#hdnService_Id").val(Id);

    $('#frmServiceList').attr("action", "/home/view-service-details-by-id");
    $('#frmServiceList').attr("method", "POST");
    $('#frmServiceList').submit();

}