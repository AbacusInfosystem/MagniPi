function Get_Testimonials() {
    var homeViewModel =
      {
          Pager:
              {
                  CurrentPage: $('#hdfCurrent_Page').val(),
              },
      }

    CallAjax("/home/get-testimonials-list/", "json", JSON.stringify(homeViewModel), "POST", "application/json", false, Bind_Testimonials, "", null);
}

function Bind_Testimonials(data) {

    var htmlText = "";

    if (data.testimonials.length > 0) {
       
        for (i = 0; i < data.testimonials.length; i++) {

            htmlText += "<div class='row testimonial'>";

            htmlText += "<div class='col-md-2 col-sm-2'>";

            htmlText += "<img src='" + data.testimonials[i].Author_Image_Url + "' style='height:180px;width:180px;'>";

            htmlText += "</div>";

            htmlText += "<div class='col-md-10 col-sm-10'>";

            htmlText += "<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + data.testimonials[i].Content + "</p>";

            htmlText += "<h4>" + data.testimonials[i].Author_Name + "</h4>";

            htmlText += "<h5>Blue Bottle keffiyeh<br>Sartorial locavore Schlitz ennui</h5>";

            htmlText += "</div>";

            htmlText += "</div>";
            
        }
    }

    if ($('#hdfCurrent_Page').val() == 0) {
        $("#dvTestimonial").append(htmlText);
    }
    else {
        $('.testimonial:last').after(htmlText);
    }

    var pageNo = $('#hdfCurrent_Page').val();
    pageNo = parseInt(pageNo) + 1;
    $('#hdfCurrent_Page').val(pageNo);

    Friendly_Message(data);
    $('#loading').hide();

}