using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;
using UserFB.Model;

namespace UserFB.DAL
{
	/// <summary>
	/// 数据访问类:FeedbackService
	/// </summary>
	public partial class FeedbackService
	{
		public FeedbackService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("feedbackID", "Feedback"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int feedbackID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Feedback");
			strSql.Append(" where feedbackID=@feedbackID");
			SqlParameter[] parameters = {
					new SqlParameter("@feedbackID", SqlDbType.Int,4)
			};
			parameters[0].Value = feedbackID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(UserFB.Model.Feedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Feedback(");
			strSql.Append("UserID,feedbackTime,categoryID,Info,contact,isInvalid,solutionState,handler,remark)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@feedbackTime,@categoryID,@Info,@contact,@isInvalid,@solutionState,@handler,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@feedbackTime", SqlDbType.SmallDateTime),
					new SqlParameter("@categoryID", SqlDbType.Int,4),
					new SqlParameter("@Info", SqlDbType.VarChar,128),
					new SqlParameter("@contact", SqlDbType.VarChar,64),
					new SqlParameter("@isInvalid", SqlDbType.VarChar,16),
					new SqlParameter("@solutionState", SqlDbType.VarChar,16),
					new SqlParameter("@handler", SqlDbType.VarChar,64),
					new SqlParameter("@remark", SqlDbType.VarChar,64)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.feedbackTime;
			parameters[2].Value = model.categoryID;
			parameters[3].Value = model.Info;
			parameters[4].Value = model.contact;
			parameters[5].Value = model.isInvalid;
			parameters[6].Value = model.solutionState;
			parameters[7].Value = model.handler;
			parameters[8].Value = model.remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.Feedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Feedback set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("feedbackTime=@feedbackTime,");
			strSql.Append("categoryID=@categoryID,");
			strSql.Append("Info=@Info,");
			strSql.Append("contact=@contact,");
			strSql.Append("isInvalid=@isInvalid,");
			strSql.Append("solutionState=@solutionState,");
			strSql.Append("handler=@handler,");
			strSql.Append("remark=@remark");
			strSql.Append(" where feedbackID=@feedbackID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@feedbackTime", SqlDbType.SmallDateTime),
					new SqlParameter("@categoryID", SqlDbType.Int,4),
					new SqlParameter("@Info", SqlDbType.VarChar,128),
					new SqlParameter("@contact", SqlDbType.VarChar,64),
					new SqlParameter("@isInvalid", SqlDbType.VarChar,16),
					new SqlParameter("@solutionState", SqlDbType.VarChar,16),
					new SqlParameter("@handler", SqlDbType.VarChar,64),
					new SqlParameter("@remark", SqlDbType.VarChar,64),
					new SqlParameter("@feedbackID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.feedbackTime;
			parameters[2].Value = model.categoryID;
			parameters[3].Value = model.Info;
			parameters[4].Value = model.contact;
			parameters[5].Value = model.isInvalid;
			parameters[6].Value = model.solutionState;
			parameters[7].Value = model.handler;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.feedbackID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int feedbackID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Feedback ");
			strSql.Append(" where feedbackID=@feedbackID");
			SqlParameter[] parameters = {
					new SqlParameter("@feedbackID", SqlDbType.Int,4)
			};
			parameters[0].Value = feedbackID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string feedbackIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Feedback ");
			strSql.Append(" where feedbackID in ("+feedbackIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserFB.Model.Feedback GetModel(int feedbackID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 feedbackID,UserID,feedbackTime,categoryID,Info,contact,isInvalid,solutionState,handler,remark from Feedback ");
			strSql.Append(" where feedbackID=@feedbackID");
			SqlParameter[] parameters = {
					new SqlParameter("@feedbackID", SqlDbType.Int,4)
			};
			parameters[0].Value = feedbackID;

			UserFB.Model.Feedback model=new UserFB.Model.Feedback();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserFB.Model.Feedback DataRowToModel(DataRow row)
		{
			UserFB.Model.Feedback model=new UserFB.Model.Feedback();
			if (row != null)
			{
				if(row["feedbackID"]!=null && row["feedbackID"].ToString()!="")
				{
					model.feedbackID=int.Parse(row["feedbackID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["feedbackTime"]!=null && row["feedbackTime"].ToString()!="")
				{
					model.feedbackTime=DateTime.Parse(row["feedbackTime"].ToString());
				}
				if(row["categoryID"]!=null && row["categoryID"].ToString()!="")
				{
					model.categoryID=int.Parse(row["categoryID"].ToString());
				}
				if(row["Info"]!=null)
				{
					model.Info=row["Info"].ToString();
				}
				if(row["contact"]!=null)
				{
					model.contact=row["contact"].ToString();
				}
				if(row["isInvalid"]!=null)
				{
					model.isInvalid=row["isInvalid"].ToString();
				}
				if(row["solutionState"]!=null)
				{
					model.solutionState=row["solutionState"].ToString();
				}
				if(row["handler"]!=null)
				{
					model.handler=row["handler"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select feedbackID,UserID,feedbackTime,categoryID,Info,contact,isInvalid,solutionState,handler,remark ");
			strSql.Append(" FROM Feedback ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" feedbackID,UserID,feedbackTime,categoryID,Info,contact,isInvalid,solutionState,handler,remark ");
			strSql.Append(" FROM Feedback ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Feedback ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.feedbackID desc");
			}
			strSql.Append(")AS Row, T.*  from Feedback T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Feedback";
			parameters[1].Value = "feedbackID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public List<feedbackEX> GetAllFeedback()
        {
            List<feedbackEX> feedbackList = new List<feedbackEX>();
            StringBuilder strSql = new StringBuilder();
            // strSql.Append(" feedbackID,UserID,feedbackTime,categoryID,Info,contact,isInvalid,solutionState,handler,remark ");
            // strSql.Append(" FROM Feedback ");
            strSql.AppendLine("select F.feedbackID,U.UserID as UserID,U.userName as userName,");
            strSql.AppendLine("F.feedbackTime,C.categoryID as categoryID,C.category as category,");
            strSql.AppendLine("F.Info,F.contact,F.isInvalid,F.solutionState,F.handler,F.remark");
            strSql.AppendLine("from Feedback as F");
            strSql.AppendLine("inner join Users as U on F.UserID=U.UserID");
            strSql.AppendLine("inner join Category as C on F.categoryID=C.categoryID");
            SqlDataReader reader = DbHelperSQL.ExecuteReader(strSql.ToString());
            while(reader.Read())
            {
                #region 封装反馈对象
                feedbackEX feedback = new feedbackEX();
                feedback.feedbackID = int.Parse(reader["feedbackID"].ToString());
                feedback.Info = reader["Info"].ToString();
                feedback.contact = reader["contact"].ToString();
                feedback.isInvalid = reader["isInvalid"].ToString();
                feedback.solutionState = reader["solutionState"].ToString();
                feedback.handler = reader["handler"].ToString();
                feedback.remark = reader["remark"].ToString();
                feedback.feedbackTime = DateTime.Parse(reader["feedbackTime"].ToString());
                feedback.UserID = int.Parse(reader["UserID"].ToString());

                Users users = new Users();
                users.UserID = int.Parse(reader["UserID"].ToString());
                users.userName = reader["userName"].ToString();
                feedback.Users = users;

                feedback.categoryID = int.Parse(reader["categoryID"].ToString());
                Category c = new Category();
                c.categoryID= int.Parse(reader["categoryID"].ToString());
                c.category = reader["category"].ToString();
                feedback.Category = c;
                #endregion

                feedbackList.Add(feedback);
            }
            reader.Close();
            return feedbackList;
        }

        ///<summary>
        ///查看详情
        /// </summary>
        /// 

        public feedbackEX GetDetails(int id)
        {
            feedbackEX Details = new feedbackEX();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine("select F.feedbackID,U.UserID as UserID,U.userName as userName,");
            strSql.AppendLine("F.feedbackTime,C.categoryID as categoryID,C.category as category,");
            strSql.AppendLine("F.Info,F.contact,F.isInvalid,F.solutionState,F.handler,F.remark");
            strSql.AppendLine("from Feedback as F");
            strSql.AppendLine("inner join Users as U on F.UserID=U.UserID");
            strSql.AppendLine("inner join Category as C on F.categoryID=C.categoryID");
            strSql.AppendFormat(" where  F.[feedbackID]={0}",id);

            SqlDataReader reader = DbHelperSQL.ExecuteReader(strSql.ToString());
            if (reader.Read())
            {
                feedbackEX feedback = new feedbackEX();
                feedback.feedbackID = int.Parse(reader["feedbackID"].ToString());
                feedback.Info = reader["Info"].ToString();
                feedback.contact = reader["contact"].ToString();
                feedback.isInvalid = reader["isInvalid"].ToString();
                feedback.solutionState = reader["solutionState"].ToString();
                feedback.handler = reader["handler"].ToString();
                feedback.remark = reader["remark"].ToString();
                feedback.feedbackTime = DateTime.Parse(reader["feedbackTime"].ToString());
                feedback.UserID = int.Parse(reader["UserID"].ToString());

                Users users = new Users();
                users.UserID = int.Parse(reader["UserID"].ToString());
                users.userName = reader["userName"].ToString();
                feedback.Users = users;

                feedback.categoryID = int.Parse(reader["categoryID"].ToString());
                Category c = new Category();
                c.categoryID = int.Parse(reader["categoryID"].ToString());
                c.category = reader["category"].ToString();
                feedback.Category = c;
            }
            return Details;
        }

        ///<summary>
        ///批量更新申请状态
        /// </summary>
        /// <param name="state">状态信息</param>
        /// <param name="idList">要修改的申请消息</param>
        /// <returns>如果更新成功，返回TRUE</returns>
        public bool UpdateInvalid(string state, string idList)
        {
            string sql = string.Format("update [Feedback] set [isInvalid] ={0} where [feedbackID] in({1})",state,idList);
            int rows = DbHelperSQL.ExecuteSql(sql);
            return rows > 0 ? true : false;
        }

        public bool UpdateSolution(string solution, string name, string idList)
        {
            string sql = string.Format("update [Feedback] set [solutionState] ={0},[handler]={1} where [feedbackID] in({2})", solution, name,idList);
            int rows = DbHelperSQL.ExecuteSql(sql);
            return rows > 0 ? true : false;
        }


        public int GetRecordCountNum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(distinct UserID ) FROM Feedback ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where UserID in");
                strSql.Append("(select UserID FROM Users where " + strWhere +")");
             //  strSql.Append("  inner join Users as U on F.UserID = U.UserID");
               
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        //public int GetRecordCountTime(string strWhere,string strTime)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(distinct UserID ) FROM Feedback ");
        //    if (strWhere.Trim() != "")
        //    {

        //        strSql.Append(" where UserID in");
        //        strSql.Append("(select UserID FROM Users where " + strWhere + ") and "+ strTime);
        //        //  strSql.Append("  inner join Users as U on F.UserID = U.UserID");

        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}


        public bool UpdateHandler(string strWhere,string str)
        {
            StringBuilder strSql = new StringBuilder();
           
            if (strWhere.Trim() != "")
            {
                strSql.Append("Update Feedback set " + strWhere);
                strSql.Append(" where " + str);

            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true ;
            }
        }


        public bool UpdateSolution(string strWhere, string str)
        {
            StringBuilder strSql = new StringBuilder();

            if (strWhere.Trim() != "")
            {
                strSql.Append("Update Feedback set " + strWhere);
                strSql.Append(" where FeedbackID in");
                strSql.Append("(select FeedbackID FROM Distribution where " + str + ")");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion  ExtensionMethod
    }
}

