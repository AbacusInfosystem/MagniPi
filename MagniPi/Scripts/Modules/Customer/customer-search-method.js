function Search_Customers() {

    var cViewModel =
        {
            Filter:
                {
                    Customer_Name: $("#txtCustomerName").val(),

                    Contact: $("#txtContact").val(),
                },

            Pager:
                {
                    CurrentPage: $('#hdfCurrent_Page').val(),
                },
        }

    $("#divSearchGridOverlay").show();

    CallAjax("/customer/get-customers/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Customer_Grid, "", null);

}

function Bind_Customer_Grid(data) {

    var htmlText = "";

    if (data.customers.length > 0) {

        for (i = 0; i < data.customers.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='r1' id='" + data.customers[i].Customer_Id + "' class='iradio-list' data-is-indivisual='" + data.customers[i].Is_Indivisual + "' />";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.customers[i].Customer_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.customers[i].Contact;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.customers[i].Address;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += ToJavaScriptDate(data.customers[i].Created_On);

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.customers[i].Is_Indivisual == true ? "Yes" : "No";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.customers[i].Is_Active == true ? "Yes" : "No";

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
    $("#tblCustomer").find("tr:gt(0)").remove();

    $('#tblCustomer tr:first').after(htmlText);


    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });


    if (data.customers.length > 0) {
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

            $("#hdnCustomer_Id").val(this.id);
            
            if ($(this).attr('data-is-indivisual') == "true")
            {
                $("#btnAddMember").attr('disabled', true);
            }
            else {
                $("#btnAddMember").attr('disabled', false);
            }
            $("#btnEdit").show();
            $("#btnAddMember").show();

        }
    });

    $("#btnEdit").hide();
    $("#btnAddMember").hide();

}


function PageMore(Id) {

    $("#btnEdit").hide();
    $("#btnAddMember").hide();

    $('#hdfCurrent_Page').val((parseInt(Id) - 1));

    $(".selectAll").prop("checked", false);

    Search_Customers();
}