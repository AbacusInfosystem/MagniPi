$(document).ready(function () {

    $("#frmAddEditBlog").validate({
        //ignore: [],
        //debug: false,
        rules: {

            "blog.Title": { required: true },

            "blog.Blog_Template": {
                required: function () {
                    CKEDITOR.instances.txtBlogContent.updateElement();
                }
            },

            //"blog.Header_Image": { required: true },

        },
        messages: {

            "blog.Title": { required: "Required field." },

            "blog.Blog_Template": { required: "Required field." },

            //"blog.Header_Image": { required: "Required field." },

        }
    });

});