//相对路径
var rootPath = "../";
//列表结构
var grid2 = $("#Div1").ligerGrid({
    columns: [{ display: "编号", name: "SpecialId", width: 50, type: "text", align: "left" },
                { display: "类型名称", name: "TypeName", width: 100, type: "textarea", align: "left" },
                { display: "类别编号", name: "ClassId", width: 200, type: "text", align: "left" },
                { display: "名称", name: "Name", width: 200, type: "text", align: "left" },
                { display: "描述", name: "Describe", width: 200, type: "text", align: "left" },
                { display: "图片地址", name: "ImageUrl", width: 200, type: "text", align: "left" },
                { display: "图片占比", name: "imageSize", width: 100, type: "text", align: "left" },
                { display: "排序编号", name: "sortId", width: 100, type: "text", align: "left" },
                { display: "省编号", name: "provinceid", width: 100, type: "text", align: "left" },
                { display: "城市编号", name: "cityId", width: 100, type: "text", align: "left"}],

    dataAction: 'server', pageSize: 6, toolbar: {},
    url: rootPath + 'handler/grid.ashx?view=AppHome_SpecialInfo', sortName: 'SpecialId',
    width: '98%', height: '40%', heightDiff: -10, checkbox: true, fixedCellHeight: true, rowHeight: 26,
    selectRowButtonOnly: true
});

//加载toolbar
LG.loadToolbar(grid2, toolbarBtnItemClick);

//双击事件
LG.setGridDoubleClick(grid2, 'modify');

//工具条事件
function toolbarBtnItemClick(item) {
    switch (item.text) {
        case "add":
            wopen('sepcialEdit.aspx?', '新增特色', '1200', '870');
            break;
     }

 }