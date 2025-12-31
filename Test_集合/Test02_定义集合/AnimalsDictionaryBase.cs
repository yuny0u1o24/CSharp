using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Test_集合.Test01.Charper11;
namespace Test_集合.Test02_定义集合
{
    public class AnimalsDictionaryBase : DictionaryBase
    {
        public void Add(string newID, Animal newAnimal) => Dictionary.Add(newID, newAnimal);
        public void Remove(string animalID) => Dictionary.Remove(animalID);

        public AnimalsDictionaryBase()
        {

        }

        public Animal this[string newAnimalID] 
        {
            get { return (Animal)Dictionary[newAnimalID]; }
            set { Dictionary[newAnimalID] = value; }
        }
    }
}
