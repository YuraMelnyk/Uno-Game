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
        public bool Direction { get; set; }
        public Dictionary<int, Card> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Direction = true;
            Hand = new Dictionary<int, Card>();
        }

        public void TakeCard(Card card)
        {
            Hand.Add(Hand.Count, card);
        }

        public Card GiveCard(int i)
        {
            Card temp = (Card)Hand[i].Clone();
            Hand.Remove(i);
            return temp;
        }

        public void Uno()
        {
            if (Hand.Count==1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("UNO!!!");
            }
        }

        public bool End()
        {
            if (Hand.Count == 0)
            {
                return true;
            }
            else return false;
        }

        public virtual Card Action(Card card)
        {
            Console.WriteLine("________________________________________");
            ShowHand();
            Console.WriteLine("Please choose card (enter number of card):");

            bool correct = false;
            int numberOfChosenCard=0;

            while (!correct)
            {
                Card chosenCard;
                int numberOfCard = int.Parse(Console.ReadLine().ToString());
                chosenCard = Hand[numberOfCard];
                if (card.Name == chosenCard.Name || card.Color == chosenCard.Color)
                {
                    correct = true;
                    numberOfChosenCard = numberOfCard;
                }
                else if (chosenCard.Name == "Wild" || chosenCard.Name == "WildDrawFour")
                {
                    bool correctColor = false;
                    while (!correctColor)
                    {
                        Console.WriteLine("Enter number of color: 1.Red 2.Yellow 3.Green 4.Blue");

                        if ("1" == Console.ReadLine())
                        {
                            chosenCard.Color = "Red";
                            correctColor = true;
                        }
                        else if ("2" == Console.ReadLine())
                        {
                            chosenCard.Color = "Yellow";
                            correctColor = true;
                        }
                        else if ("3" == Console.ReadLine())
                        {
                            chosenCard.Color = "Green";
                            correctColor = true;
                        }
                        else if ("4" == Console.ReadLine())
                        {
                            chosenCard.Color = "Blue";
                            correctColor = true;
                        }
                        else
                        {
                            Console.WriteLine("Enter correct number!!!");
                        }

                    }
                    correct = true;
                    numberOfChosenCard = numberOfCard;
                }
                else Console.WriteLine("Choose correct card!!!");               
            }
            return GiveCard(numberOfChosenCard);
        }

        public bool IsAction(Card card)
        {
            bool isCard = false;
            foreach (var item in Hand)
            {
                if (card.Name == item.Value.Name || card.Color == item.Value.Color)
                {
                    isCard = true;
                    break;
                }
                else if (item.Value.Name == "Wild" || item.Value.Name == "WildDrawFour")
                {
                    isCard = true;
                    break;
                }
                else isCard = false;
            }
            return isCard;
           
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
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (item.Value.Color == "Yellow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (item.Value.Color == "Green")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (item.Value.Color == "Blue")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (item.Value.Color == "White")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{item.Value.Name} {item.Value.Color} has {item.Value.Points} points." +
                        $" Position in deck is {item.Key }");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
    }
}
