using System;
using System.Collections.Generic;
using static System.Console;

namespace Test_集合.Test01.Charper11
{
    public abstract class Animal
    {
        protected string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Animal() => name = "The animal with no name";
        public Animal(string name) => this.name = name;

        public void Feed() => WriteLine($"{name} has been fed.");
    }
}
