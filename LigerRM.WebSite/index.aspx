
<%@ Page Language="C#" Inherits="LigerRM.Common.ViewPageBase"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <title>欢迎使用<%= LigerRM.Common.Global.GlobalHelper.GetSystemName()%></title> 
      <script src="../lib/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />

    
    <script src="../lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>  
    <script src="../lib/ligerUI/js/plugins/ligerTab.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerLayout.js" type="text/javascript"></script>
    <link href="../lib/css/common.css" rel="stylesheet" type="text/css" />  
    <link href="../lib/css/index.css" rel="stylesheet" type="text/css" />
    <script src="../lib/js/common.js" type="text/javascript"></script>
    <script src="../lib/js/LG.js" type="text/javascript"></script>
    <script src="../lib/js/login.js" type="text/javascript"></script>

        <script src="../lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script> 
    <script src="../lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="../lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script src="../lib/js/changepassword.js" type="text/javascript"></script>
    <script src="../lib/ligerUI/js/plugins/ligerForm.js" type="text/javascript"></script>
</head>
<body style="text-align:center; background:#F0F0F0; overflow:hidden;">
    <div id="pageloading" style="display:block;"></div> 
    <div id="topmenu" class="l-topmenu">
        <div class="l-topmenu-logo"><%= LigerRM.Common.Global.GlobalHelper.GetSystemName()%></div>
        <div class="l-topmenu-welcome"> 
            <span class="l-topmenu-username"></span>欢迎您  &nbsp; 
            [<a href="javascript:f_changepassword()">修改密码</a>] &nbsp; 

             [<a href="javascript:f_login()">切换用户</a>]
            [<a href="login.htm?Action=out">退出</a>] 
        </div> 
        
    </div> 
     <div id="mainbody" class="l-mainbody" style="width:99.2%; margin:0 auto; margin-top:3px;" >
        <div position="left" title="<%= LigerRM.Common.Global.GlobalHelper.GetSystemName()%>" id="mainmenu"></div>  
        <div position="center" id="framecenter"> 
            <div tabid="home" title="我的主页"> 
                <iframe frameborder="0" name="home" id="home" src="welcome.aspx"></iframe>
            </div> 
        </div> 
    </div>
    <div class="l-hidden"></div>
    <script type="text/javascript">
        //几个布局的对象
        var layout, tab, accordion;
        //tabid计数器，保证tabid不会重复
        var tabidcounter = 0;
        //窗口改变时的处理函数
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }

        //增加tab项的函数
        function f_addTab(tabid, text, url) {
            if (!tab) return;
            if (!tabid) {
                tabidcounter++;
                tabid = "tabid" + tabidcounter;
            }
            tab.addTabItem({ tabid: tabid, text: text, url: url });
        }

        function f_removeTab() {
            if (!tab) return;
            tab.removeSelectedTabItem();
        }

        function f_reloadTab(tabid) {
            if (!tab) return;
            tab.reload(tabid);
        }

        function f_reloadCurrentTab(u, text) {

            if (!tab) return;
            option = { url: u, text: text };
            tab.overrideSelectedTabItem(option);
        }
        //登录
        function f_login() {
            LG.login();
        }
        //修改密码
        function f_changepassword() {
            LG.changepassword();
        }
        var tip;
        var num = 0;

        function f_SetStatus() {
            LG.ajax({
                type: 'AjaxBaseManage',
                method: 'SetHouseStatus',
                success: function (user) {
                    
                },
                error: function () {
                }
            });
        }


        $(document).ready(function () {

            setInterval(function () {
                f_SetStatus();
                //要执行的代码                     
            }, 600000);

            //菜单初始化
            $("ul.menulist li").live('click', function () {
                var jitem = $(this);
                var tabid = jitem.attr("tabid");
                var url = jitem.attr("url");
                if (!url) return;
                if (!tabid) {
                    tabidcounter++;
                    tabid = "tabid" + tabidcounter;
                    jitem.attr("tabid", tabid);

                    //给url附加menuno
                    if (url.indexOf('?') > -1) url += "&";
                    else url += "?";
                    url += "MenuNo=" + jitem.attr("menuno");
                    jitem.attr("url", url);
                }
                f_addTab(tabid, $("span:first", jitem).html(), url);
            }).live('mouseover', function () {
                var jitem = $(this);
                jitem.addClass("over");
            }).live('mouseout', function () {
                var jitem = $(this);
                jitem.removeClass("over");
            });

            //布局初始化 
            //layout
            layout = $("#mainbody").ligerLayout({ height: '100%', heightDiff: -3, leftWidth: 190, onHeightChanged: f_heightChanged, minLeftWidth: 120 });
            var bodyHeight = $(".l-layout-center:first").height();
            //Tab
            tab = $("#framecenter").ligerTab({ height: bodyHeight, contextmenu: true });


            //预加载dialog的背景图片
            LG.prevDialogImage();

            var mainmenu = $("#mainmenu");

            $.getJSON('handler/tree.ashx?view=MyMenus&rnd=' + Math.random(), function (menus) {
                $(menus).each(function (i, menu) {
                    var item = $('<div  title="<table><tr><td><img src=' + menu.MenuIcon + ' height=18 width=18 align=top valign=middle/> ' + menu.MenuName + '</td></tr></table>"><ul class="menulist"></ul></div>');

                    $(menu.children).each(function (j, submenu) {
                        var subitem = $('<li><img/><span></span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>');
                        subitem.attr({
                            url: submenu.MenuUrl,
                            menuno: submenu.MenuNo
                        });
                        $("img", subitem).attr("src", submenu.MenuIcon || submenu.icon);
                        $("span", subitem).html(submenu.MenuName || submenu.text);

                        $("ul:first", item).append(subitem);
                    });
                    mainmenu.append(item);

                });

                //Accordion
                accordion = $("#mainmenu").ligerAccordion({ width: 250, height: bodyHeight - 24, speed: null });
                $("#pageloading").hide();
            });

            LG.ajax({
                type: 'AjaxMemberManage',
                method: 'GetCurrentUser',
                success: function (user) {
                    $(".l-topmenu-username").html(user.RealName + "，");
                },
                error: function () {
                    LG.tip('用户信息加载失败');
                }
            });
        });

    </script>
</body>
</html>
