using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using UserFB.Model;
namespace UserFB.BLL
{
	/// <summary>
	/// FeedbackManager
	/// </summary>
	public partial class FeedbackManager
	{
		private readonly UserFB.DAL.FeedbackService dal=new UserFB.DAL.FeedbackService();
		public FeedbackManager()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int feedbackID)
		{
			return dal.Exists(feedbackID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool   Add(UserFB.Model.Feedback model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.Feedback model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int feedbackID)
		{
			
			return dal.Delete(feedbackID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string feedbackIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(feedbackIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserFB.Model.Feedback GetModel(int feedbackID)
		{
			
			return dal.GetModel(feedbackID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public UserFB.Model.Feedback GetModelByCache(int feedbackID)
		{
			
			string CacheKey = "FeedbackModel-" + feedbackID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(feedbackID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (UserFB.Model.Feedback)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserFB.Model.Feedback> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserFB.Model.Feedback> DataTableToList(DataTable dt)
		{
			List<UserFB.Model.Feedback> modelList = new List<UserFB.Model.Feedback>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				UserFB.Model.Feedback model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public List<feedbackEX> GetAllFeedback()
        {
            return dal.GetAllFeedback();
        }

        ///<summary>
        ///批量更新申请状态
        /// </summary>
        /// <param name="state">状态信息</param>
        /// <param name="idList">要修改的申请消息</param>
        /// <returns>如果更新成功，返回TRUE</returns>

        public bool UpdateInvalid(string state,string idList)
        {
            return dal.UpdateInvalid(state,idList);
        }

        public bool UpdateSolution(string solution, string name, string idList)
        {
            return dal.UpdateSolution(solution,name,idList);
        }

        public int GetRecordCountNum(string strWhere)
        {
            return dal.GetRecordCountNum(strWhere);
        }

        //public int GetRecordCountTime(string strWhere, string strTime)
        //{
        //    return dal.GetRecordCountTime(strWhere, strTime);
        //}

        public bool UpdateHandler(string strWhere, string str)
        {
            return dal.UpdateHandler(strWhere, str);
        }

        public feedbackEX GetDetails(int id)
        {
            return dal.GetDetails(id);
        }

        public bool UpdateSolution(string strWhere, string str)
        {
            return dal.UpdateSolution(strWhere, str);
        }
        #endregion  ExtensionMethod
    }
}

