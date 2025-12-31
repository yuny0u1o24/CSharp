using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Test_知识巩固实验小项目.财务管理
{
    public class ShowAllTransaction
    {
        public List<TransactionData> userDataList = new List<TransactionData>();

        // 查看所有交易
        public void ShowData(string path)
        {
            if (!File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("您还没有添加条目哟~");
            }

            try
            {
                // 清空现有列表
                userDataList.Clear();
                // 加载Xml文件
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);

                // 获取所有交易节点
                XmlNodeList transactionNode = xmlDoc.SelectNodes("/TransactionData/Transaction");
                if(transactionNode == null || transactionNode.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("您还没有添加条目哟~");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("========交易条目========");
                    Console.WriteLine("{0,-15} {1,-15} {2,-15} {3}", "交易ID", "日期", "金额", "描述");
                    Console.WriteLine(new string('-', 70));

                    // 遍历每个交易节点并显示数据
                    foreach(XmlNode node in transactionNode)
                    {
                        string id = node.SelectSingleNode("Id").InnerText;
                        string dateStr = node.SelectSingleNode("Date").InnerText.ToString();
                        string amountStr = node.SelectSingleNode("Amount").InnerText;
                        string description = node.SelectSingleNode("Description").InnerText;
                        // 解析数据
                        DateTime date = DateTime.Parse(dateStr);
                        decimal amount = decimal.Parse(amountStr);

                        // 添加到列表
                        userDataList.Add(new TransactionData
                        {
                            Id = id,
                            Date = date,
                            Amount = amount,
                            Description = description
                        });

                        // 显示交易信息（格式化日期和金额）
                        string formattedDate = date.ToString("yyyy-MM-dd");
                        string formattedAmount = amount.ToString("C"); // 货币格式

                        Console.ForegroundColor = amount >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3}",
                            id, formattedDate, formattedAmount, description);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n共 {userDataList.Count} 条交易记录。");
                }
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"读取数据时发生错误: {e.Message}");  
            }
        }

        public ShowAllTransaction()
        {
            ShowData("./TransactionData.xml");
        }
    }
}
