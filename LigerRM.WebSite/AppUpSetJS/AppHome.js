

//相对路径
var rootPath = "../";
//列表结构
var grid = $("#maingrid").ligerGrid({
    columns: [{ display: "编号", name: "BannerId", width: 100, type: "text", align: "left" },
                { display: "类型", name: "BannerType", width: 200, type: "textarea", align: "left" },
                { display: "图片地址", name: "ImageUrl", width: 50, type: "text", align: "left" },
                { display: "地址", name: "Url", width: 150, type: "text", align: "left" },
                { display: "描述", name: "Describe", width: 150, type: "text", align: "left"}],
   
    dataAction: 'server', pageSize: 3, toolbar: {},
    url: rootPath + 'handler/grid.ashx?view=AppHome_Banner', sortName: 'BannerId',
    width: '98%', height: '30%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
    selectRowButtonOnly: true
});

//双击事件
LG.setGridDoubleClick(grid, 'modify');





//加载toolbar
LG.loadToolbar(grid, toolbarBtnItemClick);

//工具条事件
function toolbarBtnItemClick(item) {
    switch (item.id) {
        case "modify":
            //top.f_addTab(null, '增加客户信息', 'CustomerManage/CustomersDetail.aspx');
            wopen('AppHomeEdit.aspx?RentNo=&type=E', '新增房源', '1200', '870');
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
        case "modify1":

            var selected = grid.getSelected();
            if (!selected) { LG.tip('请选择行!'); return }
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: selected.RentNO },
                success: function (data) {
                    wopen('AppHomeEdit.aspx?RentNo=' + data + '&type=E', '修改房源信息', '700', '570');
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