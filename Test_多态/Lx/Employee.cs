using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_多态.Lx
{
    public class Employee
    {
        public virtual void Clock()
        {
            Console.WriteLine("员工9点打卡");
        }
    }
    public class Manager : Employee
    {
        public override void Clock()
        {
            Console.WriteLine("经理十一点打卡");
        }
    }

    public class Programmer : Employee
    {
        public override void Clock()
        {
            Console.WriteLine("程序员无需打卡");
        }
    }
}
