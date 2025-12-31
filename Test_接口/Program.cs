namespace Test_接口
{
    #region 1.接口的概念
    // 接口是行为的抽象概念
    // 他也是一种自定义类型
    // 关键字：interface


    // 接口声明的规范
    // 1.不包含成员变量
    // 2.只包含方法、属性、索引器、事件
    // 3.成员不能被实现
    // 4.成员可以不用写访问修饰符，不能是私有的
    // 5.接口不能继承类，但是可以继承另一个接口

    // 接口的使用规范
    // 1.类可以继承多个接口
    // 2.类继承接口后，必须实现接口中所有成员

    // 特点：
    // 1.它和类的声明类似
    // 2.接口是用来继承的
    // 3.接口不能用来实例化，但是可以用来作为容器存储对象
    #endregion

    #region 2.接口的声明
    // 接口关键字：interface
    // 语法:
    // interface I接口名
    // {
    // }
    // 一句话记忆：接口是抽象行为的“基类”
    // 接口命名规范 帕斯卡命名法 前面加上一个I
    interface IFly
    {
        public void Fly();

        public string name
        {
            get;
            set;
        }

        public event Action doSometing;
        public int this[int index]
        {
            get;
            set;
        }
    }
    #endregion

    #region 3.接口的使用
    // 接口是用来继承的
    class Animal
    {

    }
    // 1.一个类可以继承1个类，多个接口
    // 2.继承了接口后，必须实现其中的内容，并且必须时public的
    public class Person : Animal, IFly
    {
        public int this[int index] 
        { 
            get => throw new NotImplementedException(); set => throw new NotImplementedException(); 
        }

        public string name 
        { 
            get => throw new NotImplementedException(); set => throw new NotImplementedException(); 
        }

        public event Action doSometing;

        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
