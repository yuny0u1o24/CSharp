namespace Test_事件
{

    /* 1.什么是事件
        事件是基于委托的存在
        事件是委托的安全包裹
        让委托的使用具有安全性
        事件是一种特殊的变量类型
    */


    /* 2.事件的声明
        语法：
            访问修饰符 event 委托类型 事件名;
        事件的使用
            1.委托是作为 成员变量存在于类中的
            2.委托怎么用事件就怎么用
        事件相对于委托的作用
            1.不能在外部赋值
            2.不能在外部调用
        注意：
            他只能作为成员存在于类或接口以及结构中
    */

    /* 3.为什么有事件
        1.防止外部随意置空委托
        2.防止外部随意调用委托
        3.事件相当于对委托进行了一次封装 让其更安全
     */
    class Test
    {
        // 委托成员变量 用于存储 函数的
        public Action myFun;
        // 事件成员变量，也是用于存储函数的
        public event Action myEvent;

        public Test()
        {
            // 事件和委托一模一样，只是有些细微的区别
            myFun = TestFun;
            myFun += TestFun;
            myFun -= TestFun;
            myFun.Invoke();

            myEvent = TestFun;
            myEvent += TestFun;
            myEvent -= TestFun;
            myEvent.Invoke();
        }
        public void TestFun()
        {
            Console.WriteLine("13");
        }


        public void DoEvent()
        {
            if (myEvent != null)
                myEvent();
        }
    }

    public class Program
    {
        static void Main01(string[] args)
        {
            Test t = new Test();
            // 委托
            t.myFun = null;
            t.myFun = TestFun;

            // 事件不能在外部调用和赋值，可以加减，这是防止外部随意的置空委托
            //t.myEvent = null; // 1. 不能在外部赋值
            //t.myEvent(); // 2.不能在外部调用
            t.myEvent += TestFun; // 3. 可以加减，这是防止外部随意的置空委托

            // 如果非要调用事件 可以在类的内部封装成一个函数
            t.DoEvent();

            // 事件不能作为临时变量在函数中使用的
            //event Action ae = TestFun;
        }

            
        

        static void TestFun()
        {
        }
    }

    /* 总结
     * 事件和委托的区别
     * 事件和委托的使用基本是一模一样的，可以称事件是特殊的委托
     * 主要区别：
     * 事件和委托的区别在于，事件只能在类的内部调用和赋值，在外部事件只能使用 '+' / '-' 。委托在哪都能使用
     * 事件不能作为函数中的临时变量的，委托可以。
     */
}
