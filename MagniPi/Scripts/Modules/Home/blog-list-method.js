function Get_Blogs()
{
    var homeViewModel =
      {
          Filter:
              {
                  Blog_Month: $("#txtMonth").val(),
              },

          Pager:
              {
                  CurrentPage: $('#hdfCurrent_Page').val(),
              },
      }

    CallAjax("/home/get-blogs/", "json", JSON.stringify(homeViewModel), "POST", "application/json", false, Bind_Blogs, "", null);
}

function Bind_Blogs(data) {

    var htmlText = "";

    if (data.blogs.length > 0) {
        var j = 0;

        for (i = 0; i < data.blogs.length; i++) {

            if(j==0 || j%3 ==0)
            {
                htmlText += "<div class='row'>";
            }

            htmlText += "<div class='col-md-4 col-sm-12 blog-padding-right'>";

            htmlText += "<div class='single-blog two-column'>";

            htmlText += "<div class='post-thumb'>";

            htmlText += "<a href='#' onclick='ViewBlogDwtails(" + data.blogs[i].Blog_Id + ")'>";
             
            htmlText += "<img alt='' class='img-responsive' src='" + data.blogs[i].Header_Image_Url + "' style='border: 1px solid; border-color:black; height:200px; width:380px' />";

            htmlText += "</a>";

            htmlText += "<div class='post-overlay'>";

            var date = ToJavaScriptDate(data.blogs[i].Created_On);
            var values = date.split("/");
            
            //htmlText += "<span class='uppercase'><a href='#' onclick='ViewBlogDwtails(" + data.blogs[i].Blog_Id + ")'>" + values[0] + " <br><small>" + Get_Date_Month(data.blogs[i].Created_On) + "</small></a></span>";
            htmlText += "<span class='uppercase'><a href='#' onclick='ViewBlogDwtails(" + data.blogs[i].Blog_Id + ")'>" + values[0] + " <br><small>" + values[1] + "</small></a></span>";

            htmlText += "</div>";

            htmlText += "</div>";

            htmlText += "<div class='post-content overflow'>";

            htmlText += "<h2 class='post-title bold'><a href='#'>" + data.blogs[i].Title + "</a></h2>";

            htmlText += "<h3 class='post-author'><a href='#' onclick='ViewBlogDwtails(" + data.blogs[i].Blog_Id + ")'>Posted by " + data.blogs[i].User_Name + "</a></h3>";

            htmlText += "<p>" + data.blogs[i].Blog_Template + "</p>";

            htmlText += "<a class='read-more' href='#' onclick='ViewBlogDwtails(" + data.blogs[i].Blog_Id + ")'>View More</a>";

            htmlText += "</div>";

            htmlText += "</div>";

            htmlText += "</div>";

            j++;

            if (j % 3 == 0) {
                htmlText += "</div>";
            }
            
        }
    }
   
    if ($('#hdfCurrent_Page').val() == 0)
    {
        $("#dvBlogList").append(htmlText);
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


function ViewBlogDwtails(Id) {

    $("#hdnBlogId").val(Id);

    $('#frmBlogList').attr("action", "/home/view-blog-details-by-id");
    $('#frmBlogList').attr("method", "POST");
    $('#frmBlogList').submit();

}