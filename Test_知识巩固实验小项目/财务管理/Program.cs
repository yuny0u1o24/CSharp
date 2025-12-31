using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_知识巩固实验小项目.财务管理
{
    public class Program
    {
        public static void Main01(string[] args)
        {
            int choose = 0;

            while(true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n=== 个人财务管理系统 ===");
                Console.WriteLine("1. 添加交易");
                Console.WriteLine("2. 查看所有交易");
                Console.WriteLine("3. 查看余额");
                Console.WriteLine("4. 退出");
                Console.Write("请选择操作: ");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            AddTransactionData addTransaction = new AddTransactionData();
                            addTransaction.AddTransaction();
                            break;
                        case 2:
                            Console.Clear();
                            ShowAllTransaction show = new ShowAllTransaction();
                            break;
                        case 3:
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("无效输入请重新输入");
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("无效输入请重新输入");
                    continue;
                }
            }
        }
    }
}
