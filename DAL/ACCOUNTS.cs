using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BT.DAL
{
	/// <summary>
	/// 数据访问类:ACCOUNTS
	/// </summary>
	public partial class ACCOUNTS
	{
		public ACCOUNTS()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OID", "BT_ACCOUNTS"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BT_ACCOUNTS");
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
		public int Add(BT.Model.ACCOUNTS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BT_ACCOUNTS(");
			strSql.Append("CNAME,BALANCE,COMPANYID)");
			strSql.Append(" values (");
			strSql.Append("@CNAME,@BALANCE,@COMPANYID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BALANCE", SqlDbType.Money,8),
					new SqlParameter("@COMPANYID", SqlDbType.Int,4)};
			parameters[0].Value = model.CNAME;
			parameters[1].Value = model.BALANCE;
			parameters[2].Value = model.COMPANYID;

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
		public bool Update(BT.Model.ACCOUNTS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BT_ACCOUNTS set ");
			strSql.Append("CNAME=@CNAME,");
			strSql.Append("BALANCE=@BALANCE,");
			strSql.Append("COMPANYID=@COMPANYID");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@CNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BALANCE", SqlDbType.Money,8),
					new SqlParameter("@COMPANYID", SqlDbType.Int,4),
					new SqlParameter("@OID", SqlDbType.Int,4)};
			parameters[0].Value = model.CNAME;
			parameters[1].Value = model.BALANCE;
			parameters[2].Value = model.COMPANYID;
			parameters[3].Value = model.OID;

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
			strSql.Append("delete from BT_ACCOUNTS ");
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
			strSql.Append("delete from BT_ACCOUNTS ");
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
		public BT.Model.ACCOUNTS GetModel(int OID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OID,CNAME,BALANCE,COMPANYID from BT_ACCOUNTS ");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4)
			};
			parameters[0].Value = OID;

			BT.Model.ACCOUNTS model=new BT.Model.ACCOUNTS();
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
		public BT.Model.ACCOUNTS DataRowToModel(DataRow row)
		{
			BT.Model.ACCOUNTS model=new BT.Model.ACCOUNTS();
			if (row != null)
			{
				if(row["OID"]!=null && row["OID"].ToString()!="")
				{
					model.OID=int.Parse(row["OID"].ToString());
				}
				if(row["CNAME"]!=null)
				{
					model.CNAME=row["CNAME"].ToString();
				}
				if(row["BALANCE"]!=null && row["BALANCE"].ToString()!="")
				{
					model.BALANCE=decimal.Parse(row["BALANCE"].ToString());
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
			strSql.Append("select OID,CNAME,BALANCE,COMPANYID ");
			strSql.Append(" FROM BT_ACCOUNTS ");
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
			strSql.Append(" OID,CNAME,BALANCE,COMPANYID ");
			strSql.Append(" FROM BT_ACCOUNTS ");
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
			strSql.Append("select count(1) FROM BT_ACCOUNTS ");
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
			strSql.Append(")AS Row, T.*  from BT_ACCOUNTS T ");
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
			parameters[0].Value = "BT_ACCOUNTS";
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

