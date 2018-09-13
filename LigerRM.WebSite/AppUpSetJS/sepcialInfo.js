//相对路径
var rootPath = "../";
//列表结构
var grid2 = $("#Div1").ligerGrid({
    columns: [{ display: "编号", name: "SpecialId", width: 50, type: "text", align: "left" },
                { display: "标题名称", name: "TypeName", width: 100, type: "textarea", align: "left" },
                { display: "显示顺序", name: "sortId", width: 100, type: "text", align: "left" },
                { display: "单一元素名称", name: "Name", width: 200, type: "text", align: "left" },
                { display: "描述", name: "Describe", width: 200, type: "text", align: "left" },
                { display: "图片地址", name: "ImageUrl", width: 200, type: "text", align: "left" },
                { display: "图片占比", name: "imageSize", width: 100, type: "text", align: "left" },               
                { display: "省编号", name: "provinceid", width: 100, type: "text", align: "left" },
                { display: "城市编号", name: "cityId", width: 100, type: "text", align: "left"}],

    dataAction: 'server', pageSize: 6, toolbar: {},
    url: rootPath + 'handler/grid.ashx?view=AppHome_SpecialInfo', sortName: 'SpecialId',
    width2: '98%', height2: '60%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
    selectRowButtonOnly: true
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