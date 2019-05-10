using System;
namespace UserFB.Model
{
	/// <summary>
	/// Distribution:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Distribution
	{
		public Distribution()
		{}
		#region Model
		private int _distributionid;
		private int _feedbackid;
		private string _description;
		private DateTime _distributiontime= DateTime.Now;
		private int _adminid;
		private int _assignerid;
		private string _state;
		/// <summary>
		/// 
		/// </summary>
		public int distributionID
		{
			set{ _distributionid=value;}
			get{return _distributionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int feedbackID
		{
			set{ _feedbackid=value;}
			get{return _feedbackid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime distributionTime
		{
			set{ _distributiontime=value;}
			get{return _distributiontime;}
		}
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
		public int assignerID
		{
			set{ _assignerid=value;}
			get{return _assignerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

