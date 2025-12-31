using System;
using System.Linq;
namespace Test_Linq
{
    public class Program
    {
        public class Person
        {
            public string Name { set; get; }
            public int Age { set; get; }
            public bool Gender { set; get; } // true 男 false 女
            public int Salary { set; get; }


            //public Person(string name, int age, bool gender, int salary)
            //{
            //    Name = name;
            //    Age = age;
            //    Gender = gender;
            //    Salary = salary;
            //}
        }

        static void Main(string[] args)
        {
            #region 知识点1 - 什么是Linq
            // Linq(Language Integrated Query) 语言集成查询
            // 是微软为C#和VB.NET语言设计的一套用于操作数据源的统一查询语法和API
            // 它允许开发者使用类似SQL的语法来查询各种数据源，如集合、数据库、XML等
            // 它大部分是集合的扩展方法，可以让我们更方便的操作集合。
            #endregion

            #region 知识点2 Where的使用方法
            // 什么是Where: 
            // Where是Linq中的一个扩展方法，用于过滤集合中的元素
            // 它接受一个谓词函数作为参数，该函数定义了过滤条件
            // 只有满足条件的元素才会被包含在结果集中
            // 语法:
            // IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate);
            List<Person> perple = new List<Person>(){
                new Person() { Name = "张三", Age = 18, Gender = true, Salary = 5000 },
                new Person() { Name = "李四", Age = 22, Gender = true, Salary = 2000 },
                new Person() { Name = "王五", Age = 30, Gender = false, Salary = 2000 },
            };

            // Where用于过滤出年龄大于20且薪资小于等于3000的人，Select用于对Where返回的结果进行薪资的调整
            // 这里是延迟执行的，只有在遍历arr时才会执行过滤和转换操作
            //IEnumerable<Person> arr = perple.Where(p).Select(p2);
            //List<Person> arr = perple.Where(p).Select(p2).ToList();
            //Person[] arr = perple.Where(p).Select(p2).ToArray();
            ILookup<string, int> arr = perple.Where(p).Select(p2).ToLookup(s => s.Name, s => s.Salary);
            foreach (var v in arr)
            {
                //Console.WriteLine(v.Value.Name + ',' + v.Value.Salary);
                Console.WriteLine(v.Key);
            }

            //for(int i = 0; i < arr2.Count(); i++)
            //{
            //    Console.WriteLine("姓名" + perple[i].Name + "薪资+1000后" + perple[i].Salary);
            //}
            #endregion
        }

        public static bool p(Person person)
        {
            return person.Age >= 20 && person.Salary <= 3000;
        }

       public static Person p2(Person person)
        {
            person.Salary = person.Salary >= 5000 ? person.Salary - 1000 : person.Salary + 1000;
            return person;
        }
    }
}