<%@ Page Language="C#" AutoEventWireup="true" CodeFile="houseClass.aspx.cs" Inherits="AppUpSet_houseClass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>房屋类型分类</title> 
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script>
</head>
<body style="padding:10px;height:100%; text-align:center;">
   <input type="hidden" id="MenuNo" value="Rent" />
  <div id="mainsearch" style="width:98%;">
    <div class="searchtitle">
        <span>搜索</span><img src="../lib/icons/32X32/searchtool.gif" />
        <div class="togglebtn"></div> 
    </div>
    <div class="navline" style="margin-bottom:4px; margin-top:4px;"></div>
    <div class="searchbox">
        <form id="formsearch" class="l-form"></form>
    </div>
  </div>
  <div id="maingrid"></div> 

</body>
</html>

<script>


    //相对路径
    var rootPath = "../";
    //列表结构
    var grid = $("#maingrid").ligerGrid({
        columns: [{ display: "分类编号", name: "classId", width: 50, type: "text", align: "left" },
                { display: "分类级层", name: "lvlId", width: 50, type: "textarea", align: "left" },
                { display: "分类名称", name: "class_Name", width: 150, type: "text", align: "central" },
                { display: "分类图片地址", name: "imageUrl", width: 200, type: "text", align: "left" },
                { display: "分类描述", name: "description", width: 400, type: "text", align: "left"}],
        dataAction: 'server', pageSize: 20, toolbar: {},
        url: rootPath + 'handler/grid.ashx?view=appHouse_Class', sortName: 'classId',
        width: '98%', height: '100%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
        selectRowButtonOnly: true
    });

    //双击事件
    LG.setGridDoubleClick(grid, 'modify');

    //搜索表单应用ligerui样式
    $("#formsearch").ligerForm({
        fields: [
                { display: "分类编号", name: "classId", newline: false, labelWidth: 80, width: 50, space: 20, type: "text", cssClass: "field" },
                { display: "分类级层", name: "lvlId", newline: false, labelWidth: 80, width: 50, space: 20, type: "text", cssClass: "field" },


//              {
//                    display: "所属警局", name: "所属警局", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
//                    options: {
//                        url: '../handler/select.ashx?view=Rent_PoliceStation&idfield=PSName&textfield=PSName&distinct=true&needAll=1&&where={"op":"and","rules":[{"op":"equal","field":"ParentID","value":"0","type":"string"}]}',
//                        initValue: '全部', valueFieldID: 'RPSParentName', selectBoxWidth: '160'
//                    }
//                },


                 {
                 display: "分类名称", name: "分类名称", newline: false, labelWidth: 80, width: 150, space: 20, type: "select", cssClass: "field",
                     options: {
                         url: '../handler/select.ashx?view=appHouse_Class&idfield=class_Name&textfield=class_Name&distinct=true&needAll=1',
                         initValue: '全部', valueFieldID: 'class_Name', selectBoxWidth: '150'
                     }
                 },
//                { display: "社区名称", name: "社区名称", newline: false, labelWidth: 100, width: 160, space: 20, type: "select", cssClass: "field",
//                    options: {
//                        url: '../handler/select.ashx?view=Rent_Road&idfield=LRName&textfield=LRName&distinct=true&needAll=1',
//                        initValue: '全部', valueFieldID: 'RRName'
//                    }
//                },
                {display: "创建分类日期", name: "createTime", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "greaterorequal"
                    }
                },
                {
                    display: "更新分类日期", name: "updateTime", newline: false, labelWidth: 100, width: 160, space: 20, type: "date", cssClass: "field",
                    attr: {
                        op: "greaterorequal"
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
                wopen('classDetail.aspx?RentNo=&type=E', '新增房源', '700', '570');
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
</script>
