using System;
namespace UserFB.Model
{
	/// <summary>
	/// Question:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Question
	{
		public Question()
		{}
		#region Model
		private int _questionid;
		private int _categoryid;
		private string _question;
		private string _solution;
		private DateTime _time= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int questionID
		{
			set{ _questionid=value;}
			get{return _questionid;}
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
		public string question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string solution
		{
			set{ _solution=value;}
			get{return _solution;}
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

