$(document).ready(function () {

    $("#frmUpdateAboutUs").validate({

        rules: {

            "aboutus.About_Us_Template": {
                required: function () {
                    CKEDITOR.instances.txtAboutUsContent.updateElement();
                }
            },


        },
        messages: {

            "aboutus.About_Us_Template": { required: "Required field." },


        }
    });

});