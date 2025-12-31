using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test_反射.ReflectionTest
{
    /**
     * 反射的作用: 
     *  是程序运行时获取类型信息和操作类型的功能，
     * 探查类型信息（类、结构体、接口等）
     * 动态创建对象实例
     * 调用方法和访问属性
     * 获取和操作特性(Attributes)动态生成代码（通过Emit）
     * 反射的作用: 
     *  是程序运行时获取类型信息和操作类型的功能，
     *  反射的核心位于System.Reflection命名空间，主要包含以下关键类型：
     *  类型            说明          常用属性/方法
     *  Assembly       代表程序集      GetTypes(), GetModules()
     *  Module         代表模块      GetTypes(), GetFields()
     *  Type           代表类型      GetMethods(), GetProperties()
     *  MethodInfo     方法信息      Invoke(), ReturnType
     *  PropertyInfo   属性信息      GetValue(), SetValue()
     *  FieldInfo      字段信息      GetValue(), SetValue()
     */
    public class Person
    {
        private string name;
        private int age;
        private bool gender;

        // 默认使用有参构造函数
        public Person() : this(string.Empty, 0, true) { }

        public Person(string name, int age, bool gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public bool Gender { get => gender; set => gender = value; }

        public string ShowInfo()
        {
            return $"Name: {Name}, Age: {Age}, Gender:{gender}";
        }
    }

    public class  Test01
    {
        public static void Main(string[] args)
        {
            // 获取Person 的类型信息
            Type p = typeof(Person);
            // 创建Person实例
            Person pIns = Activator.CreateInstance(p) as Person;
            // 获取属性
            PropertyInfo[] pis = p.GetProperties();

            foreach(PropertyInfo pi in pis)
            {
                Console.WriteLine(pi.Name);
            }
            Console.WriteLine(pIns.Name);
        }
    }
}
