﻿<%@ page language="C#" autoeventwireup="true" inherits="Print, App_Web_gl2v1pkx" validaterequest="false" %>
<html>
<head>
    <title></title>
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
    <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>        
    <script type="text/javascript">
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

        function gethtml(g) {
            parent.$(".l-grid-header-table", g).attr("border", "1");
            parent.$(".l-grid-body-table", g).attr("border", "1"); //l-grid2
            $("#hf").val(
                        parent.$(".l-grid2 .l-grid-header", g).html() +             //这里把表头捞出来
                        parent.$(".l-grid-body-inner", g).html() 
                        //+         //表身，具体数据
                        //parent.$(".l-panel-bar-total", g).html() + "<br/>" + //这是全局汇总，1.1.0版本新添加的                       
                        //parent.$(".l-bar-text", g).html()                 //这是翻页讯息       
                        );

            parent.$(".l-grid-header-table", g).attr("border", "0");
            parent.$(".l-grid-body-table", g).attr("border", "0");
            // parent.$(".l-grid-header-table",g).removeAttr("border");              
            // parent.$(".l-grid-body-table",g).removeAttr("border");                                                
        }

        function init() {
            if (GetQueryString("exporttype") == "xls") {
                document.getElementById("btnxls").click();
            }
            else {
                document.getElementById("btndoc").click();
            }
            setTimeout(function () {
                parent.$.ligerDialog.close();
                parent.$(".l-dialog,.l-window-mask").css("display", "none");
            }, 3000);
        }
                                
    </script>
</head>
<body style="padding:00px" onload="init()">
    <form id="form1" runat="server">        
    导出中...
    <div style="visibility:hidden">
    <asp:Button ID="btnxls" runat="server" Text="导出Excel" onclick="Button1_Click" OnClientClick="gethtml('#maingrid')"/>
    <asp:Button ID="btndoc" runat="server" Text="导出Word"  onclick="Button2_Click" OnClientClick="gethtml('#maingrid')"/>
    </div>
    <asp:HiddenField ID="hf" runat="server" />  
    </form>
</body>
</html>
