namespace  Test_特殊的引用类型String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region string的它变我不变
            string str = "123";
            string str1 = str;

            // 按理说string也是他变我不变的原则
            // string是一个特殊的引用类型，它具备值类型的特征 它变我不变
            // string在赋值时，会在堆内存空间中重新分配一个 "321"的空间并指向它。
            str1 = "321";

            Console.WriteLine(str);
            #endregion
        }
    }
}
