using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Test_单例模式
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class Yunyou :Show
    {
        private string name;
        private string url;
        public Yunyou(string name, string url)
        {
            this.name = name;
            this.url = url;
        }
        public override void ShowMe()
        {
            Console.WriteLine($"名字:{name},网址:{url}");
        }
    }
}
