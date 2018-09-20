

//相对路径
var rootPath = "../";
//列表结构
var grid = $("#maingrid").ligerGrid({
    columns: [{ display: "房源编号", name: "RentNO", width: 100, type: "text", align: "left" },
        { display: "具体地址", name: "RAddress", width: 400, type: "textarea", align: "left" },
        { display: "房主姓名", name: "ROwner", width: 100, type: "text", align: "left" },
        { display: "房主电话", name: "ROwnerTel", width: 100, type: "text", align: "left" },
        { display: "租赁人", name: "RRAContactName", width: 100, type: "text", align: "left" },
        { display: "身份证号码", name: "RRAIDCard", width: 200, type: "text", align: "left" },
        { display: "联系电话", name: "RRAContactTel", width: 100, type: "text", align: "left" },
        { display: "开始日期", name: "RRAStartDate", width: 100, type: "date", align: "left" },
        { display: "结束日期", name: "RRAEndDate", width: 100, type: "date", align: "left" }
        ],
    dataAction: 'server', pageSize: 20, toolbar: {},
    url: rootPath + 'handler/grid.ashx?view=v_RentHistory_view', sortName: 'RRACreatedDate',
    width: '98%', height: '100%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
    selectRowButtonOnly: true, sortOrder: 'desc'
});

//双击事件
LG.setGridDoubleClick(grid, 'modify');

//搜索表单应用ligerui样式
$("#formsearch").ligerForm({
    fields: [
        { display: "房源编号", name: "RentNO", newline: false, labelWidth: 100, width: 100, space: 20, type: "text", cssClass: "field" },
        { display: "具体地址", name: "RAddress", newline: false, labelWidth: 100, width: 160, space: 20, type: "text", cssClass: "field" },
        //姓名查询事件
        {display: "姓名", name: "RRAContactName", newline: false, labelWidth: 60, width: 100, space: 20, type: "text", cssClass: "field" },
<<<<<<< HEAD
        { display: "身份证号", name: "RRAIDCard", newline: false, labelWidth: 60, width: 180, space: 20, type: "text", cssClass: "field" },
=======
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
        {
            display: "所属区域", name: "所属区域", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
            options: {
                url: '../handler/select.ashx?view=Rent_District&idfield=LDName&textfield=LDName&distinct=true&needAll=1',
                initValue: '全部', valueFieldID: 'RDName', selectBoxWidth: '100'
            }
        },
        {
            display: "社区名称", name: "社区名称", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
            options: {
                url: '../handler/select.ashx?view=Rent_Road&idfield=LRName&textfield=LRName&distinct=true&needAll=1',
                initValue: '全部', valueFieldID: 'RRName'
            }
        },
        {
            display: "创建开始日期", name: "RCreatedDate", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
            attr: {
                op: "greaterorequal"
            }
        },
        {
            display: "创建结束日期", name: "RCreatedDate1", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
            attr: {
                op: "lessorequal"
            }
        }
    ],
    toJSON: JSON2.stringify
});

//增加搜索按钮,并创建事件
LG.appendSearchButtons("#formsearch", grid);

//加载toolbar
LG.loadToolbar(grid, toolbarBtnItemClick);

//工具条事件
function toolbarBtnItemClick(item) {
    switch (item.id) {
        case "add":
            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return }
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: selected.RRAID },
                success: function (data) {
                    //wopen('RentInfoAdd.aspx?RentNo=' + data + '&type=A', '租赁信息增加', '750', '400');
                    $.ligerDialog.open({ height: 500, width: 750, url: 'RentInfoAdd.aspx?RentNo=' + data + '&type=A', title: '租赁信息增加' });
                },
                error: function (message) {
                }
            });
            break;
        case "modify":
            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return }
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: selected.RRAID },
                success: function (data) {
                    //wopen('RentInfoAdd.aspx?RentNo=' + data + '&type=E', '租赁信息修改', '750', '400');
                    $.ligerDialog.open({ height: 500, width: 750, url: 'RentInfoAdd.aspx?RentNo=' + data + '&type=E', title: '租赁信息修改' });
                },
                error: function (message) {
                }
            });
            break;
        case "delete":
            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return }
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: selected.RRAID },
                success: function (data) {
                    //wopen('RentInfoAdd.aspx?RentNo=' + data + '&type=D', '退房', '750', '400');
                    $.ligerDialog.open({ height: 500, width: 750, url: 'RentInfoAdd.aspx?RentNo=' + data + '&type=D', title: '退房信息' });
                },
                error: function (message) {
                }
            });
            break;
        case "view":
            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return }
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: selected.RRAID },
                success: function (data) {
//                    wopen('RentInfoAdd.aspx?RentNo=' + data + '&type=V', '查看租赁信息', '750', '400');
                    $.ligerDialog.open({ height: 500, width: 750, url: 'RentInfoAdd.aspx?RentNo=' + data + '&type=V', title: '查看信息' });
                },
                error: function (message) {
                }
            });
            break;
        case "viewRent":
            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return }
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: selected.RentNO },
                success: function (data) {
                    wopen('RentDetail.aspx?RentNo=' + data, '房源信息查询', '800', '600');
                },
                error: function (message) {
                }
            });
            break;
    }
}

function f_reload() {
    grid.loadData();
}

function wopen(pageURL, title, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2) - 20;
    var random = Math.floor(Math.random() * (1000 + 1));
    var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}
