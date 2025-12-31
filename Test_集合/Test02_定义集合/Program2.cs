using System;
using System.Collections.Generic;
using System.Collections;
using Test_集合.Test01.Charper11;

namespace Test_集合.Test02_定义集合
{
    

    public class Program2
    {
        public static void Main()
        {
            AnimalsCollectionBase animalCollection = new AnimalsCollectionBase();
            animalCollection.Add(new Cow("Donna"));
            animalCollection.Add(new Chicken("Mary"));
            foreach (Animal myAnimal in animalCollection)
            {
                myAnimal.Feed();
            }


        }
    }
}
