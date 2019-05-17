using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using UserFB.Model;
namespace UserFB.BLL
{
	/// <summary>
	/// UsersManager
	/// </summary>
	public partial class UsersManager
	{
		private readonly UserFB.DAL.UsersService dal=new UserFB.DAL.UsersService();
		public UsersManager()
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
		public bool Exists(int UserID)
		{
			return dal.Exists(UserID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(UserFB.Model.Users model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFB.Model.Users model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserID)
		{
			
			return dal.Delete(UserID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(UserIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserFB.Model.Users GetModel(int  UserID)
		{
			
			return dal.GetModel(UserID);
		}

        public UserFB.Model.Users GetModel1(string  UserID)
        {

            return dal.GetModel1(UserID);
        }


        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public UserFB.Model.Users GetModelByCache(int UserID)
		{
			
			string CacheKey = "UsersModel-" + UserID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (UserFB.Model.Users)objModel;
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
		public List<UserFB.Model.Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserFB.Model.Users> DataTableToList(DataTable dt)
		{
			List<UserFB.Model.Users> modelList = new List<UserFB.Model.Users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				UserFB.Model.Users model;
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
        //public int GetRecordCountNum(string strWhere)
        //{
        //    return dal.GetRecordCountNum(strWhere);
        //}
        #endregion  ExtensionMethod
    }
}

