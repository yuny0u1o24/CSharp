namespace Test_索引器
{
    #region 1. 索引器基本概念
    // 让对象可以像数组一样通过索引访问其中的元素，让程序看起来更直观，更容易编写
    #endregion
    #region 2. 索引器语法
    // 访问修饰符 返回值 this[参数类型 参数名, 参数类型 参数名, ...]
    //{
    //  内部写法和规则 与属性相同
    //  set{ }
    //  get{ }
    //}
    #endregion
    #region 3.实现
    class Person
    {
        private string name;
        private int age;
        private Person[] friends;

        private Person[,] array;

        #region 5.索引器可以重载
        // 只要参数类型或个数不同，顺序不同
        public Person this[int i, int j]
        {
            get
            {
                return this[i, j];
            }
        }
        #endregion

        public Person this[int index]
        {
            get
            {
                // 可以编写逻辑 根据需求来处理里面的内容
                #region 4.索引器中可以编写逻辑
                if(friends != null)
                {
                    return null;
                }
                else if(index > friends.Length - 1)
                {

                }
                #endregion
                return friends[index]; 
            }
            set
            {
                // value 代表传入的值
                friends[index] = value;
            }
        }

        #endregion


        
        internal class Program
        {
            static void Main(string[] args)
            {
                Test01 t = new Test01();

                t.Append(10);
                t.Append(20);
                t.Append(30);
                t.Append(40);
                t.Append(50);
                t.Append(60);

                t.Remove(10);

                for(int i = 0; i < 8; i++)
                {
                    Console.WriteLine(t[i]);
                }

            }
        }


        // 总结
        // 索引器的主要作用
        // 可以让我们以中括号的形式范围自定义类中的元素，规则自己定，访问时和数组一样。
        // 比较适用于 在类中有数组变量时使用，可以方便的访问和进行逻辑处理

    }
}
