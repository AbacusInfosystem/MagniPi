function Search_Testimonials() {

    var tViewModel =
        {
            //Filter:
            //    {
            //        Service_Title: $("#txtServiceTitle").val()
            //    },

            Pager:
                {
                    CurrentPage: $('#hdfCurrent_Page').val(),
                },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/testimonial/get-testimonials/", "json", JSON.stringify(tViewModel), "POST", "application/json", false, Bind_Testimonial_Grid, "", null);

}

function Bind_Testimonial_Grid(data) {

    var htmlText = "";

    if (data.testimonials.length > 0) {

        for (i = 0; i < data.testimonials.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='" + data.testimonials[i].Testimonial_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.testimonials[i].Title;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.testimonials[i].Content;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.testimonials[i].Author_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.testimonials[i].Author_Designation;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += ToJavaScriptDate(data.testimonials[i].Created_On);

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.testimonials[i].Is_Active == true ? "Yes" : "No";

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='7'> No Record found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }
    $("#tblTestimonial").find("tr:gt(0)").remove();

    $('#tblTestimonial tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });


    if (data.testimonials.length > 0) {
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

            $("#hdnTestimonialId").val(this.id);
            $("#btnEdit").show();

        }
    });

    $("#btnEdit").hide();

}


function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdfCurrent_Page').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    Search_Testimonials();
}