﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYAuto.ITSC.Chitunion2017.BLL.Media.Verification.Base;

namespace XYAuto.ITSC.Chitunion2017.BLL.Media.Verification.Verify
{
   public class VerifyOfBroadcastOperate
    {
        /// <summary>
        /// 获取用户信息的规则方法
        /// </summary>
        /// <param name="entity">需要验证的实体</param>
        /// <param name="isDefaultRule">是否是默认的全部规则</param>
        /// <param name="funcDic">传入需要验证的规则</param>
        /// <param name="isOutParam">是否需要返回值</param>
        /// <returns></returns>
       public ReturnValue Verify(Entities.Media.MediaBroadcast entity, bool isDefaultRule, Dictionary<int, Func<Entities.Media.MediaBroadcast, ReturnValue>> funcDic,
            bool isOutParam = false)
        {
            //自定义规则
            if (!isDefaultRule) new Verifiction<Entities.Media.MediaBroadcast>(funcDic).Verify(entity, isOutParam);
            //默认规则
            funcDic = new Dictionary<int, Func<Entities.Media.MediaBroadcast, ReturnValue>>
            {
                //{(int)  VerifyDataTypeEnum.VerifyOfWeiBoById, CheckWeiBoById},
                //{(int)  VerifyDataTypeEnum.VerifyOfInteractionWeiBoByMediaId, CheckInteractionWeiBoByMediaId}
            };
            return new Verifiction<Entities.Media.MediaBroadcast>(funcDic).Verify(entity, isOutParam);
        }

       public static ReturnValue CheckBroadcastNumber(Entities.Media.MediaBroadcast entity)
        {
            var retValue = new ReturnValue() { HasError = true, ErrorCode = "10020", Message = string.Format("此微平台帐号已存在") };
            var info = BLL.Media.MediaBroadcast.Instance.GetEntity(entity.Number, entity.Platform, entity.MediaID);
           if (info != null)
           {
               retValue.ReturnObject = info;
               return retValue;
           }
           retValue.HasError = false;
            retValue.Message = string.Empty;
            return retValue;
        }
    }
}