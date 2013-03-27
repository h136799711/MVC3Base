/// <reference path="jquery/1.9.1-vsdoc.js" />

$.extend($.mvc, { ajaxLink: {
    change: function () {
        var settings = arguments[0] || {};
        settings.attr = settings.attr || "ajaxLinkDisable";
        settings.container = settings.container || "main-body";

        $("a." + settings.attr).each(function (index, item) {

            $(item).bind("click", { href: $(item).attr("href"), type: $(item).hasClass("ajaxGet") ? "get" : "post" }, function (event) {
                if (event.preventDefault)
                    event.preventDefault();
                else if (event.stopPropagation)
                    event.stopPropagation();
                else
                    window.event.returnValue = false;
                $.mvc.LoadView(event.data.href, {
                    container: settings.container
                });
            });
            $(item).removeClass(settings.attr).addClass("ajaxLinkEnable");
        });

        $("form.ajaxFormDisable").each(function (index, item) {
            var submit = $(item).find("input:submit");
            if (submit.length == 0) return;

            $(submit[0]).bind("click", { href: $(item).attr("action"), type: $(item).attr("method") }, function (event) {
                //阻止默认浏览器动作(W3C) 
                if (event.preventDefault)
                    event.preventDefault();
                else if (event.stopPropagation)
                    event.stopPropagation();
                else
                    window.event.returnValue = false;

                $.mvc.LoadView(event.data.href, {
                    type: event.data.type,
                    container: settings.container
                });
            });
            $(item).removeClass("ajaxFormDisable").addClass("ajaxFormEnable");
        });

    }
}
});


//sysxcode

$.extend($.mvc, { sysxcode: {
    LoadPrimaryNav: function (id, settings) {
        var id = id;
        $.mvc.sysxcode.LoadSubNav({ data: { id: id} },
        {
            action: "AdminNav",
            controller: "SysXCode",
            success: function (data, textStatus) {
                $("#" + id).empty();
                if (data.length == 0) {
                    data[0] = { empty: true };
                }
                $("#" + id).html($("#PrimaryNavTemplate").render({ innerData: data }));
                $("#" + id + " a").each(function (index, item) {
                    if (index == data.length - 1) {
                        $(item).attr("class", "defaultLoad");
                    }
                    $(item).bind("click", { id: settings.containerID, xid: data[index].XID }, function (params) {
                        $("a.defaultLoad").removeClass("navclick").removeClass("defaultLoad");
                        $(this).addClass("navclick").addClass("defaultLoad");
                        if (settings.callback && typeof (settings.callback) == "function") {
                            settings.callback(params);
                        }
                    });
                });

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $("#" + id).html("请求失败，<a href='' onclick='LoadPrimaryNav()'> 点击重试 </a> ");
            },
            complete: function (XMLHttpRequest, textStatus) {
                $("a.defaultLoad").trigger("click");
            }
        });
    },
    LoadSubNav: function (params, settings) {
        var id = "#";
        if (typeof (params.data.id) != "string") {
            id = params.data.id;            // 元素
        } else {
            id = id + params.data.id;      // 元素ID
        }
        var settings = settings || {};
        settings.tmpl = settings.tmpl || "SubNavTemplate"; //渲染模板
        settings.type = settings.type || "post"; // 请求类型
        settings.subnav = settings.subnav || " a"; // 对此类型元素绑定click事件
        settings.action = settings.action || "SubNavOf";
        settings.controller = settings.controller || "SysXCode";
        settings.area = settings.area || "Main";

        $.mvc.ajax({
            type: settings.type,
            action: settings.action,
            controller: settings.controller,
            area: settings.area,
            params: { ID: params.data.xid }, // ID 参数
            beforeSend: settings.beforeSend || function (XMLHttpRequest) {
                $(id).html("<img src='/images/loading2.jpg' title='载入中'/>");
            },
            success: settings.success || function (data, textStatus) {
                if (!data && !data.length) {
                    $(id).html("服务器返回数据错误，<a href='' onclick='LoadSubNav(" + params.data.XID + ")'> 点击重试 </a> ");

                    return;
                }
                if (data.code) {
                    $(id).html(data.message);
                    return;
                }

                $(id).empty();
                try {
                    $(id).accordion("destroy");
                } catch (e) {
                }
                if (data.length == 0) {
                    data[0] = { empty: true };
                }

                $(id).html($("#" + settings.tmpl).render(data));
                $(id + settings.subnav).each(function (index, item) {
                    $(item).bind("click", { id: $(item).next(), xid: data[index].XID }, function (params) {

                        if (settings.callback && typeof (settings.callback) == "function") {
                            settings.callback(params);
                        }
                    });
                });
                $(id).accordion({
                    create: function (event, ui) {
                        ui.header.trigger("click");
                    },
                    activate: function (event, ui) {
                        //$(id).accordion("refresh");
                    },
                    heightStyle: "content"
                });

            },
            error: settings.error || function (XMLHttpRequest, textStatus, errorThrown) {
                $(id + settings.subnav).find("div").html("请求失败，<a href='' onclick='LoadSubNav(" + params.data.xid + ")'> 点击重试 </a> ");
            },
            complete: settings.complete
        });
    },
    LoadThirdNav: function (params, settings) {
        var settings = settings;
        var id = params.data.id;
        $.mvc.sysxcode.LoadSubNav(params,
        {
            success: function (data, textStatus) {
                if (data && data.code) {
                    $(id).html(data.message);
                    return;
                }
                $(id).html($("#" + settings.tmpl).render({ innerData: data }));
                if (settings.callback && typeof (settings.callback) == "function") {
                    settings.callback();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $(id).html("请求失败 ");
            }
        });
    }
}
});