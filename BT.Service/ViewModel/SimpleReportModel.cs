using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT.Service.ViewModel
{
    /// <summary>
    /// 分类支出/收入汇总模型
    /// </summary>
    public class CategorySum
    {
        public string CategoryName { get; set; }
        public string SumTotal { get; set; }
    }

    /// <summary>
    /// 一期报表模型
    /// </summary>
    public class SimpleReportModel
    {
        /// <summary>
        /// 支出总额
        /// </summary>
        public string OutTotal { get; set; }
        /// <summary>
        /// 收入总额
        /// </summary>
        public string InTotal { get; set; }

        /// <summary>
        /// 支出笔数
        /// </summary>
        public string OutCount { get; set; }

        /// <summary>
        /// 收入笔数
        /// </summary>
        public string InCount { get; set; }

        /// <summary>
        /// 支出分类汇总
        /// </summary>
        public List<CategorySum> OutCategorySum { get; set; }

        /// <summary>
        /// 收入分类汇总
        /// </summary>
        public List<CategorySum> InCategorySum { get; set; }
    }
}
