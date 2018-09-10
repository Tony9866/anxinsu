<%@ Page Language="C#" Inherits="LigerRM.Common.ViewDetailPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>区域明细</title>
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
</head>
<body style="padding-bottom:31px;">
    <form id="mainform" method="post"></form> 
    <script type="text/javascript">  

         var config = <%= SystemService.GetDetailPageConfig("Rent_District") %>;

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

        //创建表单结构
        var mainform = $("#mainform");  
        mainform.ligerForm({ 
         inputWidth: 280,
         fields : [
         {name:"LDID",type:"hidden"},
         {display:"区域名称",name:"LDName",newline:true,labelWidth:100,width:420,space:30,type:"text",validate:{maxlength:50}},
         {display:"区域描述",name:"LDDescription",newline:true,labelWidth:100,width:420,space:30,type:"textarea",validate:{maxlength:1000}},
         {display:"区域地图",name:"LDMap",newline:true,labelWidth:100,width:420,space:30,type:"textarea",validate:{maxlength:50}},
         {display:"区域简写",name:"LDShortName",newline:true,labelWidth:100,width:420,space:30,type:"text",validate:{maxlength:10}},
         {display:"区域状态",name:"LDStatus",newline:true,labelWidth:100,width:420,space:30,type:"checkbox",validate:{maxlength:50}},
         {display:"是否重点区域",name:"LDIsImport",newline:true,labelWidth:100,width:420,space:30,type:"checkbox",validate:{maxlength:50}}
         ],
		 toJSON:JSON2.stringify
        });  

        var actionRoot = "../handler/ajax.ashx?type=AjaxBaseManage";
        if(isEdit){ 
            mainform.attr("action", actionRoot + "&method=UpdateDistrict"); 
        }
        if (isAddNew) {
            mainform.attr("action", actionRoot + "&method=AddDistrict");
        }
        else { 
            LG.loadForm(mainform, { type: 'AjaxBaseManage', method: 'GetDistrict', data: { ID: currentID} },f_loaded);
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
                        win.LG.closeAndReloadParent(null, "AreaManagement");
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

