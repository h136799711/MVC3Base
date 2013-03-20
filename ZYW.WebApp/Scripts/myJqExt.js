/// <reference path="jquery/1.9.1-vsdoc.js" />

$.extend({
    validatorModify: function () {
        $.validator.setDefaults({
            //光标移出时
            onfocusout: function (element) {
                this.element(element);
            },
            //光标移入时
            onfocusin: function (element, event) {
                //找到显示错误提示的标签并移除,针对jquery.validate.unobtrusive
                var errorElement = $(element).next('span.field-validation-error');
                if (errorElement) {
                    errorElement.children().remove();
                }
            },
            onkeyup: function (element, event) {
            }
        });
    }
});