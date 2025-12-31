using System;
using System.Collections; 
namespace Test_Stack
{
    public class  Program
    {
        public static void Main01()
        {
            #region 知识点一 Stack的本质
            // Stack是一个栈结构的集合类
            // 栈结构是一种后进先出（LIFO）的数据结构
            // 后进的元素最先被取出
            // Stack类帮助我们实现了栈结构的增删查改
            // 我们可以把Stack类理解为一个只能在一端进行操作的数组
            // 这一端称为栈顶，另一端称为栈底
            // Stack中不存在删除的概念，只有弹出(取)和压入
            // 不能在栈底进行任何操作
            #endregion

            #region 知识点二 Stack的声明
            // 需要引用命名空间 using System.Collections;
            Stack stack = new Stack();
            #endregion

            #region 知识点三 Stack的增
            // 压栈
            stack.Push(1);
            stack.Push("123");
            stack.Push(true);
            stack.Push(1.2f);
            #endregion

            #region 知识点四 Stack的增删查改
            object o = stack.Pop(); // 弹出栈顶元素
            Console.WriteLine(o);

            // 1.栈无法查看指定位置的元素
            //  只能查看栈顶元素
            o = stack.Peek(); // 查看栈顶元素
            Console.WriteLine(o);

            // 栈无法改变其中的元素 只能压（存）和弹（取）
            // 实在要改 只有清空
            stack.Clear();
            stack.Push(1);
            stack.Push(1.2f);
            #endregion

            #region 知识点五 Stack的遍历
            // 1.长度
            Console.WriteLine(stack.Count);

            // 2.用foreach遍历
            // Stack是后进先出 所以遍历的顺序是从栈顶到栈底
            foreach(object v in stack)
            {
                Console.WriteLine(v);
            }
            //3.还有一种遍历方式
            // 把栈转换成object数组
            object[] obj = stack.ToArray();
            // 遍历出来的顺序也是从栈底到栈顶
            for(int i = 0; i < obj.Length; i++)
            {
                Console.WriteLine(obj[i]);
            }
            // 4.循环弹栈
            while(stack.Count > 0)
            {
                object a = stack.Pop();
                Console.WriteLine(a);
            }
            Console.WriteLine(stack.Count);
            #endregion

            #region 知识点六 装箱与拆箱
            // Stack存储的是object类型的元素
            // 由于stack使用object类型存储值类型的数据，自然存在装箱与拆箱的问题
            // 当往其中存储值类型数据时，就是在装箱
            // 当从中取出值类型对象取出来转换时，就是在拆箱
            stack.Push(123); // 装箱
            Console.WriteLine(stack.Count);
            int b = (int)stack.Pop(); // 拆箱
            Console.WriteLine(b);
            #endregion

        }
    }
}