using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Class
{
    internal class Tournoi
    {
        //Initialisation des participants
        private List<Guerrier> _participants;
        //Contrainte du duel
        private int _duelDurationLimit;
        //Gestions des participants
        private List<Guerrier> _warriorStillInTheFight;
        private List<Guerrier> _warriorLoser;

        public List<Guerrier> Participants { get { return _participants; } set { _participants = value; } }
        public int DuelDurationLimit { get { return _duelDurationLimit; } set { _duelDurationLimit = value; } }
        public Tournoi(List<Guerrier> participants, int duelDurationLimit)
        {
            _participants = participants;
            _duelDurationLimit= duelDurationLimit;
        }
        public void StartOfTheTournament()
        {
            _warriorStillInTheFight = _participants;
            int counterWarior;
            Duel fight;
            do
            {
                // Gestion du participant impaire
                // Faire affronter le moins bon dans ce cas avec le meilleur
                counterWarior = _warriorStillInTheFight.Count();
                if ( counterWarior <= 1)
                {
                    if (counterWarior % 2 != 0)
                    {
                    for (int i=0; i <= counterWarior; i += 2)
                    {
                            if (i + 1 == counterWarior)
                            {
                                fight = new Duel(new Tuple<Guerrier, Guerrier>(_warriorStillInTheFight[0], _warriorStillInTheFight[i + 1]),5);
                                fight.StartDuel();
                                
                            }

                    }

                    }
                    else
                    {
                        for (int i = 0; i < counterWarior; i += 2)
                        {

                        }
                    }


                }
                else
                {
                    Console.WriteLine($"Le Grand Gagnant de ce tournoi est {_warriorStillInTheFight[0].GetName()} Félicitation avec tes {_warriorStillInTheFight[0].Score}");
                    break;
                }
               _warriorStillInTheFight = _warriorStillInTheFight.OrderByDescending(warrior => warrior.Score).ToList();
                _warriorLoser.Add(_warriorStillInTheFight.Last());
               _warriorStillInTheFight.Remove(_warriorStillInTheFight.Last());
            } while(true);
        }
    }
}
