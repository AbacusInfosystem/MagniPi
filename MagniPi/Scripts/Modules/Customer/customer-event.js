$(document).ready(function () {

    $("#Indivisual").find('.form-control').removeClass('ignore');
    $("#Indivisual").find('.iradio-list').removeClass('ignore');
    $("#Corporate").find('.form-control').addClass('ignore');

    if ($("#hdnCustomerType").val() != "True") {
        $("#Indivisual").hide();
        $("#Corporate").show();
        
        $("#Indivisual").find('.form-control').addClass('ignore');
        $("#Indivisual").find('.iradio-list').addClass('ignore');
        $("#Corporate").find('.form-control').removeClass('ignore');

    }

    $('[name="Is_Indivisual"]').on('ifChecked', function (event) {

        if ($(this).val() == "True") {
            $("#Indivisual").show();
            $("#Corporate").hide();
            $("#hdnCustomerType").val($(this).val());

            $("#Indivisual").find('.form-control').removeClass('ignore');
            $("#Indivisual").find('.iradio-list').removeClass('ignore');
            $("#Corporate").find('.form-control').addClass('ignore');

        }
        else if ($(this).val() == "False") {
            $("#Corporate").show();
            $("#Indivisual").hide();
            $("#hdnCustomerType").val($(this).val());

            $("#Indivisual").find('.form-control').addClass('ignore');
            $("#Indivisual").find('.iradio-list').addClass('ignore');
            $("#Corporate").find('.form-control').removeClass('ignore');

        }

    });

    $('[name="chkIs_Active"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

    $('[name="chkIs_Active1"]').on('ifChanged', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active1").val(true);
        }
        else {
            $("#hdnIs_Active1").val(false);
        }
    });


    $("#btnSave").click(function (event) {

        if ($("#frmAddEditCustomer").valid()) {

            if ($("#hdnCustomerType").val() == "True")
            {
                var htmlText = "";

                htmlText += "<input type='hidden' name='customer.Customer_Name' value='" + $("#txtFirstName").val() + " " + $("#txtLastName").val() + " ' />";
                htmlText += "<input type='hidden' name='customer.Address' value='" + $("#txtAddress").val() + "' />";
                htmlText += "<input type='hidden' name='customer.Contact' value='" + $("#txtContact").val() + "' />";
                htmlText += "<input type='hidden' name='customer.Email' value='" + $("#txtEmail").val() + "' />";
                htmlText += "<input type='hidden' name='customer.Is_Active' value='" + $("#hdnIs_Active").val() + "' />";

                $('#dvHidden').append(htmlText);
            }
            
            $('#frmAddEditCustomer').attr("action", "/customer/save-customer");
            $('#frmAddEditCustomer').attr("method", "POST");
            $('#frmAddEditCustomer').submit();

        }

    });


    //$("#btnSave").click(function (event) {

    //    if ($("#hdnCustomerType").val() == "True")
    //    {
    //        if ($("#Indivisual").valid()) {

    //            var htmlText = "";

    //            htmlText += "<input type='hidden' name='customer.Customer_Name' value='" + $("#txtFirstName").val() + " " + $("#txtLastName").val() + " ' />";
    //            htmlText += "<input type='hidden' name='customer.Address' value='" + $("#txtAddress").val() + "' />";
    //            htmlText += "<input type='hidden' name='customer.Contact' value='" + $("#txtContact").val() + "' />";
    //            htmlText += "<input type='hidden' name='customer.Is_Active' value='" + $("#hdnIs_Active").val() + "' />";

    //            $('#dvHidden').append(htmlText);

    //            $('#frmAddEditCustomer').attr("action", "/customer/save-customer");
    //            $('#frmAddEditCustomer').attr("method", "POST");
    //            $('#frmAddEditCustomer').submit();

    //        }
    //    }
    //    else {
    //        if ($("#Corporate").valid()) {

    //            $('#frmAddEditCustomer').attr("action", "/customer/save-customer");
    //            $('#frmAddEditCustomer').attr("method", "POST");
    //            $('#frmAddEditCustomer').submit();

    //        }
    //    }


    //});



});