namespace Test_值类型和引用类型
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("值类型和引用类型");
            #region 变量类型复习
            // 无符号整形
            byte b = 1;
            ushort us = 1;
            uint ui = 1;
            ulong ul= 1;

            // 有符号整形
            sbyte sb = 1;
            short s = 1;
            int i = 1;
            long l = 1;
            // 浮点型
            float f = 1f;
            double d = 1.1;
            decimal de = 1.1m;

            // 特殊类型
            bool bo = true;
            char c = 'a';
            string str = "strs";
            // 复杂数据类型
            // 枚举
            // 数组(一维、多维、交错)

            // 以上数据类型分成值类型和引用类型
            // 引用类型: string, 数组、类
            // 值类型: 以上、结构体
            #endregion

            #region 值类型和引用类型的区别
            // 值类型
            int a = 10;
            // 引用类型
            int[] arr = new int[] { 1, 2, 3 };

            // 声明一个b让其等于之间的a
            int b1 = a;
            // 声明了一个arr2让其等于之前的arr
            int[] arr2 = arr;
            Console.WriteLine("a={0}, b={1}", a, b1);

            Console.WriteLine("arr={0}, arr2={1}", arr, arr2);

            // 值类型，在相互赋值时，是将值直接拷贝给对方，不会影响原变量的值
            // 引用类型，在相互赋值时，实际上是将地址拷贝给对方，两个指向同一个地址，改变其中一个值时，另一个值也会随之改变。

            // 值类型和引用类型，存储的内存区域不同，存储的方式也不同
            // 值类型是存储在 栈空间 的 —— 由系统分配，自动回收，小而快
            // 引用类型 存储在堆空间 —— 手动申请和释放，大而慢

            string str1 = "123";
            string str2 = str1;
            str2 = "321";
            Console.WriteLine(str1);

            #endregion
        }
    }
}
