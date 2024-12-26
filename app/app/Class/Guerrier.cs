using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Class
{
    internal class Guerrier
    {
        //Different type de dés initialiser
        // Reflechir a la version  tronquer des variable exemple juste d20
        const int d20_icosahedron = 20;
        const int d12_dodecahedron = 12;
        const int d10_decahedron = 10;
        const int d8_octahedron = 8;
        const int d6_cube = 6;
        const int d4_tetrahedron = 4;


        private string _name;
        private int _lifePoints;
        private int _attackDice;

        public string Name { get ; set; } = "Missing No";
        public int LifePoints { get; set; }
        public int AttackDice { get; set;}

        public Guerrier(string name, int lifePoints, int attackDice)
        {
            Name = name;
            LifePoints = lifePoints;
            AttackDice = attackDice;
        }

        public string GetName()
        { return _name; }
        public int GetLifePoints() { return _lifePoints; }
        public void SetLifePoints(int lifePoints) { _lifePoints = lifePoints; }
        public int GetAttackDice()
            { return _attackDice; }
        public virtual int Tackle(int typeDice = d6_cube)
        {
            Random dice = new Random();
            int rollOfDice = dice.Next(1, typeDice);

            return rollOfDice;
        }
        public virtual void TakeDamage(int damage)
        {
            if (LifePoints - damage < 0)
            { SetLifePoints(0); }
            else
            { SetLifePoints(LifePoints - damage); }
        }


    }
}
