//相对路径
var rootPath = "../";
//列表结构
var grid2 = $("#Div1").ligerGrid({
    columns: [{ display: "编号", name: "SpecialId", width: 50, type: "text", align: "left" },
                { display: "标题名称", name: "TypeName", width: 100, type: "textarea", align: "left" },
                { display: "单一元素名称", name: "Name", width: 200, type: "text", align: "left" },
                { display: "描述", name: "Describe", width: 200, type: "text", align: "left" },
                { display: "图片地址", name: "ImageUrl", width: 200, type: "text", align: "left" },
                { display: "图片占比", name: "imageSize", width: 100, type: "text", align: "left" },
                { display: "所属城市", name: "cityName", width: 100, type: "text", align: "left" },
                { display: "省编号", name: "provinceid", width: 100, type: "text", align: "left" },
                { display: "城市编号", name: "cityId", width: 100, type: "text", align: "left" },
                { display: "当前排序", name: "sortId", width: 60, type: "text", align: "central" },
                { display: "编辑排列", name: "sortId", width: 100, type: "text", align: "left", 
                columns:[
                { display: "置顶", name: '置顶', align: 'central', width: 50,
                    render: function (record, rowindex, value, column) 
                    {
                        return '<input type="image" id = "front" name = "front" src="../lib/icons/function_icon_set/arrow_up_48.png" />';
                    } 
                 },
                { display: "末端", name: '末端', align: 'central', width: 50,
                    render: function (record, rowindex, value, column) {
                        return '<input type="image" id = "end" name = "end" src="../lib/icons/function_icon_set/arrow_down_48_2.png" />';
                    }                
                 },
                { display: "上移", name: '上移', align: 'central', width: 50,
                    render: function (record, rowindex, value, column) {
                        return '<input type="image" id = "end" name = "end" src="../lib/icons/function_icon_set/arrow_up_green_48.png" />';
                    } 
                 },
                { display: "下移", name: '下移', align: 'central', width: 50,
                    render: function (record, rowindex, value, column) {
                        return '<input type="image" id = "end" name = "end" src="../lib/icons/function_icon_set/arrow_down_green_48_2.png" />';
                    } 
                 }
                ]}],

    dataAction: 'server', pageSize: 6, toolbar: {},
    url: rootPath + 'handler/grid.ashx?view=AppHome_SpecialInfo', sortName: 'SpecialId',
    width2: '98%', height2: '60%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
    selectRowButtonOnly: true
//    &idfield=cityId&textfield=cityId&distinct=true&needAll=1&&where={"op":"and","rules":[{"op":"equal","field":"cityId","value":"120100","type":"string"}]}
});

//加载toolbar
LG.loadToolbar(grid2, toolbarBtnItemClick);

//双击事件
LG.setGridDoubleClick(grid2, 'modify');

//工具条事件
function toolbarBtnItemClick(item) {
    switch (item.id) {
        case "add":
            wopen('sepcialEdit.aspx?SpecialId=0', '新增特色', '1200', '870');
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


//搜索表单应用ligerui样式
$("#formsearch").ligerForm({
    fields: [
                { display: "所属城市", name: "cityName", newline: false, labelWidth: 80, width: 120, space: 20, type: "text", cssClass: "field" }
            ],
    toJSON: JSON2.stringify
});

//增加搜索按钮,并创建事件
LG.appendSearchButtons("#formsearch", grid2);




