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
	/// 数据访问类:DistributionService
	/// </summary>
	public partial class DistributionService
	{
		public DistributionService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("distributionID", "Distribution"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int distributionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Distribution");
			strSql.Append(" where distributionID=@distributionID");
			SqlParameter[] parameters = {
					new SqlParameter("@distributionID", SqlDbType.Int,4)
			};
			parameters[0].Value = distributionID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(UserFB.Model.Distribution model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Distribution(");
			strSql.Append("feedbackID,description,distributionTime,adminID,assignerID,state)");
			strSql.Append(" values (");
			strSql.Append("@feedbackID,@description,@distributionTime,@adminID,@assignerID,@state)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@feedbackID", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.VarChar,128),
					new SqlParameter("@distributionTime", SqlDbType.SmallDateTime),
					new SqlParameter("@adminID", SqlDbType.Int,4),
					new SqlParameter("@assignerID", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.VarChar,64)};
			parameters[0].Value = model.feedbackID;
			parameters[1].Value = model.description;
			parameters[2].Value = model.distributionTime;
			parameters[3].Value = model.adminID;
			parameters[4].Value = model.assignerID;
			parameters[5].Value = model.state;

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
		public bool Update(UserFB.Model.Distribution model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Distribution set ");
			strSql.Append("feedbackID=@feedbackID,");
			strSql.Append("description=@description,");
			strSql.Append("distributionTime=@distributionTime,");
			strSql.Append("adminID=@adminID,");
			strSql.Append("assignerID=@assignerID,");
			strSql.Append("state=@state");
			strSql.Append(" where distributionID=@distributionID");
			SqlParameter[] parameters = {
					new SqlParameter("@feedbackID", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.VarChar,128),
					new SqlParameter("@distributionTime", SqlDbType.SmallDateTime),
					new SqlParameter("@adminID", SqlDbType.Int,4),
					new SqlParameter("@assignerID", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.VarChar,64),
					new SqlParameter("@distributionID", SqlDbType.Int,4)};
			parameters[0].Value = model.feedbackID;
			parameters[1].Value = model.description;
			parameters[2].Value = model.distributionTime;
			parameters[3].Value = model.adminID;
			parameters[4].Value = model.assignerID;
			parameters[5].Value = model.state;
			parameters[6].Value = model.distributionID;

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
		public bool Delete(int distributionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Distribution ");
			strSql.Append(" where distributionID=@distributionID");
			SqlParameter[] parameters = {
					new SqlParameter("@distributionID", SqlDbType.Int,4)
			};
			parameters[0].Value = distributionID;

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
		public bool DeleteList(string distributionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Distribution ");
			strSql.Append(" where distributionID in ("+distributionIDlist + ")  ");
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
		public UserFB.Model.Distribution GetModel(int distributionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 distributionID,feedbackID,description,distributionTime,adminID,assignerID,state from Distribution ");
			strSql.Append(" where distributionID=@distributionID");
			SqlParameter[] parameters = {
					new SqlParameter("@distributionID", SqlDbType.Int,4)
			};
			parameters[0].Value = distributionID;

			UserFB.Model.Distribution model=new UserFB.Model.Distribution();
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
		public UserFB.Model.Distribution DataRowToModel(DataRow row)
		{
			UserFB.Model.Distribution model=new UserFB.Model.Distribution();
			if (row != null)
			{
				if(row["distributionID"]!=null && row["distributionID"].ToString()!="")
				{
					model.distributionID=int.Parse(row["distributionID"].ToString());
				}
				if(row["feedbackID"]!=null && row["feedbackID"].ToString()!="")
				{
					model.feedbackID=int.Parse(row["feedbackID"].ToString());
				}
				if(row["description"]!=null)
				{
					model.description=row["description"].ToString();
				}
				if(row["distributionTime"]!=null && row["distributionTime"].ToString()!="")
				{
					model.distributionTime=DateTime.Parse(row["distributionTime"].ToString());
				}
				if(row["adminID"]!=null && row["adminID"].ToString()!="")
				{
					model.adminID=int.Parse(row["adminID"].ToString());
				}
				if(row["assignerID"]!=null && row["assignerID"].ToString()!="")
				{
					model.assignerID=int.Parse(row["assignerID"].ToString());
				}
				if(row["state"]!=null)
				{
					model.state=row["state"].ToString();
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
			strSql.Append("select distributionID,feedbackID,description,distributionTime,adminID,assignerID,state ");
			strSql.Append(" FROM Distribution ");
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
			strSql.Append(" distributionID,feedbackID,description,distributionTime,adminID,assignerID,state ");
			strSql.Append(" FROM Distribution ");
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
			strSql.Append("select count(1) FROM Distribution ");
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
				strSql.Append("order by T.distributionID desc");
			}
			strSql.Append(")AS Row, T.*  from Distribution T ");
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
			parameters[0].Value = "Distribution";
			parameters[1].Value = "distributionID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        //public DistributionEX GetDistributionD(int id)
        //{
        //    DistributionEX distribution = new DistributionEX();
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.AppendLine("select D.distributionID,D.feedbackID,D.description,D.distributionTime,D.state");
        //   
        //}

        //public List<feedbackEX> GetAllFeedback()
        //{
        //    List<feedbackEX> feedbackList = new List<feedbackEX>();
        //    StringBuilder strSql = new StringBuilder();
        //    // strSql.Append(" feedbackID,UserID,feedbackTime,categoryID,Info,contact,isInvalid,solutionState,handler,remark ");
        //    // strSql.Append(" FROM Feedback ");
        //    strSql.AppendLine("select F.feedbackID,U.UserID as UserID,U.userName as userName,");
        //    strSql.AppendLine("F.feedbackTime,C.categoryID as categoryID,C.category as category,");
        //    strSql.AppendLine("F.Info,F.contact,F.isInvalid,F.solutionState,F.handler,F.remark");
        //    strSql.AppendLine("from Feedback as F");
        //    strSql.AppendLine("inner join Users as U on F.UserID=U.UserID");
        //    strSql.AppendLine("inner join Category as C on F.categoryID=C.categoryID");
        //    SqlDataReader reader = DbHelperSQL.ExecuteReader(strSql.ToString());
        //    while (reader.Read())
        //    {
        //        #region 封装反馈对象
        //        feedbackEX feedback = new feedbackEX();
        //        feedback.feedbackID = int.Parse(reader["feedbackID"].ToString());
        //        feedback.Info = reader["Info"].ToString();
        //        feedback.contact = reader["contact"].ToString();
        //        feedback.isInvalid = reader["isInvalid"].ToString();
        //        feedback.solutionState = reader["solutionState"].ToString();
        //        feedback.handler = reader["handler"].ToString();
        //        feedback.remark = reader["remark"].ToString();
        //        feedback.feedbackTime = DateTime.Parse(reader["feedbackTime"].ToString());
        //        feedback.UserID = int.Parse(reader["UserID"].ToString());

        //        Users users = new Users();
        //        users.UserID = int.Parse(reader["UserID"].ToString());
        //        users.userName = reader["userName"].ToString();
        //        feedback.Users = users;

        //        feedback.categoryID = int.Parse(reader["categoryID"].ToString());
        //        Category c = new Category();
        //        c.categoryID = int.Parse(reader["categoryID"].ToString());
        //        c.category = reader["category"].ToString();
        //        feedback.Category = c;
        //        #endregion

        //        feedbackList.Add(feedback);
        //    }
        //    reader.Close();
        //    return feedbackList;
        //}

        public bool UpdateList(string state, string idList)
        {
            string sql = string.Format("update [Distribution] set [state] ={0} where [distributionID] in({1})", state, idList);
            int rows = DbHelperSQL.ExecuteSql(sql);
            return rows > 0 ? true : false;
        }



        #endregion  ExtensionMethod
    }
}

