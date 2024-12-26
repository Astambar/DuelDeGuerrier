using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace app.Class
{
    internal class Nain:Guerrier
    {
        private bool _armureLourde;
        public string _name;

        public bool ArmureLourde { get; set; }

        public Nain(string name, int lifePoints, int attackDice, bool armureLourde)
            : base(name, lifePoints, attackDice)
        {
            ArmureLourde = armureLourde;
        }
        public override void TakeDamage(int damage)
        {
            if (ArmureLourde)
            {
                damage /= 2;
            }
            base.TakeDamage(damage);
        }
    }
}
