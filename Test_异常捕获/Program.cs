namespace Test_异常捕获
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 必须
            try
            {
                // 捕获异常，出现报错时执行catch代码块
            }
            catch(Exception e)
            {
                // 出现异常时执行
            }
            // 可选
            finally
            {
                // 无论有没有异常都会执行
            }

            try
            {
                string str = Console.ReadLine();
                int i = Convert.ToInt32(str); // 转换为数字
                Console.WriteLine(i);
            }
            catch(Exception e)
            {
                Console.WriteLine("输入错误，只能输入数字不能含有任何其他字符.");
            }

        }
    }
}
