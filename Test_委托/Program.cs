namespace Test_委托
{
    /**
        委托是什么
            委托是函数的容器
            可以理解为表示函数的变量类型，也就是用于存储函数的变量类型
            主要用于：存储、传递函数
            委托本质上是一个类，用来定义函数的返回值类型
            不同的函数必须对应和各自“格式”一致的委托

        基本语法
            关键字：delegate
            语法：访问控制修饰符 delegate 返回值 委托名(参数列表)
            可以声明在namespace和class语句中
            更多的是写在namespace中
    */

    //定义自定义委托
    //        访问修饰符不写，默认是public再别的命名空间中也能使用
    //        private其他命名空间不能使用
    //        一般使用public
    // 声明了一个无参无返回值函数的容器
    // 下面这个委托只是定义了一个委托，并没有使用它
    public delegate void MyFun();

    // 委托不能重名，也不能重载
    // 表示用来装载或者传递 返回值为int 有一个int参数的函数 的委托 
    public delegate int MyInt(int a);


    //委托常用在
    // 1.作为类的成员函数
    // 2.作为函数的参数
    class Test
    {
        public MyFun fun;
        public MyInt fInt;

        public void TestFun(MyFun a, MyInt b)
        {
            //先处理一些别的逻辑 当这些逻辑处理完了，在执行传入的函数
            int i = 1;
            i *= 2;
            i += 2;

            //a();
            //b(i);
            this.fun = a;
            this.fInt = b;
        }
    }





    //使用定义好的容器
    public class Program
    {
        static void Main(string[] args)
        {
            MyFun myFun = new MyFun(Fun);
            MyFun f = Fun;// 与上面等价

            // 调用   
            //myFun.Invoke(); // 使用委托提供的方法Invoke()调用
            //myFun();// 像函数一样调用


            Console.WriteLine("------------------------");
            // 清除委托
            //f -= Fun;
            // f = null; // 将委托清空

            // 委托变量可以存储多个函数（多播委托）
            //f += Fun2;
            //f();

            //// 清除委托
            //f -= Fun;

            // C#提供的委托
            Action a = Fun; // C#提供的无参无返回值的委托类型
            //a += Fun2;
            // Func 无参有返回值的委托
            //Func<int> funcInt = Fun2; 

            // 有参无返回值委托 Action 可以传n个参数的委托
            Action<int, int> ac = Fun2;


        }

        static void Fun()
        {
            Console.WriteLine("调用了Fun");
        }
        static void Fun2(int a, int b)
        {
            Console.WriteLine("fun2");
            //return 1;
        }
    }
}
