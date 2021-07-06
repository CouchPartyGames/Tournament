using System;
using System.Collections.Generic;

namespace CouchParty.Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Opponent> opps = new List<Opponent>() {
                new Opponent(1, "Bill"),
                new Opponent(2, "Bob"),
                new Opponent(3, "Steve"),
                new Opponent(4, "Greg", 3),
                new Opponent(5, "Jeter", 7),
                new Opponent(6, "Carter", 9),
                new Opponent(7, "Aaron", 2),
                new Opponent(8, "Tom", 4),
                new Opponent(9, "Carl", 5),
                new Opponent(10, "Rick", 15),
                new Opponent(11, "Will", 25),
            };

            Tournament tournay = new Tournament(new TournamentSettings());

            foreach(Opponent opp in opps) {
                tournay.AddOpponent(opp);
            }

            //tournay.SetOpponents();
            tournay.Generate();


            Console.WriteLine("Ranked Order");
            OpponentOrderRank rank = new OpponentOrderRank(opps);
            Console.WriteLine($"Num Byes: {rank.NumByes}");
            Console.WriteLine($"Draw Size: {rank.DrawSize}");

            foreach(KeyValuePair<int, Opponent> entry in rank.OpponentsInOrder) {
                Console.WriteLine($"{entry.Key} {entry.Value.Name} {entry.Value.Rank}");
            }


            /*
            Console.WriteLine("");
            OpponentOrderRandom rank2 = new OpponentOrderRandom(opps);
            Console.WriteLine("Random Order");
            Console.WriteLine($"Num Byes: {rank2.NumByes}");
            Console.WriteLine($"Draw Size: {rank.DrawSize}");

            foreach(KeyValuePair<int, Opponent> entry in rank2.OpponentsInOrder) {
                Console.WriteLine($"{entry.Key} {entry.Value.Name} {entry.Value.Rank}");
            }*/


            MatchGenerator gen = new MatchGenerator(rank);
            foreach(Match match in gen.MatchList) {
                Console.WriteLine($"{match}");
            }

        }
    }
}


/*
app.MapGet("/tournament");
app.Run();
*/
