
//以下是ligerUI的列表写法。 其中add modify delete等都是id 属于管理页面展示。
//相对路径
var rootPath = "../";
//列表结构
var grid = $("#maingrid").ligerGrid({
    columns: [{ display: "编号", name: "BannerId", width: 50, type: "text", align: "left" },
                { display: "类型", name: "BannerType", width: 50, type: "textarea", align: "left" },
                { display: "图片地址", name: "ImageUrl", width: 200, type: "text", align: "left" },
                { display: "地址", name: "Url", width: 200, type: "text", align: "left" },
                { display: "描述", name: "Describe", width: 300, type: "text", align: "left" },
                { display: "添加人编号", name: "AddUser", width: 100, type: "text", align: "left" },
                { display: "添加时间", name: "AddTime", width: 150, type: "date", align: "left"}],
   
    dataAction: 'server', pageSize: 10, toolbar: {},
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
        case "add":
            //top.f_addTab(null, '增加客户信息', 'CustomerManage/CustomersDetail.aspx');
<<<<<<< HEAD
            wopen('AppHomeEdit.aspx?BannerId=&type=E', '新增头部轮播图', '1200', '870');
=======
            wopen('AppHomeEdit.aspx?BannerId=0', '新增房源', '1200', '870');
>>>>>>> 864e080041293c34e12c9fac267b55a50e2086bc
            break;
        case "view":
            var selected = grid.getSelected();
            wopen('AppHomeEdit.aspx?BannerId=' + selected.BannerId, '编辑APP首页轮播图', '1200', '870');
            break;
        case "modify":
            var selected = grid.getSelected();
<<<<<<< HEAD
            if (!selected) { LG.tip('请选择行!'); return }
            LG.ajax({
                type: 'AjaxPage',
                method: 'GetEncryptString',
                loading: '正在获取中...',
                data: { sourceStr: selected.BannerId },
                success: function (data) {
                    wopen('AppHomeEdit.aspx?RentNo=' + data + '&type=E', '修改房源信息', '700', '570');
                },
                error: function (message) {
                }
            });
=======
            wopen('AppHomeEdit.aspx?BannerId=' + selected.BannerId, '编辑APP首页轮播图', '1200', '870');
>>>>>>> 864e080041293c34e12c9fac267b55a50e2086bc
            break;
        case "delete":
            var selected = grid.getSelected();
            jQuery.ligerDialog.confirm('确定删除吗?', function (confirm) {
                if (confirm)
                $.ajax({
                    cache: false,
                    async: false,
                    type: 'post',
                    dataType: 'json',
                    data: { "type": "DeleteBanner", "BannerId": selected.BannerId },
                    url: "/AppUpSetAshx/ajax.ashx",
                    success: function (data) {
                        if (data.Code == "0") {
                            LG.showSuccess(data.Msg);
                            grid.loadData();
                        } else {
                            LG.showSuccess(data.Msg);
                        }
                    }
                });
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