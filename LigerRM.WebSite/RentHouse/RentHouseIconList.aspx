<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RentHouseIconList.aspx.cs" Inherits="RentHouse_RentHouseIconList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<script src="https://img.hcharts.cn/jquery/jquery-1.8.3.min.js"></script>
	<script src="https://img.hcharts.cn/highcharts/highcharts.js"></script>
	<script src="https://img.hcharts.cn/highcharts/modules/exporting.js"></script>
	<script src="https://img.hcharts.cn/highcharts/modules/oldie.js"></script>
	<script src="https://img.hcharts.cn/highcharts-plugins/highcharts-zh_CN.js"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>   
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <script src="../lib/js/common.js" type="text/javascript"></script>   
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/json2.js" type="text/javascript"></script> 
</head>

<body>
<div style=" margin:5px; padding:5px;">
	<div id="r-result">
		  <div id="mainsearch" style=" width:100%">
    <div class="searchtitle">
        <span>搜索</span><img src="../lib/icons/32X32/searchtool.gif" />
        <div class="togglebtn"></div> 
    </div>
    <div class="navline" style="margin-bottom:4px; margin-top:4px;"></div>
    <div class="searchbox">
        <form id="formsearch" class="l-form"></form>
    </div>
  </div>
        </div>
        <div>
        <form runat="server">
        <span style="padding-left:10px; font-size:16px;">登记入住</span>
        <hr style=" border:none; border-bottom:3px solid #dddddd;width:99%;" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="display:none;"><asp:Button ID="btnPost" runat="server" Text="Button" onclick="btnPost_Click" /></div>
            <asp:HiddenField ID="hdStart" runat="server" />
            <asp:HiddenField ID="hdEnd" runat="server" />
         <asp:DataList ID="dlHouse" runat="server" RepeatColumns="6" 
            RepeatDirection="Horizontal">
            <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr><td>
                <img  style=" padding:10px; cursor:pointer;"  src=<%# Eval("IsUsed").ToString()=="0"?"../images/House-1.png":"../images/House-2.png"%> onclick="javascript:OpenRentRecord('<%# Eval("RentNO") %>','<%# Eval("IsUsed").ToString()%>','<%# Eval("RRAID").ToString()%>');" alt="空闲" title=<%# Eval("IsUsed").ToString()=="0"?"空闲":"已租"%> />
                </td></tr>
                <tr><td align="center">
               <%# Eval("RDoor") %>（<%# Eval("RRoomTypeDesc") %>）
                </td></tr>
            </table>
            
            </ItemTemplate>
        </asp:DataList>       
        </ContentTemplate>
        </asp:UpdatePanel>
        <p></p>
        <span style="padding-left:20px;">
            <asp:HiddenField ID="hdTimerID" runat="server" Value="0" />
            <input id="Button1" type="button" value="自动入住" class="buttonDefault" onclick="javascript:AutoRecord();" /></span>
        </form>
        </div>
</div>


	<script>

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
	    $("#formsearch").ligerForm({
	        fields: [

          { display: "入住日期", name: "RRAStartDate", newline: false, labelWidth: 100, width: 150, space: 20, type: "date", cssClass: "field",
              attr: {
                  op: "greaterorequal"
              }
          },
        { display: "退房日期", name: "RRAEndDate", newline: false, labelWidth: 100, width: 150, space: 20, type: "date", cssClass: "field",
            attr: {
                op: "lessorequal"
            }
        }

          ],
	        toJSON: JSON2.stringify
	    });

	    var dtNow = new Date();
	    var dtStart = new Date(dtNow.getTime());
	    $("#RRAStartDate").val(formatDate(dtStart));

	    var t1;


	    var button = $('<ul><li style="margin-right:8px"></li><li></li></ul><div class="l-clear"></div>').appendTo("#formsearch");
	    LG.createButton({
	        appendTo: button,
	        text: '搜索',
	        defaultButton: 'true',
	        click: function () {
	            var rule = LG.bulidFilterGroup("#formsearch");

	            var start = $("#RRAStartDate").val();
	            var end = $("#RRAEndDate").val();
	            var hdStart = document.getElementById("<%=hdStart.ClientID %>");
	            var hdEnd = document.getElementById("<%=hdEnd.ClientID %>");
	            hdStart.value = start;
	            hdEnd.value = end;
	            var btn = document.getElementById("<%=btnPost.ClientID %>");
	            btn.click();
	        }
	    });


	    function formatDate(d) {
	        month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

	        if (month.length < 2) month = '0' + month;
	        if (day.length < 2) day = '0' + day;

	        return [year, month, day].join('-');
	    }

	    function activeLastPointToolip(chart) {
	        var points = chart.series[0].points;
	        chart.tooltip.refresh(points[points.length - 1]);
	    }

	    function OpenRentRecord(rentNo, isUsed,rraId) {
	        var start = $("#RRAStartDate").val();
	        var end = $("#RRAEndDate").val();
	        $.ligerDialog.open({ height: 480, width: 750, url: 'RentIconAdd.aspx?RentNo=' + rentNo + '&type=A&isUsed=' + isUsed + '&startDate=' + start + "&endDate=" + end + "&rraId=" + rraId, title: '添加租房记录'});
        }

        function wopen(pageURL, title, w, h) {
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);
            var targetWin = window.open(pageURL, title, ' width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

        }

        function AutoRecord() {
            wopen("RentAutoRecordParent.aspx", "添加租房记录", 750, 280);
        }


        function Search() {
            var btn = document.getElementById("<%=btnPost.ClientID %>");
            btn.click();
        }

        Search();
</script>
</body>
</html>
