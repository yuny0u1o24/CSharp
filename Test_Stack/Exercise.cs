using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Stack
{
    public class Exercise
    {
        public static void Main()
        {
            Console.WriteLine("输入任意一个整数");
            int num = Convert.ToInt32(Console.ReadLine());
            ConverToBinary(num);
        }

        public static void ConverToBinary(int number)
        {
            Stack stack = new Stack();
            int num = number;
            if (num == 0)
            {
                stack.Push(num);
            }
            else
            {
                num = Math.Abs(num);
                while (num > 0)
                {
                    int rem = num % 2;
                    stack.Push(rem);
                    num = num / 2;
                }
            }
            Console.WriteLine($"{number}的二进制数是: ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
