using System;
namespace UserFB.Model
{
	/// <summary>
	/// Category:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Category
	{
		public Category()
		{}
		#region Model
		private int _categoryid;
		private string _category;
		private DateTime _time= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int categoryID
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

