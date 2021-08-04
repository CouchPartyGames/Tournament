
namespace CouchParty.Tournament.Preset {

    public class SingleElimination : Tournament {

        public SingleElimination(TournamentSettings settings) : base(settings) {
        }


        public override void Generate() {
            var order = 1;
            int numMatchesInRound = 0; 
            int numRounds = 0;
            int id = 100;
            
                // order all opponents in the draw (doesn't include byes)
            IOpponentOrder orderedOpponents = 1 == 1 ? new OpponentOrderRank(Opponents) : new OpponentOrderRandom(Opponents);


                // Generate Matches for First Round (adds byes)
            MatchGenerator gen = 1 == 1 ? new IndividualMatchGenerator(orderedOpponents) : new GroupMatchGenerator(orderedOpponents);

            foreach(var match in gen.MatchList) {
                Console.WriteLine($"{match}");
            }
            
                // Get the Total Num of Rounds in this tournament
            numRounds = (int)Math.Log2((double) gen.DrawSize) ;


            List<IndividualMatch> someMatches = new List<IndividualMatch>();
            IMatch nextMatch = new IndividualMatch(id, 0);

            /*
            for(int round = 2; round <= numRounds; round++) {
                //Round round = new Round();

                    // Find the number of matches in this round
                numMatchesInRound = (int)gen.DrawSize / (int)Math.Pow(2, round);
                
                Console.WriteLine($"round: {round} matches; {numMatchesInRound}");
                for(int matchId = 1; matchId <= numMatchesInRound; matchId++) {

                        // create a match for this round
                    nextMatch = new IndividualMatch(id, (RoundId)round);

                    //IndividualMatch prevMatch1 = ;
                    //IndividualMatch prevMatch2 = ; 
                    
                        // set the progression
                    prevMatch1.SetProgression( new Progression() { NextMatch = nextMatch } );
                    prevMatch2.SetProgression( new Progression() { NextMatch = nextMatch } );


                    id++;
                }

            }*/
        }
    }
}
