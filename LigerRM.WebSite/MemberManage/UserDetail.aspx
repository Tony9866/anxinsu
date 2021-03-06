﻿<%@ Page Language="C#" Inherits="LigerRM.Common.ViewDetailPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户 明细</title>
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>  
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>    
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script> 
    <script src="../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script src="../lib/jquery.form.js" type="text/javascript"></script>
    <script src="../lib/json2.js" type="text/javascript"></script>
    <script src="../lib/js/validator.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/ligerUI/js/plugins/ligerForm.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerTree.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerComboBox.js" type="text/javascript"></script>
</head>
<body style="padding-bottom:31px;">
    <form id="mainform" method="post"></form> 
    <script type="text/javascript"> 
        var config = <%= SystemService.GetDetailPageConfig("CF_User") %>;

        var forbidFields = <%= SystemService.GetForbidFields("CF_User") %>;

        LG.adujestConfig(config,forbidFields);

        var roleids = '<%=AjaxMemberManage.GetRoleList(CurrentID) %>';
        //当前ID
        var currentID = '<%= CurrentID %>';
        //是否新增状态
        var isAddNew = currentID == "" || currentID == "0";
        //是否查看状态
        var isView = <%=IsView %>;
        //是否编辑状态
        var isEdit = !isAddNew && !isView;

        //覆盖本页面grid的loading效果
        LG.overrideGridLoading(); 

        //表单底部按钮 
        LG.setFormDefaultBtn(f_cancel,isView ? null : f_save);

        var deptTree = {
            url :'../handler/tree.ashx?view=CF_Department&idfield=DeptID&textfield=DeptName&pidfield=DeptParentID',
            checkbox:false,
            nodeWidth :220
        };

        //创建表单结构
        var mainform = $("#mainform");  
        mainform.ligerForm({ 
         inputWidth: 280,
         //fields : config.Form.fields,
		 fields:[
         {name:"UserID",type:"hidden"},{display:"用户名",name:"LoginName",newline:true,labelWidth:100,width:220,space:30,type:"text",group:"基本信息",groupicon:"../lib/icons/32X32/communication.gif",validate : {required:true,username:true,minlength:4,maxlength:25,remote:'../handler/validate.ashx?Action=Exist&View=user',messages:{required:'请输入用户名',remote:'用户名已经存在!'}}  
         },
         {display:"用户级别",name:"DeptID",newline:false,labelWidth:100,width:220,space:30,type:"select",comboboxName:"DepartmentDeptName",options:{tree:{             url :'../handler/tree.ashx?view=CF_Department&idfield=DeptID&textfield=DeptName&pidfield=DeptParentID',checkbox:false,nodeWidth :220},valueFieldID:"DeptID",valueField:"DeptID"}},
         {display:"密码",name:"LoginPassword",newline:true,labelWidth:100,width:220,space:30,type:"password",validate:{maxlength:50,required:true,messages:{required:'请输入密码'}}},
         {display:"确认密码",name:"LoginPassword2",newline:false,labelWidth:100,width:220,space:30,type:"password",validate:{maxlength:50,required:true,equalTo:'#LoginPassword',messages:{required:'请输入密码',equalTo:'两次密码输入不一致'}}},
         {display:"真实姓名",name:"RealName",newline:true,labelWidth:100,width:220,space:30,type:"text",validate:{required:true,minlength:1,maxlength:50,messages:{required:'请输入姓名',maxlength:'你的名字有这么长嘛？'}}},
         {display:"头衔",name:"Title",newline:false,labelWidth:100,width:220,space:30,type:"text",validate:{maxlength:50}},
         {display:"角色",name:"RoleID",newline:true,labelWidth:100,width:220,space:30,type:"select",
         comboboxName:"RoleRoleName",options:{valueFieldID:"RoleID",url:"../handler/select.ashx?view=CF_Role&idfield=RoleID&textfield=RoleName",isMultiSelect:true,split:','}},
                 {display:"性别",name:"Sex",newline:true,labelWidth:100,width:220,space:30,type:"text",validate:{maxlength:255},group:"其他信息",groupicon:"../lib/icons/32X32/communication.gif"},
         {display:"电话",name:"Phone",newline:false,labelWidth:100,width:220,space:30,type:"text",validate:{maxlength:50}},
         {display:"传真",name:"Fax",newline:true,labelWidth:100,width:220,space:30,type:"text",validate:{maxlength:50}},
         {display:"电子邮件",name:"Email",newline:false,labelWidth:100,width:220,space:30,type:"text",validate:{maxlength:50}},
         {display:"身份证号",name:"IDCard",newline:true,labelWidth:100,width:220,space:30,type:"text",validate:{maxlength:50,required:true,messages:{required:'请输入身份证号码'}}},
         {display:"昵称",name:"NickName",newline:false,labelWidth:100,width:220,space:30,type:"text",validate:{maxlength:50}},
         {display:"地址",name:"Address",newline:true,labelWidth:100,width:520,space:30,type:"textarea"}
         ],
         toJSON:JSON2.stringify
        });

        $("#RoleID").val(roleids);

        var actionRoot = "../handler/ajax.ashx?type=AjaxMemberManage";
        if(isEdit){ 
            $("#LoginName").attr("readonly", "readonly").removeAttr("validate");
            mainform.attr("action", actionRoot + "&method=UpdateUser"); 
        }
        if (isAddNew) {
            mainform.attr("action", actionRoot + "&method=AddUser");
        }
        else { 
            LG.loadForm(mainform, { type: 'AjaxMemberManage', method: 'GetUser', data: { ID: currentID} },f_loaded);
        }  

        
          
        if(!isView) 
        {
            //验证
            jQuery.metadata.setType("attr", "validate"); 
            LG.validate(mainform);
        } 

		function f_loaded()
        {
            if(!isView) return; 
            //查看状态，控制不能编辑
            $("input,select,textarea",mainform).attr("readonly", "readonly");
        }
        function f_save()
        {
            LG.submitForm(mainform, function (data) {
                var win = parent || window;
                if (data.IsError) {  
                    win.LG.showError('错误:' + data.Message);
                }
                else { 
                    win.LG.showSuccess('保存成功', function () { 
                        win.LG.closeAndReloadParent(null, "MemberManageUser");
                    });
                }
            });
        }
        function f_cancel()
        {
            var win = parent || window;
            win.LG.closeCurrentTab(null);
        }

		 
    </script>
</body>
</html>

