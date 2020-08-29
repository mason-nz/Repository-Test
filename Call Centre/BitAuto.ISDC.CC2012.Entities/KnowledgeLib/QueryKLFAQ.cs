using System;
using BitAuto.ISDC.CC2012.Entities.Constants;

namespace BitAuto.ISDC.CC2012.Entities
{
	//----------------------------------------------------------------------------------
	/// <summary>
	/// ʵ����QueryKLFAQ ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	/// <author>
	/// masj
	/// </author>
	/// <history>
	/// 2012-08-21 10:19:08 Created
	/// </history>
	/// <version>
	/// 1.0
	/// </version>
	//----------------------------------------------------------------------------------
	[Serializable]
	public class QueryKLFAQ
	{
		public QueryKLFAQ()
		{
		 _klfaqid = Constant.INT_INVALID_VALUE;
		 _klid = Constant.INT_INVALID_VALUE;
		 _ask = Constant.STRING_INVALID_VALUE;
		 _question = Constant.STRING_INVALID_VALUE;
		 _createtime = Constant.DATE_INVALID_VALUE;
		 _createuserid = Constant.INT_INVALID_VALUE;
		 _modifytime = Constant.DATE_INVALID_VALUE;
		 _modifyuserid = Constant.INT_INVALID_VALUE;
         _kcdis = Constant.STRING_INVALID_VALUE;
         _keyword = Constant.STRING_INVALID_VALUE;
         _state = Constant.STRING_INVALID_VALUE;
		}
		#region Model
		private long _klfaqid;
		private long _klid;
		private string _ask;
		private string _question;
		private DateTime? _createtime;
		private int? _createuserid;
		private DateTime? _modifytime;
		private int? _modifyuserid;
        private string _kcdis;
        private string _keyword;
        private string _state;
		/// <summary>
		/// 
		/// </summary>
		public long KLFAQID
		{
			set{ _klfaqid=value;}
			get{return _klfaqid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long KLID
		{
			set{ _klid=value;}
			get{return _klid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ask
		{
			set{ _ask=value;}
			get{return _ask;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateUserID
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ModifyUserID
		{
			set{ _modifyuserid=value;}
			get{return _modifyuserid;}
		}

        //�����¼�
        public string Keywords
        {
            set { _keyword = value; }
            get { return _keyword; }
        }

        public string KCIDs
        {
            set { _kcdis = value; }
            get { return _kcdis; }
        }

        //״̬ 2���ͨ��
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
		#endregion Model

	}
}
