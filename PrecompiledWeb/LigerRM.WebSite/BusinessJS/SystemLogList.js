//相对路径
var rootPath = "../";
//列表结构
var grid = $("#maingrid").ligerGrid({
    columns: [{ display: "日志序号", name: "LogID", width: 80, type: "text", align: "left" },
                    { display: "操作用户", name: "EditUser", width: 150, type: "text", align: "left" },
                    { display: "操作时间", name: "EditTime", width: 150, type: "date", align: "left", format: "yyyy-MM-dd hh:mm:ss" },
                    { display: "操作内容", name: "EditContent", width: 300, type: "text", align: "left"},
                    { display: "类别", name: "EditType", width:120, type: "text", align: "left" }
],
    dataAction: 'server', pageSize: 20, toolbar: null,
    rownumbers: true,
    rowHeight: 35,
    url: rootPath + 'handler/grid.ashx?view=Systme_LogView', sortName: 'LogID',sortorder:'desc',
    width: '98%', height: '100%', heightDiff: -10, checkbox: false, selectRowButtonOnly: true
});

//搜索表单应用ligerui样式
$("#formsearch").ligerForm({
    fields: [{ display: "操作用户", name: "EditUser", newline: false, labelWidth: 70, width: 100, space: 30, type: "text", cssClass: "field" },
              { display: "开始时间", name: "EditTime", newline: false, labelWidth: 70, width: 100, space: 30, type: "date", cssClass: "field",
                  attr: {
                      op: "greaterorequal"
                  }
              },
            { display: "结束时间", name: "EditTimeTo", newline: false, labelWidth: 70, width: 100, space: 30, type: "date", cssClass: "field",
                attr: {
                    op: "lessorequal"
                }
            },
                        { display: "操作类别", name: "EditType", newline: false, labelWidth: 70, width: 100, space: 30, type: "text", cssClass: "field"
            }
],
    toJSON: JSON2.stringify
});
//增加搜索按钮,并创建事件
LG.appendSearchButtons("#formsearch", grid);

function f_reload() {
    grid.loadData();
}
