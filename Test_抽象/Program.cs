namespace Test_抽象
{
    #region 1.抽象类
    // 概念
    // 被抽象关键字abstract修饰的类
    // 特点：
    //  1.不能被实例化的类
    //  2.可以包含抽象方法
    //  3.继承抽象类必须重写其抽象方法

    abstract class Thing
    {
        // 抽象类中 封装的所有内容都可以在其中定义
        public string name;
        
        // 可以在抽象类中写抽象函数
    }

    class Water : Thing
    {

    }
    #endregion

    #region 2.抽象函数
    // 又叫 纯虚函数
    // 用abstract关键字修饰的方法
    // 特点
    //  1.只能在抽象类中声明
    //  2.没有方法体
    //  3.不能是私有的
    //  4.继承后必须实现 用override重写

    abstract class Fruits
    {
        public string name;
        // 抽象方法不能有函数体
        public abstract void Bad();
    }

    class Apple : Fruits
    {
        public override void Bad()
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    public class Program
    {
        static void Main(string[] args)
        {
            // 抽象类不能被实例化
            //Thing t = new Thing();
            // 可以父类装子类
            Thing t = new Water();
        }
    }
}
