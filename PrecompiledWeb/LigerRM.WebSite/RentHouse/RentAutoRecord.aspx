<%@ page language="C#" autoeventwireup="true" inherits="RentHouse_RentAutoRecord, App_Web_h3mtpn1q" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                        <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/ligerui.expand.js" type="text/javascript"></script> 
    <script src="../lib/json2.js" type="text/javascript"></script> 
        <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>  
    <script src="../lib/ligerUI/js/plugins/ligerTab.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerLayout.js" type="text/javascript"></script>
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <link href="../lib/css/index.css" rel="stylesheet" type="text/css" />
    <script src="../lib/js/common.js" type="text/javascript"></script>
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/login.js" type="text/javascript"></script>
    <script src="../lib/commonvalidate.js" type="text/javascript"></script>
        <script src="../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script> 
    <script src="../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script src="../lib/js/changepassword.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerForm.js" type="text/javascript"></script>
    <script src="../lib/js/jquery.jqprint-0.3.js" type="text/javascript"></script> 
    
    <script src="../lib/js/DateTimeControl.js" type="text/javascript"></script>
</head>
<body onunload="javascript:clearTimeout(int);">

    <object id="IdCtrl" classid="clsid:A66F5373-0A8A-4C42-814B-38A87B331D40" > </object>
    <div>
    <script type="text/javascript">

        var renteeName;
        var renteeIDCard;
        function ReadIDCard() {
            var iResut = 0;
            var strVal = "";
            iResut = IdCtrl.hxgc_OpenReader(1001);
            if (iResut != 0) {
                alert("二代证设备打开失败！");
            }
            else {
                iResut = IdCtrl.hxgc_ReadIDCard(1001);
                strVal = IdCtrl.hxgc_GetName();
                renteeName = strVal;
                strVal = IdCtrl.hxgc_GetIDCode();
                renteeIDCard = strVal;
                iResut = IdCtrl.hxgc_CloseReader(1001);
                if (renteeName == "")
                    $('#lbMessage', window.parent.document).html("");
                else
                    $('#lbMessage', window.parent.document).html(renteeName + "(" + renteeIDCard + ")" + "入住成功！");
            }
        }
        var int;
        function AddRentRecord() {

            ReadIDCard();
            clearTimeout(int);
            if (renteeName != "" && renteeIDCard != "") {

                LG.ajax({
                    type: 'AjaxRentManage',
                    method: 'AddRentRecord',
                    loading: '正在获取中...',
                    data: { name: renteeName, idcard: renteeIDCard },
                    success: function (data) {
                        //$("#lbMessage").val(renteeName + "(" + renteeIDCard + ")" + "入住成功！");
                        
                        renteeName = "";
                        renteeIDCard = "";
                        int = setTimeout("AddRentRecord()", 1000);
                    },
                    error: function (message) {
                    }
                });
            }
            int = setTimeout("AddRentRecord()", 1000);
        }
        int = setTimeout("AddRentRecord()", 1000);

        //    int = self.setInterval("AddRentRecord()", 1000)
</script>
<span style=" font-size:medium; color:Red; padding-left:40px;" id="lbMessage"></span>
    </div>

</body>
</html>
