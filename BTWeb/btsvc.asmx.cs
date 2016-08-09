using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BT.Service;

namespace BTWeb
{
    //
    /// <summary>
    /// btsvc 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.nnbetter.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class btsvc : System.Web.Services.WebService
    {
        [WebMethod(Description = "开通新账本")]
        public void AddNewAccount(string companyName, string uName, string loginName, string uPass)
        { 
            HttpContext.Current.Response.Write(BaseService.AddNewAccount(companyName,uName,loginName,uPass));
        }

        [WebMethod(Description = "添加登录账户")]
        public void CreateLoginUser(string CNAME, string LOGIN_NAME, string MEMO, string COMPANYID)
        {
            HttpContext.Current.Response.Write(BaseService.AddLoginUser(CNAME,LOGIN_NAME,MEMO,COMPANYID));
        }

         [WebMethod(Description = "删除登录账户")]
        public void DeleteLoginUser(string LoginUserOID)
        {
            HttpContext.Current.Response.Write(BaseService.DeleteLoginUser(LoginUserOID));
        }

          [WebMethod(Description = "查询登录用户列表")]
         public void ToListLoginUser(string COMPANYID)
         {
             HttpContext.Current.Response.Write(BaseService.ToListLoginUser(COMPANYID));
         }

         [WebMethod(Description = "用户登录")]
          public void Login(string LoginName, string PWD)
          {
              HttpContext.Current.Response.Write(BaseService.Login(LoginName,PWD));
          }

         [WebMethod(Description = "添加公司账户")]
         public void AddAccount(string CNAME, string BALANCE, string COMPANYID)
         {
             HttpContext.Current.Response.Write(BaseService.AddAccount(CNAME,BALANCE,COMPANYID));
         }

         [WebMethod(Description = "编辑账户")]
         public void EditAccount(string OID, string NewName, string NewBALANCE)
         {
             HttpContext.Current.Response.Write(BaseService.EditAccount(OID, NewName, NewBALANCE));
         }

         [WebMethod(Description = "记录一笔收入")]
         public void AddInACCOUNTS_LOG(string TOTAL, string CATEGORY, string ACCOUNT, string MEMBER,
            string DEALER, string ARTICLE, string MEMO, string TRADETIME, string COMPANYID)
         {
             HttpContext.Current.Response.Charset = "utf-8";
             HttpContext.Current.Response.Write(BaseService.AddInACCOUNTS_LOG(TOTAL,CATEGORY,ACCOUNT,MEMBER,DEALER,ARTICLE,MEMO,TRADETIME,COMPANYID));
         }

         [WebMethod(Description = "记录一笔支出")]
         public void AddOutACCOUNTS_LOG(string TOTAL, string CATEGORY, string ACCOUNT, string MEMBER,
            string DEALER, string ARTICLE, string MEMO, string TRADETIME, string COMPANYID)
         {
             HttpContext.Current.Response.Write(BaseService.AddOutACCOUNTS_LOG(TOTAL, CATEGORY, ACCOUNT, MEMBER, DEALER, ARTICLE, MEMO, TRADETIME, COMPANYID));
         }

        [WebMethod(Description = "查询公司账户列表")]
         public void ListAccount(string COMPANYID)
         {
             HttpContext.Current.Response.Write(BaseService.ListAccount(COMPANYID));
         }


        [WebMethod(Description = "查询公司消费类别")]
        public void ListPayCategory(string COMPANYID)
        {
            HttpContext.Current.Response.Write(BaseService.ListPayCategory(COMPANYID));
        }

        [WebMethod(Description = "查询公司指定账户的特定时间的流水明细")]
        public void ListAccountLog(string COMPANYID, string beginTime, string endTime, string account)
        {
            HttpContext.Current.Response.Write(BaseService.ListAccountLog(COMPANYID,beginTime,endTime,account));
        }

        [WebMethod(Description = "查询指定账本的最近30条的消费记录")]
        public void ListTop30AccountLog(string ACCOUNTOID)
        {
            HttpContext.Current.Response.Write(BaseService.ListTop30AccountLog(ACCOUNTOID));
        }

          [WebMethod(Description = "删除指定的交易记录")]
          public void DeleteAccountLog(string LogOID)
          {
              HttpContext.Current.Response.Write(BaseService.DeleteAccountLog(LogOID));
          }

          [WebMethod(Description = "修改密码")]
          public void ModifyPassword(string userOID, string oldPass, string newPass)
          {
              HttpContext.Current.Response.Write(BaseService.ModifyPassword(userOID,oldPass,newPass));
          }

          [WebMethod(Description = "删除某个账本")]
          public void DeleteAccount(string accountOID)
          {
              HttpContext.Current.Response.Write(BaseService.DeleteAccount(accountOID));
          }


          [WebMethod(Description = "获取一期报表")]
          public void GetReport1(string COMPANYID, string BeginDate, string EndDate, string AccountIdList)
          {
              HttpContext.Current.Response.Write(ReportService.GetReport1( COMPANYID,  BeginDate,  EndDate,  AccountIdList));
          }
    }
}
