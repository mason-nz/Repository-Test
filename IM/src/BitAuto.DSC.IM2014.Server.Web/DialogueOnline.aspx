﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DialogueOnline.aspx.cs"
    Inherits="BitAuto.DSC.IM2014.Server.Web.DialogueOnline" %>

<%@ Register Src="Controls/Top.ascx" TagName="Top" TagPrefix="uc1" %>
<%@ Register Src="Controls/Bottom.ascx" TagName="Bottom" TagPrefix="uc2" %>
<%@ Register Src="Controls/ControlManage.ascx" TagName="ControlManage" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线对话</title>
    <script src="/js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#mb1").append("<li><a href='#' class='cur'>在线对话</a></li>").append("<li><a href='MessageOnline.aspx'>在线留言</a></li>");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="head">
            <uc1:Top ID="Top1" runat="server" />
            <div class="mainmenu_bottom">
                <ul class="" id="mb1">
                    <uc3:ControlManage ID="ControlManageSet1" runat="server" />
                </ul>
                <div class="clearfix">
                </div>
            </div>
        </div>
        <!--内容开始-->
        <div class="content content2">
            <!--列表开始-->
            <div class="cxList online_dh" style="margin-top: 8px;">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="20%">
                            访客ID
                        </th>
                        <th width="20%">
                            开始时间
                        </th>
                        <th width="15%">
                            对话时长
                        </th>
                        <th width="15%">
                            姓名
                        </th>
                        <th width="15%">
                            地区
                        </th>
                        <th width="15%">
                            客服
                        </th>
                    </tr>
                    <tr>
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                    <tr class="current">
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                    <tr>
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                    <tr>
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                    <tr>
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                    <tr>
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                    <tr>
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                    <tr>
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                    <tr>
                        <td>
                            1234567890
                        </td>
                        <td>
                            2014-2-21 10:00
                        </td>
                        <td>
                            38分44秒
                        </td>
                        <td>
                            赵先生
                        </td>
                        <td>
                            北京市
                        </td>
                        <td>
                            张莹莹
                        </td>
                    </tr>
                </table>
                <!--分页开始-->
                <div class="pagesnew" style="margin-right: 0; margin-top: 10px;">
                    <span class="pre">上一页</span> <a href="#" class="active">1</a> <a href="#">2</a>
                    <a href="#">3</a> <a href="#">4</a> <a href="#">5</a> <span>...</span> <span><a href="#"
                        class="next">下一页</a></span> <span>共50页</span> <span>到第</span><input type="text" value="" /><span>页</span>
                    <span class="qd_go"><a href="#">GO</a></span>
                </div>
                <!--分页结束-->
            </div>
            <!--列表结束-->
            <!--信息展示-->
            <div class="kh_info">
                <div id="Tab1">
                    <div class="Menubox">
                        <ul>
                            <li id="one1" onclick="setTab('one',1,3)" class="hover">客记信息</li>
                            <li id="one2" onclick="setTab('one',2,3)">对话记录</li>
                            <li id="one3" onclick="setTab('one',3,3)">详细信息</li>
                        </ul>
                    </div>
                    <div class="Contentbox">
                        <!--客户信息-->
                        <div id="con_one_1" class="hover">
                            <table border="0" cellspacing="0" cellpadding="0" class="cusInfo">
                                <tr>
                                    <th width="20%">
                                        姓名：
                                    </th>
                                    <td width="30%">
                                        李先生
                                    </td>
                                    <th width="20%">
                                        性别：
                                    </th>
                                    <td width="30%">
                                        男
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        电话：
                                    </th>
                                    <td>
                                        13411111111
                                    </td>
                                    <th>
                                        QQ：
                                    </th>
                                    <td>
                                        132121312
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        邮箱：
                                    </th>
                                    <td>
                                        1@1.com
                                    </td>
                                    <th>
                                        客户分类：
                                    </th>
                                    <td>
                                        个人
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        地区：
                                    </th>
                                    <td>
                                        广东省，深圳市
                                    </td>
                                    <th>
                                        客户ID：
                                    </th>
                                    <td>
                                        CB00381147
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        工单记录：
                                    </th>
                                    <td colspan="3">
                                        网友查询昌平地区的4S店，告知在昌平暂时没有通过易车认证的，网友表示自己在看看，已记录
                                    </td>
                                </tr>
                            </table>
                            <div class="btn">
                                <div class="right">
                                    <input type="button" value="编辑信息" class="w80 gray" />
                                    <input type="button" value="添加工单" class="w80 gray" /></div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <!--客户信息-->
                        <!--对话记录-->
                        <div id="con_one_2" style="display: none">
                            <div class="dialogue">
                                <p>
                                    对话开始于: 09:53</p>
                                <div class="scroll_gd">
                                    <div class="dh1">
                                        <div class="title">
                                            张莹莹 09:53:31</div>
                                        <div class="dhc">
                                            您好，欢迎您访问！请问有什么需要咨询？</div>
                                    </div>
                                    <div class="dh1">
                                        <div class="title">
                                            张莹莹 09:53:31</div>
                                        <div class="dhc">
                                            您好，欢迎您访问！请问有什么需要咨询？</div>
                                    </div>
                                    <div class="dh1">
                                        <div class="title">
                                            张莹莹 09:53:31</div>
                                        <div class="dhc">
                                            您好，欢迎您访问！请问有什么需要咨询？</div>
                                    </div>
                                </div>
                                <p>
                                    结束:10:31:29
                                </p>
                                <p>
                                    访客关闭对话。
                                </p>
                            </div>
                        </div>
                        <!--对话记录-->
                        <!--详细信息-->
                        <div id="con_one_3" style="display: none">
                            <div class="dialogue">
                                <p>
                                    开始时间: 2014-02-21 09:5268997780</p>
                                <p>
                                    应答于: 2014-02-21 09:53</p>
                                <p>
                                    结束时间: 02-21 10:31</p>
                                <p>
                                    对话时长: 38分44秒</p>
                                <p>
                                    客服: admin001</p>
                                <p>
                                    服务评价:</p>
                                <p>
                                    访客姓名: V338616002</p>
                                <p>
                                    访客地区: 中国 北京市
                                </p>
                                <p>
                                    访客IP: 123.127.236.130</p>
                                <p>
                                    对话类型: 点击咨询图标</p>
                                <p>
                                    访客来源:<a href="#"> http://fanxian.bitauto.com/carsource/nb2977/nc102900/c201/</a></p>
                                <p>
                                    发起页面:<a href="#"> http://fanxian.bitauto.com/carsource/nb2977/nc102900/c201/</a></p>
                            </div>
                        </div>
                        <!--详细信息-->
                    </div>
                </div>
            </div>
            <!--信息展示-->
            <div class="clearfix">
            </div>
        </div>
        <div class="clearfix">
        </div>
        <!--内容结束-->
        <uc2:Bottom ID="Bottom1" runat="server" />
    </div>
    </form>
</body>
</html>