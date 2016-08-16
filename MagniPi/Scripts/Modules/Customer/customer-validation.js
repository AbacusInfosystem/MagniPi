$(document).ready(function () {

    $("#frmAddEditCustomer").validate({

        rules: {

            "customer.member.First_Name": { required: true },

            "customer.member.Last_Name": { required: true },

            "customer.member.Email": { required: true },

            "customer.member.Contact": { required: true },

            "customer.member.Address": { required: true },

            "customer.member.Gender": { required: true },

            "customer.Customer_Name": { required: true },

            "customer.Description": { required: true },

            "customer.Address": { required: true },

            "customer.Contact": { required: true },

        },
        messages: {

            "customer.member.First_Name": { required: "Required field." },

            "customer.member.Last_Name": { required: "Required field." },

            "customer.member.Email": { required: "Required field." },

            "customer.member.Contact": { required: "Required field." },

            "customer.member.Address": { required: "Required field." },

            "customer.member.Gender": { required: "Required field." },

            "customer.Customer_Name": { required: "Required field." },

            "customer.Description": { required: "Required field." },

            "customer.Address": { required: "Required field." },

            "customer.Contact": { required: "Required field." },

        }
    });

});