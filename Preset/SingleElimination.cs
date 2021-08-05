
namespace CouchParty.Tournament.Preset {

    public class SingleElimination : Tournament {

        public SingleElimination(TournamentSettings settings) : base(settings) {
        }


        public override void Generate() {
            int numMatchesInRound = 0; 
            int id = 100;

            Round prevRound = null;
            Match prevMatch1 = null;
            Match prevMatch2 = null;

            Match nextMatch = null;
            
                // order all opponents in the draw (doesn't include byes)
            IOpponentOrder orderedOpponents = OpponentOrder.Factory(Opponents, Order);

                // Generate Matches for First Round (adds byes)
            MatchGenerator gen = MatchGenerator.Factory(orderedOpponents, BracketMode.Individual);
            //MatchGenerator gen = MatchGenerator.Factory(orderedOpponents, BracketMode.Group);


                // Get the Total Num of Rounds in this tournament
            int numRounds = (int)Math.Log2((double) gen.DrawSize) ;

                // Add 1st Round
            Round round = new Round() {
                Id = 1,
                Name = "Round 1"
            };

                // Add Matches for the First Round
            foreach(var match in gen.MatchList) {
                round.AddMatch(match);
            }
            Rounds.Add(round);
            


                // All Additional Rounds
            for(int roundId = 2; roundId <= numRounds; roundId++) {

                round = new Round() { 
                    Id = roundId,
                    Name = $"Round {roundId}"
                };

                    // Find the number of matches in this round
                numMatchesInRound = (int)gen.DrawSize / (int)Math.Pow(2, roundId);
                
                prevRound = Rounds[roundId - 2];

                for(int matchId = 1; matchId <= numMatchesInRound; matchId++) {

                        // create a match for this round
                    nextMatch = new IndividualMatch(id, (RoundId)roundId);

                    prevMatch1 = prevRound.Matches[(matchId * 2) - 2];
                    prevMatch2 = prevRound.Matches[(matchId * 2) - 1]; 

                        // Single Elimination means there is only one progression, winner(s) advance
                    prevMatch1.AddProgression(new Progression( prevMatch1, nextMatch ));
                    prevMatch2.AddProgression(new Progression( prevMatch2, nextMatch ));

                    round.AddMatch(nextMatch);

                    id++;
                }

                Rounds.Add(round);
            }
        }
    }
}
