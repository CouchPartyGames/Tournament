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
                new Opponent(12, "George", 35),
                new Opponent(13, "Don", 95),
                new Opponent(14, "Obama", 75),
            };

            Tournament tournay = new Tournament(new TournamentSettings());

            foreach(Opponent opp in opps) {
                tournay.AddOpponent(opp);
            }

            //tournay.SetOpponents();
            tournay.Generate();


            Console.WriteLine("Ranked Order");
            OpponentOrderRank rank = new OpponentOrderRank(opps);
            //OpponentOrderRandom rank = new OpponentOrderRandom(opps);
            //Console.WriteLine($"Num Byes: {rank.NumByes}");
            //Console.WriteLine($"Draw Size: {rank.DrawSize}");

            foreach(KeyValuePair<int, Opponent> opponent in rank.OpponentsInOrder) {
                Console.WriteLine($"{opponent.Key} {opponent.Value.Name} {opponent.Value.Rank}");
            }


            /*
            MatchGenerator gen = new IndividualMatchGenerator(rank);
            foreach(IndividualMatch match in gen.MatchList) {
                Console.WriteLine($"{match}");
            }*/

            GroupMatchGenerator gen2 = new GroupMatchGenerator(rank);
            foreach(GroupMatch match in gen2.MatchList) {
                Console.WriteLine($"{match}");
            }

        }
    }
}


/*
app.MapGet("/tournament");
app.Run();
*/
