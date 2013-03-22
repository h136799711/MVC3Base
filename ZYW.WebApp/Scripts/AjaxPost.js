/// <reference path="jquery/1.9.1-vsdoc.js" />

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

        $.mvc.ajax({
            type: settings.type,
            action: settings.action,
            controller: settings.controller,
            params: { ID: params.data.xid }, // ID 参数
            beforeSend:settings.beforeSend || function (XMLHttpRequest) {
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
                        $(id).accordion("refresh");
                    },
                    heightStyle: "content"
                });

            },
            error:settings.error || function (XMLHttpRequest, textStatus, errorThrown) {
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
                //找到a元素
                $(id).parent().find("a").each(function (index, item) {
                    $(item).bind("click", { link: $(item).attr("data-link") }, function (event) {
                        $.mvc.sysxcode.LoadView(event.data.link, { containerID: "main-body" });
                    });
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $(id).html("请求失败 ");
            }
        });
    },
    LoadView: function (link, settings) {
        settings = settings || {};
        var id = "#" + settings.containerID;
        console.log(link);
        $.mvc.ajax({
            url: link,
            beforeSend: settings.beforeSend || function (XMLHttpRequest) {
                $(id).html("<img src='/images/loading2.jpg' title='载入中'/>");
            },
            error: settings.error || function (XMLHttpRequest, textStatus, errorThrown) {
                $(id).html("获取失败");
            },
            success: settings.success || function (data, textStatus) {
                if (data.code) {
                    $(id).html(data.message);
                    return;
                }
                $(id).html(data);
            }
        });
    }
}
});