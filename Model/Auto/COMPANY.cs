using System;
namespace BT.Model
{
	/// <summary>
	/// COMPANY:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class COMPANY
	{
		public COMPANY()
		{}
		#region Model
		private int _oid;
		private string _companycname;
		private string _companyename;
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
		public string COMPANYCNAME
		{
			set{ _companycname=value;}
			get{return _companycname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string COMPANYENAME
		{
			set{ _companyename=value;}
			get{return _companyename;}
		}
		#endregion Model

	}
}

