<%@ Page Language="C#" Inherits="LigerRM.Common.ViewDetailPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据权限 明细</title>
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
    <script src="DataPrivilageSysParm.js" type="text/javascript"></script>
    <style type="text/css">
        #fieldvalues{ padding:2px; border:1px solid #d3d3d3; margin:4px; background:#f1f1f1;}
        .fieldvaluelink{ float:left; display:block; margin:2px; margin-right:4px; text-decoration:underline}
        .fieldvaluelink:hover{ color:#FF0505;}
        .l-filter-value .valtxt{ width:200px;}
        table.l-filter-group select, table.l-filter-group .valtxt{ margin-top:2px;} 
    </style>
</head>
<body style="padding-bottom:31px;"> 
    <div id="fieldvalues" style="display:none; text-align:left; float:left; clear:both;"> 
    </div>
    <form id="mainform" method="post"></form> 
    <script type="text/javascript"> 
        var DbViews = <%=LigerRM.Service.Setting.DbSettingHelper.GetSettingsJSON() %>;  
         
        $(SysParms).each(function(){
            var link = $('<a class="fieldvaluelink" onclick="javascript:void(0)"></a>'); 
            link.html(this.display).attr("val",this.name).attr("title",this.name).appendTo('#fieldvalues'); 
        });
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

        var formFields = [{name:"DataPrivilegeID",type:"hidden"}];

        if(isAddNew)
        {
            var field = {display:"资源",width:400,name:"DataPrivilegeView",type:"select"};
            field.options = {valueField:'name',textField:'name'};
            field.validate = {required:true,remote:'../handler/validate.ashx?Action=Exist&View=DataPrivilege&rnd='+Math.random(),messages:{required:'请选择资源',remote:'该资源已经设置!'}};
            formFields.push(field);
        }
        else
        {
            formFields.push({display:"资源",width:400,name:"DataPrivilegeView",type:"text"});
        }

        formFields.push({display:"条件规则",name:"DataPrivilegeRule",type:"textarea"});

        mainform.ligerForm({  
            labelWidth:100,inputWidth:720,space:30,
            fields : formFields,
		    toJSON:JSON2.stringify
        });
        
         

        var masterManager = $.ligerui.get("DataPrivilegeView");
        if(isAddNew)
        {
            masterManager.setData(DbViews);
            masterManager.bind('selected',function(value, text){
                    filter.set('fields',getFields(value));
                });
        }
        //隐藏原来的多行文本框
        $("#DataPrivilegeRule").hide();
        //取而代之是一个条件构造器
        var filterPanle = $('<div id="filterPanle"></div>').appendTo($("#DataPrivilegeRule").parent());
        $("#fieldvalues").insertAfter(filterPanle).show();

        var filter = filterPanle.ligerFilter({fields:SysParms});



        var actionRoot = "../handler/ajax.ashx?type=AjaxSystem";
        if(isEdit){ 
            $("#DataPrivilegeView").attr("readonly","readonly");
            mainform.attr("action", actionRoot + "&method=UpdateDataPrivilege"); 
        }
        if (isAddNew) {
            mainform.attr("action", actionRoot + "&method=AddDataPrivilege");
        }
        else { 
            LG.loadForm(mainform, { type: 'AjaxSystem', method: 'GetDataPrivilege', data: { ID: currentID} },f_loaded);
        }  

        
          
        if(!isView) 
        {
            //验证
            jQuery.metadata.setType("attr", "validate"); 
            LG.validate(mainform);
        } 

		function f_loaded()
        {
            if(!isAddNew)
            {
                var master = $("#DataPrivilegeView").val(); 
                var rule = JSON2.parse($("#DataPrivilegeRule").val());
                filter.set('fields',getFields(master));  
                filter.setData(rule);
            } 
            if(!isView) return; 
            //查看状态，控制不能编辑
            $("input,select,textarea",mainform).attr("readonly", "readonly");
        }
        function f_save()
        {  
            var json = JSON2.stringify(filter.getData()); 
            $("#DataPrivilegeRule").val(json); 
            LG.submitForm(mainform, function (data) {
                var win = parent || window;
                if (data.IsError) {  
                    win.LG.showError('错误:' + data.Message);
                }
                else { 
                    win.LG.showSuccess('保存成功', function () { 
                        win.LG.closeAndReloadParent(null, "sysDataPrivilege");
                    });
                }
            });
        }
        function f_cancel()
        {
            var win = parent || window;
            win.LG.closeCurrentTab(null);
        }

		var currentText;
        //得到焦点
        $(".l-filter-value .valtxt").live('focus',function(){
            currentText = $(this); 
        });
        $("a.fieldvaluelink").live('click',function(){
            if(!currentText) {
                currentText = $(".l-filter-value .valtxt:first");
            }
            var val = $(this).attr("val");
            currentText.val(val);
        });
    </script>
</body>
</html>

