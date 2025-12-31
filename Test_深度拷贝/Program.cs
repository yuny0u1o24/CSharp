using System;
namespace Test_深度拷贝
{
    public class Cloner : ICloneable
    {
        public Content content = new Content();
        public Cloner(int newVal) => content.val = newVal;

        public object Clone()
        {
            Cloner clonedClonerr = new Cloner(content.val);
            return clonedClonerr;
        }
    }

    public class Content
    {
        public int val;
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Cloner mySource = new Cloner(5);
            Cloner myTarget = (Cloner)mySource.Clone();
            Console.WriteLine($"myTarget.MyContent.val = {myTarget.content.val}");
            Console.WriteLine($"mySource.MyContent.val = {mySource.content.val}");
            // 改变mySource.content.val的值，myTarget.content.val的值也被改变了，因为浅拷贝不能处理引用类型的成员
            mySource.content.val = 2;
            Console.WriteLine($"myTarget.MyContent.val = {myTarget.content.val}");
            Console.WriteLine($"mySource.MyContent.val = {mySource.content.val}");
        }
    }
}