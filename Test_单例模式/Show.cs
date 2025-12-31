using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_单例模式
{
    public abstract class Show:Web
    {
        public virtual void ShowMe()
        {
            Console.WriteLine($"名字:undefined,网址:undefined");
        }
    }
}
