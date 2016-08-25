$(document).ready(function () {

    $("#txtMonth").datepicker(
        {
            format: "mm-yyyy",
            viewMode: "months",
            minViewMode: "months",
            autoclose: true,
        });

    //$('#hdfCurrent_Page').val(0);
    Get_Blogs();

    $("#dvSearch").click(function (event) {

        $('#hdfCurrent_Page').val(0);
        $("#dvBlogList").html("");

        Get_Blogs();
      
    });


     var win = $(window);
    
    win.scroll(function () {
        
        if ($(document).height() - win.height() == win.scrollTop()) {

            $('#loading').show();

            Get_Blogs();

        }
    });


});

