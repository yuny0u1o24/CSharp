using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_集合.Test01.Charper11
{
    public class Cow : Animal
    {
        public void Milk()
        {
            Console.WriteLine($"{name} has been milked.");
        }

        public Cow(string newName) : base(newName) { }
    }
}
