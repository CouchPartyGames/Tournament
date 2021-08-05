
namespace CouchParty.Tournament.Preset {

    public class DoubleElimination : Tournament {

        public DoubleElimination(TournamentSettings settings) : base(settings) {
        }


        // <summary>
        // Generate All Matches in the Draw
        // </summary>
        public override void Generate() {
/*            var order = 1;
            int numMatches = 0; 
            int numRounds = 0;
            int id = 100;

                // Order Opponents in the draw
            //var rank = order == 1 ? new OpponentOrderRank(Opponents) : new OpponentOrderRandom(Opponents);
            IOpponentOrder rank = 1 == 1 ? new OpponentOrderRank(Opponents) : new OpponentOrderRandom(Opponents);


                // Generate Matches for First Round
            MatchGenerator gen = 1 == 1 ? new IndividualMatchGenerator(rank) : new GroupMatchGenerator(rank);*/
        }


        // <summary>
        // Generate Winning Side Bracket
        // </summary>
        public void GenerateWinningBracket() {

        }


        // <summary>
        // Generate Losing side of Bracket
        // </summary>
        public void GenerateLosingBracket() {

        }
    }
}
