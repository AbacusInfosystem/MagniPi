function Search_Services() {

    var sViewModel =
        {
            Filter:
                {
                    Service_Title: $("#txtServiceTitle").val()
                },

            Pager:
                {
                    CurrentPage: $('#hdfCurrent_Page').val(),
                },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/service/get-services/", "json", JSON.stringify(sViewModel), "POST", "application/json", false, Bind_Service_Grid, "", null);

}

function Bind_Service_Grid(data) {

    var htmlText = "";

    if (data.services.length > 0) {

        for (i = 0; i < data.services.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='" + data.services[i].Service_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.services[i].Title;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += ToJavaScriptDate(data.services[i].Created_On);

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.services[i].Is_Active == true ? "Yes" : "No";

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='5'> No Record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblService").find("tr:gt(0)").remove();

    $('#tblService tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });


    if (data.services.length > 0) {
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

    $('[name="r1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {

            $("#hdnService_Id").val(this.id);
            $("#btnEdit").show();
            $("#btnPreview").show();
        }
    });

    $("#btnEdit").hide();
    $("#btnPreview").hide();
}


function PageMore(Id) {

    $("#btnEdit").hide();
    $("#btnPreview").hide();

    $('#hdfCurrent_Page').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    Search_Services();
}