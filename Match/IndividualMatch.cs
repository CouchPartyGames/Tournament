

namespace CouchParty.Tournament {

    public class IndividualMatch : Match {


        public IndividualMatch(int id, RoundId round) : base(id, round) {
        }


        public IndividualMatch(int id, RoundId round, Opponent opp1, Opponent opp2) : base(id, round) {
            AddOpponent(opp1);
            AddOpponent(opp2);
        }

        // <summary>
        // Set Opponents of the Match
        // </summary>
        public void SetOpponents(Opponent opp1, Opponent opp2) {
            AddOpponent(opp1);
            AddOpponent(opp2);
        }


        public override void AddOpponent(Opponent opponent) {
            if (Opponents.Count >= 2) {
                return;
            }

            AddOpponent(opponent);
        }



        public override string ToString() {
            return $"Individual Match: {Id} {State.ToString()}";
        }

    }
}
