$(document).ready(function () {

    $("#frmAddEditEvent").validate({

        rules: {

            "Event.Event_Name": { required: true },

            "Event.Event_Type": { required: true },

            "Event.Description": { required: true },

            "Event.Location": { required: true },

        },
        messages: {

            "Event.Event_Name": { required: "Required field." },

            "Event.Event_Type": { required: "Required field." },

            "Event.Description": { required: "Required field." },

            "Event.Location": { required: "Required field." },

        }
    });



    $("#frmEventDate").validate({

        rules: {

            "Event.event_date.Date": { required: true },

            "Event.event_date.Start_Time": { required: true },

            "Event.event_date.End_Time": { required: true },

        },
        messages: {

            "Event.event_date.Date": { required: "Required field." },

            "Event.event_date.Start_Time": { required: "Required field." },

            "Event.event_date.End_Time": { required: "Required field." },

        }
    });



});