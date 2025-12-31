namespace Test_Object
{
    
    public class Test
    {

    }
    public class Program
    {
        static void Main(string[] args)
        {
            #region 1.object中的静态方法
            // 静态方法 Equals判断两个对象是否相等
            // 最终的判断权，交给左侧对象的Equals方法，
            // 不管是值类型 还是引用类型都会按照左侧对象Equals方法的规则来进行比较
            Console.WriteLine(Object.Equals(1,1));// 也可以写成 Console.WriteLine(Equals(1,1));
            Test t = new Test();
            Test t2 = new Test();

            Console.WriteLine(Object.Equals(t, t2));
            // 静态方法 ReferenceEquals
            // 比较两个对象是否是相同的引用，主要是用来比较引用类型的对象，
            // 值类型对象返回值始终是false
            Console.WriteLine(Object.ReferenceEquals(t, t2));

            #endregion

            #region 2.object中的成员方法
            // 普通方法GetType
            // 该方法在反射相关知识中是非常重要的方法，它返回一个Type类型
            // 该方法的主要作用就是获取对象运行时的类型Type 
            // 通过Type结合反射相关知识点可以做很多关于对象的操作。
            Test t3 = new Test();
            Type type = t3.GetType();

            // 普通方法MemberwiseClone
            // 该方法用于获取对象的浅拷贝对象，简单的意思就是返回一个新的对象。
            // 但是新对象中的引用变量会和老对象一致
            #endregion

        }
    }
}
