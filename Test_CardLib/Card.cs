using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_CardLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Card
    {
        public readonly Suit suit;
        public readonly Rank rank;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        private Card()
        {

        }

        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }
    }
}
