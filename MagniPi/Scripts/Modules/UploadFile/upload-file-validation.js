$(document).ready(function () {

    $("#frmUploadFile").validate({

        rules: {

            "attachment.Upload_Image": { required: true },

            "attachment.File_Type": { required: true },

        },
        messages: {

            "attachment.Upload_Image": { required: "Required field." },

            "attachment.File_Type": { required: "Required field." },

        }
    });

});