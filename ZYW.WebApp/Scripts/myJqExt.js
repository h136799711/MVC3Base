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


$.extend({ mvc: {
    _ajax: $.ajax,
    /// <summary>
    ///     封装jquery的ajax，适合于MVC
    /// </summary>
    ///	<param name="setting" type="Object">
    ///		1: action - 同MVC中的action.
    ///		2: controller - 同MVC中的controller.
    ///     3: area - 同MVC中的area.
    ///		4: callback - 当成功获取时调用.
    ///     5：type - 默认为post，同jquery的type.
    ///		6: params - 发送到服务器的数据，同jquery的data.
    ///     7: beforeSend - 同Jquery，发送前调用
    ///     8: complete - 同Jquery，完成时调用
    ///     9: error - 同Jquery，出错时调用
    ///     10: sucess -同Jquery，成功时调用
    ///	</param>
    ajax: function (settings) {
        settings = settings || {};
        var action = settings.action || '_404';
        var controller = settings.controller || 'Error';
        var area = settings.area || '';
        if (area != '') {
            area = '/' + area;
        }
        var type = settings.type || "post";
        var params = settings.params || '';
        var url = area + '/' + controller + '/' + action;
        if (settings.url) {
            url = settings.url;
        }
        $.mvc._ajax(url, {
            type: type,
            data: params,
            beforeSend: settings.beforeSend || function (XMLHttpRequest) {
                console.log("beforeSend");
            },
            complete: settings.complete || function (XMLHttpRequest, textStatus) {
                console.log("complete");
            },
            error: settings.error || function (XMLHttpRequest, textStatus, errorThrown) {
                console.log("error");
            },
            success: settings.success || function (data, textStatus) {
                console.log("success");
            }
        });
    },
    LoadView: function (link, settings) {
        settings = settings || {};
        var container = "#" + settings.container;
        $.mvc.ajax({
            url: link,
            beforeSend: settings.beforeSend || function (XMLHttpRequest) {
                $(container).html("<img src='/images/loading2.jpg' title='载入中'/>");
            },
            error: settings.error || function (XMLHttpRequest, textStatus, errorThrown) {
                $(container).html("获取失败");
            },
            success: settings.success || function (data, textStatus) {
                if (data.code) {
                    $(container).html(data.message);
                    return;
                }
                $(container).html(data);
            }
        });
    }
}
});