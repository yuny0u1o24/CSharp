namespace Test_委托_Lx
{


    /// <summary>
    /// 
    /// </summary
    public class Test
    {
        static void Main(string[] args)
        {
            Func<int, int> a = TestFun(10);
            int c = a(10);
            Console.WriteLine(c);
        }
          
        static Func<int, int> TestFun(int i)
        {
            // 这种写法会改变i的生命周期
            return delegate (int v)
            {
                return i * v;
            };
        }
    }
}
