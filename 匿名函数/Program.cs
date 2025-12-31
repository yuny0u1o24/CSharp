namespace 匿名函数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点1 什么是匿名函数
            // 顾名思义，就是没有名字的函数
            // 匿名函数的使用主要是配合委托和事件进行使用的
            // 脱离委托和事件，是不会使用匿名函数的
            #endregion

            #region 知识点2 基本语法
            // delegate(参数列表)
            // {
            //      // 函数逻辑
            // }
            // 什么时候使用
            // 1.函数中传递委托参数时
            // 2.委托或事件赋值时
            #endregion

            #region 知识点3 使用
            // 1.无参无返回值
            // 这样声明的匿名函数，只是声明函数而已，并没有调用
            // 真正调用的时候，是这个委托容器啥时候调用，就什么时候调用这个匿名函数
            Action a = delegate ()
            {
                Console.WriteLine("匿名函数逻辑");
            };
            a();

            // 有参
            Action<int, string> b = delegate (int a, string b)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
            };
            b(12,"123");

            // 有返回值
            Func<string> c = delegate ()
            {
                return "123";
            };
            // 4. 一般情况会作为函数参数传递，或者作为函数返回值

            // 参数传递
            Test t = new Test();
            t.DoSomething(100, delegate ()
            {
                Console.WriteLine("随参数传入的匿名函数");
            });
            #endregion
        }
    }

    class Test
    {
        public Action action;

        public void DoSomething(int a, Action fun)
        {
            Console.WriteLine(a);
            fun();
        }

        // 作为返回值
        public Action GetFun()
        {
            return null;
        }


    }
}
