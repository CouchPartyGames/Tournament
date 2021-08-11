
namespace CouchParty.Tournament.Preset {

    public class DoubleElimination : Tournament {

        public DoubleElimination(TournamentSettings settings) : base(settings) {
        }


        // <summary>
        // Generate All Matches in the Draw
        // </summary>
        public override void Generate() {
            int numMatchesInRound = 0; 
            int id = 100;

            Round prevRound = null;
            Match prevMatch1 = null;
            Match prevMatch2 = null;

                // order all opponents in the draw (doesn't include byes)
            IOpponentOrder orderedOpponents = OpponentOrder.Factory(Opponents, Order);

                // Generate Matches for First Round (adds byes)
            MatchGenerator gen = MatchGenerator.Factory(orderedOpponents, Mode);

                // Get the Total Num of Rounds in Tournament
            int totalRounds = (int)Math.Log2((double) gen.DrawSize);

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
            for(int roundId = 2; roundId <= totalRounds; roundId++) {

            }

        }


        // <summary>
        // Generate Winning Side Bracket
        // </summary>
        public void GenerateWinningBracket() {
            throw new NotImplementedException();
        }


        // <summary>
        // Generate Losing side of Bracket
        // </summary>
        public void GenerateLosingBracket() {
            throw new NotImplementedException();
        }
    }
}
