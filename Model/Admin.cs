using System;
namespace UserFB.Model
{
	/// <summary>
	/// Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin
	{
		public Admin()
		{}
		#region Model
		private int _adminid;
		private string _adminname;
		private string _adminpassword;
		private string _department;
		private string _job;
		private string _permission;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int adminID
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adminName
		{
			set{ _adminname=value;}
			get{return _adminname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adminPassword
		{
			set{ _adminpassword=value;}
			get{return _adminpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string department
		{
			set{ _department=value;}
			get{return _department;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string job
		{
			set{ _job=value;}
			get{return _job;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string permission
		{
			set{ _permission=value;}
			get{return _permission;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

