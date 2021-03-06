﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSecondCarView.ascx.cs"
    Inherits="BitAuto.ISDC.CC2012.Web.CustInfo.DetailV.UCSecondCarView" %>
<!--功能废弃 强斐 2016-8-3-->
<%@ Register Src="~/CustInfo/DetailV/SurveyList.ascx" TagName="SurveyList" TagPrefix="uc1" %>
<script type="text/javascript">
    var uCCustHelper = (function () {
        var loadContacts = function () {//显示客户联系人
            $('#divCustContacts').load('/CustInfo/MoreInfo/CC_Contact/List.aspx', {
                ContentElementId: 'divCustContacts',
                TID: '<%= this.TaskID %>'
            });
        },

        loadSecondCar = function () {//显示二手车规模 
            $('#divSecondCar').load('/CustInfo/MoreInfo/CC_BusinessScale/List.aspx', {
                ContentElementId: 'divCustContacts',
                TID: '<%= this.TaskID %>'
            });
        },

        loadTaskLog = function () {
            $('#divTaskLog').load('/CustInfo/DetailV/TaskLogList.aspx', {
                ContentElementId: 'divCustContacts',
                TID: '<%= this.TaskID %>',
                PageSize: 10
            });
        },

   loadCallRecord = function () {
       $('#divCallRecordList').load('/CustInfo/DetailV/TaskCallRecordList.aspx', {
           ContentElementId: 'divCustContacts',
           Action: 'view',
           TID: '<%= this.TaskID %>',
           PageSize: 10
       });
   },

        SearchSameCustName = function (custID) { //查询重复客户名称
            var custName = $('#' + custID).html();
            //alert(custName);
            $.getJSON('/CustInfo/Handler.ashx?callback=?', {
                Action: 'SearchCustNameSameList',
                CustName: encodeURIComponent($.trim(custName)),
                CustID: '<%=Task.CrmCustID %>'
            }, function (jd, textStatus, xhr) {
                if (textStatus != 'success') { $.jAlert('请求错误'); return; }
                if (jd.success) {
                    var ulSameCustName = $('#ulSameCustName');
                    if (jd.result == '') { //通过客户名称查询CRM系统，没有重复的
                        ulSameCustName.find('table.cxjg tr:gt(0)').remove();
                        ulSameCustName.hide();
                        ulSameCustName.next('div.spliter').hide();
                        //ulSameCustName.prev('div.spliter').hide();
                    }
                    else {//有重复的
                        ulSameCustName.show();
                        ulSameCustName.next('div.spliter').show();
                        //ulSameCustName.prev('div.spliter').show();
                        var tableObj = ulSameCustName.find('table.cxjg');
                        tableObj.find('tr:gt(0)').remove();
                        $.each(jd.result.split(','), function (i, n) {
                            var trObj = $('<tr>');
                            $.each(n.split('_'), function (i, m) {
                                var htmlObj = m;
                                if (i == 1)//客户名称
                                { htmlObj = unescape(m); }
                                else if (i == 2) {//客户状态
                                    var imgCustStatusObj = $('<img>').css('margin-left', '5px').attr('status', m);
                                    if (m == '0')
                                    { htmlObj = imgCustStatusObj.attr({ 'title': '在用', 'src': '/Images/xt.gif' }); }
                                    else if (m == '1')
                                    { htmlObj = imgCustStatusObj.attr({ 'title': '停用', 'src': '/Images/xt_1.gif' }); }
                                }
                                else if (i == 3) {//锁定状态
                                    var imgCustLockObj = $('<img>').css('margin-left', '5px').attr('status', m);
                                    if (m == '0')
                                    { htmlObj = imgCustLockObj.attr({ 'title': '未锁定', 'src': '/Images/unlock.gif' }); }
                                    else if (m == '1')
                                    { htmlObj = imgCustLockObj.attr({ 'title': '锁定', 'src': '/Images/lock.gif' }); }
                                }
                                //alert(htmlObj);
                                trObj.append($('<td>').html(htmlObj));
                            });

                            tableObj.append(trObj);
                        });
                    }
                    //var msg = jd.result == '1' ? 'CRM库中已存在此客户名称' : 'CRM库中不存在此客户名称';
                    //$.jAlert(msg);
                }
                else {
                    $.jAlert('错误：' + jd.message);
                }
            });

        },

        init = function () {
            loadSecondCar();
            loadTaskLog();
            loadCallRecord();
            loadContacts();
        };
        return {
            init: init,
            SearchSameCustName: SearchSameCustName
        }
    })();
</script>
<script type="text/javascript">
    $(function () {
        <% if(this.CCCust==null) {%>
        $.jAlert('在任务ID为：<%=TaskID %>中，客户信息未初始化!');
        closePage();
        <%} %>
        uCCustHelper.init();
        uCCustHelper.SearchSameCustName('<%=this.spanCustName.ClientID %>');
        //控制展开和收起
        $('img.shouqizhankai').toggle(
          function () {
              $(this).attr({ src: '/images/zhankai.gif', title: '展开' })
              .next().hide("normal");
          },
          function () {
              $(this).attr({ src: '/images/shouqi.gif', title: '收起' })
            .next().show("normal");

          }
        );
    });
    function divShowHideEvent(divId, obj) {
            if ($(obj).attr("class") == "toggle") {
                $("#" + divId).show("slow");
                $(obj).attr("class", "toggle hide");
            }
            else {
                $("#" + divId).hide("slow");
                $(obj).attr("class", "toggle");
            }
        }
