
namespace CouchParty.Tournament.Preset {

    public class SingleElimination : Tournament {

        public SingleElimination(TournamentSettings settings) : base(settings) {
        }

        public override void Generate() {
            var order = 1;
            
                // Order Opponents in the draw
            //var rank = order == 1 ? new OpponentOrderRank(Opponents) : new OpponentOrderRandom(Opponents);
            IOpponentOrder rank = 1 == 1 ? new OpponentOrderRank(Opponents) : new OpponentOrderRandom(Opponents);


                // Generate Matches for First Round
            MatchGenerator gen = 1 == 1 ? new IndividualMatchGenerator(rank) : new GroupMatchGenerator(rank);

            foreach(var match in gen.MatchList) {
                Console.WriteLine($"{match}");
            }

            
            int numRounds = (int)Math.Log2((double)gen.DrawSize) ;
            Console.WriteLine($"Num Rounds: {numRounds}");


            for(int round = numRounds - 1; round >= 1; round--) {
                Console.WriteLine(round);
                //Round round = new Round();

/*                    
                for(int match = 1; match <= ; match++) {

                        // New Match
                    IndividualMatch match = new IndividualMatch();

                        // Get Previous Matches 
                    IndividualMatch prevMatch1 = ;
                    IndividualMatch prevMatch2 = ; 

                        // Previous Round's Match to progress to this match
                    prevMatch1.SetProgression(match);
                    prevMatch2.SetProgression(match);

                }
*/

            }
        }
    }
}
