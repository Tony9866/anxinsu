﻿<%@ Page Language="C#" Inherits="LigerRM.Common.ViewPageBase" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>  
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>    
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerLayout.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script> 
    <script src="../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>

    <script src="../lib/jquery.form.js" type="text/javascript"></script>
    <script src="../lib/json2.js" type="text/javascript"></script>


    <script src="../lib/js/validator.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script>


    <style type="text/css">
    .cell-label{ width:80px;}
    #tabcontainer .l-tab-links{border-top:1px solid #D0D0D0;border-left:1px solid #D0D0D0;border-right:1px solid #D0D0D0;}
    
    .projectgrid .l-selected .l-grid-row-cell,.projectgrid .l-selected {background: none;}
    
    .access-icon{ background:url(../lib/ligerUI/skins/Aqua/images/controls/checkbox.gif) 0px 0px; height:13px; line-height:13px; width:13px; margin:4px 20px; display:block; cursor:pointer;}
    .access-icon-selected{ background-position:0px -13px;} 
    .l-panel td.l-grid-row-cell-editing { padding-bottom: 2px;padding-top: 2px;}
    </style>
</head>
<body style=" overflow:hidden;"> 
    <div id="layout" style="margin:2px; margin-right:3px;">
         <div position="left" id="mainmenu" title="用户角色" style="width:400px;"> 
              <div id="tabcontainer" style="margin:2px;">
              <div title="角色" tabid="rolelist">
                    <div id="rolegrid" style="margin:2px auto;"></div>
                 </div>
                 <div title="用户"  tabid="userlist">
                     <div id="usergrid" style="margin:2px auto;"></div>
                 </div> 
               </div>
          </div>
          <div position="center" title="权限控制">
                <div id="rightgrid" style="margin:2px auto;"></div>
          </div>
    </div>

  
    <script type="text/javascript">

        //覆盖本页面grid的loading效果
        LG.overrideGridLoading(); 

        var layout = $("#layout").ligerLayout({
            //5分之3的高度
            //bottomHeight: 3 * $(window).height() / 5,
            heightDiff: -6,
            onEndResize: updateGridHeight,
            onHeightChanged: updateGridHeight,
            leftWidth:400
        });

        

        var bottomHeader = $(".l-layout-bottom > .l-layout-header:first");

        var tab = $("#tabcontainer").ligerTab();

        var selectedUserID, selectedRoleID;

        //屏蔽系统管理员
        var gridUserFilter = {
            op: 'and',
            rules: [
                    { field: 'UserID', value: '<%=SystemService.AdminUserID %>', op: 'notequal' }
                ]
        };
        //屏蔽系统管理员角色
        var gridRoleFilter = {
            op: 'and',
            rules: [
                    { field: 'RoleID', value: '<%=SystemService.AdminRoleID %>', op: 'notequal' }
                ]
        };

        var userlistLoaded = false;
        var gridRole, gridUser;

        gridRole = $("#rolegrid").ligerGrid({
            columns:
                [
                { display: '角色名', name: 'RoleName', width: 150, align: 'left' },
                { display: '角色描述', name: 'RoleDesc', width: 450, align: 'left' }
                ], showToggleColBtn: false, width: '99%', height: '100%', rowHeight: 20, fixedCellHeight: true,
            columnWidth: 100, frozen: false, sortName: 'RoleID', usePager: false, checkbox: false, rownumbers: true,
            url: '../handler/grid.ashx?view=CF_Role', parms: { where: JSON2.stringify(gridRoleFilter) }
        });
        gridRole.bind('SelectRow', function (rowdata)
        {
            selectedUserID = null;
            selectedRoleID = rowdata.RoleID;
            //隐藏禁止权限列
            gridRight.toggleCol('Forbid', false);

            bottomHeader.html("设置角色【" + rowdata.RoleName + "】的权限");

            LG.ajax({
                loading: '正在加载角色权限中...',
                type: 'AjaxSystem',
                method: 'GetRolePermission',
                data: { RoleID: selectedRoleID },
                success: function (data)
                {
                    var rows = gridRight.rows;
                    for (var i = 0, l = rows.length; i < l; i++)
                    {
                        rows[i].Permit = checkPermit(rows[i], data);
                    }
                    gridRight.reRender();
                }
            });

            //判断是否有权限
            function checkPermit(rowdata, data)
            {
                if (!data || !data.length) return false;
                var isButton = rowdata.BtnID != null && rowdata.BtnID != 0;
                for (var i = 0, l = data.length; i < l; i++)
                {
                    if (isButton && data[i].BtnID == rowdata.BtnID)
                        return true;
                    if (!isButton && data[i].MenuID == rowdata.MenuID)
                        return true;
                }
                return false;
            }
        });

      
        //权限 保存按钮
        var toolbarOptions = {
            items: [
            { text: '保存', click: f_save, img: "../lib/icons/silkicons/page_save.png" }
        ]
        };

        //权限
        var gridRight = $("#rightgrid").ligerGrid({
            columns:
                [
                { display: '分配权限' , name:'Permit',align: 'left', width: 60, minWidth: 60,isAllowHide :false, render: function (rowdata)
                {
                    var iconHtml = '<div class="access-icon access-permit';
                    if (rowdata.Permit) iconHtml += " access-icon-selected";
                    iconHtml += '"';
                    iconHtml += ' rowid = "' + rowdata['__id'] + '"';
                    iconHtml += '></div>';
                    return iconHtml;
                }
                },
                { display: '禁止权限', name: 'Forbid', align: 'left', width: 60, minWidth: 60, isAllowHide: false, render: function (rowdata)
                {
                    var iconHtml = '<div class="access-icon access-forbid';
                    if (rowdata.Forbid) iconHtml += " access-icon-selected";
                    iconHtml += '"';
                    iconHtml += ' rowid = "' + rowdata['__id'] + '"';
                    iconHtml += '></div>';
                    return iconHtml;
                }
                },
                { display: '菜单-按钮', name: 'AccessName', align: 'left', width: 200, minWidth: 60 },
                { display: '编码', name: 'AccessNo', align: 'left', width: 200, minWidth: 60 },
                { display: '图标', name: 'AccessIcon', align: 'left', width: 200, minWidth: 60 }
                ], showToggleColBtn: false, width: '99%', height: '99%', rowHeight: 20, fixedCellHeight: true,
            columnWidth: 100, frozen: false, usePager: false, checkbox: false, rownumbers: true, toolbar: toolbarOptions,
            tree: { columnName: 'AccessName' }, 
            data: []
        });

        //分配权限、禁止权限按钮的事件
        $("div.access-icon").live('click', function ()
        {
            var selected = !$(this).hasClass("access-icon-selected");
            var ispermit = $(this).hasClass("access-permit");
            var rowid = $(this).attr("rowid");
            var rowdata = gridRight.records[rowid];
            if (ispermit)
            {
                f_Permit(rowdata, selected); 
            }
            else
            {
                f_Forbid(rowdata, selected); 
            }
        });

        //为当前选择记录 分配权限
        //1,同时分配给下级记录 
        function f_Permit(rowdata, selected)
        {
            selected = selected ? true : false;
            rowdata.Permit = rowdata.Permit ? true : false;
            if (rowdata.Permit == selected) return;
            rowdata.Permit = selected;
            var children = gridRight.getChildren(rowdata);
            if (children)
            {
                for (var i = 0, l = children.length; i < l; i++)
                {
                    f_Permit(children[i], selected);
                }
            }
            gridRight.reRender({ rowdata: rowdata });
        }
        //为当前选择记录 禁止权限 
        //1,同时对下级记录做禁止权限操作 
        function f_Forbid(rowdata, selected)
        {
            selected = selected ? true : false;
            rowdata.Forbid = rowdata.Forbid ? true : false;
            if (rowdata.Forbid == selected) return;
            rowdata.Forbid = selected;   
            if (selected)
            { 
                var children = gridRight.getChildren(rowdata);
                if (children)
                {
                    for (var i = 0, l = children.length; i < l; i++)
                    {
                        f_Forbid(children[i], selected);
                    }
                }
            }
            gridRight.reRender({ rowdata: rowdata });
        }


        //加载 菜单-按钮数据
        LG.ajax({
            loading: '正在加载菜单按钮中...',
            type: 'AjaxSystem',
            method: 'GetAccess',
            success: function (data)
            { 
                gridRight.set('data', { Rows: data });
            }
        });

        //角色,在tab选择的时候才加载表格和表格数据
        tab.bind('afterSelectTabItem', function (tabid)
        {
            if (tabid != "userlist" || userlistLoaded) return;
            userlistLoaded = true;
            //用户
            gridUser = $("#usergrid").ligerGrid({
                columns:
                [
                { display: '账号', name: 'LoginName', align: 'left', width: 200, minWidth: 60 },
                { display: '名称', name: 'RealName', align: 'left', width: 200, minWidth: 60 }
                ], showToggleColBtn: false, width: '99%', height: '99%', rowHeight: 20, fixedCellHeight: true,
                columnWidth: 100, frozen: false, sortName: 'UserID', usePager: false, checkbox: false, rownumbers: true,
                url: '../handler/grid.ashx?view=CF_User', parms: { where: JSON2.stringify(gridUserFilter) }
            });
            gridUser.bind('SelectRow', function (rowdata)
            {
                selectedUserID = rowdata.UserID;
                selectedRoleID = null;
                //显示禁止权限列
                gridRight.toggleCol('Forbid', true);

                bottomHeader.html("给用户【" + rowdata.LoginName + "】 单独设置权限");

                LG.ajax({
                    loading: '正在加载用户权限中...',
                    type: 'AjaxSystem',
                    method: 'GetUserPermission',
                    data: { UserID: selectedUserID },
                    success: function (data)
                    {
                        var rows = gridRight.rows;
                        for (var i = 0, l = rows.length; i < l; i++)
                        {
                            var hasPermit = checkPermit(rows[i], data);
                            if (hasPermit)
                            {
                                rows[i].Permit = isPermit;
                                rows[i].Forbid = !isPermit;
                            } else
                            {
                                rows[i].Permit = rows[i].Forbid = false;
                            }
                        }
                        gridRight.reRender();
                    }
                });

                //是否 分配权限 ，或者是禁止权限
                var isPermit;

                //判断是否有权限控制(按钮的，或菜单的)
                function checkPermit(rowdata, data)
                {
                    if (!data || !data.length) return false;
                    var isButton = rowdata.BtnID != null && rowdata.BtnID != 0;
                    for (var i = 0, l = data.length; i < l; i++)
                    {
                        if (isButton && data[i].BtnID == rowdata.BtnID)
                        {
                            isPermit = data[i].Permit;
                            return true;
                        }
                        if (!isButton && data[i].MenuID == rowdata.MenuID)
                        {
                            isPermit = data[i].Permit;
                            return true;
                        }
                    }
                    return false;
                }
            });
        });



        



        function f_save()
        {
            if (!selectedRoleID && !selectedUserID) return;
            var data = [];
            for (var i = 0, l = gridRight.rows.length; i < l; i++)
            {
                var o = $.extend({}, gridRight.rows[i]);
                o.Permit = o.Permit ? true : false;
                o.Forbid = o.Forbid ? true : false;
                o.BtnID = o.BtnID || 0;
                o.MenuID = o.MenuID || 0;
                o = gridRight.formatRecord(o, true);
                if ('children' in o)
                    delete o.children;
                data.push(o);
            }
            LG.ajax({
                loading: '正在保存权限设置中...',
                type: 'AjaxSystem',
                method: selectedRoleID ? 'SaveRolePermission' : 'SaveUserPermission',
                data: {
                    DataJSON: JSON2.stringify(data),
                    RoleID: selectedRoleID,
                    UserID: selectedUserID
                },
                success: function ()
                {
                    LG.showSuccess("保存成功!");
                },
                error: function (message)
                {
                    LG.showError(message);
                }
            });
        }

        function updateGridHeight()
        { 
            var topHeight = $("#layout > .l-layout-center").height();
            var bottomHeight = $("#layout > .l-layout-bottom").height();
            if(gridUser)
                gridUser.set('height', topHeight - 65);
            if (gridRole)
                gridRole.set('height', topHeight - 65);
            if(gridRight)
                gridRight.set('height', bottomHeight - 35); 
        }
        updateGridHeight();
    </script>
</body>
</html>
