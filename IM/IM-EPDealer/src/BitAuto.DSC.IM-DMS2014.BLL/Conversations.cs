using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BitAuto.Utils;
using BitAuto.Utils.Data;
using BitAuto.DSC.IM_DMS2014.Entities;
using BitAuto.DSC.IM_DMS2014.Entities.Constants;

namespace BitAuto.DSC.IM_DMS2014.BLL
{
    //----------------------------------------------------------------------------------
    /// <summary>
    /// ҵ���߼���Conversations ��ժҪ˵����
    /// </summary>
    /// <author>
    /// masj
    /// </author>
    /// <history>
    /// 2014-10-29 10:21:01 Created
    /// </history>
    /// <version>
    /// 1.0
    /// </version>
    //----------------------------------------------------------------------------------
    public class Conversations
    {
        #region Instance
        public static readonly Conversations Instance = new Conversations();
        #endregion

        #region Contructor
        protected Conversations()
        { }
        #endregion

        #region Select
        /// <summary>
        /// ���ղ�ѯ������ѯ
        /// </summary>
        /// <param name="query">��ѯ����</param>
        /// <param name="order">����</param>
        /// <param name="currentPage">ҳ��,-1����ҳ</param>
        /// <param name="pageSize">ÿҳ��¼��</param>
        /// <param name="totalCount">������</param>
        /// <returns>����</returns>
        public DataTable GetConversations(QueryConversations query, string order, int currentPage, int pageSize, out int totalCount)
        {
            return Dal.Conversations.Instance.GetConversations(query, order, currentPage, pageSize, out totalCount);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable GetAllList()
        {
            int totalCount = 0;
            return Dal.Conversations.Instance.GetConversations(new QueryConversations(), string.Empty, 1, 1000000, out totalCount);
        }

        #endregion

        #region GetModel
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Entities.Conversations GetConversations(int CSID)
        {

            return Dal.Conversations.Instance.GetConversations(CSID);
        }

        #endregion

        #region IsExists
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool IsExistsByCSID(int CSID)
        {
            QueryConversations query = new QueryConversations();
            query.CSID = CSID;
            DataTable dt = new DataTable();
            int count = 0;
            dt = GetConversations(query, string.Empty, 1, 1, out count);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Entities.Conversations GetConversationsByCsId(int CSID)
        {
            Entities.Conversations cs = null;
            QueryConversations query = new QueryConversations();
            query.CSID = CSID;
            DataTable dt = new DataTable();
            int count = 0;
            dt = GetConversations(query, string.Empty, 1, 1, out count);
            if (dt.Rows.Count > 0)
            {
                cs = new Entities.Conversations()
                {
                    CSID = CSID,
                    AgentStartTime = Convert.ToDateTime(dt.Rows[0]["AgentStartTime"]),
                    BGID = Convert.ToInt32(dt.Rows[0]["BGID"]),
                    CreateTime = Convert.ToDateTime(dt.Rows[0]["CreateTime"]),
                    EndTime = Convert.ToDateTime(dt.Rows[0]["EndTime"]),
                    OrderID = dt.Rows[0]["OrderID"].ToString(),
                    LastClientTime = Convert.ToDateTime(dt.Rows[0]["LastClientTime"]),
                    Status = Convert.ToInt32(dt.Rows[0]["Status"]),
                    UserID = Convert.ToInt32(dt.Rows[0]["UserID"]),
                    UserName = dt.Rows[0]["UserName"].ToString(),
                    VisitID = dt.Rows[0]["VisitID"].ToString()
                };

            }
            return cs;
        }

        #endregion

        #region Insert
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Insert(Entities.Conversations model)
        {
            return Dal.Conversations.Instance.Insert(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Insert(SqlTransaction sqltran, Entities.Conversations model)
        {
            return Dal.Conversations.Instance.Insert(sqltran, model);
        }

        #endregion

        #region Update
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Entities.Conversations model)
        {
            return Dal.Conversations.Instance.Update(model);
        }

        public int CallBackUpdate(Entities.Conversations model)
        {
            return Dal.Conversations.Instance.CallBackUpdate(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(SqlTransaction sqltran, Entities.Conversations model)
        {
            return Dal.Conversations.Instance.Update(sqltran, model);
        }

        #endregion

        #region Delete
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int CSID)
        {

            return Dal.Conversations.Instance.Delete(CSID);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(SqlTransaction sqltran, int CSID)
        {

            return Dal.Conversations.Instance.Delete(sqltran, CSID);
        }

        #endregion


        #region  �Ϸ�  2014-10-31

        //<summary>
        //�жϻỰ�Ƿ����
        //</summary>
        //<param name="CSID">�ỰID</param>
        //<returns></returns>
        public bool Exists(int CSID)
        {
            return Dal.Conversations.Instance.Exists(CSID);
        }
        /// <summary>
        /// ����ָ��������ѯ�Ự����
        /// </summary>
        /// <param name="query"></param>
        /// <param name="order"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataTable GetCSData(QueryConversations query, string order, int currentPage, int pageSize, out int totalCount)
        {
            return Dal.Conversations.Instance.GetCSData(query, order, currentPage, pageSize, out totalCount);
        }
        /// <summary>
        /// ����VisitID��ȡ�ͻ���Ϣ
        /// exec p_GetMemberInfoByVisitID ' and VisitID=''001'''
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetMemberInfoByVisitID(string strWhere)
        {
            return Dal.Conversations.Instance.GetMemberInfoByVisitID(strWhere);
        }
        /// <summary>
        /// ����VisitID��ȡ�Ự�����Ϣ
        /// exec p_CSRelateInfoByVisitID ' and a.VisitID=''001'''
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetCSRelateInfoByCSID(string strWhere)
        {
            return Dal.Conversations.Instance.GetCSRelateInfoByCSID(strWhere);
        }
        /// <summary>
        /// ����OrderID��ѯ���������Ϣ
        /// exec p_GetWorkOrderInfoByOrderID ' and a.OrderID = ''WO20130000000001'''
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetWorkOrderInfoByOrderID(string strWhere)
        {
            return Dal.Conversations.Instance.GetWorkOrderInfoByOrderID(strWhere);
        }

        /// <summary>
        /// ����ָ��������ѯ��ʷ��������
        /// </summary>
        /// <param name="query"></param>
        /// <param name="order"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataTable GetConversationHistoryData(QueryConversations query, string order, int currentPage, int pageSize, out int totalCount)
        {
            return Dal.Conversations.Instance.GetConversationHistoryData(query, order, currentPage, pageSize, out totalCount);
        }

        public DataTable GetConversationingCSData(string strWhere)
        {
            return Dal.Conversations.Instance.GetConversationingCSData(strWhere);
        }
        #endregion

    }
}