</script>
<div class="cont_cx khxx CustInfoArea">
    <div class="title ft16">
        基本信息 <a href="javascript:void(0)" onclick="divShowHideEvent('divCustBasicInfo',this)"
            class="toggle hide"></a>
    </div>
    <div id="divCustBasicInfo">
        <ul class="infoBlock firstPart">
            <li>
                <label style="width: 115px;">
                    客户名称：</label>
                <span id="spanCustName" name="CustName" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    客户简称：</label>
                <span id="spanCustAbbr" name="CustAbbr" runat="server" /></li>
        </ul>
        <%--<div class="spliter" style="display: none;">
        </div>--%>
        <ul class="infoBlock firstPart" id="ulSameCustName" style="display: none;">
            <li class="singleRow">
                <label style="width: 120px;">
                    客户名称重复列表：</label>
                <div style="margin-left: 78px;" class="fullRow  cont_cxjg">
                    <table cellspacing="0" cellpadding="0" border="0" class="cxjg" style="width: 100%">
                        <tbody>
                            <tr>
                                <th width="20%">
                                    客户ID
                                </th>
                                <th width="55%">
                                    客户名称
                                </th>
                                <th width="10%">
                                    客户状态
                                </th>
                                <th width="15%">
                                    客户锁定状态
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </li>
        </ul>
        <div class="spliter" style="display: none;">
        </div>
        <ul class="infoBlock firstPart">
            <li>
                <label style="width: 115px;">
                    客户类别：</label>
                <span id="spanCustType" name="CustType" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    客户行业：</label>
                <span id="spanCustIndustry" name="CustIndustry" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    经营范围：</label>
                <span id="spanCarType" name="CarType" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    客户地区：</label>
                <span id="spanArea" name="CustIndustry" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    注册地址：</label>
                <span id="spanAddress" name="Address" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    邮政编码：</label>
                <span id="spanZipcode" name="Zipcode" runat="server" /></li>
            <%--<li>
                <label style="width:115px;">
                    车商通会员ID：</label> 
                    <span id="spanCstMemberID" name="CstMemberID" style="float:left; width:auto;" runat="server"></span></li>--%>
            <%--<span id="spanCstMemberID" name="CstMemberID" runat="server" /></li>--%>
            <%if (CarType == 3)
              { %>
            <li>
                <label style="width: 115px;">
                    二手车经营类型：</label>
                <span id="spanUsedCarBusiness" name="UsedCarBusiness" runat="server" /></li>
            <%} %>
        </ul>
        <div class="spliter">
        </div>
        <ul class="infoBlock ">
            <li id="liCustStatus" runat="server" style="display: none;">
                <label style="width: 115px;">
                    客户状态：</label>
                <img style="margin-left: 5px;" id="imgCustStatus" runat="server">
            </li>
            <li id="liCustLock" runat="server" style="display: none;">
                <label style="width: 115px;">
                    锁定：</label>
                <img style="margin-left: 5px;" id="imgCustStatusLock" runat="server" />
            </li>
            <li>
                <label style="width: 115px;">
                    客户级别：</label>
                <span id="spanCustLevel" name="CustLevel" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    联系人：</label>
                <span id="spanContactName" name="ContactName" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    电话：</label>
                <span id="spanOfficeTel" name="OfficeTel" runat="server" /></li>
            <li>
                <label style="width: 115px;">
                    传真：</label>
                <span id="spanFax" name="Fax" runat="server" /></li>
            <%if (CarType != 1)
              { %>
            <li>
                <label style="width: 115px">
                    所属交易市场：</label>
                <span id="spanTradeMarketID" name="TradeMarketID" runat="server" /></li>
            <%} %>
            <li class="singleRow">
                <label style="width: 115px;">
                    备注：</label>
                <span id="spanNotes" name="Notes" runat="server" /></li>
            <li class="singleRow">
                <label style="width: 115px;">
                    客户联系人：</label>
                <div id="divCustContacts" class="fullRow  cont_cxjg" style="margin-left: 78px;">
                </div>
            </li>
            <li class="singleRow">
                <label style="width: 115px;">
                    二手车规模：</label>
                <div id="divSecondCar" class="fullRow  cont_cxjg" style="margin-left: 78px;">
                </div>
            </li>
        </ul>
    </div>
</div>
<div id="divMembers">
    <asp:PlaceHolder ID="PlaceHolder" runat="server"></asp:PlaceHolder>
</div>
<%--暂时屏蔽车商通信息--%>
<%if (1 == 2) %>
<%{ %>
<div id="divCstMembers">
    <asp:PlaceHolder ID="PlaceHolderCstMembers" runat="server"></asp:PlaceHolder>
</div>
<%} %>
<div class="cont_cx khxx CustInfoArea">
    <div class="title ft16" style="clear: both">
        问卷调查 <a class="toggle hide" onclick="divShowHideEvent('divSurvey',this)" href="javascript:void(0)">
        </a>
    </div>
    <div id="divSurvey">
        <uc1:SurveyList ID="SurveyListID" runat="server" />
    </div>
</div>
<div class="cont_cx khxx CustInfoArea">
    <div class="title ft16" style="clear: both">
        记录历史 <a href="javascript:void(0)" onclick="divShowHideEvent('infoBlock1',this)" class="toggle hide">
        </a>
    </div>
    <div id="infoBlock1">
        <ul class="infoBlock firstPart">
            <li class="singleRow">
                <div style="float: left">
                    操作记录</div>
                <div id="divTaskLog" class="fullRow cont_cxjg" style="margin-left: 78px;">
                </div>
            </li>
            <li class="singleRow">
                <div style="float: left">
                    通话记录</div>
                <div id="divCallRecordList" class="fullRow cont_cxjg" style="margin-left: 78px;">
                </div>
            </li>
        </ul>
    </div>
</div>
