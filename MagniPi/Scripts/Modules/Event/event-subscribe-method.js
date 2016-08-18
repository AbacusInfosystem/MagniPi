function Get_Event_Customers()
{
    var eViewModel =
        {
            Event:
                {
                    Event_Id: $("#hdnEvent_Id").val(),

                }

        }

    CallAjax("/event/get-customers-by-event-id/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Event_Customers, "", null);

}

function Bind_Event_Customers(data) {

    //$('.auto-complete-value').val(data.customer.Customer_Id);
    //$('.auto-complete-label').val(data.customer.Customer_Name);

    $("#dvEventCustomers").html("");

    var htmlText = "";

    if (data.Event.customer_event_mappings.length > 0) {

        for (i = 0; i < data.Event.customer_event_mappings.length; i++) {

            htmlText += "<div class='col-md-12'>";

            htmlText += "<div class='form-group'>";

            htmlText += "<input type='radio' name='rCust' id='" + data.Event.customer_event_mappings[i].Customer_Id + "' class='iradio-list' data-customer='" + data.Event.customer_event_mappings[i].Customer_Event_Mapping_Id + "'/>";

            htmlText += "&nbsp;&nbsp;&nbsp;&nbsp;";

            htmlText += "<span class='label label-success time-label'>" + data.Event.customer_event_mappings[i].Customer_Name + " </span>";

            htmlText += "</div>";

            htmlText += "</div>";

        }

    }

    $('#dvEventCustomers').append(htmlText);

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });

    $("#btnShowMembers").hide();
    Friendly_Message(data);

}

function Save_Event_Customer()
{
    var eViewModel =
        {
            Event:
                {
                    customer_event_mapping: {

                        //Event_Date_Id: $('#hdnEvent_Date_Id').val(),

                        Event_Id: $('#hdnEvent_Id').val(),

                        Customer_Id: $('#hdnCustomer_Id').val(),

                    }

                }
        }

    if ($("#frmCustomerEventMapping").valid())
    {
        CallAjax("/event/save-event-customer-mapping/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Event_Customer_CallBack, "", null);
    }
}

function Event_Customer_CallBack(data) {

    Friendly_Message(data);

    Reset_Customer();

}

function Reset_Customer()
{
    $("#txtCustomer_Name").val("");
    $("#hdnCustomer_Id").val("");
    $("#hdnCustomer_Name").val("");

    $("#txtCustomer_Name").parents('.form-group').find('.todo-list').text("");

}

function Get_Event_Members()
{
    var eViewModel =
        {
            Event:
                {
                    customer_event_mapping: {

                        //Event_Date_Id: $('#hdnEvent_Date_Id').val(),

                        Event_Id: $('#hdnEvent_Id').val(),

                        Customer_Id: $('#hdntempCust_Id').val(),

                    }

                }

        }

    CallAjax("/event/get-member-by-customer-id/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Event_Members, "", null);
}

function Bind_Event_Members(data)
{
    var htmlText = "";

    if (data.Event.member_event_mappings.length > 0) {
        
        for (i = 0; i < data.Event.member_event_mappings.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";
            
            if (data.Event.member_event_mappings[i].Member_Event_Mapping_Id != 0)
            {
                htmlText += "<input type='checkbox' name='chk_Member' id='" + data.Event.member_event_mappings[i].Member_Id + "' class='chk-list' data-mappid='" + data.Event.member_event_mappings[i].Member_Event_Mapping_Id + "' checked/>";
            }
            else {
                htmlText += "<input type='checkbox' name='chk_Member' id='" + data.Event.member_event_mappings[i].Member_Id + "' class='chk-list' data-mappid='" + data.Event.member_event_mappings[i].Member_Event_Mapping_Id + "'/>";
            }

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Event.member_event_mappings[i].Member_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Event.member_event_mappings[i].Contact;

            htmlText += "</td>";

            htmlText += "</tr>";
        }

        $("#btnSave").show();
    }
    else {

        htmlText += "<tr>";

        htmlText += "<td colspan='4'> No members found.";

        htmlText += "</td>";

        htmlText += "</tr>";

        $("#btnSave").hide();
    }
    $("#tblEventMember").find("tr:gt(0)").remove();

    $('#tblEventMember tr:first').after(htmlText);


    $('.chk-list').iCheck({
        checkboxClass: 'icheckbox_square-green',
        increaseArea: '20%'
    });

    Friendly_Message(data);
}

//
function Save_Event_Members()
{

    var eViewModel =
        {
            Event:
                {
                    member_event_mappings: Get_Values_Of_Member_List(),
                       
                }
        }
    
    if ($("#frmCustomerEventMapping").valid())
    {
        CallAjax("/event/save-event-member-mapping/", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Event_Member_CallBack, "", null);
    }
}

function Get_Values_Of_Member_List()
{
    var memberList = [];
   
    $('.chk-list').each(function () {

        if ($(this).prop('checked')) {

            var flg = true;
        }
        else {
            var flg = false;
        }

        memberList.push({
            Member_Event_Mapping_Id: $(this).attr('data-mappid'),
            Event_Id: $('#hdnEvent_Id').val(),
            Member_Id: $(this).attr('id'),
            Flag_Checked: flg,
        });
    });

    return memberList;
}

function Event_Member_CallBack(data)
{
    Friendly_Message(data);
}