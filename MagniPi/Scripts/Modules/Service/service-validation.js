$(document).ready(function () {

    $("#frmAddEditService").validate({

        rules: {

            "service.Title": { required: true },

            "service.Service_Template": {
                required: function () {
                    CKEDITOR.instances.txtServiceContent.updateElement();
                }
            },

        },
        messages: {

            "service.Title": { required: "Required field." },

            "service.Service_Template": { required: "Required field." },

        }
    });

});