using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_集合.Test01.Charper11
{
    public class Chicken : Animal
    {
        public void LayEgg()
        {
            Console.WriteLine($"{name} has laid an egg.");
        }

        public Chicken(string newName) : base(newName) { }
    }
}
