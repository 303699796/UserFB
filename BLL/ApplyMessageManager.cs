﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using UserFB.Model;
namespace UserFB.BLL
{
	/// <summary>
	/// ApplyMessageManager
	/// </summary>
	public partial class ApplyMessageManager
	{
		private readonly UserFB.DAL.ApplyMessageService dal=new UserFB.DAL.ApplyMessageService();
		public ApplyMessageManager()
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
		public bool Exists(int ApplyID)
		{
			return dal.Exists(ApplyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool   Add(UserFB.Model.ApplyMessage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.ApplyMessage model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ApplyID)
		{
			
			return dal.Delete(ApplyID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ApplyIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(ApplyIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserFB.Model.ApplyMessage GetModel(int ApplyID)
		{
			
			return dal.GetModel(ApplyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public UserFB.Model.ApplyMessage GetModelByCache(int ApplyID)
		{
			
			string CacheKey = "ApplyMessageModel-" + ApplyID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ApplyID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (UserFB.Model.ApplyMessage)objModel;
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
		public List<UserFB.Model.ApplyMessage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserFB.Model.ApplyMessage> DataTableToList(DataTable dt)
		{
			List<UserFB.Model.ApplyMessage> modelList = new List<UserFB.Model.ApplyMessage>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				UserFB.Model.ApplyMessage model;
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


        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet GetNewList(string strWhere)
        {
            return dal.GetNewList(strWhere);
        }

        public DataSet GetALLNewList( )
        {
            return GetNewList("");
        }

        public DataSet GetHistoryList(string strWhere)
        {
            return dal.GetHistoryList(strWhere);
        }

        public DataSet GetHistoryList()
        {
            return GetHistoryList("");
        }

        ///<summary>
        ///批量更新申请状态
        /// </summary>
        /// <param name="state">状态信息</param>
        /// <param name="idList">要修改的申请消息</param>
        /// <returns>如果更新成功，返回TRUE</returns>

        public bool UpdateList(string state, string idList)
        {
            return dal.UpdateList(state,idList);
        }

        public bool UpdateState(string state1)
        {
            return dal.UpdateState(state1);
        }

        #endregion  ExtensionMethod
    }
}

