
      //相对路径
      var rootPath = "../";
      //列表结构
      var grid = $("#maingrid").ligerGrid({
          columns: [{ display: "使用单位编号", name: "co_corp_id", width: 100, type: "text", align: "left" },
          { display: "使用单位名称", name: "co_corp_name", width: 350, type: "text", align: "left" },
          { display: "所属区域", name: "ar_area_name", width: 100, type: "text", align: "left" },
          { display: "企业类型", name: "corptypename", width: 150, type: "text", align: "left" },
          { display: "企业法人", name: "co_boss", width: 100, type: "date", align: "left" },
          { display: "法人身份证", name: "co_boss_idcard", width: 150, type: "text", align: "left" },
          { display: "备案日期", name: "co_create_date", width: 100, type: "date", align: "left"}],
          dataAction: 'server', pageSize: 20, toolbar: {},
          url: rootPath + 'handler/grid.ashx?view=t_corporation_view', sortName: 'co_corp_id',
          width: '98%', height: '100%', heightDiff: -10, checkbox: false, fixedCellHeight: true, rowHeight: 26,rownumbers:true,
          selectRowButtonOnly: true,isScroll:false
      });

      //双击事件
      LG.setGridDoubleClick(grid, 'view');

      //搜索表单应用ligerui样式
      $("#formsearch").ligerForm({
          fields: [{ display: "使用单位编号", name: "co_corp_id", newline: false, labelWidth: 100, width: 100, space: 20, type: "text", cssClass: "field" },
          { display: "使用单位名称", name: "co_corp_name", newline: false, labelWidth: 100, width: 120, space: 20, type: "text", cssClass: "field" },
                    { display: "所属区域", name: "所属区域", newline: false, labelWidth: 80, width: 100, space: 20, type: "select", cssClass: "field",
                        options: {
                            url: '../handler/select.ashx?view=t_area&idfield=ar_area_id&textfield=ar_area_name&distinct=true&needAll=1',
                            initValue: '全部', valueFieldID: 'co_area_id'
                        }
                    },
                    { display: "企业类型", name: "corptypename", newline: false, labelWidth: 80, width: 160, space: 20, type: "select", cssClass: "field",
                        options: {
                            url: '../handler/select.ashx?view=t_general_code&idfield=gc_id&textfield=gc_name&distinct=true&needAll=1&&where={"op":"and","rules":[{"op":"like","field":"gc_code_group","value":"CT","type":"string"}]}',
                            initValue: '全部', valueFieldID: 'co_type'
                        }
                    },
                    { display: "备案开始日期", name: "co_create_date", newline: true, labelWidth: 100, width: 100, space: 20, type: "date", cssClass: "field",
                        attr: {
                            op: "greaterorequal"
                        }
                    },
                    { display: "备案结束日期", name: "co_create_date1", newline: false, labelWidth: 100, width: 120, space: 20, type: "date", cssClass: "field",
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

              case "view":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  LG.ajax({
                      type: 'AjaxPage',
                      method: 'GetEncryptString',
                      loading: '正在获取中...',
                      data: { sourceStr: selected.co_corp_id },
                      success: function (data) {
                          wopen('../InfoRegister/CorporationDetail.aspx?CorpId=' + data, '使用单位详细信息', '610', '550');
                      },
                      error: function (message) {
                      }
                  });
                  
                  //top.f_addTab(null, '查看客户信息', 'CustomerManage/CustomersDetail.aspx?IsView=1&ID=' + selected.CustomerID);
                  break;
              case "print":
                  $("#maingrid").jqprint();
                  break;
              case "signet":
                  var selected = grid.getSelected();
                  if (!selected) { LG.tip('请选择行!'); return }
                  $.ligerDialog.open({ height: 450, width: 750, url: '../InfoQuery/CorporationSignetQuery.aspx?corpId=' + selected.co_corp_id, title: '关联印章' });
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
          var targetWin = window.open(pageURL + '&' + random, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
      }

      function f_delete() {
          var selected = grid.getSelected();
          if (selected) {
              LG.ajax({
                  type: 'AjaxCorporationManage',
                  method: 'RemoveCorps',
                  loading: '正在删除中...',
                  data: { ID: selected.co_corp_id },
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
