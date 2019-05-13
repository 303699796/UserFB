using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace UserFB.DAL
{
	/// <summary>
	/// 数据访问类:AdminService
	/// </summary>
	public partial class AdminService
	{
		public AdminService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("adminID", "Admin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int adminID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Admin");
			strSql.Append(" where adminID=@adminID");
			SqlParameter[] parameters = {
					new SqlParameter("@adminID", SqlDbType.Int,4)
			};
			parameters[0].Value = adminID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(UserFB.Model.Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Admin(");
			strSql.Append("adminName,adminPassword,department,job,permission,remark)");
			strSql.Append(" values (");
			strSql.Append("@adminName,@adminPassword,@department,@job,@permission,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@adminName", SqlDbType.VarChar,64),
					new SqlParameter("@adminPassword", SqlDbType.VarChar,64),
					new SqlParameter("@department", SqlDbType.VarChar,64),
					new SqlParameter("@job", SqlDbType.VarChar,64),
					new SqlParameter("@permission", SqlDbType.VarChar,16),
					new SqlParameter("@remark", SqlDbType.VarChar,64)};
			parameters[0].Value = model.adminName;
			parameters[1].Value = model.adminPassword;
			parameters[2].Value = model.department;
			parameters[3].Value = model.job;
			parameters[4].Value = model.permission;
			parameters[5].Value = model.remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return false;
			}
			else
			{
				return true ;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Admin set ");
			strSql.Append("adminName=@adminName,");
			strSql.Append("adminPassword=@adminPassword,");
			strSql.Append("department=@department,");
			strSql.Append("job=@job,");
			strSql.Append("permission=@permission,");
			strSql.Append("remark=@remark");
			strSql.Append(" where adminID=@adminID");
			SqlParameter[] parameters = {
					new SqlParameter("@adminName", SqlDbType.VarChar,64),
					new SqlParameter("@adminPassword", SqlDbType.VarChar,64),
					new SqlParameter("@department", SqlDbType.VarChar,64),
					new SqlParameter("@job", SqlDbType.VarChar,64),
					new SqlParameter("@permission", SqlDbType.VarChar,16),
					new SqlParameter("@remark", SqlDbType.VarChar,64),
					new SqlParameter("@adminID", SqlDbType.Int,4)};
			parameters[0].Value = model.adminName;
			parameters[1].Value = model.adminPassword;
			parameters[2].Value = model.department;
			parameters[3].Value = model.job;
			parameters[4].Value = model.permission;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.adminID;

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
		public bool Delete(int adminID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin ");
			strSql.Append(" where adminID=@adminID");
			SqlParameter[] parameters = {
					new SqlParameter("@adminID", SqlDbType.Int,4)
			};
			parameters[0].Value = adminID;

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
		public bool DeleteList(string adminIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Admin ");
			strSql.Append(" where adminID in ("+adminIDlist + ")  ");
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
		public UserFB.Model.Admin GetModel(int adminID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 adminID,adminName,adminPassword,department,job,permission,remark from Admin ");
			strSql.Append(" where adminID=@adminID");
			SqlParameter[] parameters = {
					new SqlParameter("@adminID", SqlDbType.Int,4)
			};
			parameters[0].Value = adminID;

			UserFB.Model.Admin model=new UserFB.Model.Admin();
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
        public UserFB.Model.Admin GetModel1(string adminID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 adminID,adminName,adminPassword,department,job,permission,remark from Admin ");
            strSql.Append(" where adminID=@adminID");
            SqlParameter[] parameters = {
                    new SqlParameter("@adminID", SqlDbType.Int,4)
            };
            parameters[0].Value = adminID;

            UserFB.Model.Admin model = new UserFB.Model.Admin();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public UserFB.Model.Admin DataRowToModel(DataRow row)
		{
			UserFB.Model.Admin model=new UserFB.Model.Admin();
			if (row != null)
			{
				if(row["adminID"]!=null && row["adminID"].ToString()!="")
				{
					model.adminID=int.Parse(row["adminID"].ToString());
				}
				if(row["adminName"]!=null)
				{
					model.adminName=row["adminName"].ToString();
				}
				if(row["adminPassword"]!=null)
				{
					model.adminPassword=row["adminPassword"].ToString();
				}
				if(row["department"]!=null)
				{
					model.department=row["department"].ToString();
				}
				if(row["job"]!=null)
				{
					model.job=row["job"].ToString();
				}
				if(row["permission"]!=null)
				{
					model.permission=row["permission"].ToString();
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
			strSql.Append("select adminID,adminName,adminPassword,department,job,permission,remark ");
			strSql.Append(" FROM Admin ");
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
			strSql.Append(" adminID,adminName,adminPassword,department,job,permission,remark ");
			strSql.Append(" FROM Admin ");
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
			strSql.Append("select count(1) FROM Admin ");
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
				strSql.Append("order by T.adminID desc");
			}
			strSql.Append(")AS Row, T.*  from Admin T ");
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
			parameters[0].Value = "Admin";
			parameters[1].Value = "adminID";
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

