$(document).ready(function () {

    InitializeAutoComplete($('#txtCustomerName'));

    Search_Customer_Member();

    Get_Customer_Events();

    $("#btnSaveMember").click(function (event) {

        Save_Customer_Member();

        Search_Customer_Member();
       
    });


    $(document).on('ifChanged', '[name="Gender"]', function (event) {
        
        if ($(this).prop('checked')) {
            
            $("#hdnGender").val($(this).val());

        }
    });

    $(document).on('ifChanged', '[name="rMember"]', function (event) {
        if ($(this).prop('checked')) {

            $("#hdntempMember_Id").val(this.id);
            $("#btnUpdate").show();

        }
    });
   
    $(document).on('ifChanged', '[name="chkIs_Active"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnIs_Active").val(true);
        }
        else {
            $("#hdnIs_Active").val(false);
        }
    });

    $("#btnAddNew").click(function (event) {

        $('[name="rMember"]').iCheck('uncheck');
        $("#btnUpdate").hide();

        Reset_Customer_Member()

    });

    $("#btnUpdate").click(function (event) {

        Get_Member_Details();

    });

    $("#hdnCustomer_Id").change(function (event) {

        Search_Customer_Member();
        Get_Customer_Events();

    });

    

});


