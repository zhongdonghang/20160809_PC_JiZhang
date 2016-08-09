using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BT.DAL
{
	/// <summary>
	/// 数据访问类:ACCOUNTS_LOG
	/// </summary>
	public partial class ACCOUNTS_LOG
	{
		public ACCOUNTS_LOG()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OID", "BT_ACCOUNTS_LOG"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BT_ACCOUNTS_LOG");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4)
			};
			parameters[0].Value = OID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BT.Model.ACCOUNTS_LOG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BT_ACCOUNTS_LOG(");
			strSql.Append("OPERATE,TOTAL,CATEGORY,ACCOUNT,MEMBER,DEALER,ARTICLE,MEMO,TRADETIME,CRDTIME,CREON,MODTIME,MODON,COMPANYID)");
			strSql.Append(" values (");
			strSql.Append("@OPERATE,@TOTAL,@CATEGORY,@ACCOUNT,@MEMBER,@DEALER,@ARTICLE,@MEMO,@TRADETIME,@CRDTIME,@CREON,@MODTIME,@MODON,@COMPANYID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OPERATE", SqlDbType.NVarChar,10),
					new SqlParameter("@TOTAL", SqlDbType.Money,8),
					new SqlParameter("@CATEGORY", SqlDbType.NVarChar,20),
					new SqlParameter("@ACCOUNT", SqlDbType.Int,4),
					new SqlParameter("@MEMBER", SqlDbType.NVarChar,20),
					new SqlParameter("@DEALER", SqlDbType.NVarChar,20),
					new SqlParameter("@ARTICLE", SqlDbType.NVarChar,100),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,200),
					new SqlParameter("@TRADETIME", SqlDbType.DateTime),
					new SqlParameter("@CRDTIME", SqlDbType.DateTime),
					new SqlParameter("@CREON", SqlDbType.NVarChar,50),
					new SqlParameter("@MODTIME", SqlDbType.DateTime),
					new SqlParameter("@MODON", SqlDbType.NVarChar,50),
					new SqlParameter("@COMPANYID", SqlDbType.Int,4)};
			parameters[0].Value = model.OPERATE;
			parameters[1].Value = model.TOTAL;
			parameters[2].Value = model.CATEGORY;
			parameters[3].Value = model.ACCOUNT;
			parameters[4].Value = model.MEMBER;
			parameters[5].Value = model.DEALER;
			parameters[6].Value = model.ARTICLE;
			parameters[7].Value = model.MEMO;
			parameters[8].Value = model.TRADETIME;
			parameters[9].Value = model.CRDTIME;
			parameters[10].Value = model.CREON;
			parameters[11].Value = model.MODTIME;
			parameters[12].Value = model.MODON;
			parameters[13].Value = model.COMPANYID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BT.Model.ACCOUNTS_LOG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BT_ACCOUNTS_LOG set ");
			strSql.Append("OPERATE=@OPERATE,");
			strSql.Append("TOTAL=@TOTAL,");
			strSql.Append("CATEGORY=@CATEGORY,");
			strSql.Append("ACCOUNT=@ACCOUNT,");
			strSql.Append("MEMBER=@MEMBER,");
			strSql.Append("DEALER=@DEALER,");
			strSql.Append("ARTICLE=@ARTICLE,");
			strSql.Append("MEMO=@MEMO,");
			strSql.Append("TRADETIME=@TRADETIME,");
			strSql.Append("CRDTIME=@CRDTIME,");
			strSql.Append("CREON=@CREON,");
			strSql.Append("MODTIME=@MODTIME,");
			strSql.Append("MODON=@MODON,");
			strSql.Append("COMPANYID=@COMPANYID");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OPERATE", SqlDbType.NVarChar,10),
					new SqlParameter("@TOTAL", SqlDbType.Money,8),
					new SqlParameter("@CATEGORY", SqlDbType.Int,4),
					new SqlParameter("@ACCOUNT", SqlDbType.Int,4),
					new SqlParameter("@MEMBER", SqlDbType.NVarChar,20),
					new SqlParameter("@DEALER", SqlDbType.NVarChar,20),
					new SqlParameter("@ARTICLE", SqlDbType.NVarChar,100),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,200),
					new SqlParameter("@TRADETIME", SqlDbType.DateTime),
					new SqlParameter("@CRDTIME", SqlDbType.DateTime),
					new SqlParameter("@CREON", SqlDbType.NVarChar,50),
					new SqlParameter("@MODTIME", SqlDbType.DateTime),
					new SqlParameter("@MODON", SqlDbType.NVarChar,50),
					new SqlParameter("@COMPANYID", SqlDbType.Int,4),
					new SqlParameter("@OID", SqlDbType.Int,4)};
			parameters[0].Value = model.OPERATE;
			parameters[1].Value = model.TOTAL;
			parameters[2].Value = model.CATEGORY;
			parameters[3].Value = model.ACCOUNT;
			parameters[4].Value = model.MEMBER;
			parameters[5].Value = model.DEALER;
			parameters[6].Value = model.ARTICLE;
			parameters[7].Value = model.MEMO;
			parameters[8].Value = model.TRADETIME;
			parameters[9].Value = model.CRDTIME;
			parameters[10].Value = model.CREON;
			parameters[11].Value = model.MODTIME;
			parameters[12].Value = model.MODON;
			parameters[13].Value = model.COMPANYID;
			parameters[14].Value = model.OID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int OID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BT_ACCOUNTS_LOG ");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4)
			};
			parameters[0].Value = OID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string OIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BT_ACCOUNTS_LOG ");
			strSql.Append(" where OID in ("+OIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BT.Model.ACCOUNTS_LOG GetModel(int OID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OID,OPERATE,TOTAL,CATEGORY,ACCOUNT,MEMBER,DEALER,ARTICLE,MEMO,TRADETIME,CRDTIME,CREON,MODTIME,MODON,COMPANYID from BT_ACCOUNTS_LOG ");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4)
			};
			parameters[0].Value = OID;

			BT.Model.ACCOUNTS_LOG model=new BT.Model.ACCOUNTS_LOG();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BT.Model.ACCOUNTS_LOG DataRowToModel(DataRow row)
		{
			BT.Model.ACCOUNTS_LOG model=new BT.Model.ACCOUNTS_LOG();
			if (row != null)
			{
				if(row["OID"]!=null && row["OID"].ToString()!="")
				{
					model.OID=int.Parse(row["OID"].ToString());
				}
				if(row["OPERATE"]!=null)
				{
					model.OPERATE=row["OPERATE"].ToString();
				}
				if(row["TOTAL"]!=null && row["TOTAL"].ToString()!="")
				{
					model.TOTAL=decimal.Parse(row["TOTAL"].ToString());
				}
				if(row["CATEGORY"]!=null && row["CATEGORY"].ToString()!="")
				{
					model.CATEGORY=row["CATEGORY"].ToString();
				}
				if(row["ACCOUNT"]!=null && row["ACCOUNT"].ToString()!="")
				{
					model.ACCOUNT=int.Parse(row["ACCOUNT"].ToString());
				}
				if(row["MEMBER"]!=null)
				{
					model.MEMBER=row["MEMBER"].ToString();
				}
				if(row["DEALER"]!=null)
				{
					model.DEALER=row["DEALER"].ToString();
				}
				if(row["ARTICLE"]!=null)
				{
					model.ARTICLE=row["ARTICLE"].ToString();
				}
				if(row["MEMO"]!=null)
				{
					model.MEMO=row["MEMO"].ToString();
				}
				if(row["TRADETIME"]!=null && row["TRADETIME"].ToString()!="")
				{
					model.TRADETIME=DateTime.Parse(row["TRADETIME"].ToString());
				}
				if(row["CRDTIME"]!=null && row["CRDTIME"].ToString()!="")
				{
					model.CRDTIME=DateTime.Parse(row["CRDTIME"].ToString());
				}
				if(row["CREON"]!=null)
				{
					model.CREON=row["CREON"].ToString();
				}
				if(row["MODTIME"]!=null && row["MODTIME"].ToString()!="")
				{
					model.MODTIME=DateTime.Parse(row["MODTIME"].ToString());
				}
				if(row["MODON"]!=null)
				{
					model.MODON=row["MODON"].ToString();
				}
				if(row["COMPANYID"]!=null && row["COMPANYID"].ToString()!="")
				{
					model.COMPANYID=int.Parse(row["COMPANYID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OID,OPERATE,TOTAL,CATEGORY,ACCOUNT,MEMBER,DEALER,ARTICLE,MEMO,TRADETIME,CRDTIME,CREON,MODTIME,MODON,COMPANYID ");
			strSql.Append(" FROM BT_ACCOUNTS_LOG ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" OID,OPERATE,TOTAL,CATEGORY,ACCOUNT,MEMBER,DEALER,ARTICLE,MEMO,TRADETIME,CRDTIME,CREON,MODTIME,MODON,COMPANYID ");
			strSql.Append(" FROM BT_ACCOUNTS_LOG ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BT_ACCOUNTS_LOG ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.OID desc");
			}
			strSql.Append(")AS Row, T.*  from BT_ACCOUNTS_LOG T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "BT_ACCOUNTS_LOG";
			parameters[1].Value = "OID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

