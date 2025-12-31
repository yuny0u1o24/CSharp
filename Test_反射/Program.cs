using System.Reflection;

namespace Test_反射
{
    #region 1.什么是程序集
    // 程序集是经由编译器编译得到的，供进一步编译执行的那个中间产物
    // 在Windows系统中，它一般表现为后缀为.dll(库文件) 或者是.exe(可执行文件)的格式

    // 说人话:
    // 程序集就是我们写的一个代码集合，我们现在写的所有代码
    // 最终都会被编译器翻译为一个程序集供别人使用
    // 比如一个代码库文件(dll)或者一个可执行文件(exe)
    #endregion

    #region 2.元数据
    // 元数据就是用来描述数据的数据
    // 这个概念不仅仅用于程序上，在别的领域也有元数据

    // 说人话:
    // 程序中的类，类中的函数、变量等等信息就是程序的元数据
    // 有关程序以及类型的数据被称为 元数据，它们保存在程序集中
    #endregion

    #region 3.反射的概念
    // 程序正在运行时，可以查看其他程序集或者自身的元数据。
    // 一个运行的程序查看本身或者其他程序的元数据的行为叫做反射

    // 说人话:
    // 在程序运行时，通过反射可以得到其他程序集或者自己程序集代码的各种信息
    // 类、函数、变量、对象等等，实例化它们，执行他们，操作他们
    #endregion

    #region 4.反射的作用 
    // 因为反射可以再程序编译后获得信息，所以它提高了程序的扩展性和灵活性
    // 1.程序运行时得到所有元数据，包括元数据的特性
    // 2.程序运行时，实例化对象，操作对象
    // 3.程序运行时创建新对象，用这个对象执行任务
    #endregion

    class Test
    {
        private int i = 1;
        public int j = 0;
        public string str = "123";

        public Test()
        {

        }

        public Test(int i)
        {
            this.i = i;
        }

        public Test(int i, string str) : this(i)
        {
            this.str = str;
        }

        public void Speak()
        {
            Console.WriteLine(i);
        }
    }

