namespace Test_List
{
    #region 
    #endregion

    public class Program
    {
        static void Main01(string[] args)
        {
            #region 1.List的本质
            // List是一个C#为我们封装好的类，
            // 它的本质是一个可变类型的泛型数组
            // List类帮助我们实现了很多方法
            // 比如泛型数组的增删查改
            #endregion

            #region 2.声明
            // 引用命名空间 System.Collections.Generic
            List<int> list = new List<int>();
            List<string> list2 = new List<string>();
            #endregion 

            #region 3.增删查改
            #region 增
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list2.Add("123");

            List<string> listStr = new List<string>();
            listStr.Add("123");
            list2.AddRange(listStr);
            #endregion

            #region 删
            list.Remove(1);

            list.Clear(); // 清空
            #endregion

            #region 查
            Console.WriteLine(list[0]);
            if (list.Contains(1))
            {
                Console.WriteLine("存在1");
            }
            // 正向查找元素位置
            int index = list.IndexOf(1);

            // 反向查找元素位置
            index = list.LastIndexOf(1);
            #endregion

            #region 改
            Console.WriteLine(list[0]);

            list[0] = 99;
            #endregion

            #endregion

            #region 4.遍历
            // 长度
            Console.WriteLine(list.Count);
            // 容量
            Console.WriteLine(list.Capacity);
            #endregion
        }
    }
}
 