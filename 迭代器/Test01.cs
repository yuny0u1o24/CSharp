using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器
{
    // 第一种方法，继承两个接口
    public class Test01 : IEnumerable, IEnumerator
    {
        private int[] list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int postion = -1;
        // 实现 IEnumerable中的GetNumerator方法
        public IEnumerator GetEnumerator()
        {
            Reset(); // 这个函数不会自己调用，写到这里是因为 GetEnumerator只会被获取一次
            return this; // 这个对象本身就继承了 IEnumerator并且实现了里面的内容，所以返回自身是没问题的
        }

        public bool MoveNext()
        {
            postion++;
            // 如果posiiton溢出则返回false否则返回true
            return postion < list.Length;
        }

        public object Current
        {
            get
            {
                return list[postion];
            }
        }

        public void Reset()
        {
            postion = -1;
        }
    }
    public class Test : IEnumerable
    {
        private int[] list = new int[] { 1,2,3,4,5,6,7,8,9,10 };

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                yield return list[i];
            }
        }
    }
}
