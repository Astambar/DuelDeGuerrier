using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Class
{
    internal class Elfe : Guerrier
    {

        private object _focus;
        public string _name;

        public Guerrier Focus { get; set; }

        public Elfe(string name, int lifePoints, int attackDice, Guerrier focus)
            : base(name, lifePoints, attackDice)
        {
            Focus = focus;
        }
        public override int Tackle(int typeDice = 6)
        {

            Random dice = new Random();
            int rollOfDice = dice.Next(1, typeDice);
            if (Focus is Nain)
            {
                if (rollOfDice < 2)
                {
                    rollOfDice = 2;
                }
            }
            return rollOfDice + (Focus.GetLifePoints()/3);

        }
    }
}
