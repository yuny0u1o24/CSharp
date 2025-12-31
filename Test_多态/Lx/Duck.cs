using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Test_多态.Lx
{
    public class Duck
    {
        public virtual void Yell()
        {
            Console.WriteLine("嘎嘎叫");
        }
    }

    public class WoodenDuck : Duck
    {
        public override void Yell()
        {
            Console.WriteLine("吱吱叫");
        }
    }

    public class RubberDuck:Duck
    {
        public override void Yell()
        {
            Console.WriteLine("唧唧叫");
        }
    }
}
