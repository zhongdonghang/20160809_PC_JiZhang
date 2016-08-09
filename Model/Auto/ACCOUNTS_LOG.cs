using System;
namespace BT.Model
{
	/// <summary>
	/// ACCOUNTS_LOG:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ACCOUNTS_LOG
	{
		public ACCOUNTS_LOG()
		{}
		#region Model
		private int _oid;
		private string _operate;
		private decimal? _total;
		private string _category;
		private int? _account;
		private string _member;
		private string _dealer;
		private string _article;
		private string _memo;
		private DateTime _tradetime;
		private DateTime? _crdtime;
		private string _creon;
		private DateTime? _modtime;
		private string _modon;
		private int? _companyid;
		/// <summary>
		/// 
		/// </summary>
		public int OID
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OPERATE
		{
			set{ _operate=value;}
			get{return _operate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TOTAL
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CATEGORY
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ACCOUNT
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MEMBER
		{
			set{ _member=value;}
			get{return _member;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEALER
		{
			set{ _dealer=value;}
			get{return _dealer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ARTICLE
		{
			set{ _article=value;}
			get{return _article;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MEMO
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime TRADETIME
		{
			set{ _tradetime=value;}
			get{return _tradetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CRDTIME
		{
			set{ _crdtime=value;}
			get{return _crdtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CREON
		{
			set{ _creon=value;}
			get{return _creon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MODTIME
		{
			set{ _modtime=value;}
			get{return _modtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MODON
		{
			set{ _modon=value;}
			get{return _modon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? COMPANYID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		#endregion Model

	}
}

