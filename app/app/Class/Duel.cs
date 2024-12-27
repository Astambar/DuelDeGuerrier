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
            if (_countManche < NombreManche)
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

                if (Duelists.Item2.GetLifePoints() == 0 && Duelists.Item1.GetLifePoints() == 0)
                {
                    _score = new Tuple<int, int>(Score.Item1 + 1, Score.Item2 + 1);
                }
                else if(Duelists.Item2.GetLifePoints() == 0)
                {
                    _score = new Tuple<int, int>(Score.Item1 + 2, Score.Item2);
                }
                else if (Duelists.Item1.GetLifePoints() == 0)
                {
                    _score = new Tuple<int, int>(Score.Item1, Score.Item2 + 2);
                }
                    _countManche++;

            }

        }
        public void StartDuel()
        {
            for (int coun
        }
    }
}
