$(function () {
    SearchItemTable();

});

function SearchItemTable(ItemId) {
    var UserCategoryId = $("#SearchUserCategory").val();
    var JobTitleId = $("#SearchJobTitle").val();
    var UserId = $("#SearchUser").val();
    Metronic.blockUI({
        target: '.item-table'
    });
    $.ajax(
        {
            type: "GET",
            url: itemTableUrl,
            data: { UserCategoryId: UserCategoryId, JobTitleId: JobTitleId, UserId: UserId, ItemId: ItemId },
            success: function (data) {
                $(".item-table").html(data);
                BuildQuantityEditable();
                BuildWeightEditable();
                Metronic.unblockUI('.item-table');
            },
        });
}



function BuildQuantityEditable() {
    $('.Standard_Quantity').editable({
        emptytext: emptyQuantityLoc,
        validate: function (value) {
            if (value.IsContinuous == 'false' && !value.Quantity) return validationEditable;
        },
        display: function (value) {
            if (!value || !value.IsContinuous) {
                $(this).empty();
                return;
            }
            if (value.IsContinuous.toLowerCase() == 'true') {
                $(this).html(isContinuousLoc);
            } else {
                $(this).html(value.Quantity);
            }
        },
        error: function (response, newValue) {
            var error = $.parseHTML(response.responseText);
            swal({
                title: 'error',
                content: error,
                icon: "error",
                html: true,
                buttons: {
                    close: {
                        text: unsuccessOkButton
                    }
                }
            });
        }
    });
}


(function ($) {
    "use strict";
    var StandardQuantity = function (options) {
        this.init('standardQuantity', options, StandardQuantity.defaults);
    };

    //inherit from Abstract input
    $.fn.editableutils.inherit(StandardQuantity, $.fn.editabletypes.abstractinput);

    $.extend(StandardQuantity.prototype, {
        /**
        Renders input from tpl

        @method render() 
        **/
        render: function () {

            this.$input = this.$tpl.find('input');
        },

        /**
        Default method to show value in element. Can be overwritten by display option.
        
        @method value2html(value, element) 
        **/
        value2html: function (value, element) {
            if (!value) {
                $(element).empty();
                return;
            }
            //var html = $('<div>').text(value.IsContinuous).html() + ', ' + $('<div>').text(value.Quantity).html() + ' st., bld. ' + $('<div>').text(value.building).html();
            //$(element).html(html);
        },

        /**
        Gets value from element's html
        
        @method html2value(html) 
        **/
        html2value: function (html) {
            /*
              you may write parsing method to get value by element's html
              e.g. "Moscow, st. Lenina, bld. 15" => {IsContinuous: "Moscow", Quantity: "Lenina", building: "15"}
              but for complex structures it's not recommended.
              Better set value directly via javascript, e.g. 
              editable({
                  value: {
                      IsContinuous: "Moscow", 
                      Quantity: "Lenina", 
                      building: "15"
                  }
              });
            */
            return null;
        },

        /**
         Converts value to string. 
         It is used in internal comparing (not for sending to server).
         
         @method value2str(value)  
        **/
        value2str: function (value) {
            var str = '';
            if (value) {
                for (var k in value) {
                    str = str + k + ':' + value[k] + ';';
                }
            }
            return str;
        },

        /*
         Converts string to value. Used for reading value from 'data-value' attribute.
         
         @method str2value(str)  
        */
        str2value: function (str) {
            /*
            this is mainly for parsing value defined in data-value attribute. 
            If you will always set value by javascript, no need to overwrite it
            */
            return str;
        },

        /**
         Sets value of input.
         
         @method value2input(value) 
         @param {mixed} value
        **/
        value2input: function (value) {
            if (!value) {
                return;
            }
            var IsContinuousSet = (value.IsContinuous.toLowerCase() == 'true');
            this.$input.filter('[name="IsContinuous"]').prop('checked', IsContinuousSet);
            this.$input.filter('[name="Quantity"]').val(value.Quantity);
            IsContinuousFlag(this.$input.filter('[name="IsContinuous"]'));
        },

        /**
         Returns value of input.
         
         @method input2value() 
        **/
        input2value: function () {
            return {
                IsContinuous: String(this.$input.filter('[name="IsContinuous"]').is(":checked")),
                Quantity: this.$input.filter('[name="Quantity"]').val(),
                TargetCategory: $("#TargetCategory").val(),
                ValueJson: this.options.scope.dataset.value,
            };
        },

        /**
        Activates input: sets focus on the first field.
        
        @method activate() 
       **/
        activate: function () {
            this.$input.filter('[name="Quantity"]').focus();
        },

        /**
         Attaches handler to submit form in case of 'showbuttons=false' mode
         
         @method autosubmit() 
        **/
        autosubmit: function () {
            this.$input.keydown(function (e) {
                if (e.which === 13) {
                    $(this).closest('form').submit();
                }
            });
        }
    });

    StandardQuantity.defaults = $.extend({}, $.fn.editabletypes.abstractinput.defaults, {
        tpl: '<div class="editable-standard-isContinuous"><label><span>' + isContinuousLoc + ': </span><input id="IsContinuous" onchange="IsContinuousFlag(this)" name="IsContinuous"   type="checkbox"><b></b></label></div>' +
            '<div class="editable-standard-Quantity"><label><span>' + quantityLoc + ': </span><input type="text" name="Quantity" class="input-small"></label></div>',
        inputclass: ''
    });

    $.fn.editabletypes.standardQuantity = StandardQuantity;

}(window.jQuery));




function BuildWeightEditable() {
    //$('.Standard_Weight').editable('option', 'validate', function (value) {
    //    if (!value)
    //        return ValidationWeightRequired;
    //    if (isNaN(value)) 
    //        return ValidationWeightNumber;

    //});



    $('.Standard_Weight').editable({
        validate: function (value) {
            if (!value)
                return ValidationWeightRequired;
            if (isNaN(value))
                return ValidationWeightNumber;
        },
        success: function (response, newValue) {
            if (response) {
                return response;
            }
        }
    });
}



function IsContinuousFlag(thisCheckbox) {
    var quantityDiv = $(thisCheckbox).parent().parent().parent().find('.editable-standard-Quantity');
    var isChecked = $(thisCheckbox).is(":checked");
    if (isChecked) {
        quantityDiv.css('visibility', 'hidden');
    }
    else {
        quantityDiv.css('visibility', 'visible');
    }
}