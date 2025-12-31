using System.Collections;

namespace 迭代器
{
    #region 知识点1 迭代器是什么
    // 迭代器(iterator) 有时又称光标(cursor)
    // 是程序设计的软件设计模式
    // 迭代器模式提供一个方法顺序访问一个聚合对象中的各个元素（简单点说就是：迭代器模式提供一个方法顺序访问一个数组、列表、集合等对象中的各个元素）
    // 而又不暴露其内部的标识

    // 在表现效果上看
    // 是可以在容器对象(例如链表或数组) 上便利访问的接口
    // 设计人员无需关心容器对象的内存分配的实现细节
    // 可以用foreach遍历的类，都是实现了迭代器的 
    #endregion

    #region 知识点2 标准迭代器的实现方法
    // 关键接口：IEnumerator、IEnumerable
    // 命名空间: using System.Collerctions;
    // 可以通过继承IEnumertor和IEnumerable实现其中的方法
    class Customlist : IEnumerable, IEnumerator
    {
        private int[] aa;
        // 从-1开始的光标 用于表示 数据得到了哪个位置
        private int pos = -1;
        public Customlist()
        {
            aa = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }


        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        public object Current
        {
            get
            {
                return aa[pos];
            }
        }
        public bool MoveNext()
        {
            ++pos;
            return pos < aa.Length;
        }

        public void Reset()
        {
            pos = -1;
        }
    }
    #endregion

    #region 知识点3 用yield return 语法糖实现迭代器
    // yield return 是C#提供给我们的语法糖，主要作用就是简化上面的代码(Customlist类的代码，只需要继承IEnumerable)
    // 所谓语法糖，也称糖衣语法
    // 主要作用就是将复杂逻辑简单化，可以增加程序的可读性
    // 从而减少程序代码出错的机会

    // 关键接口: IEnumerable
    // 命名空间: using System.Collections;
    // 想要通过foreach遍历的自定义类实现接口中的方法GetEnumerator即可

    public class CustomList2 : IEnumerable
    {
        private int[] list;

        public CustomList2()
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                // yield关键字 配合迭代器使用
                // 可以理解为 暂时返回 保留当前的状态
                yield return list[i];
            }
        }
    }
    #endregion

    #region 知识点4 用yield return 语法糖为泛型类实现迭代器
    public class CustomList<T> : IEnumerable
    {
        private T[] list;

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < list.Length; i++)
            {
                yield return list[i]    ;
            }
        }
    }
    #endregion


    internal class Program
    {
        static void Main01(string[] args)
        {
            //Customlist cl = new Customlist();
            //// foreach本质
            //// 1.先获取in后面这个对象的 IEnumerator
            ////  会调用对象其中的GetEnumerator方法来获取
            //// 2.执行得到这个IEnumerator对象中的MoveNext方法
            //// 3.只要MoveNext方法的返回值是true 就会去得到Current
            ////      然后赋值给item
            //foreach(int a in cl)
            //{
            //    Console.WriteLine(a);
            //}

            //CustomList2 cl2 = new CustomList2();

            //foreach(int a in cl2)
            //{
            //    Console.WriteLine(a);
            //}

            // 练习
            Test01 t = new Test01();

            foreach(int item in t)
            {
                Console.WriteLine(item);
            }

            Test t2 = new Test();
            foreach (int item in t2)
            {
                Console.WriteLine(item);
            }

        }
    }

    // 总结：
    // 迭代器就是可以让我们在外部直接通过foreach遍历对象中元素而不需要了解其结构
    // 主要的两种方式
    // 1.传统方式，继承两个接口，实现里面的方法
    // 2.使用语法糖 yield return 去返回内容，只需要继承有一个接口即可，
}
