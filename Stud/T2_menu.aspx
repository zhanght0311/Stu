<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T2_menu.aspx.cs" Inherits="Stud.T2_menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生发展档案管理系统</title>
    <style type="text/css">
    body{ margin:0px; padding:0px; font-size:12px}
    </style>
 
    <link href="Styles/style.css" rel="Stylesheet" type="text/css" />
    <link href="scripts/ui/skins/Aqua/css/ligerui-all.css" rel="Stylesheet" type="text/css" />
    <script src="scripts/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="scripts/ui/js/ligerBuild.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        var tree = null;

        $(function () {
            //页面布局
            $("#global_layout").ligerLayout({ leftWidth: 180, height: '100%', topHeight: 70, bottomHeight: 24, allowTopResize: false, allowBottomResize: false, allowLeftCollapse: true, onHeightChanged: f_heightChanged });

            var height = $(".l-layout-center").height();

            //Tab
            $("#framecenter").ligerTab({ height: height });

            //左边导航面板
            $("#global_left_nav").ligerAccordion({ height: height - 25, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });

            //设置频道菜单
            $("#global_channel_tree").ligerTree({
                url: 'Ajax/admin_ajax.ashx?action=sys_channel_load&us',
                checkbox: false,
                nodeWidth: 112,
                //attribute: ['nodename', 'url'],
                onSelect: function (node) {
                    if (!node.data.url) return;
                    var tabid = $(node.target).attr("tabid");
                    if (!tabid) {
                        tabid = new Date().getTime();
                        $(node.target).attr("tabid", tabid)
                    }
                    f_addTab(tabid, node.data.text, node.data.url);
                }
            });

            //加载插件菜单
            loadPluginsNav();

            //快捷菜单
            var menu = $.ligerMenu({ width: 120, items:
		[
			{ text: '管理首页', click: itemclick },
			{ line: true },
			{ text: '关闭菜单', click: itemclick }
            
		]
            });
            $("#tab-tools-nav").bind("click", function () {
                var offset = $(this).offset(); //取得事件对象的位置
                menu.show({ top: offset.top + 27, left: offset.left - 120 });
                return false;
            });

            tab = $("#framecenter").ligerGetTabManager();
            accordion = $("#global_left_nav").ligerGetAccordionManager();
            tree = $("#global_channel_tree").ligerGetTreeManager();
            //tree.expandAll(); //默认展开所有节点
            $("#pageloading_bg,#pageloading").hide();
        });

        //频道菜单异步加载函数，结合ligerMenu.js使用
        function loadChannelTree() {
            if (tree != null) {
                tree.clear();

                tree.loadData(null, "Ajax/admin_ajax.ashx?action=sys_channel_load");
            }
        }

        //加载插件管理菜单
        function loadPluginsNav() {
            $.ajax({
                type: "POST",
                url: "Ajax/admin_ajax.ashx?action=plugins_nav_load&time=" + Math.random(),
                timeout: 20000,
                beforeSend: function (XMLHttpRequest) {
                    $("#global_plugins").html("<div style=\"line-height:30px; text-align:center;\">正在加载，请稍候...</div>");
                },
                success: function (data, textStatus) {
                    $("#global_plugins").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $("#global_plugins").html("<div style=\"line-height:30px; text-align:center;\">加载插件菜单出错！</div>");
                }
            });
        }

        //快捷菜单回调函数
        function itemclick(item) {
            switch (item.text) {
                case "管理首页":
                    f_addTab('home', '管理中心', 'center.aspx');
                    break;
                default:
                    f_CloseTab();
                    break;
            }
        }
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        //添加Tab，可传3个参数
        function f_addTab(tabid, text, url, iconcss) {
            if (arguments.length == 4) {
                tab.addTabItem({ tabid: tabid, text: text, url: url, iconcss: iconcss });
            } else {
                tab.addTabItem({ tabid: tabid, text: text, url: url });
            }
        }
        //关闭Tab
        function f_CloseTab() {
            var itemiframe = "#framecenter .l-tab-content .l-tab-content-item";
            var curriframe = "";
            $(itemiframe).each(function () {
                if ($(this).css("display") != "none") {
                    curriframe = $(this).attr("tabid");
                    return false;
                }
            });
            if (curriframe != "home") {
                tab.removeTabItem(curriframe);
                dialog.close();
            }
        }

        //提示Dialog并关闭Tab
        function f_errorTab(tit, msg) {
            $.ligerDialog.open({
                isDrag: false,
                allowClose: false,
                type: 'error',
                title: tit,
                content: msg,
                buttons: [{
                    text: '确定',
                    onclick: function (item, dialog, index) {
                        //查找当前iframe名称
                        var itemiframe = "#framecenter .l-tab-content .l-tab-content-item";
                        var curriframe = "";
                        $(itemiframe).each(function () {
                            if ($(this).css("display") != "none") {
                                curriframe = $(this).attr("tabid");
                                return false;
                            }
                        });
                        if (curriframe != "") {
                            tab.removeTabItem(curriframe);
                            dialog.close();
                        }
                    }
                }]
            });
        }
</script>
</head>
<body>
 <form id="form1" runat="server">
 <div id="global_layout" class="layout" style="width:100%">
 <!--头部-->
    <div  position="top" class="header">
        <div style="background-image:url(Image/Index_02.gif); height:15px;">
        
        </div>
        <div style="background-image:url(Image/Index_04.gif); height:60px;">
            <div style=" height:60px; width:400px; float:left;">
    <img alt="" src="Image/Index_03.gif" />
    </div>
            <div style=" height:60px; width:300px; float:right; text-align:right;">
    <div style="margin-top:20px; margin-right:55;color: #464646;  font-size: 14px;";>
    <asp:Label ID="Lb_User" runat="server" Text=""></asp:Label>
    </div>
    </div>
        </div>
    </div>
    <div position="left"  title="快捷菜单" id="global_left_nav"> 
            <div title="信息录入" iconcss="menu-icon-model" class="l-scroll">
                <ul class="nlist">
                <% if (true) 
                { %>
                    <li><a class="l-link" href="javascript:f_addTab('listpage1','记录学生专业课表现','teacher2/T2_1.aspx')">记录学生专业课表现</a></li>
               <%}
                if (true) 
                { %>
                    <li><a class="l-link" href="javascript:f_addTab('listpage2','学生专业发展评价','teacher2/T2_2.aspx')">学生专业发展评价</a></li>
                <%}%>
                </ul>
            </div>
            
                <div title="系统设置" iconcss="menu-icon-model" class="l-scroll">
                <ul class="nlist">
                   
                  <%if (true)
                  { %>
                   <li><a class="l-link" href="javascript:f_addTab('listpage6','修改密码','passwd.aspx')">修改密码</a></li>
                   <%} %>  
                    
                     <% if (true) 
                { %>
                    <li><a class="l-link" href="Default.aspx">退出系统</a></li>
                <%}%>
                </ul>
            </div>
           
           
            
           
          
            
        </div>
        <div position="center" id="framecenter" toolsid="tab-tools-nav"> 
            <div tabid="home" title="个人中心" iconcss="tab-icon-home" style="height:300px" >
                <iframe frameborder="0" name="sysMain" ></iframe> 

            </div> 
        </div> 
        <div position="bottom" class="footer">
            <div class="copyright">Copyright &copy; Hebei University of Technology , 河北工业大学</div>
        </div>
    </div>
    </form>
    </body>
</html>

