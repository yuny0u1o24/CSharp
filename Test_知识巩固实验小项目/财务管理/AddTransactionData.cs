using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Test_知识巩固实验小项目.财务管理
{
    public class AddTransactionData
    {
        // 存储用户交易数据的列表
        public List<TransactionData> userDataList = new List<TransactionData>();

        private string id;
        private DateTime date;
        private decimal amount;
        private string description;

        // 添加交易方法
        public void AddTransaction()
        {
            try
            {
                Console.WriteLine("========添加交易========");
                Console.Write("请输入交易ID:");
                id = Console.ReadLine();
                Console.Write("请输入交易日期(格式:yyyy-MM-dd):");
                date = Convert.ToDateTime(Console.ReadLine());
                Console.Write("请输入交易金额:");
                amount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("请输入交易描述:");
                description = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("输入有误，请重新添加交易");
            }
            // 将交易数据添加到列表中
            userDataList.Add(new TransactionData
            {
                Id = id,
                Date = date,
                Amount = amount,
                Description = description
            });

            SaveData("./TransactionData.xml");
        }

        // 将Xml文件存储到本地
        private void SaveData(string path)
        {
            // 创建文本对象
            XmlDocument xml = new XmlDocument();
            if (File.Exists(path))
            {
                // 如果文件存在，加载现有数据
                xml.Load(path);
            }
            else
            {
                // 添加XML固定格式的声明
                XmlDeclaration xmlDec = xml.CreateXmlDeclaration("1.0", "utf-8", "");
                // 将声明添加到XML文档中
                xml.AppendChild(xmlDec);
                // 创建根节点
                XmlElement root = xml.CreateElement("TransactionData");
                // 将根节点添加到XML文件中
                xml.AppendChild(root);
            }

            // 获取根节点
            XmlElement rootNode = xml.DocumentElement;

            // 遍历交易数据列表
            foreach (var data in userDataList)
            {
                XmlElement transactionElem = xml.CreateElement("Transaction");
                // 创建并添加ID节点
                XmlElement idElement = xml.CreateElement("Id");
                // 设置Id节点的值
                idElement.InnerText = data.Id;
                transactionElem.AppendChild(idElement);
                // 创建并添加Date节点
                XmlElement dateElement = xml.CreateElement("Date");
                dateElement.InnerText = data.Date.ToString();
                transactionElem.AppendChild(dateElement);

                // 创建并添加Amount节点
                XmlElement amountElement = xml.CreateElement("Amount");
                amountElement.InnerText = data.Amount.ToString();
                transactionElem.AppendChild(amountElement);

                // 创建并添加Description节点
                XmlElement descriptionElement = xml.CreateElement("Description");
                descriptionElement.InnerText = data.Description;
                transactionElem.AppendChild(descriptionElement);
                // 将交易节点添加到根节点中
                rootNode.AppendChild(transactionElem);
            }
            // 保存XML文件
            xml.Save("./TransactionData.xml");
            
        }
    }
}