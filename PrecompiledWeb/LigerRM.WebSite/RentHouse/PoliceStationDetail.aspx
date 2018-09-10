<%@ Page Language="C#" Inherits="LigerRM.Common.ViewDetailPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>警局明细</title>
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

         var config = <%= SystemService.GetDetailPageConfig("Rent_PoliceStation") %>;

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
            {name:"PSID",display:"单位编码",newline:true,labelWidth:100,width:420,space:30,type:"text",validate:{maxlength:50}},
            {display:"警局名称",name:"PSName",newline:true,labelWidth:100,width:420,space:30,type:"text",validate:{maxlength:500}},
            {display:"上级单位",name:"ParentID",newline:true,labelWidth:100,width:220,space:30,type:"select",
            comboboxName:"ParentName",options:{valueFieldID:"ParentID",url:"../handler/select.ashx?view=v_ParentPoliceStation&idfield=PSID&textfield=PSName"}},
            {display:"描述",name:"PSDescription",newline:true,labelWidth:100,width:420,space:30,type:"textarea",validate:{maxlength:1000}},
            {display:"联系人",name:"PSContactPerson",newline:true,labelWidth:100,width:140,space:30,type:"text",validate:{maxlength:50}},
            {display:"联系电话",name:"PSContactTel",newline:false,labelWidth:100,width:140,space:30,type:"text",validate:{maxlength:50}},
            {display:"联系地址",name:"PSAddress",newline:true,labelWidth:100,width:420,space:30,type:"textarea",validate:{maxlength:50}},
            {display:"简写",name:"PSShortName",newline:true,labelWidth:100,width:50,space:30,type:"text",validate:{maxlength:50}},
            {display:"是否重点警局",name:"PSIsImport",newline:false,labelWidth:100,width:50,space:30,type:"checkbox",validate:{maxlength:50}},
            {display:"警局状态",name:"PSStatus",newline:false,labelWidth:100,width:50,space:30,type:"checkbox",validate:{maxlength:50}},
            {display:"创建时间",name:"PSCreatedDate",newline:true,labelWidth:100,width:140,space:30,type: "date", align: "left", format: "yyyy-MM-dd hh:mm:ss" },
            {display:"修改时间",name:"PSModifiedDate",newline:false,labelWidth:100,width:140,space:30,type: "date", align: "left", format: "yyyy-MM-dd hh:mm:ss" },
            {display:"地图信息",name:"PSMapID",newline:true,labelWidth:100,width:420,space:30,type:"textarea",validate:{maxlength:50}}
            ],
            toJSON:JSON2.stringify
        });  

        var actionRoot = "../handler/ajax.ashx?type=AjaxBaseManage";
        if(isEdit){ 
            mainform.attr("action", actionRoot + "&method=UpdatePoliceStation"); 
        }
        if (isAddNew) {
            mainform.attr("action", actionRoot + "&method=AddPoliceStation");
        }
        else { 
            LG.loadForm(mainform, { type: 'AjaxBaseManage', method: 'GetPoliceStation', data: { ID: currentID} },f_loaded);
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
                        win.LG.closeAndReloadParent(null, "PoliceStationManagement");
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

