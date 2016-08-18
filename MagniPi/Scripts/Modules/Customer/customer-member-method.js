function Search_Customer_Member() {
    
    var cViewModel =
        {
            customer:
                {
                    Customer_Id: $("#hdnCustomer_Id").val(),

                }

        }

    CallAjax("/customer/get-customer-members-by-customer-id/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Customer_Members, "", null);

}

function Bind_Customer_Members(data) {

    $('.auto-complete-value').val(data.customer.Customer_Id);
    $('.auto-complete-label').val(data.customer.Customer_Name);
   
    $("#dvCustomerMember").html("");

    var htmlText = "";

    if (data.customer.members.length > 0) {

        for (i = 0; i < data.customer.members.length; i++) {

            htmlText += "<div class='col-md-12'>";

            htmlText += "<div class='form-group'>";

            htmlText += "<input type='radio' name='rMember' id='" + data.customer.members[i].Member_Id + "' class='iradio-list' />";

            htmlText += "&nbsp;&nbsp;&nbsp;&nbsp;";

            htmlText += "<span class='label label-success time-label'>" + data.customer.members[i].First_Name + " " + data.customer.members[i].Last_Name + "</span>";

            htmlText += "</div>";

            htmlText += "</div>";

        }

    }

    $('#dvCustomerMember').append(htmlText);
   
    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });

    Friendly_Message(data);

}

function Save_Customer_Member() {

    var cViewModel =
        {
            customer:
                {
                    Member: {

                        Member_Id: $('#hdnMember_Id').val(),

                        Customer_Id: $('#hdnCustomer_Id').val(),

                        First_Name: $('#txtFirstName').val(),

                        Last_Name: $('#txtLastName').val(),

                        Gender: $('#hdnGender').val(),

                        //Gender: $('[name="Gender"]').val(),

                        Contact: $('#txtContact').val(),

                        Email: $('#txtEmail').val(),

                        Address: $('#txtAddress').val(),

                        Is_Active: $('#hdnIs_Active').val(),
                    }

                }

        }

    if ($("#frmCustomerMember").valid()) {
        CallAjax("/customer/save-customer-member/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Customer_Member_CallBack, "", null);
    }
}

function Customer_Member_CallBack(data) {

    Reset_Customer_Member();

    Friendly_Message(data);

}

function Reset_Customer_Member()
{

    $('#hdnMember_Id').val("");

    //$('#txtCustomer_Id').val("");

    $('#txtFirstName').val("");

    $('#txtLastName').val("");

    $('#hdnGender').val("");
    $('[name="Gender"]').iCheck('uncheck');

    $('#txtContact').val("");

    $('#txtEmail').val("");

    $('#txtAddress').val("");

    $('#hdnIs_Active').val("");
    $("#chkIsActive").iCheck('uncheck');

    $("#btnUpdate").hide();

}

function Get_Member_Details() {

    var cViewModel =
        {
            customer:
                {
                    Member:
                        {
                            Customer_Id: $("#hdnCustomer_Id").val(),

                            Member_Id: $("#hdntempMember_Id").val(),
                        }
                    
                }

        }

    CallAjax("/customer/get-member-details-by-id/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Set_Member_Details, "", null);

}

function Set_Member_Details(data)
{

    $('#hdnMember_Id').val(data.customer.member.Member_Id);

    $('#txtCustomer_Id').val(data.customer.member.Customer_Id);

    $('#txtFirstName').val(data.customer.member.First_Name);

    $('#txtLastName').val(data.customer.member.Last_Name);

    $('#hdnGender').val(data.customer.member.Gender);
    
    if (data.customer.member.Gender == "M")
    {
        $("#rMale").iCheck('check');
    }
    else if (data.customer.member.Gender == "F")
    {
        $("#rFemale").iCheck('check');
    }

    $('#txtContact').val(data.customer.member.Contact);

    $('#txtEmail').val(data.customer.member.Email);

    $('#txtAddress').val(data.customer.member.Address);

    $('#hdnIs_Active').val(data.customer.member.Is_Active);

    if (data.customer.member.Is_Active)
    {
        $("#chkIsActive").iCheck('check');
    }

}

//event
function Get_Customer_Events()
{
    var cViewModel =
        {
            customer:
                {
                    Customer_Id: $("#hdnCustomer_Id").val(),

                }

        }

    CallAjax("/customer/get-customer-events-by-customer-id/", "json", JSON.stringify(cViewModel), "POST", "application/json", false, Bind_Customer_Events_Grid, "", null);

}

function Bind_Customer_Events_Grid(data) {

    var htmlText = "";

    if (data.customer.events.length > 0) {

        for (i = 0; i < data.customer.events.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += data.customer.events[i].Event_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.customer.events[i].Event_Type;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.customer.events[i].Description;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.customer.events[i].Location;

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
    $("#tblEvent").find("tr:gt(0)").remove();

    $('#tblEvent tr:first').after(htmlText);

    Friendly_Message(data);

}