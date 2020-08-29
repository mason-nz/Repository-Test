﻿/********************************
* 项目名称 ：XYAuto.ChiTu2018.Service.App.Sign
* 类 名 称 ：AppSignService
* 描    述 ：
* 作    者 ：zhangjl
* 创建时间 ：2018/6/12 10:37:47
********************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYAuto.ChiTu2018.BO.HD;
using XYAuto.ChiTu2018.BO.Task;
using XYAuto.ChiTu2018.BO.Wechat;
using XYAuto.ChiTu2018.Entities.Chitunion2017.LE;
using XYAuto.ChiTu2018.Entities.Enum.Profit;
using XYAuto.ChiTu2018.Entities.Enum.Wechat;
using XYAuto.ChiTu2018.Infrastructure.AutoMapper;
using XYAuto.ChiTu2018.Service.App.Sign.Dto;
using XYAuto.CTUtils.Config;
using XYAuto.CTUtils.Sys;

namespace XYAuto.ChiTu2018.Service.App.Sign
{
    public class AppSignService
    {
        #region 初始化
        private AppSignService() { }
        private static readonly Lazy<AppSignService> linstance = new Lazy<AppSignService>(() => new AppSignService());

        public static AppSignService Instance => linstance.Value;
        #endregion

        /// <summary>
        /// 微信签到
        /// </summary>
        /// <param name="IP">签到IP</param>
        /// <returns></returns>
        public AppRespLeDaySignDto DaySign(string IP, int userId)
        {

            DateTime dtNow = DateTime.Now;
            var LeDaySignDto = new WechatSignBO().GetSignNumber(userId).MapTo<AppLeDaySignDto>();

            LE_DaySign daySignInfo = new LE_DaySign { SignUserID = userId, SignTime = dtNow, SignPrice = 0, IP = IP };
            //根据用户ID获取当天订单数量
            int orderCount = new LEADOrderInfoBO().GetUserOrderCount(userId);

            var signOrderCount = ConfigurationUtil.GetAppSettingValue("SignOrderCount", "5");

            if (LeDaySignDto == null)
            {
                daySignInfo.SignNumber = 1;
            }
            else
            {
                DateTime dtSign = ConverHelper.ObjectToDateTime(ConverHelper.ObjectToDateTime(LeDaySignDto.SignTime).ToString("yyyy-MM-dd"));
                TimeSpan dSpan = ConverHelper.ObjectToDateTime(dtNow.ToString("yyyy-MM-dd")).Subtract(dtSign);
                if (dSpan.Days > 0)
                {
                    if (dSpan.Days == 1 && ConverHelper.ObjectToInteger(LeDaySignDto.SignNumber) < 7)
                    {
                        daySignInfo.SignNumber = ConverHelper.ObjectToInteger(LeDaySignDto.SignNumber) + 1;
                    }
                    else
                    {
                        daySignInfo.SignNumber = 1;
                    }
                }
                else
                {
                    return new AppRespLeDaySignDto { Amount = 0, Message = "您今天已签到", isLuckDraw = false, AlreadyOrderCount = orderCount, SignOrderCount = ConverHelper.ObjectToInteger(signOrderCount) };
                }
            }
            if (orderCount < Convert.ToInt32(signOrderCount))
            {
                return new AppRespLeDaySignDto { Amount = 0, Message = $"分享{signOrderCount}篇文章后才可签到哦！", isLuckDraw = false, AlreadyOrderCount = orderCount, SignOrderCount = ConverHelper.ObjectToInteger(signOrderCount) };

            }
            if (!string.IsNullOrEmpty(IP) && new WechatSignBO().VeriftIsDaySign(userId, IP))
            {
                string price = ConfigurationUtil.GetAppSettingValue("DaySignPrice", "0.1,0.2,0.25,0.3,0.35,0.4,0.5");
                if (daySignInfo?.SignNumber != null)
                    daySignInfo.SignPrice = ConverHelper.ObjectToDecimal(price.Split(',')[(int)daySignInfo.SignNumber - 1]);
            }
            if (new WechatSignBO().AddDaySign(daySignInfo) == null)
            {
                return new AppRespLeDaySignDto { Amount = 0, Message = $"签到失败，请重试", isLuckDraw = false, AlreadyOrderCount = orderCount, SignOrderCount = ConverHelper.ObjectToInteger(signOrderCount) };

            }
            var isLuckDraw = false;
            var hdLuckList = new HdLuckDrawActivityBO().GetActivityInfo();
            if (hdLuckList == null || hdLuckList.Count <= 0)
                return new AppRespLeDaySignDto { Amount = ConverHelper.ObjectToDecimal(daySignInfo.SignPrice), Message = string.Empty, isLuckDraw = isLuckDraw, AlreadyOrderCount = orderCount, SignOrderCount = ConverHelper.ObjectToInteger(signOrderCount) };
            var dr = hdLuckList[0];
            var luckDrawStartDate = Convert.ToDateTime(dr.StartTime);
            var luckDrawEndDate = Convert.ToDateTime(dr.EndTime);
            if (dtNow >= luckDrawStartDate && dtNow <= luckDrawEndDate)
            {
                if (true)
                {
                    isLuckDraw = true;
                }
            }
            return new AppRespLeDaySignDto { Amount = ConverHelper.ObjectToDecimal(daySignInfo.SignPrice), Message = string.Empty, isLuckDraw = isLuckDraw, AlreadyOrderCount = orderCount, SignOrderCount = ConverHelper.ObjectToInteger(signOrderCount) };

        }
        /// <summary>
        /// 根据年月查询签到日期
        /// </summary>
        /// <param name="signYear">年</param>
        /// <param name="signMonth">月</param>
        /// <returns></returns>
        public AppRespWeChatSignDto DaySignList(int signYear, int signMonth, int userId)
        {
            AppRespWeChatSignDto dto = new AppRespWeChatSignDto();

            string nowDate = signYear + "-" + signMonth.ToString().PadLeft(2, '0');
            string lastDate = ConverHelper.ObjectToDateTime(nowDate).AddMonths(-1).ToString("yyyy-MM");
            string mextDate = ConverHelper.ObjectToDateTime(nowDate).AddMonths(1).ToString("yyyy-MM");

            var leDaySignList = new WechatSignBO().SelectDaySignListByMonth().AsEnumerable()
                .Where(p => p.SignUserID == userId && ConverHelper.ObjectToDateTime(ConverHelper.ObjectToDateTime(p.SignTime).ToString("yyyy-MM-01")) > ConverHelper.ObjectToDateTime(lastDate)
                 && ConverHelper.ObjectToDateTime(ConverHelper.ObjectToDateTime(p.SignTime).ToString("yyyy-MM-01")) <= ConverHelper.ObjectToDateTime(mextDate))
                .ToList()
                .MapToList<LE_DaySign, AppLeDaySignDto>();
            if (leDaySignList != null && leDaySignList.Count > 0)
            {
                dto.SignDayList = new List<string>();
                foreach (AppLeDaySignDto item in leDaySignList)
                {
                    {
                        dto.SignDayList.Add(ConverHelper.ObjectToDateTime(item.SignTime).ToString("yyyy-M-d"));
                    }
                }
            }
            dto.IsSign = new WechatSignBO().SelectDaySignListByMonth().Any(p => p.SignUserID == userId && DbFunctions.TruncateTime(p.SignTime) == DbFunctions.TruncateTime(DateTime.Now));
            dto.TotalPrice = new WechatSignBO().GetTotalPriceByUserId(userId, (int)ProfitTypeEnum.签到红包统计);
            return dto;
        }
        /// <summary>
        /// 判断活动是否结束
        /// </summary>
        /// <param name="req"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public object IsValidActivity(AppSignReqDto req, ref string errorMsg)
        {
            errorMsg = string.Empty;
            if (!req.CheckSelfModel(out errorMsg))
                return null;
            var tmpDate = new DateTime(1900, 1, 1);
            if (req.ActivityType == (int)ActivityTypeEnum.签到有礼)
                tmpDate = ConverHelper.ObjectToDateTime(ConfigurationUtil.GetAppSettingValue("SignDate"));
            else
                tmpDate = ConverHelper.ObjectToDateTime(ConfigurationUtil.GetAppSettingValue("InviteDate"));

            TimeSpan ts = tmpDate.Date.Subtract(DateTime.Now.Date);
            return ts.Days > 0;
        }
    }
}