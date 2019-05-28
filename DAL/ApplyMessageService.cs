using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace UserFB.DAL
{
	/// <summary>
	/// 数据访问类:ApplyMessageService
	/// </summary>
	public partial class ApplyMessageService
	{
		public ApplyMessageService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ApplyID", "ApplyMessage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ApplyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ApplyMessage");
			strSql.Append(" where ApplyID=@ApplyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4)
			};
			parameters[0].Value = ApplyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(UserFB.Model.ApplyMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ApplyMessage(");
			strSql.Append("applicantID,approverID,name,department,job,permission,applyTime,applyState,remark)");
			strSql.Append(" values (");
			strSql.Append("@applicantID,@approverID,@name,@department,@job,@permission,@applyTime,@applyState,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@applicantID", SqlDbType.Int,4),
					new SqlParameter("@approverID", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,64),
					new SqlParameter("@department", SqlDbType.VarChar,64),
					new SqlParameter("@job", SqlDbType.VarChar,64),
					new SqlParameter("@permission", SqlDbType.VarChar,16),
					new SqlParameter("@applyTime", SqlDbType.SmallDateTime),
					new SqlParameter("@applyState", SqlDbType.VarChar,16),
					new SqlParameter("@remark", SqlDbType.VarChar,64)};
			parameters[0].Value = model.applicantID;
			parameters[1].Value = model.approverID;
			parameters[2].Value = model.name;
			parameters[3].Value = model.department;
			parameters[4].Value = model.job;
			parameters[5].Value = model.permission;
			parameters[6].Value = model.applyTime;
			parameters[7].Value = model.applyState;
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
		public bool Update(UserFB.Model.ApplyMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ApplyMessage set ");
			strSql.Append("applicantID=@applicantID,");
			strSql.Append("approverID=@approverID,");
			strSql.Append("name=@name,");
			strSql.Append("department=@department,");
			strSql.Append("job=@job,");
			strSql.Append("permission=@permission,");
			strSql.Append("applyTime=@applyTime,");
			strSql.Append("applyState=@applyState,");
			strSql.Append("remark=@remark");
			strSql.Append(" where ApplyID=@ApplyID");
			SqlParameter[] parameters = {
					new SqlParameter("@applicantID", SqlDbType.Int,4),
					new SqlParameter("@approverID", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,64),
					new SqlParameter("@department", SqlDbType.VarChar,64),
					new SqlParameter("@job", SqlDbType.VarChar,64),
					new SqlParameter("@permission", SqlDbType.VarChar,16),
					new SqlParameter("@applyTime", SqlDbType.SmallDateTime),
					new SqlParameter("@applyState", SqlDbType.VarChar,16),
					new SqlParameter("@remark", SqlDbType.VarChar,64),
					new SqlParameter("@ApplyID", SqlDbType.Int,4)};
			parameters[0].Value = model.applicantID;
			parameters[1].Value = model.approverID;
			parameters[2].Value = model.name;
			parameters[3].Value = model.department;
			parameters[4].Value = model.job;
			parameters[5].Value = model.permission;
			parameters[6].Value = model.applyTime;
			parameters[7].Value = model.applyState;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.ApplyID;

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
		public bool Delete(int ApplyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ApplyMessage ");
			strSql.Append(" where ApplyID=@ApplyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4)
			};
			parameters[0].Value = ApplyID;

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
		public bool DeleteList(string ApplyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ApplyMessage ");
			strSql.Append(" where ApplyID in ("+ApplyIDlist + ")  ");
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
		public UserFB.Model.ApplyMessage GetModel(int ApplyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ApplyID,applicantID,approverID,name,department,job,permission,applyTime,applyState,remark from ApplyMessage ");
			strSql.Append(" where ApplyID=@ApplyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4)
			};
			parameters[0].Value = ApplyID;

			UserFB.Model.ApplyMessage model=new UserFB.Model.ApplyMessage();
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
		public UserFB.Model.ApplyMessage DataRowToModel(DataRow row)
		{
			UserFB.Model.ApplyMessage model=new UserFB.Model.ApplyMessage();
			if (row != null)
			{
				if(row["ApplyID"]!=null && row["ApplyID"].ToString()!="")
				{
					model.ApplyID=int.Parse(row["ApplyID"].ToString());
				}
				if(row["applicantID"]!=null && row["applicantID"].ToString()!="")
				{
					model.applicantID=int.Parse(row["applicantID"].ToString());
				}
				if(row["approverID"]!=null && row["approverID"].ToString()!="")
				{
					model.approverID=int.Parse(row["approverID"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
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
				if(row["applyTime"]!=null && row["applyTime"].ToString()!="")
				{
					model.applyTime=DateTime.Parse(row["applyTime"].ToString());
				}
				if(row["applyState"]!=null)
				{
					model.applyState=row["applyState"].ToString();
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
			strSql.Append("select ApplyID,applicantID,approverID,name,department,job,permission,applyTime,applyState,remark ");
			strSql.Append(" FROM ApplyMessage ");
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
			strSql.Append(" ApplyID,applicantID,approverID,name,department,job,permission,applyTime,applyState,remark ");
			strSql.Append(" FROM ApplyMessage ");
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
			strSql.Append("select count(1) FROM ApplyMessage ");
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
				strSql.Append("order by T.ApplyID desc");
			}
			strSql.Append(")AS Row, T.*  from ApplyMessage T ");
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
			parameters[0].Value = "ApplyMessage";
			parameters[1].Value = "ApplyID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet GetNewList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
             strSql.Append("select ApplyID,applicantID,approverID,name,department,job,permission,applyTime,applyState,remark");
            //strSql.Append("select ApplyID,applicantID,approverID,name,department,job,");
           
            //strSql.Append("applyTime,applyState,remark,");
            //strSql.Append("  case   when permission=" + "1"+ " then  " + " 超级管理员" + " else  " + " 普通管理员 " + "  end ");
            strSql.Append(" FROM ApplyMessage ");
            strSql.Append(" where applyState is null order by applyTime Desc");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetHistoryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ApplyID,applicantID,approverID,name,department,job,permission,applyTime,applyState,remark");
            strSql.Append(" FROM ApplyMessage ");
            strSql.Append(" where applyState is not null  order by applyTime Desc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///<summary>
        ///批量更新申请状态
        /// </summary>
        /// <param name="state">状态信息</param>
        /// <param name="idList">要修改的申请消息</param>
        /// <returns>如果更新成功，返回TRUE</returns>
        
        public bool UpdateList(string state,string idList)
        {
            string sql = string.Format("update [ApplyMessage] set [applyState] ={0} where [ApplyID] in({1})",state,idList);
            int rows = DbHelperSQL.ExecuteSql(sql);
            return rows >0?true:false;
        }

        public bool UpdateState(string state1)
        {
            string sql = string.Format("update [ApplyMessage] set [remark] ={0} where [remark] =1", state1);
            int rows = DbHelperSQL.ExecuteSql(sql);
            return rows > 0 ? true : false;
        }



        #endregion  ExtensionMethod
    }
}

