using System;
namespace UserFB.Model
{
	/// <summary>
	/// ApplyMessage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ApplyMessage
	{
		public ApplyMessage()
		{}
		#region Model
		private int _applyid;
		private int _applicantid;
		private int _approverid;
		private string _name;
		private string _department;
		private string _job;
		private string _permission;
		private DateTime _applytime= DateTime.Now;
		private string _applystate;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int ApplyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int applicantID
		{
			set{ _applicantid=value;}
			get{return _applicantid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int approverID
		{
			set{ _approverid=value;}
			get{return _approverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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
		public DateTime applyTime
		{
			set{ _applytime=value;}
			get{return _applytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string applyState
		{
			set{ _applystate=value;}
			get{return _applystate;}
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

