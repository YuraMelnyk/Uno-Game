using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame.Model;

namespace UnoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.ShowDeck();
            deck.ShuffleDeck();
            deck.ShowDeck();
        }
    }
}
