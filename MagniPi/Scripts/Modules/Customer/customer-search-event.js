$(document).ready(function () {

    Search_Customers();

    $("#btnSearch").click(function (event) {

        Search_Customers();

    });

    $("#btnEdit").click(function (event) {

        $('#frmCustomerListing').attr("action", "/customer/get-customer-by-id");
        $('#frmCustomerListing').attr("method", "POST");
        $('#frmCustomerListing').submit();

    });

    $("#btnAddMember").click(function (event) {

        $('#frmCustomerListing').attr("action", "/customer/add-customer-members");
        $('#frmCustomerListing').attr("method", "POST");
        $('#frmCustomerListing').submit();

    });


});