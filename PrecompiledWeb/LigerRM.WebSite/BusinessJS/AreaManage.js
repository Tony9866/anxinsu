
      var maingform = $("#mainform");
      $.metadata.setType("attr", "validate");
      LG.validate(maingform, { debug: false });
      var rootPath = "../";
      var provinceData;
      $.ajax({
          cache: false,
          async: false,
          type: 'post',
          dataType: 'json',
          data: { where: JSON2.stringify({
              op: 'and',
              rules: [
               { field: 'gc_code_group', value: 'PR', op: 'equal' }
               ]
          })
          },
      url: rootPath + 'handler/select.ashx?view=t_general_code&idfield=gc_id&textfield=gc_name&distinct=true',
          success: function (data) {
              provinceData = data;
              LG.hideLoading('');
          }
      });

      //相对路径
      
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "区域编号", name: "ar_area_id", width: 100, type: "text", align: "left",
              editor: { type: "text" }, validate: { required: true }
          },
          { display: "区域名称", name: "ar_area_name", width: 350, type: "text", align: "left",
              editor: { type: "text" }, validate: { required: true }
          },
          { display: "所属城市", name: "ar_city", width: 100, type: "text", align: "left",
              editor: { type: "text" }
          },
          { display: "所属省份", name: "ar_province", width: 100, type: "text", align: "left",
               editor: { type: 'select', data: provinceData},
               render: function (item) {
                   for (var i = 0; i < provinceData.length; i++) {
                       if (provinceData[i].value == item.ar_province)
                           return provinceData[i].text;
                   }
                   return item.ar_province;
               }
          },
          { display: "备注", name: "ar_memo", width: 100, type: "text", align: "left",
              editor: { type: "text" }
          }],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=t_area', sortName: 'ar_area_id',
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26,
          selectRowButtonOnly: true, enabledEdit: true, clickToEdit: false, rownumbers: true
      });

      //双击事件
      //LG.setGridDoubleClick(grid, 'modify');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "区域编号", name: "ar_area_id", newline: false, labelWidth: 100, width: 150, space: 30, type: "text", cssClass: "field"
          },
          { display: "区域名称", name: "ar_area_name", newline: false, labelWidth: 100, width: 150, space: 30, type: "text", cssClass: "field"
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
              data.ar_area_id = e.record.ar_area_id;
          LG.ajax({
              loading: '正在保存数据中...',
              type: 'AjaxBaseManage',
              method: isAddNew ? "AddArea" : "UpdateArea",
              data: { ID: data.ar_area_id, Name: data.ar_area_name, alias: data.ar_alias_name, city: data.ar_city, province: data.ar_province, memo: data.ar_memo },
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
                  if (editingrow == null) {
                      addNewRow();
                  } else {
                      LG.tip('请先提交或取消修改');
                  }
                  break;
              case "cancel":
                  cancelEdit();
                  break;
              case "modify":
                  if (editingrow == null) {
                      modifyRow();
                  } else {
                      LG.tip('请先提交或取消修改');
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
                  method: 'RemoveArea',
                  loading: '正在删除中...',
                  data: { ID: selected.ar_area_id },
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
