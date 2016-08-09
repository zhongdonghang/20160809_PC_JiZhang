using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BT.Service.ViewModel;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace BT.Service
{
    public static class ReportService
    {
        /// <summary>
        /// 获取报表
        /// </summary>
        /// <param name="COMPANYID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="AccountIdList"></param>
        /// <returns></returns>
        public static string GetReport1(string COMPANYID, string BeginDate, string EndDate, string AccountIdList)
        {
            ReturnSimpleResult2<SimpleReportModel> ret = new ReturnSimpleResult2<SimpleReportModel>();
            try
            {
                SimpleReportModel model = new SimpleReportModel();
                //某个时间段的支出总额 
                string sql = " select SUM(TOTAL) from dbo.BT_ACCOUNTS_LOG where COMPANYID=" + COMPANYID + " " +
                    " and TRADETIME >= '" + BeginDate + " ' and TRADETIME <= '" + EndDate + " ' and OPERATE='支出' and ACCOUNT in (" + AccountIdList + ") ";
                object obj = DbHelperSQL.GetSingle(sql);
                if (obj != null)
                {
                    model.OutTotal = obj.ToString();
                }
                else
                {
                    model.OutTotal = "0";
                }

                //某个时间段的收入总额
                sql = " select SUM(TOTAL) from dbo.BT_ACCOUNTS_LOG where COMPANYID=" + COMPANYID + " " +
                                " and TRADETIME >= '" + BeginDate + " ' and TRADETIME <= '" + EndDate + " ' and OPERATE='收入' and ACCOUNT in (" + AccountIdList + ") ";
                obj = DbHelperSQL.GetSingle(sql);
                if (obj != null)
                {
                    model.InTotal = obj.ToString();
                }
                else
                {
                    model.InTotal = "0";
                }

                //某个时间段的支出笔数
                sql = " select COUNT(OID) from dbo.BT_ACCOUNTS_LOG where COMPANYID=" + COMPANYID + " " +
                                " and TRADETIME >= '" + BeginDate + " ' and TRADETIME <= '" + EndDate + " ' and OPERATE='支出' and ACCOUNT in (" + AccountIdList + ") ";

                obj = DbHelperSQL.GetSingle(sql);
                if (obj != null)
                {
                    model.OutCount = obj.ToString();
                }
                else
                {
                    model.OutCount = "0";
                }

                //某个时间段的收入笔数
                sql = " select COUNT(OID) from dbo.BT_ACCOUNTS_LOG where COMPANYID=" + COMPANYID + " " +
                                " and TRADETIME >= '" + BeginDate + " ' and TRADETIME <= '" + EndDate + " ' and OPERATE='收入' and ACCOUNT in (" + AccountIdList + ") ";
                obj = DbHelperSQL.GetSingle(sql);
                if (obj != null)
                {
                    model.InCount = obj.ToString();
                }
                else
                {
                    model.InCount = "0";
                }

                //某个时间段的支出分类汇总
                sql = " select CATEGORY,SUM(total) from BT_ACCOUNTS_LOG  where " +
                    " TRADETIME >= '" + BeginDate + " ' and TRADETIME <= '" + EndDate + " ' and" +
                    " OPERATE='支出' and ACCOUNT in (" + AccountIdList + ")  group by CATEGORY ";

                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
                {
                    if (reader.HasRows)
                    {
                        model.OutCategorySum = new List<CategorySum>();
                        while (reader.Read())
                        {
                            CategorySum cs = new CategorySum();
                            cs.CategoryName = reader[0].ToString();
                            cs.SumTotal = reader[1].ToString();
                            model.OutCategorySum.Add(cs);
                        }
                    }
                    else
                    {
                        model.OutCategorySum = new List<CategorySum>();
                    }
                }

                //某个时间段的收入分类汇总
                sql = " select CATEGORY,SUM(total) from BT_ACCOUNTS_LOG  where " +
                    " TRADETIME >= '" + BeginDate + " ' and TRADETIME <= '" + EndDate + " ' and" +
                    " OPERATE='收入' and ACCOUNT in (" + AccountIdList + ")  group by CATEGORY ";

                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
                {
                    if (reader.HasRows)
                    {
                        model.InCategorySum = new List<CategorySum>();
                        while (reader.Read())
                        {
                            CategorySum cs = new CategorySum();
                            cs.CategoryName = reader[0].ToString();
                            cs.SumTotal = reader[1].ToString();
                            model.InCategorySum.Add(cs);
                        }
                    }
                    else
                    {
                        model.InCategorySum = new List<CategorySum>();
                    }
                }
                ret.t = model;
                ret.Msg = "查询成功";
                ret.ResultCode = "0";
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.t = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }
    }
}
