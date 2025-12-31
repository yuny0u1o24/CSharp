using System;
using System.Collections;

namespace Test_Queue
{
    public class Program
    {
        public static void Main() 
        {
            #region 知识点一 Queue的本质
            // Queue即队列，是一种先进先出（FIFO，First In First Out）的数据结构。
            // 它的本质也是object[]数组，通过动态扩容来存储数据。
            // 只是封装了特殊的存储规则 —— 先进先出。
            // Queue类位于System.Collections命名空间中。
            #endregion

            #region 知识点二 声明
            Queue queue = new Queue();
            #endregion

            #region 知识点三 增删查改
            #region 增
            queue.Enqueue("A");
            queue.Enqueue(1);
            queue.Enqueue(2.3f);
            #endregion
            #region 取
            // 队列中不存在删除的概念的
            // 只有取的概念 取出先加入的对象
            object v = queue.Dequeue();
            Console.WriteLine(v);
            v = queue.Dequeue();
            Console.WriteLine(v);
            #endregion

            #region 查
            // 1.查看队列头部元素但不会将其移除
            v = queue.Peek();
            Console.WriteLine(v);

            // 2.查看元素是否存在于队列中
            if (queue.Contains(2.3f))
            {
                Console.WriteLine("队列中存在2.3f");
            }
            #endregion

            #region 改
            // 队列无法改变其中的元素 只能进出队列
            // 实在需要改变 可以出队列后再入队列或者清除后重新入队列
            queue.Clear();
            queue.Enqueue("B");
            queue.Enqueue(3);
            #endregion
            #endregion

            #region 知识点四 遍历
            // 1.长度
            Console.WriteLine($"队列长度为: {queue.Count}");
            // 2.使用foreach遍历
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }
            // 3.将队列转换为数组遍历
            object[] arr = queue.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            // 4.循环出列
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            #endregion

            #region 知识点五 注意事项
            // 1. Queue可以存储不同类型的元素 因为其存储的是object类型
            // 2. 如果需要存储特定类型的元素 可以使用泛型Queue<T> 来自System.Collections.Generic命名空间
            // 3. Queue不是线程安全的 如果在多线程环境下使用 需要自行实现同步机制
            // 4. Queue没有索引访问方式 只能通过出队列的方式访问元素
            // 5. 出队列时 如果队列为空 会抛出InvalidOperationException异常
            // 6. 可以使用Count属性获取队列中元素的数量
            // 7. 可以使用Clear方法清空队列中的所有元素
            // 8. 可以使用ToArray方法将队列转换为数组

            // 以下是没有学过的内容 可作为扩展后续学习
            // 9. 可以使用TrimToSize方法将队列的容量设置为实际元素数量以节省内存
            // 10. 可以使用GetEnumerator方法获取队列的枚举器以进行自定义遍历
            // 11. 可以使用CopyTo方法将队列元素复制到现有的一维数组中
            // 12. 可以使用Synchronized方法获取线程安全的队列包装器
            #endregion
        }
    }
}