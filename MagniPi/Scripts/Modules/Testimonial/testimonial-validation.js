$(document).ready(function () {

    $("#frmAddEditTestimonial").validate({

        rules: {

            "testimonial.Title": { required: true },

            "testimonial.Author_Name":{ required: true },
          
            "testimonial.Content": { required: true },

            "testimonial.Author_Designation": { required: true },

        },
        messages: {

            "testimonial.Title": { required: "Required field." },

            "testimonial.Author_Name": { required: "Required field." },

            "testimonial.Content": { required: "Required field." },

            "testimonial.Author_Designation": { required: "Required field." },

        }
    });

});