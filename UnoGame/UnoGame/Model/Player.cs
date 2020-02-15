using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame.Model
{
    public class Player
    {
        public string Name { get; set; }

        public Dictionary<int, Card> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new Dictionary<int, Card>();
        }

        public void TakeCard(Card card)
        {
            Hand.Add(Hand.Count, card);
        }

        public Card GiveCard()
        {
            Card temp = (Card)Hand[Hand.Count - 1].Clone();
            Hand.Remove(Hand.Count - 1);
            return temp;
        }

        public void ShowHand()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Name} has next card:\n" +
                $"_______________________________________");
            foreach (var item in this.Hand)
            {

                if (item.Value.Color == "Red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                }
                if (item.Value.Color == "Yellow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                }
                if (item.Value.Color == "Green")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                }
                if (item.Value.Color == "Blue")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                }
                if (item.Value.Color == "White")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                }

            }
        }
    }
}
