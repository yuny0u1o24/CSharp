using System;
using System.Collections;

namespace Test_Hashtable
{
    public class Program
    {
        public static void Main()
        {
            #region 知识点1 Hashtable的本质
            // Hashtable（又称散列表）是基于键的哈希代码组织起来的 键/值对集合
            // 它的主要作用是提高数据查询的效率
            // 使用键来访问集合中的元素
            #endregion

            #region 知识点2 声明
            // 需要引入 System.Collections 命名空间
            Hashtable hashtable = new Hashtable();
            #endregion

            #region 知识点3 增删查改

            #region 增
            hashtable.Add(1, "123");
            hashtable.Add("123", 2);
            hashtable.Add(true, false);
            hashtable.Add(false, true);
            // !注意：不能出现相同的键
            #endregion

            #region 删
            // 1.只能通过键来删除
            //hashtable.Remove(1);
            // 2.删除不存在的键不会报错
            //hashtable.Remove(2);
            // 3.或者直接清空
            //hashtable.Clear();
            #endregion

            #region 查
            // 1.通过键来获取值
            //  找不到会返回 null
            object v = hashtable[1];
            object v2 = hashtable["123"];

            // 2.判断是否包含某个键
            //  根据键来检测
            Console.WriteLine(hashtable[1]);
            Console.WriteLine(hashtable["123"]);
            Console.WriteLine(hashtable[666]); // 不存在的键返回为null
            //  根据值来检测
            if (hashtable.ContainsValue(1))
            {
                Console.WriteLine("存在值为1的键值对");
            }
            #endregion

            #region 改
            // 只能改 键对应的值内容 无法修改键
            hashtable[1] = "修改后的值";
            Console.WriteLine(hashtable[1]);
            #endregion

            #endregion

            #region 知识点4 遍历
            // 得到键值对 对数
            Console.WriteLine(hashtable.Count);
            // 1.遍历所有的键
            foreach(object item in hashtable.Keys)
            {
                Console.WriteLine(item); // 得到所有的键
                Console.WriteLine(hashtable[item]); // 根据键得到对应的值
            }
            // 2.遍历所有的值
            foreach(object item in hashtable.Values)
            {
                Console.WriteLine("值:" + item);
            }

            // 3.遍历所有的键值对
            foreach(DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item);
            }

            // 4.迭代器遍历
            IDictionaryEnumerator myEnumerator = hashtable.GetEnumerator();
            bool flag = myEnumerator.MoveNext();
            while(flag)
            {
                Console.WriteLine(myEnumerator.Value+","+myEnumerator.Key);
                flag = myEnumerator.MoveNext();
            }
            #endregion
        }
    }
}