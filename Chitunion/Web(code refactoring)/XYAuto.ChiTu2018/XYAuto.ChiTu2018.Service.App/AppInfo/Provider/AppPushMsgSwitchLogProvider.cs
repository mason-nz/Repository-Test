﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYAuto.ChiTu2018.BO.Android;
using XYAuto.ChiTu2018.Infrastructure.Extensions;
using XYAuto.ChiTu2018.Infrastructure.VerifyArgs;
using XYAuto.ChiTu2018.Service.App.AppInfo.Dto.Request;
using XYAuto.ChiTu2018.Service.App.AppInfo.Dto.Response;
using XYAuto.CTUtils.Config;

namespace XYAuto.ChiTu2018.Service.App.AppInfo.Provider
{
    /// <summary>
    /// 注释：AppPushMsgSwitchLogProvider
    /// 作者：lix
    /// 日期：2018/6/5 9:23:57
    /// 版权所有：Copyright  2018 行圆汽车-分发业务中心
    /// </summary>
    public class AppPushMsgSwitchLogProvider : VerifyOperateBase
    {
        private readonly ReqAppPushSwitchDto _reqAppPushSwitchDto;
        private readonly AppDeviceBO _appDeviceBo;
        private readonly AppPushMsgSwitchLogBO _appPushMsgSwitchLogBo;

        public AppPushMsgSwitchLogProvider(ReqAppPushSwitchDto reqAppPushSwitchDto)
        {
            _reqAppPushSwitchDto = reqAppPushSwitchDto;
            _appDeviceBo = new AppDeviceBO();
            _appPushMsgSwitchLogBo = new AppPushMsgSwitchLogBO();
        }

        #region 配置

        public bool GlobalSwitch
        {
            get
            {
                var config = ConfigurationUtil.GetAppSettingValue("AppPushSwitchConfig", true);
                return config.Split('|')[0].ToBoolean(false);
            }
        }

        public int GlobalSwitchPushDay
        {
            get
            {
                var config = ConfigurationUtil.GetAppSettingValue("AppPushSwitchConfig", true);
                return config.Split('|')[1].ToInt(7);
            }
        }
        #endregion


        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public RespAppPushDto GetPushConfig()
        {
            var resp = new RespAppPushDto();
            if (_reqAppPushSwitchDto == null || string.IsNullOrWhiteSpace(_reqAppPushSwitchDto.DeviceId))
            {
                return resp;
            }
            //todo:先去上报设备里面查询最近一次，是否有开启消息通知
            var info = _appDeviceBo.IsExistIsAllowMsgNotice(_reqAppPushSwitchDto.DeviceId);
            if (info == null)
                return resp;
            if (info.IsAllowMsgNotice)
            {
                //todo:如果已经开启
                resp.GlobalSwitch = GlobalSwitch;
                resp.IsOpen = info.IsAllowMsgNotice;
                return resp;
            }
            //todo:如果指定时间 7天内没有推送提示了，则推送，需要展示
            if (!_appPushMsgSwitchLogBo.IsExist(_reqAppPushSwitchDto.DeviceId, GlobalSwitchPushDay))
            {
                //todo:如果第一次或者满足了7天条件没有推送，是否还需要判断用户手动点击了【x】关闭
                resp.IsShowNow = true;
                //todo:默认情况下是没有数据的，所以第一次需要手动添加一条记录
                _appPushMsgSwitchLogBo.InsertFisrt(new Entities.Chitunion2017.AppPushMsgSwitchLog()
                {
                    DeviceId = _reqAppPushSwitchDto.DeviceId,
                    IsOpen = info.IsAllowMsgNotice,
                    PushShowTime = DateTime.Now,
                    IsClosed = false
                });
            }
            else
            {
                //todo:如果第一次或者满足了7天条件没有推送，是否还需要判断用户手动点击了【x】关闭
                resp.IsShowNow = !_appPushMsgSwitchLogBo.IsClosed(_reqAppPushSwitchDto.DeviceId, GlobalSwitchPushDay);

                //todo:已经在时间周期内存在推送记录；返回接口之前，插入一条提示记录,指定时间段内只提醒一次
                //resp.IsShowNow = false;
                //Dal.APP.AppPushMsgSwitchLog.Instance.Insert(new Entities.APP.AppPushMsgSwitchLog()
                //{
                //    DeviceId = _reqAppPushSwitchDto.DeviceId,
                //    IsOpen = info.IsAllowMsgNotice,
                //});
            }

            resp.GlobalSwitch = GlobalSwitch;
            resp.IsOpen = info.IsAllowMsgNotice;
            return resp;
        }

        /// <summary>
        /// 用户按照提示 设置 开启了消息通知
        /// </summary>
        /// <returns></returns>
        public ReturnValue SetPushConfig()
        {
            var retValue = new ReturnValue();
            if (_reqAppPushSwitchDto == null || string.IsNullOrWhiteSpace(_reqAppPushSwitchDto.DeviceId))
            {
                return CreateFailMessage(retValue, "1001", "请输入参数");
            }

            //todo:插入信息（更改），暂时不需要了，因为一切都是根据AppDevice表来判断的，AppPushMsgSwitchLog表里面只存 IsOpend = false 的数据，只有false的情况下才推送
            //todo:AppPushMsgSwitchLog表是推送记录表
            //todo:更改AppDevice 里面的开关，毕竟是根源
            _appDeviceBo.UpdateIsAllowMsgNotice(_reqAppPushSwitchDto.DeviceId,
                _reqAppPushSwitchDto.IsOpend);

            return retValue;
        }

        /// <summary>
        /// 用户手动关闭提示
        /// </summary>
        /// <returns></returns>
        public ReturnValue ClosedPushTips()
        {
            var retValue = new ReturnValue();
            if (_reqAppPushSwitchDto == null || string.IsNullOrWhiteSpace(_reqAppPushSwitchDto.DeviceId))
            {
                return CreateFailMessage(retValue, "1001", "请输入参数");
            }

            _appPushMsgSwitchLogBo.UpdateClosed(_reqAppPushSwitchDto.DeviceId);

            return retValue;
        }
    }
}