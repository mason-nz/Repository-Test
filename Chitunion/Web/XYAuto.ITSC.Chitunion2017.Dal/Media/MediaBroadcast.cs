﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XYAuto.Utils.Data;

using System.Collections.Generic;

using XYAuto.ITSC.Chitunion2017.Entities;
using XYAuto.ITSC.Chitunion2017.Entities.DTO;
using XYAuto.ITSC.Chitunion2017.Entities.Enum;

namespace XYAuto.ITSC.Chitunion2017.Dal.Media
{
    //媒体-直播信息
    public class MediaBroadcast : DataBase
    {
        #region Instance

        public static readonly MediaBroadcast Instance = new MediaBroadcast();

        #endregion Instance

        public Entities.Media.MediaBroadcast GetEntity(int mediaId)
        {
            const string sql = @"SELECT [MediaID]
                              ,[Platform]
                              ,[RoomID]
                              ,[Number]
                              ,[Name]
                              ,[HeadIconURL],FansCountURL
                              ,[Sex]
                              ,[FansCount]
                              ,[CategoryID]
                              ,[Profession]
                              ,[ProvinceID]
                              ,[CityID]
                              ,[IsAuth]
                              ,[LevelType]
                              ,[IsReserve]
                                 ,[Status],[Source]
                              ,[CreateTime]
                              ,[CreateUserID]
                              ,[LastUpdateTime]
                              ,[LastUpdateUserID]
                          FROM [dbo].[Media_Broadcast] WITH(NOLOCK) WHERE Status = 0 AND MediaID = @MediaID";
            var paras = new List<SqlParameter>() { new SqlParameter("@MediaID", mediaId) };
            var data = SqlHelper.ExecuteDataset(CONNECTIONSTRINGS, CommandType.Text, sql, paras.ToArray());
            return DataTableToEntity<Entities.Media.MediaBroadcast>(data.Tables[0]);
        }

