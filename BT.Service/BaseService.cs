using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace BT.Service
{
    public static class BaseService
    {
        static BLL.SYSUSER bllSysUser = new BLL.SYSUSER();
        static BLL.ACCOUNTS bllAccounts = new BLL.ACCOUNTS();
        static BLL.ACCOUNTS_LOG bllACCOUNTS_LOG = new BLL.ACCOUNTS_LOG();
        static BT.BLL.COMPANY bllCOMPANY = new BT.BLL.COMPANY();

        /// <summary>
        /// 开通新用户
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="uName"></param>
        /// <param name="loginName"></param>
        /// <param name="uPass"></param>
        /// <returns></returns>
        public static string AddNewAccount(string companyName, string uName, string loginName, string uPass)
        {
            //添加公司账户
            //添加登陆用户
            //添加基本户
            ReturnSimpleResult1 ret = new ReturnSimpleResult1();
            try
            {
                BT.Model.COMPANY companyModel = new Model.COMPANY();
                companyModel.COMPANYCNAME = companyName;
                companyModel.COMPANYENAME = companyName;
                int companyOid = bllCOMPANY.Add(companyModel);
                if (companyOid > 0)//添加公司成功
                {
                    List<Model.SYSUSER> list = bllSysUser.GetModelList(" LOGIN_NAME='" + loginName + "' ");
                    if (list == null || list.Count == 0)
                    {
                        Model.SYSUSER modelUser = new Model.SYSUSER();
                        modelUser.CNAME = uName;
                        modelUser.LOGIN_NAME = loginName;
                        modelUser.MEMO = "暂无";
                        modelUser.CRDON = "administrator";
                        modelUser.CRDTIME = DateTime.Now;
                        modelUser.LOGIN_PWD = uPass;
                        modelUser.MODON = "administrator";
                        modelUser.MODTIME = DateTime.Now;
                        modelUser.COMPANYID = companyOid;
                        int userOid = bllSysUser.Add(modelUser);
                        if (userOid > 0) //添加账本用户成功
                        {
                            Model.ACCOUNTS addObj = new Model.ACCOUNTS();
                            addObj.CNAME = "基本户";
                            addObj.BALANCE = 0;
                            addObj.COMPANYID = companyOid;
                            int accountOid = bllAccounts.Add(addObj);

                            addObj.CNAME = "微信钱包";
                            addObj.BALANCE = 0;
                            addObj.COMPANYID = companyOid;
                            accountOid = bllAccounts.Add(addObj);

                            addObj.CNAME = "支付宝";
                            addObj.BALANCE = 0;
                            addObj.COMPANYID = companyOid;
                            accountOid = bllAccounts.Add(addObj);

                            addObj.CNAME = "市民卡";
                            addObj.BALANCE = 0;
                            addObj.COMPANYID = companyOid;
                            accountOid = bllAccounts.Add(addObj);

                            if (accountOid > 0)
                            {
                                ret.Msg = "账本开通成功";
                                ret.ResultCode = "0";
                            }
                            else
                            {
                                ret.Msg = "添加失败，请稍后再试";
                                ret.ResultCode = "-1";
                            }
                        }
                        else
                        {
                            ret.ResultCode = "-1";
                            ret.Msg = "添加账本用户失败";
                        }
                    }
                    else
                    {
                        ret.ResultCode = "-1";
                        ret.Msg = "添加账本用户失败,登录名已经存在";
                    }
                }
                else
                {
                    ret.ResultCode = "-1";
                    ret.Msg = "添加账本失败";
                }

            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 添加登录账户
        /// </summary>
        /// <param name="CNAME"></param>
        /// <param name="LOGIN_NAME"></param>
        /// <param name="MEMO"></param>
        /// <param name="COMPANYID"></param>
        /// <returns></returns>
        public static string AddLoginUser(string CNAME, string LOGIN_NAME, string MEMO, string COMPANYID)
        {
            ReturnSimpleResult2<Model.SYSUSER> ret = new ReturnSimpleResult2<Model.SYSUSER>();
            try
            {
                List<Model.SYSUSER> list = bllSysUser.GetModelList(" LOGIN_NAME='" + LOGIN_NAME + "' ");
                if (list == null || list.Count == 0)
                {
                    Model.SYSUSER modelUser = new Model.SYSUSER();
                    modelUser.CNAME = CNAME;
                    modelUser.LOGIN_NAME = LOGIN_NAME;
                    modelUser.MEMO = MEMO;
                    modelUser.CRDON = "administrator";
                    modelUser.CRDTIME = DateTime.Now;
                    modelUser.LOGIN_PWD = "123456";
                    modelUser.MODON = "administrator";
                    modelUser.MODTIME = DateTime.Now;
                    modelUser.COMPANYID = int.Parse(COMPANYID);
                    int count = bllSysUser.Add(modelUser);
                    if (count > 0)
                    {
                        ret.Msg = "添加登录账户成功";
                        ret.ResultCode = "0";
                        ret.t = modelUser;
                    }
                    else
                    {
                        ret.Msg = "添加登录账户失败";
                        ret.ResultCode = "-1";
                        ret.t = null;
                    }
                }
                else
                {
                    ret.Msg = "添加登录账户失败，登录名已经存在";
                    ret.ResultCode = "-1";
                    ret.t = null;
                }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.t = null;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }


        /// <summary>
        /// 删除登录账户
        /// </summary>
        /// <param name="LoginUserOID"></param>
        /// <returns></returns>
        public static string DeleteLoginUser(string LoginUserOID)
        {
            ReturnSimpleResult1 ret = new ReturnSimpleResult1();
            try
            {
                BT.Model.SYSUSER currentUser =  bllSysUser.GetModel(int.Parse(LoginUserOID));
                //COMPANYID
                List<BT.Model.SYSUSER> listUser = bllSysUser.GetModelList(" COMPANYID=" + currentUser.COMPANYID + " ");
                if (listUser.Count == 0)
                {
                    ret.Msg = "删除登录账户失败，当前只有一个账户，不能删除";
                    ret.ResultCode = "-1";
                }
                else if (listUser[0].OID.ToString() == LoginUserOID)
                {
                    ret.Msg = "删除登录账户失败，不能删除主账户";
                    ret.ResultCode = "-1";
                }
                else
                {
                    bool b = bllSysUser.Delete(int.Parse(LoginUserOID));
                    if (b)
                    {
                        ret.Msg = "删除登录账户成功";
                        ret.ResultCode = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }


        /// <summary>
        /// 查询登录账户列表
        /// </summary>
        /// <returns></returns>
        public static string ToListLoginUser(string COMPANYID)
        {
            ReturnPageResult<Model.SYSUSER> ret = new ReturnPageResult<Model.SYSUSER>();
            try
            {
                List<Model.SYSUSER> list = bllSysUser.GetModelList(" COMPANYID=" + COMPANYID + " ");
                ret.Page = new PageObject<Model.SYSUSER>();
                ret.Page.Data = list;
                ret.Page.PageCount = 9999;
                ret.Page.PageIndex = 0;
                ret.Page.PageSize = 9999;
                ret.Page.RecordCount = list.Count;
                ret.Msg = "查询成功";
                ret.ResultCode = "0";
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.Page = null;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PWD"></param>
        /// <returns></returns>
        public static string Login(string LoginName, string PWD)
        {
            ReturnSimpleResult2<Model.SYSUSER> ret = new ReturnSimpleResult2<Model.SYSUSER>();
            try
            {
                List<Model.SYSUSER> list = bllSysUser.GetModelList(" LOGIN_NAME='" + LoginName.Trim() + "' and LOGIN_PWD='" + PWD.Trim() + "' ");
                if (list == null)
                {
                    ret.Msg = "账户密码不对";
                    ret.ResultCode = "-1";
                    ret.t = null;
                }
                else if (list.Count == 1)
                {
                    ret.Msg = "登录成功";
                    ret.ResultCode = "0";
                    ret.t = list[0];
                }
                else
                {
                    ret.Msg = "账户异常";
                    ret.ResultCode = "-1";
                    ret.t = null;
                }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.t = null;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 添加记账账户
        /// </summary>
        /// <param name="CNAME"></param>
        /// <param name="BALANCE"></param>
        /// <param name="COMPANYID"></param>
        /// <returns></returns>
        public static string AddAccount(string CNAME, string BALANCE, string COMPANYID)
        {
            ReturnSimpleResult2<Model.ACCOUNTS> ret = new ReturnSimpleResult2<Model.ACCOUNTS>();
            try
            {
                List<Model.ACCOUNTS> list = bllAccounts.GetModelList(" COMPANYID=" + COMPANYID + " and CNAME='" + CNAME + "' ");
                if (list == null || list.Count == 0)
                {
                    Model.ACCOUNTS addObj = new Model.ACCOUNTS();
                    addObj.CNAME = CNAME;
                    addObj.BALANCE = Decimal.Parse(BALANCE);
                    addObj.COMPANYID = int.Parse(COMPANYID);
                    int count = bllAccounts.Add(addObj);
                    if (count > 0)
                    {
                        ret.Msg = "添加账户成功";
                        ret.ResultCode = "0";
                        ret.t = addObj;
                    }
                    else
                    {
                        ret.Msg = "添加失败，请稍后再试";
                        ret.ResultCode = "-1";
                        ret.t = null;
                    }
                }
                else
                {
                    ret.Msg = "添加失败，该单位已经存在同名的账户";
                    ret.ResultCode = "-1";
                    ret.t = null;
                }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.t = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 编辑某个账本
        /// </summary>
        /// <param name="OID"></param>
        /// <param name="NewName"></param>
        /// <param name="NewBALANCE"></param>
        /// <returns></returns>
        public static string EditAccount(string OID, string NewName, string NewBALANCE)
        {
            ReturnSimpleResult2<Model.ACCOUNTS> ret = new ReturnSimpleResult2<Model.ACCOUNTS>();
            try
            {
               BT.Model.ACCOUNTS oldModel = bllAccounts.GetModel(int.Parse(OID));

               List<Model.ACCOUNTS> list = bllAccounts.GetModelList(" COMPANYID=" + oldModel.COMPANYID + " and CNAME='" + NewName + "' ");
               if (list == null || list.Count == 0)
               {
                   oldModel.BALANCE = decimal.Parse(NewBALANCE);
                   oldModel.CNAME = NewName;
                   bool isTrue = bllAccounts.Update(oldModel);
                   if (isTrue)
                   {
                       ret.Msg = "编辑账户成功";
                       ret.ResultCode = "0";
                       ret.t = oldModel;
                   }
                   else
                   {
                       ret.Msg = "操作失败，请稍后再试";
                       ret.ResultCode = "-1";
                       ret.t = null;
                   }
               }
               else
               {
                   ret.Msg = "编辑失败，该单位已经存在同名的账户";
                   ret.ResultCode = "-1";
                   ret.t = null;
               }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.t = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }


        /// <summary>
        /// 记一笔（收入）
        /// </summary>
        /// <param name="TOTAL"></param>
        /// <param name="CATEGORY"></param>
        /// <param name="ACCOUNT"></param>
        /// <param name="MEMBER"></param>
        /// <param name="DEALER"></param>
        /// <param name="ARTICLE"></param>
        /// <param name="MEMO"></param>
        /// <param name="TRADETIME"></param>
        /// <param name="COMPANYID"></param>
        /// <returns></returns>
        public static string AddInACCOUNTS_LOG(string TOTAL, string CATEGORY, string ACCOUNT, string MEMBER,
            string DEALER, string ARTICLE, string MEMO, string TRADETIME, string COMPANYID)
        {
            ReturnSimpleResult2<Model.ACCOUNTS_LOG> ret = new ReturnSimpleResult2<Model.ACCOUNTS_LOG>();
            try
            {
                Model.ACCOUNTS_LOG addObj = new Model.ACCOUNTS_LOG();
                addObj.TOTAL = decimal.Parse(TOTAL);
                addObj.CATEGORY = CATEGORY;
                addObj.OPERATE = "收入";
                addObj.ACCOUNT = int.Parse(ACCOUNT);
                addObj.MEMBER = MEMBER;
                addObj.DEALER = DEALER;
                addObj.ARTICLE = ARTICLE;
                addObj.MEMO = MEMO;
                addObj.TRADETIME = DateTime.Parse(TRADETIME);
                addObj.COMPANYID = int.Parse(COMPANYID);
                addObj.CRDTIME = DateTime.Now;
                addObj.CREON = "administrator";
                addObj.MODTIME = DateTime.Now;
                addObj.MODON = "administrator";
                int count = bllACCOUNTS_LOG.Add(addObj);
                if (count > 0)
                {
                    //变更该账户余额
                    Model.ACCOUNTS curAccount = bllAccounts.GetModel(int.Parse(ACCOUNT));
                    curAccount.BALANCE += decimal.Parse(TOTAL);
                    if (bllAccounts.Update(curAccount))
                    {
                        ret.Msg = "成功记录一笔收入";
                        ret.ResultCode = "0";
                        ret.t = addObj;
                    }
                }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.t = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }


        /// <summary>
        /// 记一笔（支出）
        /// </summary>
        /// <param name="TOTAL"></param>
        /// <param name="CATEGORY"></param>
        /// <param name="ACCOUNT"></param>
        /// <param name="MEMBER"></param>
        /// <param name="DEALER"></param>
        /// <param name="ARTICLE"></param>
        /// <param name="MEMO"></param>
        /// <param name="TRADETIME"></param>
        /// <param name="COMPANYID"></param>
        /// <returns></returns>
        public static string AddOutACCOUNTS_LOG(string TOTAL, string CATEGORY, string ACCOUNT, string MEMBER,
            string DEALER, string ARTICLE, string MEMO, string TRADETIME, string COMPANYID)
        {
            ReturnSimpleResult2<Model.ACCOUNTS_LOG> ret = new ReturnSimpleResult2<Model.ACCOUNTS_LOG>();
            try
            {
                Model.ACCOUNTS_LOG addObj = new Model.ACCOUNTS_LOG();
                addObj.TOTAL = decimal.Parse(TOTAL);
                addObj.CATEGORY = CATEGORY;
                addObj.OPERATE = "支出";
                addObj.ACCOUNT = int.Parse(ACCOUNT);
                addObj.MEMBER = MEMBER;
                addObj.DEALER = DEALER;
                addObj.ARTICLE = ARTICLE;
                addObj.MEMO = MEMO;
                addObj.TRADETIME = DateTime.Parse(TRADETIME);
                addObj.COMPANYID = int.Parse(COMPANYID);
                addObj.CRDTIME = DateTime.Now;
                addObj.CREON = "administrator";
                addObj.MODTIME = DateTime.Now;
                addObj.MODON = "administrator";
                int count = bllACCOUNTS_LOG.Add(addObj);
                if (count > 0)
                {
                    //变更该账户余额
                    Model.ACCOUNTS curAccount = bllAccounts.GetModel(int.Parse(ACCOUNT));
                    curAccount.BALANCE -= decimal.Parse(TOTAL);
                    if (bllAccounts.Update(curAccount))
                    {
                        ret.Msg = "成功记录一笔支出";
                        ret.ResultCode = "0";
                        ret.t = addObj;
                    }
                }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.t = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 查询账户列表
        /// </summary>
        /// <param name="COMPANYID"></param>
        /// <returns></returns>
        public static string ListAccount(string COMPANYID)
        {
            ReturnPageResult<Model.ACCOUNTS> ret = new ReturnPageResult<Model.ACCOUNTS>();
            try
            {
                List<Model.ACCOUNTS> list = bllAccounts.GetModelList(" COMPANYID=" + COMPANYID + " ");
                ret.Page = new PageObject<Model.ACCOUNTS>();
                ret.Page.Data = list;
                ret.Page.PageCount = 9999;
                ret.Page.PageIndex = 0;
                ret.Page.PageSize = 9999;
                ret.Page.RecordCount = list.Count;

                ret.Msg = "查询成功";
                ret.ResultCode = "0";
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.Page = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 查询消费类别列表
        /// </summary>
        /// <param name="COMPANYID"></param>
        /// <returns></returns>
        public static string ListPayCategory(string COMPANYID)
        {
            ReturnPageResult<Model.PayCategory> ret = new ReturnPageResult<Model.PayCategory>();
            try
            {
                List<Model.PayCategory> list = new List<Model.PayCategory>();//bllAccounts.GetModelList(" COMPANYID=" + COMPANYID + " ");

                using (SqlDataReader dr = DbHelperSQL.ExecuteReader("select distinct(CATEGORY) from dbo.BT_ACCOUNTS_LOG where COMPANYID = " + COMPANYID + ""))
                {
                    while (dr.Read())
                    {
                        Model.PayCategory category = new Model.PayCategory();
                        category.CategoryString = dr[0].ToString();
                        list.Add(category);
                    }
                }
                ret.Page = new PageObject<Model.PayCategory>();
                ret.Page.Data = list;
                ret.Page.PageCount = 9999;
                ret.Page.PageIndex = 0;
                ret.Page.PageSize = 9999;
                ret.Page.RecordCount = list.Count;

                ret.Msg = "查询成功";
                ret.ResultCode = "0";
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.Page = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 查询最新30条的指定账本的交易流水
        /// </summary>
        /// <param name="ACCOUNTOID"></param>
        /// <returns></returns>
        public static string ListTop30AccountLog(string ACCOUNTOID)
        {
            ReturnPageResult<Model.ACCOUNTS_LOG> ret = new ReturnPageResult<Model.ACCOUNTS_LOG>();
            try
            {
                List<Model.ACCOUNTS_LOG> list = new List<Model.ACCOUNTS_LOG>();
                string sql = "select top 30 * from BT_ACCOUNTS_LOG where  ACCOUNT = " + ACCOUNTOID + " order by oid desc";
                DataSet ds = DbHelperSQL.Query(sql);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Model.ACCOUNTS_LOG log = new Model.ACCOUNTS_LOG();
                    log.OID = int.Parse(item["OID"].ToString());
                    log.OPERATE = item["OPERATE"].ToString();
                    log.TOTAL = decimal.Parse(item["TOTAL"].ToString());
                    log.CATEGORY = item["CATEGORY"].ToString();
                    log.ACCOUNT = int.Parse(item["ACCOUNT"].ToString());
                    log.MEMBER = item["MEMBER"].ToString();
                    log.DEALER = item["DEALER"].ToString();
                    log.ARTICLE = item["ARTICLE"].ToString();
                    log.MEMO = item["MEMO"].ToString();
                    log.TRADETIME = DateTime.Parse( item["TRADETIME"].ToString());
                    log.COMPANYID = int.Parse(item["COMPANYID"].ToString());
                    list.Add(log);
                }
                ret.Page = new PageObject<Model.ACCOUNTS_LOG>();
                ret.Page.Data = list;
                ret.Page.PageCount = 9999;
                ret.Page.PageIndex = 0;
                ret.Page.PageSize = 9999;
                ret.Page.RecordCount = list.Count;

                ret.Msg = "查询成功";
                ret.ResultCode = "0";
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.Page = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 根据时间条件查询账户流水记录列表
        /// </summary>
        /// <param name="COMPANYID"></param>
        /// <returns></returns>
        public static string ListAccountLog(string COMPANYID, string beginTime, string endTime, string account)
        {
            ReturnPageResult<Model.ACCOUNTS_LOG> ret = new ReturnPageResult<Model.ACCOUNTS_LOG>();
            try
            {
                List<Model.ACCOUNTS_LOG> list = bllACCOUNTS_LOG.GetModelList(" ACCOUNT=" + account + " and TRADETIME>='" + beginTime + "' and TRADETIME<='" + endTime + "' and COMPANYID=" + COMPANYID + " order by OID desc ");
               
                ret.Page = new PageObject<Model.ACCOUNTS_LOG>();
                ret.Page.Data = list;
                ret.Page.PageCount = 9999;
                ret.Page.PageIndex = 0;
                ret.Page.PageSize = 9999;
                ret.Page.RecordCount = list.Count;

                ret.Msg = "查询成功";
                ret.ResultCode = "0";
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
                ret.Page = null;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 删除指定的交易记录
        /// </summary>
        /// <param name="LogOID"></param>
        /// <returns></returns>
        public static string DeleteAccountLog(string LogOID)
        {
            //删除记录
            //还原余额
            ReturnSimpleResult1 ret = new ReturnSimpleResult1();
            try
            {
                BT.Model.ACCOUNTS_LOG currentLog = bllACCOUNTS_LOG.GetModel(int.Parse(LogOID));
                bool b = bllACCOUNTS_LOG.Delete(int.Parse(LogOID));
                if (b)
                {
                    BT.Model.ACCOUNTS currentAccount = bllAccounts.GetModel(int.Parse(currentLog.ACCOUNT.ToString()));
                    if (currentLog.OPERATE == "收入")
                    {
                        currentAccount.BALANCE -= currentLog.TOTAL;
                    }
                    else//支出
                    {
                        currentAccount.BALANCE += currentLog.TOTAL;
                    }
                    bool bb = bllAccounts.Update(currentAccount);
                    if (bb)
                    {
                        ret.Msg = "删除成功，余额已恢复";
                        ret.ResultCode = "0";
                    }
                    else
                    {
                        ret.Msg = "删除失败，请检查";
                        ret.ResultCode = "-1";
                    }
                }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="userOID"></param>
        /// <param name="oldPass"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public static string ModifyPassword(string userOID, string oldPass, string newPass)
        {
            //删除记录
            //还原余额
            ReturnSimpleResult1 ret = new ReturnSimpleResult1();
            try
            {
                BT.Model.SYSUSER currentUser =  bllSysUser.GetModel(int.Parse(userOID));
                if (currentUser.LOGIN_PWD == oldPass)
                {
                    currentUser.LOGIN_PWD = newPass;
                    if (bllSysUser.Update(currentUser))
                    {
                        ret.Msg = "修改成功";
                        ret.ResultCode = "0";
                    }
                    else
                    {
                        ret.Msg = "修改失败，请联系管理员";
                        ret.ResultCode = "-1";
                    }
                }
                else
                {
                    ret.Msg = "旧密码输入错误";
                    ret.ResultCode = "-1";
                }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

        /// <summary>
        /// 删除某个账本
        /// </summary>
        /// <param name="accountOID"></param>
        /// <returns></returns>
        public static string DeleteAccount(string accountOID)
        {
            ReturnSimpleResult1 ret = new ReturnSimpleResult1();
            try
            {
               BT.Model.ACCOUNTS currentAccount = bllAccounts.GetModel(int.Parse(accountOID));
               if (currentAccount.CNAME == "基本户")
               {
                   ret.Msg = "不能删除基本户";
                   ret.ResultCode = "-1";
               }
               else
               {
                   string sql = "delete from BT_ACCOUNTS_LOG where ACCOUNT = " + accountOID + "    ;delete from BT_ACCOUNTS where OID = " + accountOID + "";
                   int count = DbHelperSQL.ExecuteSql(sql);
                   if (count > 0)
                   {
                       ret.Msg = "删除成功";
                       ret.ResultCode = "0";
                   }
                   else
                   {
                       ret.Msg = "修改失败，请联系管理员";
                       ret.ResultCode = "-1";
                   }
               }
            }
            catch (Exception ex)
            {
                ret.Msg = "异常:" + ex.ToString();
                ret.ResultCode = "-1";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
        }

    }
}
