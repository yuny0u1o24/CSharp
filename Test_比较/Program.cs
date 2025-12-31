using System;

namespace Test_比较
{
    class Demo
    {

    }

    public class Program
    {
        public static void Main(string[] args)
        {

            //is运算符进行模式匹配
            object[] data = { 1.6180f, null, new Demo(), "None" };

            foreach (object d in data)
            {
                if(d is float) Console.WriteLine(d);
                else if(d is null) Console.WriteLine("空");
                else if(d is Demo) Console.WriteLine(d.ToString());
                else Console.WriteLine(d);
            }
        }
    }
}