using System;
using Test_CardLib;

namespace Test_CardClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            for (int i = 0; i < 52; i++) 
            {
                Card tempCard = myDeck.GetCard(i);
               Console.Write(tempCard.ToString());
                if (i != 51)
                    Console.Write(", ");
                else
                    Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}