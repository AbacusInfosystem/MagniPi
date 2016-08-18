$(document).ready(function () {

    if ($("#hdnCustomerType").val() != "True")
    {
        $("#Indivisual").hide();
        $("#Corporate").show();
    }

    $('[name="Is_Indivisual"]').on('ifChecked', function (event) {

        if ($(this).val() == "True") {
            $("#Indivisual").show();
            $("#Corporate").hide();
            $("#hdnCustomerType").val($(this).val());
        }
        else if ($(this).val() == "False") {
            $("#Corporate").show();
            $("#Indivisual").hide();
            $("#hdnCustomerType").val($(this).val());
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

            //alert($("#hdnCustomerType").val());
            if ($("#hdnCustomerType").val() == "True")
            {
                var htmlText = "";

                htmlText += "<input type='hidden' name='customer.Customer_Name' value='" + $("#txtFirstName").val() + " " + $("#txtLastName").val() + " ' />";
                htmlText += "<input type='hidden' name='customer.Address' value='" + $("#txtAddress").val() + "' />";
                htmlText += "<input type='hidden' name='customer.Contact' value='" + $("#txtContact").val() + "' />";
                htmlText += "<input type='hidden' name='customer.Is_Active' value='" + $("#hdnIs_Active").val() + "' />";

                $('#dvHidden').append(htmlText);
            }
            
            $('#frmAddEditCustomer').attr("action", "/customer/save-customer");
            $('#frmAddEditCustomer').attr("method", "POST");
            $('#frmAddEditCustomer').submit();

        }

    });




});