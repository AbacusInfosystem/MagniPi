$(document).ready(function () {

    Search_Testimonials();

    $("#btnEdit").click(function (event) {

        $('#frmTestimonialListing').attr("action", "/testimonial/get-testimonial-by-id");
        $('#frmTestimonialListing').attr("method", "POST");
        $('#frmTestimonialListing').submit();

    });

  


});