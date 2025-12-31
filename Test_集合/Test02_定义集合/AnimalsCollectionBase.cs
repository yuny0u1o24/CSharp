using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_集合.Test01.Charper11;

namespace Test_集合.Test02_定义集合
{
    public class AnimalsCollectionBase : CollectionBase
    {
        //public void Add(Animal newAnimal) => List.Add(newAnimal);
        public void Add(Animal newAnimal)
        {
            List.Add(newAnimal); // List是IList接口中的提供的接口 返回的是一个Object类型
        }

        // Lambda表达式写法
        //public void Remove(Animal newAnimal) => List.Remove(newAnimal);
        public void Remove(Animal oldAnimal)
        {
            List.Remove(oldAnimal);
        }

        public AnimalsCollectionBase()
        {

        }

        // 索引器
        public Animal this[int animalIndex]
        {
            // 这里强转后 不需要再使用((Animal)animalCollection[0]).Feed()访问了
            get { return (Animal)List[animalIndex]; }
            set { List[animalIndex] = value; }
        }
    }
}
