using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BT.Model;
namespace BT.BLL
{
	/// <summary>
	/// ACCOUNTS_LOG
	/// </summary>
	public partial class ACCOUNTS_LOG
	{
		private readonly BT.DAL.ACCOUNTS_LOG dal=new BT.DAL.ACCOUNTS_LOG();
		public ACCOUNTS_LOG()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OID)
		{
			return dal.Exists(OID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BT.Model.ACCOUNTS_LOG model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BT.Model.ACCOUNTS_LOG model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int OID)
		{
			
			return dal.Delete(OID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string OIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(OIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BT.Model.ACCOUNTS_LOG GetModel(int OID)
		{
			
			return dal.GetModel(OID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BT.Model.ACCOUNTS_LOG GetModelByCache(int OID)
		{
			
			string CacheKey = "ACCOUNTS_LOGModel-" + OID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BT.Model.ACCOUNTS_LOG)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BT.Model.ACCOUNTS_LOG> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BT.Model.ACCOUNTS_LOG> DataTableToList(DataTable dt)
		{
			List<BT.Model.ACCOUNTS_LOG> modelList = new List<BT.Model.ACCOUNTS_LOG>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BT.Model.ACCOUNTS_LOG model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

