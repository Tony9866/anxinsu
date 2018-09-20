

//相对路径
var rootPath = "../";
//列表结构
var grid = $("#maingrid").ligerGrid({
    columns: [{ display: "房源编号", name: "RentNO", width: 100, type: "text", align: "left" },
                { display: "具体地址", name: "RAddress", width: 200, type: "textarea", align: "left" },
                { display: "是否租赁", name: "IsAvailable", width: 50, type: "text", align: "left" },
                { display: "所属警局", name: "RPSParentName", width: 150, type: "text", align: "left" },
                { display: "所属派出所", name: "RPSName", width: 150, type: "text", align: "left" },
                { display: "社区名称", name: "RRName", width: 150, type: "text", align: "left" },
                { display: "门牌号", name: "RDoor", width: 100, type: "text", align: "left" },
                { display: "房主姓名", name: "ROwner", width: 100, type: "text", align: "left" },
<<<<<<< HEAD
                { display: "房主电话", name: "ROwnerTel", width: 100, type: "text", align: "left" },
                { display: "房主身份证号", name: "RIDCard", width: 200, type: "text", align: "left" },
=======
                { display: "房主电话", name: "ROwnerTel", width: 80, type: "text", align: "left" },
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
                { display: "楼层", name: "RFloor", width: 100, type: "text", align: "left"}],
    dataAction: 'server', pageSize: 20, toolbar: {},
    url: rootPath + 'handler/grid.ashx?view=v_RentDetail_view', sortName: 'RentNO',
    width: '98%', height: '100%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
    selectRowButtonOnly: true
});

//双击事件
LG.setGridDoubleClick(grid, 'modify');

//搜索表单应用ligerui样式
$("#formsearch").ligerForm({
    fields: [
                { display: "房源编号", name: "RentNO", newline: false, labelWidth: 100, width: 100, space: 20, type: "text", cssClass: "field" },
                { display: "具体地址", name: "RAddress", newline: false, labelWidth: 100, width: 160, space: 20, type: "text", cssClass: "field" },
                //姓名查询事件
                {display: "姓名", name: "ROwner", newline: false, labelWidth: 60, width: 100, space: 20, type: "text", cssClass: "field" },
<<<<<<< HEAD
                { display: "身份证号", name: "RIDCard", newline: false, labelWidth: 60, width: 180, space: 20, type: "text", cssClass: "field" },
=======
>>>>>>> 29cbe2b7972511884ac3f729e17ee8077fefb03b
                {
                    display: "所属警局", name: "所属警局", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
                    options: {
                        url: '../handler/select.ashx?view=Rent_PoliceStation&idfield=PSName&textfield=PSName&distinct=true&needAll=1&&where={"op":"and","rules":[{"op":"equal","field":"ParentID","value":"0","type":"string"}]}',
                        initValue: '全部', valueFieldID: 'RPSParentName', selectBoxWidth: '160'
                    }
                },
                 {
                     display: "所属派出所", name: "所属派出所", newline: false, labelWidth: 80, width: 180, space: 20, type: "select", cssClass: "field",
                     options: {
                         url: '../handler/select.ashx?view=Rent_PoliceStation&idfield=PSName&textfield=PSName&distinct=true&needAll=1&&where={"op":"and","rules":[{"op":"notequal","field":"ParentID","value":"0","type":"string"}]}',
                         initValue: '全部', valueFieldID: 'RPSName', selectBoxWidth: '180'
                     }
                 },
                { display: "社区名称", name: "社区名称", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
                    options: {
                        url: '../handler/select.ashx?view=Rent_Road&idfield=LRName&textfield=LRName&distinct=true&needAll=1',
                        initValue: '全部', valueFieldID: 'RRName'
                    }
                },
                { display: "创建开始日期", name: "RCreatedDate", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
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
            //top.f_addTab(null, '增加客户信息', 'CustomerManage/CustomersDetail.aspx');
            wopen('RentDetail.aspx?RentNo=&type=E', '新增房源', '700', '570');
            break;
        case "view":
            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return }
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: selected.RentNO },
                success: function (data) {
                    wopen('RentDetail.aspx?RentNo=' + data, '查看房源信息', '700', '570');
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
                data: { sourceStr: selected.RentNO },
                success: function (data) {
                    wopen('RentDetail.aspx?RentNo=' + data + '&type=E', '修改房源信息', '700', '570');
                },
                error: function (message) {
                }
            });
            break;
        case "delete":
            jQuery.ligerDialog.confirm('确定删除吗?', function (confirm) {
                if (confirm)
                    f_delete();
            });
            break;
        //case "viewRentPerson": 
        //    var selected = grid.getSelected(); 
        //    if (!selected) { LG.tip('请选择行!'); return } 
        //    $.ligerDialog.open({ height: 450, width: 750, url: 'RentAttribute.aspx?RID=' + selected.RentNO, title: '承租人信息' }); 
        //    break; 
        case "viewHistory":
            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return }
            $.ligerDialog.open({ height: 450, width: 850, url: 'RentInfoHistory.aspx?RentNo=' + selected.RentNO + '&type=V', title: '租赁历史信息' });
            break;
        case "export":
            $.ligerDialog.open({ url: "../print.aspx?exporttype=xls" }); return;
            break;
        case "image":
            var rows = grid.getCheckedRows();
            var signetIds = '';
            for (var i = 0, l = rows.length; i < l; i++) {
                signetIds += ",'" + rows[i].se_signet_id + "'";

            }
            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return; }

            top.f_addTab(null, selected.RentNO + '-房源照片', '../RentHouse/RentImageList.aspx?RentNO=' + selected.RentNO);
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
    var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left + ',scrollbars=yes');
}
function f_delete() {
    var selected = grid.getSelected();
    if (selected) {
        LG.ajax({
            type: 'AjaxBaseManage',
            method: 'RemoveRent',
            loading: '正在删除中...',
            data: { ID: selected.RentNO },
            success: function () {
                LG.showSuccess('删除成功');
                f_reload();
            },
            error: function (message) {
                LG.showError(message);
            }
        });
    }
    else {
        LG.tip('请选择行!');
    }
}