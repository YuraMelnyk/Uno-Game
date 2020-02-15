using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame.Model;

namespace UnoGame.Controller
{
    public class Bot : Player
    {
        public Bot(string name) : base (name)
        {
            Name = name;
            Hand = new Dictionary<int, Card>();
        }
    }
}
