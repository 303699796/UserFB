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
	/// 数据访问类:ReplyService
	/// </summary>
	public partial class ReplyService
	{
		public ReplyService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("replyID", "Reply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int replyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Reply");
			strSql.Append(" where replyID=@replyID");
			SqlParameter[] parameters = {
					new SqlParameter("@replyID", SqlDbType.Int,4)
			};
			parameters[0].Value = replyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(UserFB.Model.Reply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Reply(");
			strSql.Append("feedbackID,replierID,receiverID,text,time,remark)");
			strSql.Append(" values (");
			strSql.Append("@feedbackID,@replierID,@receiverID,@text,@time,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@feedbackID", SqlDbType.Int,4),
					new SqlParameter("@replierID", SqlDbType.Int,4),
					new SqlParameter("@receiverID", SqlDbType.Int,4),
					new SqlParameter("@text", SqlDbType.VarChar,128),
					new SqlParameter("@time", SqlDbType.SmallDateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,64)};
			parameters[0].Value = model.feedbackID;
			parameters[1].Value = model.replierID;
			parameters[2].Value = model.receiverID;
			parameters[3].Value = model.text;
			parameters[4].Value = model.time;
			parameters[5].Value = model.remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return  false;
			}
			else
			{
				return true;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.Reply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Reply set ");
			strSql.Append("feedbackID=@feedbackID,");
			strSql.Append("replierID=@replierID,");
			strSql.Append("receiverID=@receiverID,");
			strSql.Append("text=@text,");
			strSql.Append("time=@time,");
			strSql.Append("remark=@remark");
			strSql.Append(" where replyID=@replyID");
			SqlParameter[] parameters = {
					new SqlParameter("@feedbackID", SqlDbType.Int,4),
					new SqlParameter("@replierID", SqlDbType.Int,4),
					new SqlParameter("@receiverID", SqlDbType.Int,4),
					new SqlParameter("@text", SqlDbType.VarChar,128),
					new SqlParameter("@time", SqlDbType.SmallDateTime),
					new SqlParameter("@remark", SqlDbType.VarChar,64),
					new SqlParameter("@replyID", SqlDbType.Int,4)};
			parameters[0].Value = model.feedbackID;
			parameters[1].Value = model.replierID;
			parameters[2].Value = model.receiverID;
			parameters[3].Value = model.text;
			parameters[4].Value = model.time;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.replyID;

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
		public bool Delete(int replyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Reply ");
			strSql.Append(" where replyID=@replyID");
			SqlParameter[] parameters = {
					new SqlParameter("@replyID", SqlDbType.Int,4)
			};
			parameters[0].Value = replyID;

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
		public bool DeleteList(string replyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Reply ");
			strSql.Append(" where replyID in ("+replyIDlist + ")  ");
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
		public UserFB.Model.Reply GetModel(int replyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 replyID,feedbackID,replierID,receiverID,text,time,remark from Reply ");
			strSql.Append(" where replyID=@replyID");
			SqlParameter[] parameters = {
					new SqlParameter("@replyID", SqlDbType.Int,4)
			};
			parameters[0].Value = replyID;

			UserFB.Model.Reply model=new UserFB.Model.Reply();
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
		public UserFB.Model.Reply DataRowToModel(DataRow row)
		{
			UserFB.Model.Reply model=new UserFB.Model.Reply();
			if (row != null)
			{
				if(row["replyID"]!=null && row["replyID"].ToString()!="")
				{
					model.replyID=int.Parse(row["replyID"].ToString());
				}
				if(row["feedbackID"]!=null && row["feedbackID"].ToString()!="")
				{
					model.feedbackID=int.Parse(row["feedbackID"].ToString());
				}
				if(row["replierID"]!=null && row["replierID"].ToString()!="")
				{
					model.replierID=int.Parse(row["replierID"].ToString());
				}
				if(row["receiverID"]!=null && row["receiverID"].ToString()!="")
				{
					model.receiverID=int.Parse(row["receiverID"].ToString());
				}
				if(row["text"]!=null)
				{
					model.text=row["text"].ToString();
				}
				if(row["time"]!=null && row["time"].ToString()!="")
				{
					model.time=DateTime.Parse(row["time"].ToString());
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
			strSql.Append("select replyID,feedbackID,replierID,receiverID,text,time,remark ");
			strSql.Append(" FROM Reply ");
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
			strSql.Append(" replyID,feedbackID,replierID,receiverID,text,time,remark ");
			strSql.Append(" FROM Reply ");
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
			strSql.Append("select count(1) FROM Reply ");
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
				strSql.Append("order by T.replyID desc");
			}
			strSql.Append(")AS Row, T.*  from Reply T ");
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
			parameters[0].Value = "Reply";
			parameters[1].Value = "replyID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod


        public List<ReplyEX> GetFBList(string str)
        {
            List<ReplyEX> replyIces = new List<ReplyEX>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendLine("select R.replyID,F.feedbackID as feedbackID,F.Info as Info,");
            strSql.AppendLine("R.replierID,R.receiverID,R.text,R.time,R.remark");

           // strSql.AppendLine("U.UserID as UserID,U.userName as userName");

            strSql.AppendLine("from Reply as R");

         //   strSql.AppendLine("inner join Users as U on R.replierID=U.UserID");

            strSql.AppendLine("inner join Feedback as F on R.feedbackID=F.feedbackID");
            if (str.Trim() != "")
            {
                strSql.Append(" where " + str);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(strSql.ToString());
            while (reader.Read())
            {
                
                ReplyEX reply = new ReplyEX();
                reply.replyID = int.Parse(reader["replyID"].ToString());
                reply.replierID=int.Parse(reader["replierID"].ToString());
              

                //Users users = new Users();
                //users.UserID = int.Parse(reader["UserID"].ToString());
                //users.userName = reader["userName"].ToString();
                //reply.Users = users;

                reply.receiverID= int.Parse(reader["receiverID"].ToString());
                reply.text= reader["text"].ToString();
                reply.remark = reader["remark"].ToString();
                reply.time=DateTime.Parse(reader["time"].ToString());

                reply.feedbackID= int.Parse(reader["feedbackID"].ToString());
                Feedback feedback = new Feedback();
                feedback.feedbackID= int.Parse(reader["feedbackID"].ToString());
                feedback.Info = reader["Info"].ToString();
                reply.Feedback = feedback;

                replyIces.Add(reply);
            }
            reader.Close();
            return replyIces;
        }

        //public List<ReplyEX> GetFBList_Admin(string str)
        //{
        //    List<ReplyEX> replies = new List<ReplyEX>();
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.AppendLine("select R.replyID,F.feedbackID as feedbackID,F.Info as Info,");
        //    strSql.AppendLine("U.UserID as UserID,U.userName as userName,");

        //    strSql.AppendLine("R.receiverID,R.text,R.time,R.remark");
        //    strSql.AppendLine("from Reply as R");

        //    strSql.AppendLine(" inner join Feedback as F on R.feedbackID=F.feedbackID");
        //    strSql.AppendLine(" inner join Users as U on R.replierID=U.UserID");


        //    SqlDataReader reader = DbHelperSQL.ExecuteReader(strSql.ToString());
        //    while (reader.Read())
        //    {

        //        ReplyEX reply = new ReplyEX();
        //        reply.replyID = int.Parse(reader["replyID"].ToString());

        //        reply.replierID = int.Parse(reader["replierID"].ToString());
        //        Users users = new Users();
        //        users.UserID= int.Parse(reader["UserID"].ToString());
        //        users.userName = reader["userName"].ToString();
        //        reply.Users = users;

        //        reply.receiverID = int.Parse(reader["receiverID"].ToString());             
        //        reply.text = reader["text"].ToString();
        //        reply.remark = reader["remark"].ToString();
        //        reply.time = DateTime.Parse(reader["time"].ToString());

        //        reply.feedbackID = int.Parse(reader["feedbackID"].ToString());
        //        Feedback feedback = new Feedback();
        //        feedback.feedbackID = int.Parse(reader["feedbackID"].ToString());
        //        feedback.Info = reader["Info"].ToString();
        //        reply.Feedback = feedback;
        //        replies.Add(reply);


        //    }
        //    reader.Close();
        //    return replies;
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


        public string GetUserID(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select replierID ");
            strSql.Append(" FROM Reply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return Convert.ToString(obj);
            }


        }


        public string GetFBID(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select feedbackID ");
            strSql.Append(" FROM Reply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return Convert.ToString(obj);
            }


        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddReply(UserFB.Model.Reply model,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Reply(");
            strSql.Append("feedbackID,replierID,receiverID,text,time,remark)");
            strSql.Append(" values (");
            strSql.Append("@feedbackID,@replierID,@receiverID,@text,@time,@remark)");
            strSql.Append(";select @@IDENTITY");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            SqlParameter[] parameters = {
                    new SqlParameter("@feedbackID", SqlDbType.Int,4),
                    new SqlParameter("@replierID", SqlDbType.Int,4),
                    new SqlParameter("@receiverID", SqlDbType.Int,4),
                    new SqlParameter("@text", SqlDbType.VarChar,128),
                    new SqlParameter("@time", SqlDbType.SmallDateTime),
                    new SqlParameter("@remark", SqlDbType.VarChar,64)};
            parameters[0].Value = model.feedbackID;
            parameters[1].Value = model.replierID;
            parameters[2].Value = model.receiverID;
            parameters[3].Value = model.text;
            parameters[4].Value = model.time;
            parameters[5].Value = model.remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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

