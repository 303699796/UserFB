using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace UserFB.DAL
{
	/// <summary>
	/// 数据访问类:QuestionService
	/// </summary>
	public partial class QuestionService
	{
		public QuestionService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("questionID", "Question"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int questionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Question");
			strSql.Append(" where questionID=@questionID");
			SqlParameter[] parameters = {
					new SqlParameter("@questionID", SqlDbType.Int,4)
			};
			parameters[0].Value = questionID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(UserFB.Model.Question model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Question(");
			strSql.Append("categoryID,question,solution,time)");
			strSql.Append(" values (");
			strSql.Append("@categoryID,@question,@solution,@time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@categoryID", SqlDbType.Int,4),
					new SqlParameter("@question", SqlDbType.VarChar,128),
					new SqlParameter("@solution", SqlDbType.VarChar,128),
					new SqlParameter("@time", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.categoryID;
			parameters[1].Value = model.question;
			parameters[2].Value = model.solution;
			parameters[3].Value = model.time;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.Question model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Question set ");
			strSql.Append("categoryID=@categoryID,");
			strSql.Append("question=@question,");
			strSql.Append("solution=@solution,");
			strSql.Append("time=@time");
			strSql.Append(" where questionID=@questionID");
			SqlParameter[] parameters = {
					new SqlParameter("@categoryID", SqlDbType.Int,4),
					new SqlParameter("@question", SqlDbType.VarChar,128),
					new SqlParameter("@solution", SqlDbType.VarChar,128),
					new SqlParameter("@time", SqlDbType.SmallDateTime),
					new SqlParameter("@questionID", SqlDbType.Int,4)};
			parameters[0].Value = model.categoryID;
			parameters[1].Value = model.question;
			parameters[2].Value = model.solution;
			parameters[3].Value = model.time;
			parameters[4].Value = model.questionID;

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
		public bool Delete(int questionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Question ");
			strSql.Append(" where questionID=@questionID");
			SqlParameter[] parameters = {
					new SqlParameter("@questionID", SqlDbType.Int,4)
			};
			parameters[0].Value = questionID;

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
		public bool DeleteList(string questionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Question ");
			strSql.Append(" where questionID in ("+questionIDlist + ")  ");
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
		public UserFB.Model.Question GetModel(int questionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 questionID,categoryID,question,solution,time from Question ");
			strSql.Append(" where questionID=@questionID");
			SqlParameter[] parameters = {
					new SqlParameter("@questionID", SqlDbType.Int,4)
			};
			parameters[0].Value = questionID;

			UserFB.Model.Question model=new UserFB.Model.Question();
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
		public UserFB.Model.Question DataRowToModel(DataRow row)
		{
			UserFB.Model.Question model=new UserFB.Model.Question();
			if (row != null)
			{
				if(row["questionID"]!=null && row["questionID"].ToString()!="")
				{
					model.questionID=int.Parse(row["questionID"].ToString());
				}
				if(row["categoryID"]!=null && row["categoryID"].ToString()!="")
				{
					model.categoryID=int.Parse(row["categoryID"].ToString());
				}
				if(row["question"]!=null)
				{
					model.question=row["question"].ToString();
				}
				if(row["solution"]!=null)
				{
					model.solution=row["solution"].ToString();
				}
				if(row["time"]!=null && row["time"].ToString()!="")
				{
					model.time=DateTime.Parse(row["time"].ToString());
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
			strSql.Append("select questionID,categoryID,question,solution,time ");
			strSql.Append(" FROM Question ");
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
			strSql.Append(" questionID,categoryID,question,solution,time ");
			strSql.Append(" FROM Question ");
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
			strSql.Append("select count(1) FROM Question ");
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
				strSql.Append("order by T.questionID desc");
			}
			strSql.Append(")AS Row, T.*  from Question T ");
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
			parameters[0].Value = "Question";
			parameters[1].Value = "questionID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