        public int GetRepeatCount(string number, string name, int platform, List<string> roleIds,
            string mediaTableName = "Media_Broadcast", int filterMediaId = 0)
        {
            var sql = string.Format(@"SELECT  COUNT(1)
                        FROM    dbo.{0} WITH ( NOLOCK )
                        WHERE   Status = 0 ", mediaTableName);
            var paras = new List<SqlParameter>();
            if (filterMediaId > 0)
            {
                sql += " AND MediaID != @MediaID";
                paras.Add(new SqlParameter("@MediaID", filterMediaId));
            }
            if (!string.IsNullOrWhiteSpace(number))
            {
                sql += " AND Number = @Number";
                paras.Add(new SqlParameter("@Number", number));
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                sql += " AND Name = @Name";
                paras.Add(new SqlParameter("@Name", name));
            }
            if (platform > 0)
            {
                sql += " AND [Platform] = @Platform";
                paras.Add(new SqlParameter("@Platform", platform));
            }
            if (roleIds.Count > 0)
            {
                var userIdSql = new StringBuilder(" AND CreateUserID IN (");
                userIdSql.AppendFormat(@"SELECT DISTINCT
                                        ( UserID )
                              FROM      UserRole
                              WHERE     RoleID IN ('{0}'))", string.Join("','", roleIds));

                sql += userIdSql.ToString();
            }

            return Convert.ToInt32(SqlHelper.ExecuteScalar(CONNECTIONSTRINGS, CommandType.Text, sql, paras.ToArray()));
        }

        public Entities.Media.MediaBroadcast GetEntity(string number, int platform, int filterMediaId = 0)
        {
            string sql = @"SELECT TOP 1 [MediaID]
                              ,[Platform]
                              ,[RoomID]
                              ,[Number]
                              ,[Name]
                              ,[HeadIconURL],FansCountURL
                              ,[Sex]
                              ,[FansCount]
                              ,[CategoryID]
                              ,[Profession]
                              ,[ProvinceID]
                              ,[CityID]
                              ,[IsAuth]
                              ,[LevelType]
                              ,[IsReserve]
                            ,[Status],[Source]
                              ,[CreateTime]
                              ,[CreateUserID]
                              ,[LastUpdateTime]
                              ,[LastUpdateUserID]
                          FROM [dbo].[Media_Broadcast] WITH(NOLOCK) WHERE Status = 0 AND Platform = @Platform AND Number = @Number";
            var paras = new List<SqlParameter>()
            {
                new SqlParameter("@Platform", platform),
                new SqlParameter("@Number", number)
            };
            if (filterMediaId > 0)
            {
                sql += " AND MediaID != @MediaID";
                paras.Add(new SqlParameter("@MediaID", filterMediaId));
            }
            var data = SqlHelper.ExecuteDataset(CONNECTIONSTRINGS, CommandType.Text, sql, paras.ToArray());
            return DataTableToEntity<Entities.Media.MediaBroadcast>(data.Tables[0]);
        }

        public int Insert(Entities.Media.MediaBroadcast entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("insert into Media_Broadcast(");
            strSql.Append("Platform,RoomID,Number,Name,HeadIconURL,FansCountURL,Sex,FansCount,CategoryID,Profession,ProvinceID,CityID,IsAuth,LevelType,IsReserve,Status,Source,CreateTime,CreateUserID,LastUpdateTime,LastUpdateUserID");
            strSql.Append(") values (");
            strSql.Append("@Platform,@RoomID,@Number,@Name,@HeadIconURL,@FansCountURL,@Sex,@FansCount,@CategoryID,@Profession,@ProvinceID,@CityID,@IsAuth,@LevelType,@IsReserve,@Status,@Source,@CreateTime,@CreateUserID,@LastUpdateTime,@LastUpdateUserID");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            var parameters = new SqlParameter[]{
                        new SqlParameter("@Platform",entity.Platform),
                        new SqlParameter("@RoomID",entity.RoomID),
                        new SqlParameter("@Number",entity.Number),
                        new SqlParameter("@Name",entity.Name),
                        new SqlParameter("@HeadIconURL",entity.HeadIconURL),
                            new SqlParameter("@FansCountURL",entity.FansCountURL),
                        new SqlParameter("@Sex",entity.Sex),
                        new SqlParameter("@FansCount",entity.FansCount),
                        new SqlParameter("@CategoryID",entity.CategoryID),
                        new SqlParameter("@Profession",entity.Profession),
                        new SqlParameter("@ProvinceID",entity.ProvinceID),
                        new SqlParameter("@CityID",entity.CityID),
                        new SqlParameter("@IsAuth",entity.IsAuth),
                        new SqlParameter("@LevelType",entity.LevelType),
                        new SqlParameter("@IsReserve",entity.IsReserve),
                        new SqlParameter("@Source",entity.Source),
                        new SqlParameter("@Status",entity.Status),
                        new SqlParameter("@CreateTime",entity.CreateTime),
                        new SqlParameter("@CreateUserID",entity.CreateUserID),
                        new SqlParameter("@LastUpdateTime",entity.LastUpdateTime),
                        new SqlParameter("@LastUpdateUserID",entity.LastUpdateUserID),
                        };

            var obj = SqlHelper.ExecuteScalar(CONNECTIONSTRINGS, CommandType.Text, strSql.ToString(), parameters);
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        public int Update(Entities.Media.MediaBroadcast entity)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"UPDATE [dbo].[Media_Broadcast]");
            strSql.Append(@"SET [Platform] = @Platform
                              ,[RoomID] = @RoomID
                              --,[Number] = @Number
                              ,[Name] = @Name
                              ,[HeadIconURL] = @HeadIconURL
                                ,[FansCountURL] = @FansCountURL
                              ,[Sex] = @Sex
                              ,[FansCount] = @FansCount
                              ,[CategoryID] =@CategoryID
                              ,[Profession] = @Profession
                              ,[ProvinceID] = @ProvinceID
                              ,[CityID] = @CityID
                              ,[IsAuth] = @IsAuth
                              ,[LevelType] = @LevelType
                              ,[IsReserve] = @IsReserve
                              ,[Status] = @Status
                              --,[CreateTime] = @CreateTime
                              --,[CreateUserID] = @CreateUserID
                              ,[LastUpdateTime] = @LastUpdateTime
                              ,[LastUpdateUserID] = @LastUpdateUserID
                            WHERE MediaID = @MediaID");
            var parameters = new SqlParameter[]{
                new SqlParameter("@MediaID",entity.MediaID),
                        new SqlParameter("@Platform",entity.Platform),
                        new SqlParameter("@RoomID",entity.RoomID),
            			//new SqlParameter("@Number",entity.Number),
            			new SqlParameter("@Name",entity.Name),
                        new SqlParameter("@HeadIconURL",entity.HeadIconURL),
                            new SqlParameter("@FansCountURL",entity.FansCountURL),
                        new SqlParameter("@Sex",entity.Sex),
                        new SqlParameter("@FansCount",entity.FansCount),
                        new SqlParameter("@CategoryID",entity.CategoryID),
                        new SqlParameter("@Profession",entity.Profession),
                        new SqlParameter("@ProvinceID",entity.ProvinceID),
                        new SqlParameter("@CityID",entity.CityID),
                        new SqlParameter("@IsAuth",entity.IsAuth),
                        new SqlParameter("@LevelType",entity.LevelType),
                        new SqlParameter("@IsReserve",entity.IsReserve),
                        new SqlParameter("@Status",entity.Status),
            			//new SqlParameter("@CreateTime",entity.CreateTime),
            			//new SqlParameter("@CreateUserID",entity.CreateUserID),
            			new SqlParameter("@LastUpdateTime",entity.LastUpdateTime),
                        new SqlParameter("@LastUpdateUserID",entity.LastUpdateUserID),
                        };
            return SqlHelper.ExecuteNonQuery(CONNECTIONSTRINGS, CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 存在就编辑，否则就添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Operate(Entities.Media.MediaBroadcast entity, int userId)
        {
            if (string.IsNullOrWhiteSpace(entity.Name) || entity.Platform < 1 || userId <= 0)
            {
                throw new Exception("媒体-直播-请输入Name，Platform,创建用户Id");
            }
            var info = GetEntity(entity.Name, entity.Platform);
            if (info == null)
            {
                return Insert(entity);
            }
            if (entity.CreateUserID == userId)
            {
                entity.MediaID = info.MediaID;
                return Update(entity) > 0 ? entity.MediaID : 0;
            }
            return Insert(entity);
        }

        public List<Entities.Media.MediaBroadcast> GetList(int platform, string name, string number, int source, string createUser, string beginDate, string endDate, string rightSql,
int categoryId, string orderby, int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = 0;
            SqlParameter[] parameters = {
                new SqlParameter("@Platform", SqlDbType.Int),
                new SqlParameter("@Name", SqlDbType.VarChar),
                new SqlParameter("@Number", SqlDbType.VarChar),
                new SqlParameter("@Source", SqlDbType.Int),
                new SqlParameter("@CreateUser", SqlDbType.VarChar),
                new SqlParameter("@BeginDate", SqlDbType.VarChar),
                new SqlParameter("@EndDate", SqlDbType.VarChar),
                new SqlParameter("@RightSql",SqlDbType.VarChar),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@TotalCount", SqlDbType.Int),
                new SqlParameter("@Orderby", SqlDbType.NVarChar),
                new SqlParameter("@CategoryId", SqlDbType.Int),
            };
            parameters[0].Value = platform;
            parameters[1].Value = SqlFilter(name);
            parameters[2].Value = SqlFilter(number);
            parameters[3].Value = source;
            parameters[4].Value = SqlFilter(createUser);
            parameters[5].Value = SqlFilter(beginDate);
            parameters[6].Value = SqlFilter(endDate);
            parameters[7].Value = rightSql;
            parameters[8].Value = pageIndex;
            parameters[9].Value = pageSize;
            parameters[10].Direction = ParameterDirection.Output;
            parameters[11].Value = orderby;
            parameters[12].Value = categoryId;
            DataTable dt = SqlHelper.ExecuteDataset(CONNECTIONSTRINGS, CommandType.StoredProcedure, "p_Media_Broadcast_Select", parameters).Tables[0];
            List<Entities.Media.MediaBroadcast> list = new List<Entities.Media.MediaBroadcast>();

            #region 填充

            totalCount = Convert.ToInt32(parameters[10].Value);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Entities.Media.MediaBroadcast()
                {
                    MediaID = Convert.ToInt32(dr["MediaID"]),
                    Name = dr["Name"].ToString(),
                    Number = dr["Number"].ToString(),
                    HeadIconURL = dr["HeadIconURL"].ToString(),
                    FansCount = dr["FansCount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FansCount"]),
                    CityID = dr["CityID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CityID"]),
                    LevelType = dr["LevelType"] == DBNull.Value ? 0 : Convert.ToInt32(dr["LevelType"]),
                    CreateTime = dr["CreateTime"] == DBNull.Value ? new DateTime(1900, 01, 01) : Convert.ToDateTime(dr["CreateTime"]),
                    LevelTypeName = dr["LevelTypeName"].ToString(),
                    TrueName = dr["TrueName"].ToString(),
                    UserName = dr["UserName"].ToString(),
                    SourceName = dr["SourceName"].ToString(),
                    PlatformName = dr["PlatformName"].ToString(),
                    PubCount = Convert.ToInt32(dr["PubCount"]),
                    Status = Convert.ToInt32(dr["AuditStatus"]),
                    PubID = dr["PubID"].ToString(),
                    CategoryName = dr["Category"].ToString(),
                    CanAddToRecommend = Convert.ToBoolean(dr["CanAddToRecommend"]),
                    IsRange = Convert.ToBoolean(dr["IsRange"])
                });
            }

