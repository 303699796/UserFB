﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using UserFB.Model;
namespace UserFB.BLL
{
	/// <summary>
	/// DistributionManager
	/// </summary>
	public partial class DistributionManager
	{
		private readonly UserFB.DAL.DistributionService dal=new UserFB.DAL.DistributionService();
		public DistributionManager()
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
		public bool Exists(int distributionID)
		{
			return dal.Exists(distributionID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(UserFB.Model.Distribution model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.Distribution model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int distributionID)
		{
			
			return dal.Delete(distributionID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string distributionIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(distributionIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserFB.Model.Distribution GetModel(int distributionID)
		{
			
			return dal.GetModel(distributionID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public UserFB.Model.Distribution GetModelByCache(int distributionID)
		{
			
			string CacheKey = "DistributionModel-" + distributionID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(distributionID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (UserFB.Model.Distribution)objModel;
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
		public List<UserFB.Model.Distribution> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserFB.Model.Distribution> DataTableToList(DataTable dt)
		{
			List<UserFB.Model.Distribution> modelList = new List<UserFB.Model.Distribution>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				UserFB.Model.Distribution model;
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
        public bool UpdateList(string state, string idList)
        {
            return dal.UpdateList(state, idList);
        }


        #endregion  ExtensionMethod
    }
}

