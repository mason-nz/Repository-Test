﻿using System.Web.Http.Filters;

namespace XYAuto.BUOC.ChiTuData2017.WebAPI
{
    public class CrossSiteAttribute : ActionFilterAttribute
    {
        private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        private const string originHeaderdefault = "http://client.data1.chitunion.com";
        private bool IsSetCrossSite = bool.Parse(XYAuto.Utils.Config.ConfigurationUtil.GetAppSettingValue("IsSetCrossSite", false));

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (IsSetCrossSite && actionExecutedContext.Response != null)
            {
                actionExecutedContext.Response.Headers.Add(AccessControlAllowOrigin, originHeaderdefault);
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}