using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_索引器
{
    public class Test01
    {
        // 数组初始容量
        private int capacity = 4;
        private int length = 0;
        private int[] arr;

        public int Length
        {
            get
            {
                return length;
            }
        }

        public Test01()
        {
            arr = new int[capacity];
        }
        

        // 增
        public void Append(int value)
        {
            if(length < capacity)
            {
                arr[length] = value;
                length++;
            }
            else
            {
                capacity *= 2;
                
                int[] newArr = new int[capacity];
                for(int i = 0; i < arr.Length; i++)
                {
                    newArr[i] = arr[i];
                }
                // 指向新的数组
                arr = newArr;

                arr[length] = value;
                length++;
            }
        }
        // 删
        public void Remove(int value)
        {
            // 根据值删除
            for (int i = 0; i < length; i++)
            {
                if (arr[i] == value)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveAt(int index)
        {
            // 根据索引删除
            if(index > length - 1)
            {
                Console.WriteLine($"当前数组只有{length}");
                return;
            }

            for(int i = index; i < length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            --length;
        }

        // 改查
        public int this[int index]
        {
            get
            {
                if(index >= arr.Length || index < 0)
                {
                    Console.WriteLine("数组越界");
                    return 0;
                }
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
    }
}
