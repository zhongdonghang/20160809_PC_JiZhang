using System;
namespace BT.Model
{
	/// <summary>
	/// SYSUSER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYSUSER
	{
		public SYSUSER()
		{}
		#region Model
		private int _oid;
		private string _cname;
		private string _login_name;
		private string _login_pwd;
		private string _memo;
		private DateTime? _crdtime;
		private string _crdon;
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
		public string CNAME
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LOGIN_NAME
		{
			set{ _login_name=value;}
			get{return _login_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LOGIN_PWD
		{
			set{ _login_pwd=value;}
			get{return _login_pwd;}
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
		public DateTime? CRDTIME
		{
			set{ _crdtime=value;}
			get{return _crdtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CRDON
		{
			set{ _crdon=value;}
			get{return _crdon;}
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

