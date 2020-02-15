using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame.Model
{
    public class DiscardPile
    {
        public Dictionary<int, Card> Discard_Pile { get; set; }

        public DiscardPile()
        {
            Discard_Pile = new Dictionary<int, Card>();
        }

        public void TakeCard(Card card)
        {
            Discard_Pile.Add(Discard_Pile.Count, card);
        }

        public Card GiveCard()
        {
            Card temp = (Card)Discard_Pile[Discard_Pile.Count - 1].Clone();
            Discard_Pile.Remove(Discard_Pile.Count - 1);
            return temp;
        }
        public void ShowLastCard()
        {
            Card lastCard = Discard_Pile[Discard_Pile.Count-1];
            if (lastCard.Color == "Red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{lastCard.Name} {lastCard.Color} has {lastCard.Points} points.");
            }
            if (lastCard.Color == "Yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{lastCard.Name} {lastCard.Color} has {lastCard.Points} points.");
            }
            if (lastCard.Color == "Green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{lastCard.Name} {lastCard.Color} has {lastCard.Points} points.");
            }
            if (lastCard.Color == "Blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{lastCard.Name} {lastCard.Color} has {lastCard.Points} points.");
            }
            if (lastCard.Color == "White")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{lastCard.Name} {lastCard.Color} has {lastCard.Points} points.");
            }
        }

    }
}
