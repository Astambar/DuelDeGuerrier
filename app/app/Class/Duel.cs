using System;

namespace app.Class
{
    internal class Duel
    {
        private Tuple<Guerrier, Guerrier> _duelists;
        private Tuple<int, int> _score;
        private int _nombreManche;
        private int _countManche = 0;

        public Tuple<Guerrier, Guerrier> Duelists { get { return _duelists; } set { _duelists = value; } }
        public Tuple<int, int> Score { get { return _score; } }
        public int NombreManche { get { return _nombreManche; } set { _nombreManche = value; } }

        public Duel(Tuple<Guerrier, Guerrier> duelists, int nombreManche)
        {
            Duelists = duelists;
            NombreManche = nombreManche;
            _score = new Tuple<int, int>(0, 0);
        }

        public void StartManche(Tuple<int, int> orderOfBattles)
        {
                if (orderOfBattles.Item1 == 0)
                {
                    Duelists.Item2.TakeDamage(Duelists.Item1.Tackle());
                    Duelists.Item1.TakeDamage(Duelists.Item2.Tackle());
                }
                else if (orderOfBattles.Item2 == 0)
                {
                    Duelists.Item1.TakeDamage(Duelists.Item2.Tackle());
                    Duelists.Item2.TakeDamage(Duelists.Item1.Tackle());
                }

                _countManche++;

        }

        public Tuple<int,int> StartDuel()
        {
            Random random = new Random();
            int num1 = random.Next(0,2);
            int num2;
            Tuple<int, int> tempscore;
            if (num1 == 0)
            {
                num2 = 1;
            }
            else
            {
                num2 = 0;
            }
            while(_countManche < NombreManche)
            {
                StartManche(new Tuple<int,int>(num1,num2));
                if (Duelists.Item2.GetLifePoints() == 0)
                {
                    Console.WriteLine("Duelist 2 0 LifePoint");
                    if(Duelists.Item1.GetLifePoints() == 0)
                    {
                        _score = new Tuple<int, int>(Score.Item1 + 1, Score.Item2 + 1);
                        Console.WriteLine("Duelist 1 idem 0 LifePoint");
                    }
                    else
                    {
                        _score = new Tuple<int, int>(Score.Item1 + 2, Score.Item2);
                        Console.WriteLine("Le  Duelist 2 à perdu");
                    }
                    break;
                }
                else if (Duelists.Item1.GetLifePoints() == 0)
                {
                    _score = new Tuple<int, int>(Score.Item1, Score.Item2 + 2);
                    Console.WriteLine("Duelist 1 à perdu");
                    break;
                }
            }
            if (_score.Item1 == 0 && _score.Item2 == 0)
            {
                if(Duelists.Item1.GetLifePoints() > 0 && Duelists.Item2.GetLifePoints() > 0)
                {
                    Console.WriteLine("Egalité des 2 duelist");
                    _score = new Tuple<int, int>(_score.Item1 + 1, _score.Item2 + 1);
                }
                else
                {
                    Console.WriteLine("Il y à eu un Bug");
                }
            }
            _countManche=0;
            tempscore = _score;
            _score = new Tuple<int, int>(0, 0);
            return tempscore;
        }
    }
}
