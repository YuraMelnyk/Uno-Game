using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame.Model;
using UnoGame.Controller;

namespace UnoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deck deck = new Deck();
            //deck.ShowDeck();
            //deck.ShuffleDeck();
            //deck.ShowDeck();

            Game game = new Game();
            game.StartGame();
            game.Play();
            
        }
    }
}
