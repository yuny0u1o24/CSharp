using System.Collections;
using Test_集合.Test01.Charper11;

namespace Test_集合.Test01
{
    internal class Program1
    {
        static void Main01(string[] args)
        {
            Console.WriteLine("创建一个Animal[]类型的数组: ");
            Animal[] animalArray = new Animal[2];
            Cow myCow1 = new Cow("Lea");
            animalArray[0] = myCow1;
            animalArray[1] = new Chicken("Noa");

            foreach (Animal myAnimal in animalArray)
            {
                Console.WriteLine($"新添加的 {myAnimal.ToString()} 已经添加到Animal数组中");
            }

            Console.WriteLine($"数组中包含的对象有{animalArray.Length}个");
            animalArray[0].Feed();
            ((Chicken)animalArray[1]).LayEgg();
            Console.WriteLine();
            Console.WriteLine("创建一个ArrayList类型的Animal集合: ");
            ArrayList animalArrayList = new ArrayList();
            Cow myCow2 = new Cow("Mia");
            animalArrayList.Add(myCow2);
            animalArrayList.Add(new Chicken("Andrea"));
            foreach (Animal myAnimal in animalArrayList)
            {
                Console.WriteLine($"新添加的 {myAnimal.ToString()} 已经添加到ArrarytList对象" +
                    $"集合名称 = {myAnimal.Name}");
            }
            Console.WriteLine($"ArrayList中共有 {animalArrayList.Count} 个"
                                + "对象.");
            animalArray[0].Feed();
            ((Chicken)animalArrayList[1]).LayEgg();

            Console.WriteLine();

            Console.WriteLine("对ArrayList进行操作: ");
            animalArrayList.RemoveAt(0);
            ((Animal)animalArrayList[0]).Feed(); // 只剩下了Chicken对象
            animalArrayList.AddRange(animalArray); // 追加到这个集合的末尾
            ((Chicken)animalArrayList[2]).LayEgg();
            Console.WriteLine($"名为 {myCow1.Name} 的索引是 {animalArrayList.IndexOf(myCow1)}。");
            myCow1.Name = "Mary";
            Console.WriteLine($"这只动物现在是: {((Animal)animalArrayList[1]).Name}");

        }
    }
}
