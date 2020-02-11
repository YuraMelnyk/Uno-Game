using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnoGame.Model
{
    public class Deck
    {
        const byte countOfDeck = 100;
        private List<string> Colors = new List<string>()
            {
            "Red", "Yellow", "Green","Blue", "White" 
            };
        private List<string> NameOfCards = new List<string>()
        {
            "Zero", "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine", "Skip", "DrawTwo",
            "Wild", "WildDrawFour"
        };
        private static Random rng = new Random();

        //Dictionary<palceInDeck, Card>
        public  Dictionary<int, Card> CardDeck { get; set; }

        public Deck()
        {
            //Create Deck
            CardDeck = new Dictionary<int, Card>();
            int countOfDeck = 0;
            while (countOfDeck != Deck.countOfDeck)
            {

                for (int i = 0; i <= 11; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        this.CardDeck.Add(countOfDeck++, new Card(NameOfCards[i], Colors[j], i));
                        if (i != 0)
                        {
                            this.CardDeck.Add(countOfDeck++, new Card(NameOfCards[i], Colors[j], i));
                        }
                    }
                }                

                for (int i = 0; i < 4; i++)
                {
                    this.CardDeck.Add(countOfDeck++, new Card(NameOfCards[12], Colors[4], 50));
                    this.CardDeck.Add(countOfDeck++, new Card(NameOfCards[13], Colors[4], 50));
                }

            }
        }
      
        public void TakeCard(Card card)
        {
            CardDeck.Add(CardDeck.Count, card);
        }

        public Card GiveCard()
        {
            Card temp = (Card)CardDeck[CardDeck.Count - 1].Clone();
            CardDeck.Remove(CardDeck.Count - 1);
            return temp;
        }

        public void ShuffleDeck()
        {
            int n = this.CardDeck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var temp = CardDeck[k];
                CardDeck[k] = CardDeck[n];
                CardDeck[n] = temp;

            }
        }

        public void ShowDeck()
        {
            foreach (var item in this.CardDeck)
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
