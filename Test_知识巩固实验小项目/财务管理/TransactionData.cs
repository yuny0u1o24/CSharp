using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test_知识巩固实验小项目.财务管理
{
    public class TransactionData
    {
        // 交易ID
        public string Id { get; set; }
        // 交易日期
        public DateTime Date {get;set; }
        // 交易金额
        public decimal Amount { get; set; }
        // 交易描述
        public string Description { get; set; }
    }
}
