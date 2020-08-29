﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StopCustTaskOperationLog.aspx.cs"
    Inherits="BitAuto.ISDC.CC2012.Web.CustInfo.MoreInfo.StopCustTaskOperationLog" %>

<script type="text/javascript">
    $('#tableList tr:even').addClass('color_hui'); //设置列表行样式
    //分页操作
    function ShowDataByPost1(pody) {
        $('#divOperationLogPop').load('/CustInfo/MoreInfo/StopCustTaskOperationLog.aspx #divOperationLogPop > *', pody + '&random=' + Math.random(), LoadDivSuccess);
    }
    //查询之后，回调函数
    function LoadDivSuccess(data) {
        $('#divOperationLogPop tr:even').addClass('color_hui'); //设置列表行样式
    }
</script>
<div class="pop pb15 openwindow">
    <div class="title bold">
        <h2>
            审批记录55</h2>
        <span><a href="javascript:void(0)" onclick="javascript:$.closePopupLayer('OperationLogPop');">
        </a></span>
    </div>
    <div class="Table2" id="divOperationLogPop">
        <table width="98%" border="1" cellpadding="0" cellspacing="0" class="Table2List"
            id="tableList">
            <tbody>
                <tr class="bold">
                    <th style="width: 25%;">
                        操作时间
                    </th>
                    <th style="width: 15%;">
                        操作人
                    </th>
                    <th style="width: 15%;">
                        操作类型
                    </th>
                    <th style="width: 15%;">
                        状态
                    </th>
                    <th style="width: 30%;">
                        备注
                    </th>
                </tr>
                <asp:repeater id="repeaterTableList2" runat="server">
        <ItemTemplate>
            <tr>   
                <td >
                    <%# BitAuto.ISDC.CC2012.Entities.CommonFunction.GetDateTimeStrForPage(Eval("CreateTime").ToString())%>&nbsp;
                </td>         
                 <td >
                    <%# Eval("TrueName")%>&nbsp;
                </td>  
                <td>
                    <%# Eval("OperationStatus")%>&nbsp;
                </td>  
                <td >
                    <%# Eval("TaskStatus")%>&nbsp;
                </td>  
                <td>
                    <%# Eval("Remark")%>&nbsp;
                </td>                   
            </tr>
        </ItemTemplate>        
    </asp:repeater>
            </tbody>
        </table>
    </div>
    <!--分页-->
    <div class="pageTurn mr10">
        <p>
            <asp:literal runat="server" id="litPagerDown22"></asp:literal>
        </p>
    </div>
</div>