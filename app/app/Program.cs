using app.Class;

Nain Durin = new Nain("Durin", 15, 6, true);
Elfe Elrond = new Elfe("Elrond", 15, 6, Durin);

Duel DurinVsElrond = new Duel(new Tuple<Guerrier, Guerrier>(Durin, Elrond), 5);

Console.WriteLine(DurinVsElrond.StartDuel());