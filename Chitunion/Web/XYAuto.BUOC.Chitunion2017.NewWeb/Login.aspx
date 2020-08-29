﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="XYAuto.BUOC.Chitunion2017.NewWeb.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录-赤兔联盟</title>
    <meta http-equiv="keywords" content="赤免联盟,登录" />
    <meta http-equiv="description" content="赤兔联盟,登录,微播易,新榜,蜂传,疯传,Robin8" />
    <meta name="keywords" content="赤免联盟,登录" />
    <meta name="description" content="赤兔联盟,登录,微播易,新榜,蜂传,疯传,Robin8" />

    <link rel="stylesheet" href="/css/common.css" />
    <script type="text/javascript" src="/js/jquery.1.11.3.min.js"></script>
    <script type="text/javascript" src="/js/jquery.browser.js"></script>
    <script type="text/javascript" src="/js/Common_chitu.js"></script>


    <script type="text/javascript" src="/js/tab.js"></script>
    <script type="text/javascript" src="/js/login.js"></script>


     <script>
        //百度统计代码
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "https://hm.baidu.com/hm.js?25a4fec22e854c0ec742ae03e3036fc7";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
         </script>
</head>
<body onkeydown="LoginHelper.KeyDown(event);">
    <div class="login_container">
        <div class="logo_txt">

            <img src="../images/login/logo.png" />
        </div>
        <div class="shape">

            <div class="main">
                <div class="left">
                    <!-- 身份角色 -->
                    <ul class="nav">
                        <li class="selected" category='29001'><a href="javascript:void(0);">广告主</a></li>
                        <li category='29002'><a href="javascript:void(0);">媒体主</a></li>
                    </ul>

                    <!-- 两种身份入口 -->
                    <div class="two_rules">

                        <!-- 广告主 1.账号登录  2.微信二维码扫描登录-->
                        <div class="role_advertisers">

                            <!-- 1.账号登录 -->
                            <div class="account" style='display: block;'>
                                <ul class="all_input">
                                    <li>
                                        <input id="txtGGZUserName" type="text" placeholder="请输入用户名/手机号" onblur="javascript:if(this.value != '') LoginHelper.Verify(29001);" autocomplete="off" />
                                    </li>
                                    <li>
                                        <input id="txtGGZPwd" type="password" placeholder="请输入密码（6-20字符）" onblur="javascript:if(this.value != '') LoginHelper.Verify(29001);" autocomplete="off" />
                                        <a href="javascript:void(0);" class="close pwdTag">
                                            <img  src='../images/login/close.png'/></a>
                                    </li>
                                    <li>
                                        <input id="txtGGZCheckCode" type="text" placeholder="请输入验证码" />
                                        <%--<a href="javascript:;" class="code">获取验证码</a>--%>

                                        <img id="imgGGZ" class="code" src='CheckCode.aspx' />
                                    </li>
                                    <li>
                                        <img class="imgerror" src='../images/login/error.png' style="visibility: hidden;">
                                        <label id="divErrorGGZMsg" class="notes"></label>
                                    </li>
                                </ul>
                                <div class="btn">
                                    <a href="javascript:void(0);" onclick="javascript:LoginHelper.Login(29001);" class="login_btn">登录</a>
                                </div>
                                <ul class="bottom">
                                    <li>
                                        <a href="/usermanager/ForgetPwd.html?Type=1">忘记密码</a>
                                    </li>

                                    <li>
                                        <img src='../images/login/btn_wechat.png' />
                                        微信
										<a name="aWxLogin" href="javascript:void(0);">登录</a>
                                    </li>
                                    <li>还没账号 <a href="/usermanager/Register.html?Type=1">注册</a></li>
                                </ul>
                            </div>

                            <!-- 2.微信二维码扫描登录 -->

                            <div class="we_code" style="display: none;">
                                <img  class="code">
                                <p name="pwx_OK" style="display:none;" class="tit">
                                    <img src="../images/login/alreday.png">
                                    扫描成功，请在微信点击确认即可登录
                                </p>
                                <p name="pwx_tag" class="tit">打开微信扫一扫登录 赤兔联盟</p>
                                <p class="bottom">
                                    <a name="aAcctLogin" href="javascript:void(0);">账号登录</a>
                                </p>

                            </div>

                        </div>

                        <!-- 媒体主 -->
                        <div class="role_media">

                            <!-- 1.账号登录 -->
                            <div class="account" style='display: none;'>
                                <ul class="all_input">
                                    <li>
                                        <input id="txtMTZUserName" type="text" placeholder="请输入用户名/手机号" onblur="javascript:if(this.value != '') LoginHelper.Verify(29002);" autocomplete="off" />
                                    </li>
                                    <li>
                                        <input id="txtMTZPwd" type="password" placeholder="请输入密码（6-20字符）" onblur="javascript:if(this.value != '') LoginHelper.Verify(29002);" autocomplete="off" />
                                        <a href="javascript:;" class="close pwdTag">
                                            <img src='../images/login/close.png'></a>
                                    </li>
                                    <li>
                                        <input id="txtMTZCheckCode" type="text" placeholder="请输入验证码" />
                                        <%--<a href="javascript:;" class="code">获取验证码</a>--%>

                                        <img id="imgMTZ" class="code" src='CheckCode.aspx' />
                                    </li>
                                    <li>
                                        <img class="imgerror" src='../images/login/error.png' style="visibility: hidden;">
                                        <label id="divErrorMTZMsg" class="notes"></label>
                                    </li>
                                </ul>
                                <div class="btn">
                                    <a href="javascript:void(0);" onclick="javascript:LoginHelper.Login(29002);" class="login_btn">登录</a>
                                </div>
                                <ul class="bottom">
                                    <li>
                                        <a href="/usermanager/ForgetPwd.html?Type=2">忘记密码</a>
                                    </li>
                                    <li>
                                        <img src='../images/login/btn_wechat.png'>
                                        微信
										<a name="aWxLogin" href="javascript:void(0);">登录</a>
                                    </li>
                                    <li>还没账号 <a href="/usermanager/Register.html?Type=2">注册</a></li>
                                </ul>
                            </div>

                            <!-- 2.微信二维码扫描登录 -->
                            <div class="we_code" style="display: none;">
                                <img  class="code">
                                <p name="pwx_OK" style="display:none;" class="tit">
                                    <img src="../images/login/alreday.png">
                                    扫描成功，请在微信点击确认即可登录
                                </p>
                                <p name="pwx_tag" class="tit">打开微信扫一扫登录 赤兔联盟</p>
                                <p class="bottom">
                                    <a name="aAcctLogin" href="javascript:void(0);">账号登录</a>
                                </p>
                            </div>

                        </div>
                    </div>

                </div>
                <div class="right">
                    <img src="../images/login/right.png">
                </div>
            </div>
        </div>
    </div>

    <!--统计代码-->
    <!--#include virtual="/base/statistics.html" -->
</body>
</html>