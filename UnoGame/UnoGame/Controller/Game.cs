using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame.Model;

namespace UnoGame.Controller
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public int NumberOfPlayers { get; set; }

        public void StartGame()
        {
            Deck gameDeck = new Deck();
            gameDeck.ShuffleDeck();
            Players = new List<Player>();

            Console.WriteLine("Enter your name:");
            Player player = new Player(Console.ReadLine().ToString());
            Players.Add(player);

            Console.WriteLine("Enter number of players:");
            NumberOfPlayers = int.Parse(Console.ReadLine().ToString());
            for (int i = 1; i < NumberOfPlayers - 1; i++)
            {
                Players.Add(new Bot("Bot" + i));
            }

            for (int i = 0; i < 5; i++)
            {
                foreach (var item in Players)
                {
                    item.TakeCard(gameDeck.GiveCard());
                }
            }

            foreach (var item in Players)
            {
                item.ShowHand();
            }

            gameDeck.ShowDeck();

        }
    }
}
