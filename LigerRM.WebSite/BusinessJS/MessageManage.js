
      var maingform = $("#mainform");
      $.metadata.setType("attr", "validate");
      LG.validate(maingform, { debug: false });
      //相对路径
      var rootPath = "../";
      Date.prototype.Format = function (fmt) { //author: meizz 
          var o = {
              "M+": this.getMonth() + 1,                 //月份 
              "d+": this.getDate(),                    //日 
              "h+": this.getHours(),                   //小时 
              "m+": this.getMinutes(),                 //分 
              "s+": this.getSeconds(),                 //秒 
              "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
              "S": this.getMilliseconds()             //毫秒 
          };
          if (/(y+)/.test(fmt))
              fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
          for (var k in o)
              if (new RegExp("(" + k + ")").test(fmt))
                  fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
          return fmt;
      }

      $.ligerDefaults.Grid.formatters['currency'] = function (num, column) {
          //num 当前的值
          //column 列信息
          if (!num) return "￥0.00";
          num = num.toString().replace(/\$|\,/g, '');
          if (isNaN(num))
              num = "0.00";
          sign = (num == (num = Math.abs(num)));
          num = Math.floor(num * 100 + 0.50000000001);
          cents = num % 100;
          num = Math.floor(num / 100).toString();
          if (cents < 10)
              cents = "0" + cents;
          for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
              num = num.substring(0, num.length - (4 * i + 3)) + ',' +
         num.substring(num.length - (4 * i + 3));
          return "￥" + (((sign) ? '' : '-') + '' + num + '.' + cents);
      };


      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [
          { display: "信息标题", name: "wt_title", width: 300, type: "text", align: "left",
              editor: { type: "text",height:40,width:450 }, validate: { required: true }
          },
                    { display: "发布人", name: "wt_reporter", width: 120, type: "text", align: "left",
              editor: { type: "text",height:40,width:450 }, validate: { required: true }
          },
          { display: "发布日期", name: "wt_time", width: 180, type: "date", align: "left", format: "yyyy-MM-dd hh:mm:ss"
          }
          ],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=t_web_text', sortName: 'wt_serial_id', sortOrder:'desc',
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true, enabledEdit: true, clickToEdit: false, rownumbers: true,
          detail: { height: 'auto',onShowDetail: f_showStatus }
      });

      function f_showStatus(row, detailPanel, callback) {
          var grid = document.createElement('div');
          $(detailPanel).append(grid);
          $(grid).css('margin-left', 50).css('text-align','left').ligerGrid({
              columns:
                            [
                            { display: '接收单位', name: 'cac_corp_id', width: 90,type: 'text' },
                            { display: '单位名称', name: 'cac_corp_name', width: 250, type: 'text', align:'left' },
                            { display: '是否已阅', name: 'Read',width:80 },
                            { display: '阅读日期', name: 'ReadDate', type: 'date', format: "yyyy-MM-dd hh:mm:ss",width:150 }
                            ], dataAction: 'server',isScroll: false, showToggleColBtn: false, width: '90%', sortName: 'ID',
              url: rootPath + 'handler/grid.ashx?view=t_WebTextRelation_View', showTitle: false, columnWidth: 100
                 , onAfterShowData: callback, frozen: false, usePager: false, checkbox: false,
              parms: {
                  where: JSON2.stringify({
                      op: 'and',
                      rules: [{ field: 'MessageID', value: row.wt_serial_id, op: 'equal'}]
                  })
              }
              //t_WebTextRelation_View
          });
      }

      //双击事件
      //LG.setGridDoubleClick(grid, 'modify');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "信息内容", name: "wt_text", newline: false, labelWidth: 100, width: 250, space: 30, type: "text", cssClass: "field"
          }],
          toJSON: JSON2.stringify
      });

      //增加搜索按钮,并创建事件
      LG.appendSearchButtons("#formsearch", grid);

      //加载toolbar
      LG.loadToolbar(grid, toolbarBtnItemClick);

      function addNewRow() {
          grid.addEditRow();
      }

      function modifyRow() {
          var row = grid.getSelectedRow();
          if (!row) { alert('请选择行'); return; }
          grid.beginEdit(row);
      }

      function cancelEdit() {
          grid.cancelEdit();
      }

      grid.bind('beforeSubmitEdit', function (e) {
          if (!LG.validator.form()) {
              LG.showInvalid();
              return false;
          }
          return true;
      });
      grid.bind('afterSubmitEdit', function (e) {
          var isAddNew = e.record['__status'] == "add";
          var data = e.newdata;
          if (!isAddNew)
              data.wt_serial_id = e.record.wt_serial_id;
          LG.ajax({
              loading: '正在保存数据中...',
              type: 'AjaxBaseManage',
              method: isAddNew ? "AddMessage" : "UpdateMessage",
              data: { text: data.wt_text, id: data.wt_serial_id },
              success: function () {
                  grid.loadData();
                  LG.tip('保存成功!');
              },
              error: function (message) {
                  LG.tip(message);
              }
          });
      });
      //工具条事件
      function toolbarBtnItemClick(item) {
          var editingrow = grid.getEditingRow();
          switch (item.id) {
              case "add":
                  $.ligerDialog.open({ height: 440, width: 620, url: '../BaseManage/MessageDetail.aspx', title: '发布信息' });
                  break;
              case "cancel":
                  cancelEdit();
                  break;
              case "modify":
                  var selected = grid.getSelected();
                  if (selected) {
                      $.ligerDialog.open({ height: 440, width: 620, url: '../BaseManage/MessageDetail.aspx?EditType=E&Id=' + selected.wt_serial_id, title: '发布信息' });
                  }
                  else {
                      LG.tip('请选择行!');
                  }

                  break;
              case "save":
                  saveRow();
                  break;
              case "delete":
                  jQuery.ligerDialog.confirm('确定删除吗?', function (confirm) {
                      if (confirm)
                          f_delete();
                  });
                  break;

          }
      }

      function saveRow() {
          var editingrow = grid.getEditingRow();
          if (editingrow != null) {
              grid.endEdit(editingrow);
          } else {
              LG.tip('现在不在编辑状态!');
          }
      }

      function f_reload() {
          grid.loadData();
      }
      function f_delete() {
          var selected = grid.getSelected();
          if (selected) {
              LG.ajax({
                  type: 'AjaxBaseManage',
                  method: 'RemoveMessage',
                  loading: '正在删除中...',
                  data: { id: selected.wt_serial_id },
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
