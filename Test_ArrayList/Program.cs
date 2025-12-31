using System.Collections;

namespace Test_ArrayList
{
    public class Test
    {
            
    }
    public class Program
    {
        static void Main(string[] args)
        {
            #region 1.ArrayList的本质
            // ArrayaList是一个C#为我们封装好的类，
            // 它的本质是一个object类型的数组，
            // ArrayList类帮助我们实现了很多方法
            // 比如数组的增删查改
            #endregion

            #region 2.声明
            // 需要引用命名空间 using System.Collection;
            ArrayList array = new ArrayList();
            #region 3增删查改
            // 增
            array.Add(1);
            array.Add("123");
            array.Add(true);
            array.Add(new object());
            array.Add(new Test());

            array.Insert(0,true); // 在0位置插入true

            // 删
            array.Remove(1);
            array.RemoveAt(2);
            //array.Clear(); //清空

            // 查
            Console.WriteLine(array[0]); // 得到指定位置的元素 
            // 查看元素是否存在
            if (array.Contains("123"))
            {
                Console.WriteLine("存在123");
            }

            // 正向查找元素位置
            // 找到的返回值是位置，找不到返回-1
            int index = array.IndexOf(true);

            // 反向查找位置
            index = array.LastIndexOf(true);
            Console.WriteLine(index);

            // 改
            array[0] = "999";

            #endregion

            #endregion

            #region 3.遍历
            // 长度
            Console.WriteLine(array.Count);
            // 容量
            // 避免产生过多的垃圾
            Console.WriteLine(array.Capacity);
            Console.WriteLine("*******************");
            for(int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("*******************");
            // 迭代器遍历
            foreach (object obj in array)
            {
                Console.WriteLine(obj);
            }

            #endregion

            #region 数组和ArrayList的区别
            /*
             * ArrayList本质上是一个object数组的封装
             * 
             * 1.ArrayList可以不用一开始就定长，单独使用数组是定长的
             * 2.数组可以指定存储类型，ArrayList默认为object类型
             * 3.数组的增删需要自己去实现，ArrayList帮我们封装了方便的API来使用
             * 4.ArrayList使用时可能存在装箱拆箱，数组使用时只要不是object数组那就不存在这个问题
             * 5.数组长度为Length，ArrayList长度为Count
             */
            #endregion




        }
    }
}
