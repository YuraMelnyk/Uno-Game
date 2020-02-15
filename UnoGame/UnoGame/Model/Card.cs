using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame.Model
{
    public class Card : ICloneable
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Points { get; set; }

        public Card() { }
        

        public Card(string name, string color, int points)
        {
            Name = name;
            Color = color;

            if (points == 10 || points == 11 || points == 12)
            {
                Points = 20;
            }
            else Points = points;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
