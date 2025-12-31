namespace Test_协变逆变
{
    #region 1.什么是协变逆变
    // 协变
    // 和谐的变化，自然地变化
    // 所以 子类变父类
    // 比如 string 变成 object
    // 感受是和谐的

    // 逆变
    // 逆常规的变化，不正常的变化
    // 因为 里氏替换原则 父类可以装子类，但是子类不能装父类
    // 比如 object 变成 string
    // 感受是不和谐的

    // 协变和逆变是用来修饰泛型的
    // 协变:out
    // 逆变:in
    // 用于在泛型中 修饰泛型字母的
    // 只有泛型接口和泛型委托才能使用
    #endregion

    #region 2.作用
    // 1.返回值和参数
    // 用out修饰的泛型 只能作为返回值
    //delegate T TestOut<out T>(T v);
    delegate T TestOut<out T>();

    // 用in修饰的泛型 只能作为参数
    delegate void TestIn<in T>(T v);
    //delegate T TestIn<in T>(T v);

    // 2.结合里氏替换原则理解
    class Father
    {

    }

    class Son:Father
    {

    }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 2.作用（结合里氏替换原则）
            // 协变 父类能被子类替换
            TestOut<Son> os = ()=> { 
                return new Son();
            };
            // TestOut<out T>如果不加out关键字 下面就不能使用 赋值运算符
            TestOut<Father> of = os;

            Father f = of(); // 实际上返回的是os里面装的函数 返回的是Son 

            // 逆变 父类总是能被子类替换
            TestIn<Father> iF = (value) =>
            {

            };

            TestIn<Son> iS = iF;

            iS(new Son());
            #endregion
        }
    }

    // 总结
    // 协变 out
    // 逆变 in

    // 用来修饰 泛型替代符的 只能修饰接口和委托中的泛型

    // 作用两点
    // 1.out修饰的泛型类型 只能作为返回值类型 in修饰的泛型类型 只能作为参数
    // 2.遵循里氏替换原则的 yongout和in修饰的泛型委托 可以相互装载(有父子关系的泛型)
    // 协变:父类泛型委托装子类泛型委托
    // 逆变：子类泛型委托装父类泛型委托
}
