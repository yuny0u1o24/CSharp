using Test_多态.Lx;

namespace Test_多态
{

    #region 1. 多态的概念
    // 多态按字面意思就是“多中形态”
    // 让继承同一父类的子类们 在执行相同方法时有不同的表现(状态)
    // 主要目的
    // 同一父类的对象 执行相同行为(方法) 有不同的表现
    // 解决的问题
    // 让同一对象有唯一行为的特征
    #endregion

    #region 2.解决的问题

    class Father
    {
        public void SpeakName()
        {
            Console.WriteLine("Father的方法");
        }
    }

    class Son : Father
    {
        public void SpeakName()
        {
            Console.WriteLine("Son的方法");
        }
    }

    #endregion

    #region 3.多态的实现
    // 我们目前已经学过的多态
    // 编译时多态——函数重载，开始就是写好的
    // 运行时 多态(virtual、override、base，抽象函数、接口)
    class GameObject
    {
        public string name;
        public GameObject(string name)
        {
            this.name = name;
        }

        // 虚函数
        public virtual void Atk()
        {
            Console.WriteLine("游戏对象进行攻击");
        }
    }

    class Player : GameObject 
    {
        public Player(string name):base(name)
        {

        }

        // 重写虚函数
        public override void Atk()
        {
            
            base.Atk(); // 保留父类的行为
            Console.WriteLine("玩家攻击"); // 子类的行为
        }
    }
    #endregion
    public class Program
    {
        static void Main(string[] args)
        {
            #region 需要解决的问题
            Father f = new Son();
            f.SpeakName();
            (f as Son).SpeakName(); // 这里有点破坏多态的
            #endregion

            #region 多态的使用
            GameObject go = new Player("");
            go.Atk();
            #endregion

            #region 练习题
            Duck duck = new Duck();
            Duck woodenDuck = new WoodenDuck();
            Duck rubberDuck = new RubberDuck();

            duck.Yell();
            woodenDuck.Yell();
            rubberDuck.Yell();

            Employee employee = new Employee();
            Employee manager = new Manager();
            Employee programmer = new Programmer();

            employee.Clock();
            manager.Clock();
            programmer.Clock();


            #endregion
        }
    }

    // 总结
    // 多态： 让同一类型的对象，执行相同行为时有不同的表现
    // 解决的对象: 让同一类型的对象有唯一的行为特征
}
