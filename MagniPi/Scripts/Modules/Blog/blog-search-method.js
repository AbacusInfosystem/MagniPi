function Search_Blogs()
{
    
    var bViewModel =
        {
            Filter:
                { 
                    //Blog_Name: $("#txtBlogName").val(),

                    Month: $("#txtMonth").val()
                },

            Pager:
                {
                CurrentPage: $('#hdfCurrent_Page').val(),
            },
        }

    $("#divSearchGridOverlay").show();
    
    CallAjax("/blog/get-blogs/", "json", JSON.stringify(bViewModel), "POST", "application/json", false, Bind_Blog_Grid, "", null);

}

function Bind_Blog_Grid(data) {

    var htmlText = "";

    if (data.blogs.length > 0) {

        for (i = 0; i < data.blogs.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='"+ data.blogs[i].Blog_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.blogs[i].Title;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += ToJavaScriptDate(data.blogs[i].Created_On);

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
    $("#tblBlog").find("tr:gt(0)").remove();

    $('#tblBlog tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' 
    });


    if (data.blogs.length > 0) {
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

            $("#hdnBlogId").val(this.id);
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

    Search_Blogs();
}