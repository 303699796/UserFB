using System;
namespace UserFB.Model
{
	/// <summary>
	/// Feedback:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Feedback
	{
		public Feedback()
		{}
		#region Model
		private int _feedbackid;
		private int _userid;
		private DateTime _feedbacktime= DateTime.Now;
		private int _categoryid;
		private string _info;
		private string _contact;
		private string _isinvalid;
		private string _solutionstate;
		private string _handler;
		private string _remark;
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
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime feedbackTime
		{
			set{ _feedbacktime=value;}
			get{return _feedbacktime;}
		}
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
		public string Info
		{
			set{ _info=value;}
			get{return _info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isInvalid
		{
			set{ _isinvalid=value;}
			get{return _isinvalid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string solutionState
		{
			set{ _solutionstate=value;}
			get{return _solutionstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string handler
		{
			set{ _handler=value;}
			get{return _handler;}
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

