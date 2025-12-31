using System;

namespace Test_顺序存储和链式存储
{
    public class Program
    {
        public static void Main()
        {
            #region 知识点1 数据结构
            // 数据结构
            // 数据结构是计算机中存储、组织数据的方式(规则)
            // 数据结构是指相互之间存在一种或多种特定关系的数据元素的集合
            // 比如自定义的一个 类 也可以称为一种数据结构 自己定义的数据组合规则

            // 不要把数据结构想的太复杂
            // 简单点理解，就是人定义的一种 存储数据 和 表示数据之间关系的规则而已

            // 常用的数据结构
            // 数组、链表、栈、队列、树、图、散列表(哈希表)
            #endregion

            #region 知识点2 线性表
            // 线性表是一种数据结构，是由n个具有相同特性的数据元素的有限序列
            // 比如：数组、ArrayList、Stack、Queue 链表都是线性表
            #endregion

            // 顺序存储和链式存储 是线性表的两种存储方式

            #region 知识点3 顺序存储
            // 数组、Stack、Queue、List、ArrayList —— 顺序存储
            // 只是数组、Stack、Queue的 组织规则不同而已
            // 顺序存储:
            // 用一组连续的存储单元依次存储线性表中的各个数据元素

            #endregion

            #region 知识点4 链式存储
            // 单向链表、双向链表、循环链表 —— 链式存储
            // 链式存储:
            // 用一组任意存储单元存储线性表中的各个数据元素
            #endregion

            //LinkedNode<int> node1 = new LinkedNode<int>(1);
            //LinkedNode<int> node2 = new LinkedNode<int>(2);

            //node1.next = node2;
            //Console.WriteLine(node1.value); // 输出 1
            //node2.next = new LinkedNode<int>(3);
            //node2.next.next = new LinkedNode<int>(4);

            LinkedList<int> link = new LinkedList<int>();
            link.Add(1);
            link.Add(2);
            link.Add(3);
            link.Add(4);
            LinkedNode<int> node = link.head;
            while(node != null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
            link.Remove(3);
            node = link.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
        }
    }

    #region 知识点5 自己实现一个最简单的单向链表
    /// <summary>
    /// 单向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedNode<T>
    {
        public T value; // 节点存储的数据
        // 这个存储下一个元素
        public LinkedNode<T> next; // 指向下一个节点的引用

        public LinkedNode(T value)
        {
            this.value = value;
        }
    }
    /// <summary>
    /// 单向链表类，管理 节点、添加等操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList<T>
    {
        public LinkedNode<T> head;
        public LinkedNode<T> last;

        public void Add(T value)
        {
            // 添加节点 必然是new一个新的节点
            LinkedNode<T> newNode = new LinkedNode<T>(value);
            if(head == null)
            {
                head = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                last = newNode;
            }
        }

        public void Remove(T value)
        {
            if(head == null)
            {
                return;
            }
            if(head.value.Equals(value))
            {
                head = head.next;
                // 如果头节点 被移除后 变成了null
                // 说明链表已经空了，那么尾节点也要变成null
                if (head == null) 
                {
                    last = null;
                }
                return;
            }

            LinkedNode<T> node = head;
            while(node.next != null)
            {
                if (node.next.value.Equals(value))
                {
                    // 让当前找到的这个元素的上一个节点 指向它的下一个节点
                    // 指向 自己的下一个节点
                    node.next = node.next.next;
                    break;
                }
                node = node.next;
            }
        }
    }
    #endregion

    #region 知识点6 总结

    #endregion
}