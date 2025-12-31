namespace Test_匿名委托
{
    // (注: @!!!表示知识点 非常重要)

    //顾名思义 就是没有名字的函数
    // 匿名函数的使用主要是配合委托和事件进行使用

    // @!!! 脱离委托和事件，是不会使用匿名函数的 !!!@

    // 基本语法
    // delegate(参数列表){ 函数逻辑 };
    // 什么时候使用：
    // 1.函数中传递委托参数时
    // 2.委托或事件赋值时
    // 缺点：
    // 匿名函数无法通过 -= 的方式从委托中移除


    // 使用
    class Test
    {
        
        
        public void Fun(Action a)
        {
            a();
        }
    }

    public class Program
    {
        static void Main01(string[] args)
        {
            // 1.无参无返回值的匿名函数    使用自带的委托 Action

            // 这样声明匿名函数 仅仅只是声明函数而已，还没有调用
            // 真正调用它的时候 这个委托容器啥时候调用就什么时候调用这个匿名函数
            Action ac = delegate ()
            {
                Console.WriteLine("你好啊");
            };

            // 2.有参匿名函数
            Action<int,string> b = delegate (int a, string b)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
            };
            b(100, "1123");

            // 3.有返回值的匿名函数 使用自带的委托Func
            Func<int, float, string> a = delegate (int a, float b)
            {
                return "1234123";
            };


            // 4.作为函数参数传递 或者 作为函数返回值
            Test test = new Test();
            test.Fun(delegate ()
            {
                Console.WriteLine("Fun的传进去的匿名委托");
            });


            // 匿名函数的缺点:
            //      添加到委托或事件中后 不记录 无法单独移除
            //      因为匿名函数没有名字 所以 没有办法指定移除某一个 匿名函数
            Action c = delegate ()
            {
                Console.WriteLine("1");
            };
            c += delegate ()
            {
                Console.WriteLine("2");
            };
            
        }
    }

    /* 总结
     *      匿名函数 就是没有名字的函数
     *      固定写法
     *      delegate(参数列表){
     *      
     *      }
     *      主要是在 委托传递和存储时 为了方便可以直接使用匿名函数
     *      缺点是 没有办法指定移除
     */
}
