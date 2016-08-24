$(document).ready(function () {

    //$('#hdfCurrent_Page').val(0);
    Get_Services();

    $("#dvSearch").click(function (event) {

        $('#hdfCurrent_Page').val(0);
        $("#dvServiceList").html("");

        Get_Services();

    });


    var win = $(window);

    win.scroll(function () {

        if ($(document).height() - win.height() == win.scrollTop()) {

            $('#loading').show();

            Get_Services();

        }
    });


});

