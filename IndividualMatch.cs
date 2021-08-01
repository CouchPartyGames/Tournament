

namespace CouchParty.Tournament {

    public class IndividualMatch : IMatch {

        public enum RoundId {
            Round128,
            Round64,
            Round32,
            Round16,
            Quarterfinals,
            Semifinals,
            Finals
        }

        public enum MatchState {
            Ready = 0,
            InProgress,
            Completed
        }


        public int Id { get; set; }
        public MatchState State { get; set; } = MatchState.Ready;
        public Opponent Opp1 { get; private set; }
        public Opponent Opp2 { get; private set; }
        public Opponent Winner { get; set; } 
        public RoundId Round { get; private set; }


        public IndividualMatch(int id, RoundId round) {
            Id = id;
            Round = round;
        }


        public IndividualMatch(int id, RoundId round, Opponent opp1, Opponent opp2) {
            Id = id;
            Round = round;

            SetOpponents(opp1, opp2);
        }

        public void SetOpponents(Opponent opp1, Opponent opp2) {
            Opp1 = opp1;
            Opp2 = opp2;
        }


        public void SetWinner(Opponent winner) {
            if (Winner == null) {
                if (winner.Id == Opp1.Id || winner.Id == Opp2.Id) {
                    State = MatchState.Completed;
                    Winner = winner;
                }
            }
        }



        public override string ToString() {
            return $"Match Id: {Id} {Opp1} vs {Opp2} {State.ToString()}";
        }
    }

}
