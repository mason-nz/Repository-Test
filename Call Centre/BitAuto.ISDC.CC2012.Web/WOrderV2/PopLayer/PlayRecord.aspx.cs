﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitAuto.ISDC.CC2012.Web.WOrderV2.PopLayer
{
	public partial class PlayRecord : System.Web.UI.Page
	{
        #region 属性定义
        public string RequestRecordURL
        {
            get { return BLL.Util.GetCurrentRequestFormStr("RecordURL"); }
        }
        #endregion

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}