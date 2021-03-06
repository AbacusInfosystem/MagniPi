﻿
var InitializeAutoComplete = function (elementObject) {

    $(elementObject).autocomplete({
        source: function (request, response) {

            var urlString = ''

            if ($(elementObject).attr("id") == 'txtCustomerName') {
                urlString = "/customer/get-customer-list-by-name/" + $('#txtCustomerName').val();
            }

            if ($(elementObject).attr("id") == 'txtEventName') {
                urlString = "/event/get-event-list-by-name/" + $('#txtEventName').val();
            }
           
            if ($(elementObject).attr("id") == 'txtCustomer_Name') {
                urlString = "/event/get-customer-list-by-name/" + $('#txtCustomer_Name').val() + "/" + $('#hdnEvent_Id').val();
            }

            $.ajax({
                url: urlString,
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Label,
                            value: item.Value
                        }
                    }));
                }
            });
        },

        minLength: 2,
        focus: function (event, ui) {
            $(this).val(ui.item.label);
            return false;
        },
        select: function (event, ui) {

            $(this).val(ui.item.label);
            
            $(this).parents('.form-group').find('input[type=text]').val("");
            $(this).parents('.form-group').find('.auto-complete-value').val(ui.item.value);
            $(this).parents('.form-group').find('.auto-complete-label').val(ui.item.label);

            $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
            $(this).parents('.form-group').find('.auto-complete-label').trigger('change');

            if ($(this).parents('.form-group').find(".todo-list")[0]) {
                $(this).parents('.form-group').find('.todo-list').remove();
            }

            var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + ui.item.label + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            if ($(this).parents('.form-group').find(".ui-menu")[0]) {

                $(this).parents('.form-group').find('.text').html(ui.item.label);
            } else {

                $(this).parents('.form-group').append(htmlText);
            }

            $(this).parents('.form-group').find('.fa-remove').click(function (event) {
                event.preventDefault();
                $(this).parents('.form-group').find('input[type=text]').val("");
                $(this).parents('.form-group').find('.auto-complete-value').val("");
                $(this).parents('.form-group').find('.auto-complete-label').val("");
                $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
                $(this).parents('.form-group').find('.auto-complete-label').trigger('change');
                $(this).parents('.form-group').find('.todo-list').remove();
            });

            $('.ui-autocomplete').html("");
            return false;
        },
        open: function () {
            
            $(this).removeClass("ui-corner-all").addClass("ui-sortable");
        },
        close: function (event, ui) {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");

        }
    });

    $(elementObject).each(function () {

        if ($(this).parents('.form-group').find('.auto-complete-value').val() != 0) {

            var htmlText = "<ul class='todo-list ui-sortable'><li ><span class='text'>" + $(this).parents('.form-group').find('.auto-complete-label').val() + "</span><div class='tools'><i class='fa fa-remove'></i></div></li></ul>";

            if ($(this).parents('.form-group').find(".ui-menu")[0]) {

                $(this).parents('.form-group').find('.text').html(ui.item.label);
            } else {

                $(this).parents('.form-group').append(htmlText);
            }

            $(this).parents('.form-group').find('input[type=text]').val("");

            $(this).parents('.form-group').find('.fa-remove').click(function (event) {
                event.preventDefault();
                $(this).parents('.form-group').find('input[type=text]').val("");
                $(this).parents('.form-group').find('.auto-complete-value').val("");
                $(this).parents('.form-group').find('.auto-complete-label').val("");
                $(this).parents('.form-group').find('.auto-complete-value').trigger('change');
                $(this).parents('.form-group').find('.auto-complete-label').trigger('change');
                $(this).parents('.form-group').find('.todo-list').remove();

            });
        }
        else {
            $(this).parents('.form-group').find('.todo-list').remove();
        }
    });
}