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
        public Deck gameDeck { get; set; }
        public DiscardPile discardPile { get; set; }

        public void StartGame()
        {
            gameDeck = new Deck();

            gameDeck.ShuffleDeck();
            Players = new List<Player>();

            Console.WriteLine("Enter your name:");
            Player player = new Player(Console.ReadLine().ToString());
            Players.Add(player);

            Console.WriteLine("Enter number of players:");
            NumberOfPlayers = int.Parse(Console.ReadLine().ToString());
            for (int i = 1; i < NumberOfPlayers; i++)
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

            //gameDeck.ShowDeck();

        }

        public void Play()
        {
            discardPile = new DiscardPile();
            Random rnd = new Random();
            bool endGame = false;
            int i = rnd.Next(0, NumberOfPlayers - 1);
            Card firstCardInDiscard = Players[i].GiveCard(rnd.Next(0, Players[i].Hand.Count - 1));
            discardPile.TakeCard(firstCardInDiscard);
            do
            {
                if (i == NumberOfPlayers - 1 && Players[i].Direction == true)//Players[i].Direction
                {
                    i = 0;
                }
                else if (i == 0 && Players[i].Direction == false)//!Players[i].Direction
                {
                    i = NumberOfPlayers - 1;
                }
                else if (Players[i].Direction)
                {
                    i++;
                }
                else
                {
                    i--;
                }
                
                discardPile.ShowLastCard();
                if (discardPile.lastCard.Name == "Skip")
                {
                    Console.WriteLine();
                    Console.WriteLine("You skip!");
                    continue;
                }
                else if(discardPile.lastCard.Name == "DrawTwo")
                {
                    Console.WriteLine();
                    Console.WriteLine("Take two cards!");
                    Players[i].TakeCard(gameDeck.GiveCard());
                    Players[i].TakeCard(gameDeck.GiveCard());
                }
                else if (discardPile.lastCard.Name == "WildDrawFour")
                {
                    Console.WriteLine();
                    Console.WriteLine("Take four cards!");
                    for (int k = 0; k < 4; k++)
                    {
                        Players[i].TakeCard(gameDeck.GiveCard());
                    }
                }

                if (Players[i].IsAction(discardPile.lastCard))
                {
                    Console.WriteLine();
                    Console.WriteLine("Your turn!");
                    discardPile.TakeCard(Players[i].Action(discardPile.lastCard));
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry you dont have card");
                    Players[i].TakeCard(gameDeck.GiveCard());
                }
                //Action(i);
                Players[i].Uno();
                endGame = Players[i].End();

                if (endGame)
                {
                    Console.WriteLine("Greate game! Bay!");
                }

            } while (endGame == false);
        }

        //public void Action(int i)
        //{
        //    if (discardPile.lastCard.Name == "DrawTwo")
        //    {
        //        Console.WriteLine("Take two cards!");
        //        Players[i].TakeCard(gameDeck.GiveCard());
        //        Players[i].TakeCard(gameDeck.GiveCard());
        //    }
        //    else if (discardPile.lastCard.Name == "WildDrawFour")
        //    {
        //        Console.WriteLine("Take four cards!");
        //        for (int k = 0; k < 4; k++)
        //        {
        //            Players[i].TakeCard(gameDeck.GiveCard());
        //        }
        //    }
        //    if (Players[i].IsAction(discardPile.lastCard))
        //    {
        //        Console.WriteLine("Your turn!");
        //        discardPile.TakeCard(Players[i].Action(discardPile.lastCard));
        //    }
        //    else
        //    {
        //        Console.WriteLine("Sorry you dont have card");
        //        Players[i].TakeCard(gameDeck.GiveCard());
        //    }
        //}
    }
}
