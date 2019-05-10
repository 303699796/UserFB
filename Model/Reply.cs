using System;
namespace UserFB.Model
{
	/// <summary>
	/// Reply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Reply
	{
		public Reply()
		{}
		#region Model
		private int _replyid;
		private int _feedbackid;
		private int _replierid;
		private int _receiverid;
		private string _text;
		private DateTime _time= DateTime.Now;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int replyID
		{
			set{ _replyid=value;}
			get{return _replyid;}
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
		public int replierID
		{
			set{ _replierid=value;}
			get{return _replierid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int receiverID
		{
			set{ _receiverid=value;}
			get{return _receiverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string text
		{
			set{ _text=value;}
			get{return _text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime time
		{
			set{ _time=value;}
			get{return _time;}
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

