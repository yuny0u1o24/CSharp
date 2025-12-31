namespace Test_拓展方法
{

    /*
        概念
            为现有的非静态类 变量类型 添加 新的方法
        作用
            1.提升程序扩展性
            2.不需要再对像中重写写方法
            3.不需要继承来添加方法
            4.为别人封装的类型写额外的方法
        特点：
            1.一定是写在静态类中
            2.一定是个静态函数
            3.第一个参数为拓展目标
            4.第一个参数必须要用this修饰，来表明它是一个拓展方法
    */

    // 基本语法：
    // 访问修饰符 statuc 返回值类型 函数名(this 要拓展的类名 参数名, 参数类型 参数名... )

    public class Test
    {

    }

    public static class Tool
    {
        public static int Add(this Test t, int a, int b)
        {
            return a + b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            int  i  = test.Add(1,2);
            Console.WriteLine(i);
        }
    }
}
