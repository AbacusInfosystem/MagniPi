$(document).ready(function () {

    Get_Testimonials();

    var win = $(window);

    win.scroll(function () {

        if ($(document).height() - win.height() == win.scrollTop()) {

            $('#loading').show();

            Get_Testimonials();

        }
    });

});