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

            htmlText += "<div class='media testimonial-media' id='" + data.testimonials[i].Testimonial_Id + "'>";

            //if (i % 2 == 0) {
            //    htmlText += "<div class='pull-right'>";
            //}
            //else {
            //    htmlText += "<div class='pull-left'>";
            //}
            
            htmlText += "<div class='pull-left'>";

            htmlText += "<img alt='' src='" + data.testimonials[i].Author_Image_Url + "' style='height:120px; width:120px; border: 1px solid;'>";

            htmlText += "</div>";

            htmlText += "<div class='media-body'>";

            htmlText += "<blockquote>" + data.testimonials[i].Content + "</blockquote>";

            htmlText += "<h3><a href='#'>- " + data.testimonials[i].Author_Name + "</a></h3>";

            htmlText += "</div>";

            htmlText += "</div>";
            
        }
    }
    
    if ($('#hdfCurrent_Page').val() == 0) {
        $("#dvTestimonial").append(htmlText);

    }
    else {
        $('.testimonial-media:last').after(htmlText);
    }

    var pageNo = $('#hdfCurrent_Page').val();
    pageNo = parseInt(pageNo) + 1;
    $('#hdfCurrent_Page').val(pageNo);

    Friendly_Message(data);
    $('#loading').hide();

}