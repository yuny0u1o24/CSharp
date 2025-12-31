namespace Test_泛型约束
{

    #region 1.什么是泛型约束
    // 让泛型的类型有一定的限制
    // 关键字: Where
    // 泛型约束一共有6种
    // 1.值类型                        where 泛型字母:struct
    class Test<T> where T : struct
    {
        public T value;

        public void TestFun<K>() where K : struct
        {

        }
    }
    // 2. 引用类型                      where 泛型字母: class
    class Test2<T> where T : class
    {
        public T value;
        public void Fun<K>() where K : class
        {

        }
    }
    // 3.存在无参公共构造函数的非抽象类   where 泛型字母:new()
    class Test3<T> where T: new()
    {

    }
    //abstract class Test_3<T> where T: new()
    //{
        //存在无参公共构造函数 抽象方法并不能被new可以定义，使用时会报错
    //}

    // 4.某个类本身或者其派生类           where 泛型字母:类名
        class Test4<T>() : Test<int> where T : Test<int>
        {

        }

        class Test6<T>() : Test<int> where T : Test<int>
        {
          
        }
    // 5.某个接口的派生类型              where 泛型字母:接口名
    // 6.另一个泛型类行本身或者派生类型    where 泛型字母:另一个泛型字母 

    // where 泛型字母:(约束类型)

    // 引用类型约束

    // 限制泛型的类型在某一范围之内
        #endregion


        #region 2.各泛型约束讲解
        #endregion

        #region 3.约束的组合使用
    class Test03<T> where T : class, new()
    {

    }
    #endregion

    #region 4.多个泛型有约束
    class Test05<T,K> where T : class, new() where K : struct
    {

    }
    #endregion

    #region 5.总结
    // 反省约束：让类型有一定限制
    // class
    // struct
    // new()
    // // 类名
    // 接口名
    // 另一个泛型字母
     
    // 注意：
    // 可以组合搭配
    // 多个泛型约束 用where连接即可
    #endregion
    public class Program
    { 
        static void Main(string[] args)
        {
            Single s = new Single();
            s.Show();

            Test4<Test<int>> t4 = new Test4<Test<int>>();
            Test6<Test4<Test<int>>> test6 = new Test6<Test4<Test<int>>>();
        }
    }
}
