var $mvc3 = $mvc3 || {};
$mvc3.main = $mvc3.main || {};

$mvc3.main.sysxcode = (function ($) {
    if (typeof ($) == "undefined" && typeof ($(document).datagrid) == "undefined") {
        throw new Error("未载入jquery与easyui脚本");
    }
    function list(id, queryData) {

        $("#" + id).datagrid({
            onBeforeLoad: function (params) {
                $.extend(params, {
                    pageNumber:
                    $("#" + id).datagrid('options').pageNumber,
                    pageSize:
                    $("#" + id).datagrid('options').pageSize
                });
                console.log(params);
                return true;
            },
            title: '编码管理',
            url: '/Main/SysXCode/PagingList',
            sortName: "ID",
            sortOrder: "asc",
            remoteSort: false,
            pagination: true,
            rownumbers: true,
            pageList: [10, 20,30, 50],
            queryParams: queryData,
            fit: true,
            columns: [[
                    //XID, XName, XCode, XDepth, XOrderNumber, XSource, XRemark, XFlag
					{field: 'XID', title: 'ID',  sortable: true },
					{ field: 'XName', title: '名称',  sortable: true },
                    { field: 'XCode', title: "编码",  sortable: true },
                    { field: 'XDepth', title: "深度",  sortable: true },
                    { field: 'XOrderNumber', title: "排序号",  sortable: true },
                    { field: 'XSource', title: "来源",  sortable: true },
                    { field: 'XRemark', title: "备注",  sortable: true },
                    { field: 'XFlag', title: "启用",  sortable: true }
                ]],
            toolbar: [{
                id: 'btnadd',
                text: '添加',
                iconCls: 'icon-add',
                handler: function () {
                    //实现弹出添加用户信息的层
                    //ShowCreateUserRoleDialog();
                }
            }, '-', {
                id: 'btncut',
                text: '修改',
                iconCls: 'icon-cut',
                handler: function () {
                    //实现弹出修改用户信息的层
                    //ShowUpdateUserRoleDialog();
                }
            }, '-', {
                id: 'btnsave',
                text: '删除',
                iconCls: 'icon-remove',
                handler: function () {
                    //确认只删除一条用户信息
                    //DeleteUserRoleInfoByClick();
                }
            }]
        });
    }

    return {
        list: list
    };
})($);