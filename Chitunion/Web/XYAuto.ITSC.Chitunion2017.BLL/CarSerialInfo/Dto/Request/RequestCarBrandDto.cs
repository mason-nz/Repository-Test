﻿/********************************************************
*创建人：lixiong
*创建时间：2017/7/24 20:20:41
*说明：
*版权所有：Copyright  2017 流量变现平台事业部-北京行圆汽车信息技术有限公司
*********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYAuto.ITSC.Chitunion2017.BLL.CarSerialInfo.Dto.Request
{
    public class RequestCarBrandDto
    {
        public int MasterBrandId { get; set; }
        public int BrandId { get; set; }

        public string MasterBrandName { get; set; }
    }
}