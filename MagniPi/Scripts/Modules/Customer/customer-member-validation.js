$(document).ready(function () {

    $("#frmCustomerMember").validate({

        rules: {

            "customer.member.First_Name": { required: true },

            "customer.member.Last_Name": { required: true },

            "customer.member.Email": { required: true },

            "customer.member.Contact": { required: true },

            "customer.member.Address": { required: true },

            "Gender": { required: true },

            

        },
        messages: {

            "customer.member.First_Name": { required: "Required field." },

            "customer.member.Last_Name": { required: "Required field." },

            "customer.member.Email": { required: "Required field." },

            "customer.member.Contact": { required: "Required field." },

            "customer.member.Address": { required: "Required field." },

            "Gender": { required: "Required field." },


        }
    });

});