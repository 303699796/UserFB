using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using UserFB.Model;
using Maticsoft.DBUtility;

namespace UserFB.BLL
{
	/// <summary>
	/// AdminManager
	/// </summary>
	public partial class AdminManager
	{
		private readonly UserFB.DAL.AdminService dal=new UserFB.DAL.AdminService();
		public AdminManager()
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
		public bool Exists(int adminID)
		{
			return dal.Exists(adminID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(UserFB.Model.Admin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.Admin model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int adminID)
		{
			
			return dal.Delete(adminID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string adminIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(adminIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserFB.Model.Admin GetModel(int adminID)
		{
			
			return dal.GetModel(adminID);
		}
        public UserFB.Model.Admin GetModel1(string adminID)
        {

            return dal.GetModel1(adminID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public UserFB.Model.Admin GetModelByCache(int adminID)
		{
			
			string CacheKey = "AdminModel-" + adminID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(adminID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (UserFB.Model.Admin)objModel;
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
		public List<UserFB.Model.Admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserFB.Model.Admin> DataTableToList(DataTable dt)
		{
			List<UserFB.Model.Admin> modelList = new List<UserFB.Model.Admin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				UserFB.Model.Admin model;
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
        public bool UpdateAdminList(string state, string idList)
        {
            string sql = string.Format("update [Admin] set [permission] ={0} where [ApplyID] in({1})", state, idList);
            int rows = DbHelperSQL.ExecuteSql(sql);
            return rows > 0 ? true : false;
        }
        #endregion  ExtensionMethod
    }
}

