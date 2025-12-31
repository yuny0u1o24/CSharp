using System;

namespace Test_成员属性
{
    #region 知识点一
    // 基本概念
    // 1.用于保护成员变量
    // 2.为成员属性的获取和赋值添加逻辑处理
    // 3.解决3P的局限性
    // public - 内外访问
    // private - 内部访问
    // protected - 内部和子类访问
    // 属性可以让成员变量在外部 只能获取不能修改 或者 只能修改 不能获取
    #endregion

    #region 知识点二 成员属性的基本语法
    // 访问修饰符 属性类型 属性名
    // {
    //      get { }
    //      set { }
    // }
    class Person
    {
        private string name;
        private int age;
        private int money;
        private bool sex;

        // 属性的命名一般使用 帕斯卡命名
        public string Name
        {
            get 
            {
                // 可以在返回之前添加一些逻辑规则
                // 意味着 这个属性可以获取内容 
                return name; 
            }

            set 
            {
                // 可以设置之前添加一些逻辑规则
                // value 关键字 用于表示外部传入的内容，改关键字只在set语句块中有用
                name = value;
            }
        }
    }
    #endregion

    public class Program
    {
        public static void Main(string[] args)
        {
            #region 知识点三 成员属性的使用
            Person p = new Person();
            p.Name = "yunyou1024";
            Console.WriteLine(p.Name);
            #endregion
        }
    }

    
}