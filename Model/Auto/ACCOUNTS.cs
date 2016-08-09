using System;
namespace BT.Model
{
	/// <summary>
	/// ACCOUNTS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ACCOUNTS
	{
		public ACCOUNTS()
		{}
		#region Model
		private int _oid;
		private string _cname;
		private decimal? _balance;
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
		public string CNAME
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BALANCE
		{
			set{ _balance=value;}
			get{return _balance;}
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