            #endregion 填充

            return list;
        }

        public MediaBroadcastDTO GetDetail(int mediaID, string rightSql)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@MediaID", SqlDbType.Int),
                new SqlParameter("@RightSql",SqlDbType.VarChar)
            };
            parameters[0].Value = mediaID;
            parameters[1].Value = rightSql;
            DataSet ds = SqlHelper.ExecuteDataset(CONNECTIONSTRINGS, CommandType.StoredProcedure, "p_Media_Broadcast_Detail", parameters);
            DataTable dt = ds.Tables[0];
            string orderRemarkName = string.Empty;
            MediaBroadcastDTO dto = new MediaBroadcastDTO();
            dto.MediaInfo = DataTableToEntity<Entities.Media.MediaBroadcast>(dt);
            if (dto.MediaInfo != null)
            {
                dto.InteractionInfo = DataTableToEntity<Entities.Interaction.InteractionBroadcast>(dt);
                dto.UserInfo = DataTableToEntity<Entities.DTO.UserInfoDTO>(dt);
                //覆盖区域
                dto.OverlayIDs = new List<ProvinceCityDTO>();
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    dto.OverlayIDs.Add(new ProvinceCityDTO()
                    {
                        ProvinceID = dr["ProvinceID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ProvinceID"]),
                        CityID = dr["CityID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CityID"]),
                        ProvinceName = dr["ProvinceName"].ToString(),
                        CityName = dr["CityName"].ToString()
                    });
                }
            }
            return dto;
        }

        public Entities.Media.MediaBroadcast GetBaseEntity(int mediaId)
        {
            var sql = @"
                        SELECT TOP 1
                                MB.*
                        FROM    dbo.Media_Broadcast AS MB WITH ( NOLOCK )
                                INNER JOIN dbo.Publish_BasicInfo AS A WITH ( NOLOCK ) ON MB.MediaID = A.MediaID
                                INNER JOIN dbo.Publish_DetailInfo AS PD WITH ( NOLOCK ) ON PD.PubID = A.PubID
                        WHERE   MB.MediaID = {0}
                                AND A.MediaType = {1}
                                AND PD.PublishStatus = {2}
                                AND GETDATE() BETWEEN A.BeginTime AND A.EndTime";
            var paras = new List<SqlParameter>();
            sql = string.Format(sql, mediaId, (int)MediaType.Broadcast, (int)EnumPublishStatus.OnSold);
            var data = SqlHelper.ExecuteDataset(CONNECTIONSTRINGS, CommandType.Text, sql, paras.ToArray());
            return DataTableToEntity<Entities.Media.MediaBroadcast>(data.Tables[0]);
        }
    }
}