    public class Program
    {
        public static void Main01(string[] args)
        {
            #region 5.语法相关

            #region Type
            // Type (类的信息)
            // 它是反射功能的基础
            // 它是访问元数据的主要方式
            // 使用Type的成员获取有关类型声明的信息
            // 有关类型的成员(如构造函数、方法、字段、属性和类的事件)

            #region 获取Type
            // 1.万物之父object中的 GetType()可以获取对象的Type
            int a = 42;
            Type type = a.GetType();
            Console.WriteLine(type);
            // 2.通过typeof关键字 传入类名 也可以得到对象的Type
            Type type2 = typeof(int);
            Console.WriteLine(type2);
            // 3.通过类的名字 也可以获取类型
            // 注意 类名必须包含命名空间不然找不到
            Type type3 = Type.GetType("System.Int32");
            Console.WriteLine(type3);
            #endregion

            #region 得到类的程序集信息
            // 可以通过Type得到类型所在的程序集信息
            Console.WriteLine(type.Assembly);
            Console.WriteLine("******************************");
            #endregion

            #region 获取类中的所有公共成员
            // 首先得到Type
            Type t = typeof(Test);
            // 然后得到所有公共成员
            // 需要引用命名空间 using System.Reflection;
            MemberInfo[] infos = t.GetMembers();
            for(int i = 0; i < infos.Length; i++)
            {
                Console.WriteLine(infos[i]);
            }
            #endregion

            #region 获取类的公共构造函数并调用
            // 1.获取所有构造函数
            ConstructorInfo[] ctors = t.GetConstructors();
            foreach (ConstructorInfo ctor in ctors)
            {
                Console.WriteLine(ctor);
            }
            // 2.获取其中一个构造函数 并执行
            // 得构造函数传入 Type数组 数组中内容按顺序是参数类型
            // 执行构造函数传入 object数组 表示按顺序传入的参数
            // 2-1得到无参构造
            ConstructorInfo info = t.GetConstructor(new Type[0]);
            // 执行无参构造 没有参数传null即可
            Test obj = info.Invoke(null) as Test;
            Console.WriteLine(obj.j);

            // 2-2得到有参构造
            ConstructorInfo info2 = t.GetConstructor(new Type[] { typeof(int)});
            obj = info2.Invoke(new object[] { 2 }) as Test;
            Console.WriteLine(obj.str);

            ConstructorInfo info3 = t.GetConstructor(new Type[] {typeof(int), typeof(string)});
            obj = info3.Invoke(new object[] { 3, "123"}) as Test;
            Console.WriteLine(obj.str);

            #endregion

            #region 获取类的公共成员变量
            // 1.得到所有成员变量
            FieldInfo[] fieldInfos = t.GetFields();
            foreach(FieldInfo f in fieldInfos)
            {
                Console.WriteLine(f);
            }
            // 2.得到指定名称的公共成员变量
            FieldInfo infoJ = t.GetField("j");
            Console.WriteLine(infoJ);

            // 3.通过反射获取和设置对象的值
            Test test = new Test();
            test.j = 99;
            test.str = "2222";
            // 3-1 通过反射 获取对象的某个变量的值
            Console.WriteLine(infoJ.GetValue(test));
            // 3-2 通过反射 设置指定对象某个变量的值
            infoJ.SetValue(test, 100);
            Console.WriteLine(infoJ.GetValue(test));
            #endregion

            #region 获取类的公共成员方法
            // 通过Type类中的GetMethod方法 得到类中的方法
            // MethodInfo 是方法的反射信息
            Type strType = typeof(string);
            // 1.如果存在方法重载 用Type数组表示参数类型
            MethodInfo[] methods = strType.GetMethods();
            foreach(MethodInfo m in methods)
            {
                Console.WriteLine(m);
            }

            MethodInfo subStr = strType.GetMethod("Substring", new Type[] { typeof(int), typeof(int)});
            // 2.调用该方法
            // 注意: 如果静态方法 Invoke中额度第一个参数传null即可
            string str = "Hello,World!";
            // 第一个参数相当于是哪个对象要执行该成员方法
            object result = subStr.Invoke(str, new object[] {1,5});
            Console.WriteLine(result);
            #endregion

            #region 其他
            // Type 获得枚举
            // GetEnumName
            // GetEnumNames

            // 得事件
            // GetEvent
            // GetEvents

            // 得接口
            // GetInterface
            // GetInterfaces

            // 锝属性
            // GetProperty
            // GetPropertys
            // 等等

            #endregion

            #endregion

            #region Assembly
            // 程序集类
            // 主要用来加载其他程序集，加载后
            // 才能用Type来使用其他程序中的信息
            // 如果想要使用不是自己程序集中额度内容 需要先加载程序集
            // 比如 dll文件(库文件)
            // 简单的把库文件看成一种代码仓库，他提供给使用着一些可以直接拿来用的变量、函数或类

            // 三种加载程序集的函数
            // 一般用来加载在同一文件下的其他程序集
            // Assembly asembly2 = Assembly.Load("程序集名称");

            // 一般用来加载不同一文件下的其它程序集 
            // Assembly asembly =  Assembly.LoadFrom("包含程序集清单的文件名称或路径");
            // Assembly asembly3  = Assembly.LoadFile("包含程序集清单的文件名称或路径");

            // 1.先加载一个指定程序集
            Assembly asembly = Assembly.LoadFrom("D:\\Node\\CSharp\\知识点\\Test_多线程\\bin\\Debug\\net8.0\\Test_多线程.dll"); // 仅仅测试，这是当前项目的程序集
            Type[] types = asembly.GetTypes();
            for(int i =0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }
            // 2.再加载程序集中的一个类对象 之后才能使用反射
            Type icon = asembly.GetType("Test_多线程.Program");
            MemberInfo[] member = icon.GetMembers();
            foreach (MemberInfo me in member)
            {
                Console.WriteLine(me);
            }
            // 通过反射 实例化一个 icon对象
            // 首先得到枚举Type 来得到可以传入的参数



            // 3.类库工程创建
            #endregion

            #region Activator
            // 用于快速实例化对象的类
            // 用于将Type对象快捷实例化为对象
            // 先得到Type
            // 然后快速实例化一个对象
            Type testType = typeof(Test);
            // 1.无参构造
            Test testObj = Activator.CreateInstance(testType) as Test;
            Console.WriteLine(testObj.j);
            // 2.有参构造
            testObj = Activator.CreateInstance(testType, 99) as Test;
            //Console.WriteLine(testObj.i);
            testObj = Activator.CreateInstance(testType, 99, "999") as Test;
            Console.WriteLine(testObj.str);
            #endregion

            #endregion
        }
    }
}
