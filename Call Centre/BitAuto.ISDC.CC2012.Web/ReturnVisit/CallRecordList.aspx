﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallRecordList.aspx.cs"
    Inherits="BitAuto.ISDC.CC2012.Web.ReturnVisit.CallRecordList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript">
    function openPlayAudioPopup(audioURL) {
        $.openPopupLayer({
            name: "PlayAudioAjaxPopup",
            parameters: { AudioURL: audioURL },
            popupMethod: 'Post',
            url: "/AjaxServers/AudioManager/PlayAudioLayer.aspx"
        });
    }
</script>
<table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="cxjg">
    <tr>
        <th width="10%">
            联系人
        </th>
        <th width="10%">
            联系电话
        </th>
        <th width="18%">
            通话开始时间
        </th>
        <th width="18%">
            通话结束时间
        </th>
        <th width="10%">
            操作人
        </th>
        <th width="10%">
            播放录音
        </th>
        <%--<th width="20%">播放录音 </th>--%>
    </tr>
    <asp:repeater id="repeater_Contact" runat="server">
        <ItemTemplate>
            <tr>
                <td><%#Eval("Contact").ToString()%></td>
                <td><%#Eval("phonenum").ToString()%></td>
                <td>
                    <%# BitAuto.ISDC.CC2012.Entities.CommonFunction.GetDateTimeStrForPage(Eval("BeginTime").ToString())%>&nbsp;
                </td>
                <td>
                    <%# BitAuto.ISDC.CC2012.Entities.CommonFunction.GetDateTimeStrForPage(Eval("EndTime").ToString())%>&nbsp;
                </td>
                <td>
                   <%#BitAuto.ISDC.CC2012.BLL.Util.GetNameInHRLimitEID(Convert.ToInt32(Eval("CreateUserID").ToString()))%>               
                </td>
                <td>
                            <%# Eval("AudioURL").ToString().Trim() == "" ? "" : "<a href='javascript:void(0);' onclick='javascript:ADTTool.PlayRecord(\"" + Eval("AudioURL").ToString() + "\");' title='播放录音' ><img src='../Images/callTel.png' /></a>"%>&nbsp;
                        </td>
                     
            </tr>               
        </ItemTemplate>
    </asp:repeater>
</table>
