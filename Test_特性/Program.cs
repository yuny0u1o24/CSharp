namespace Test_特性
{
    /*
        特性是一种允许我们向程序的程序集添加元数据的语言结构
        它是用于保存程序结构信息的某种特殊类型的类
        
        特性提供强大的方法以将声明信息与C#代码（类型、方法、属性等）相关联。
        特性与程序实体关联后，即可在运行时使用反射查询特性信息

        特性的目的是告诉编译器把程序结构的某组元数据嵌入程序集中
        它可以放置在几乎所有的声明中（类、变量、函数等等声明）
        

        简单的说，特性本质上就是一个类，我们可以利用特性类为元数据添加额外信息
        比如一个类、成员变量、成员方法等等为他们添加更多的额外信息
        之后可以通过返回来获取这些额外信息
    */

    // 自定义特性
    // 继承特性的基类 Attribute
    class TestAttribute : Attribute // 命名时必须要有Attribute，调用的时候Attribute可以省略
    {
        //特性中的成员变量，一般根据需求来写
        public string info;

        public TestAttribute(string info)
        {
            // 特性中的成员
            this.info = info;
        }

        public void TestFun()
        {
            Console.WriteLine("特性的方法");
        }
    }

    /** 限制自定义特性的使用范围 
     * 通过特性类 加特性 限制其使用范围,下面这个特性是限制自定义特性用在哪里，
     * [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
     * 
     * 参数一：AttributeTargets —— 特性能够用在哪些地方
     * 参数二：AllowMultiple —— 是否允许多个特性实例用在同一个目标上
     * 参数三：Inherited —— 特性是否能被派生类和重写成员继承
     */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    public class Test02Attribute : Attribute
    {

    }

    /* 特性的使用
        语法：[特姓名(参数列表)]
        本质上，就是调用类的构造函数
        主要写在类、函数、变量的上方
            命名时
    */
    [Test("我是MyClass的特性")]
    class MyClass
    {
        [Test("这是一个成员变量")]
        public int value;

        [Test("用于打印输出的方法")]
        public void TestFun([Test("这是一个函数参数")]int a)
        {


        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            // 特性的使用
            MyClass mc = new MyClass();
            Type t = mc.GetType(); // 获取mc的类型
            //t = typeof(MyClass);
            //t = Type.GetType("Test_特性.MyClass");


            // IsDefined()是用于 判断是否使用了特性
            // 参数
            //      1.特性的类型
            //      2.是否搜索继承链（属性和事件自动忽略此参数）
            if (t.IsDefined(typeof(TestAttribute), false))
            {
                Console.WriteLine("应用了Test特性");
            }

            // 获取Type元数据中的所有特性
            // GetCustomAttributes()获取所有的自定义特性
            object[] objs = t.GetCustomAttributes(true);
            foreach (object o in objs)
            {
                Console.WriteLine(o.ToString());
            }

            for(int i = 0; i < objs.Length; i++)
            {
                if (objs[i] is TestAttribute)
                {
                    Console.WriteLine((objs[i] as TestAttribute).info);
                    (objs[i] as TestAttribute).TestFun();
                }
            }
        }
    }
}
