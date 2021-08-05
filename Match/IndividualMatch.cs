

namespace CouchParty.Tournament {

    public class IndividualMatch : Match {

        public Opponent Opp1 { get; private set; }

        public Opponent Opp2 { get; private set; }


        public Opponent Opponents { get; private set; }

        
        // <summary>
        // Results of the Match Ordered from 1st to last place
        // </summary>
        //List<Opponent> OpponentResults { get; private set; }



        public IndividualMatch(int id, RoundId round) : base(id, round) {
        }


        public IndividualMatch(int id, RoundId round, Opponent opp1, Opponent opp2) : base(id, round) {
            SetOpponents(opp1, opp2);
        }

        // <summary>
        // Set Opponents of the Match
        // </summary>
        public void SetOpponents(Opponent opp1, Opponent opp2) {
            Opp1 = opp1;
            Opp2 = opp2;
        }

        public virtual void AddOpponent(Opponent opponent) {
            if (Opp1 == null) {
                Opp1 = opponent;
            } else {
                Opp2 = opponent;
            }
            Console.WriteLine($"Set Opponent: {this}");
        }

        // <summary>
        // Set Winner of the Match
        // winner   Opponent that won
        // </summary>
        public void SetWinner(Opponent winner) {
            if (Winner == null) {

                if (winner.Id == Opp1.Id || winner.Id == Opp2.Id) {
                    State = MatchState.Completed;
                    Winner = winner;
                }

                foreach(var progress in Progressions) {
                    progress.ProgressOpponents();
                }
                    // Set Next Match For Winner
                //IMatch winnerNextMatch = WinProgression.NextMatch;
                //nextMatch.SetOpponent(winner, 0);


                //nextMatch.SetOpponent(winner, 0);
                
            }

        }



        public override string ToString() {
            //return $"Match Id: {Id} {Opp1} vs {Opp2} {State.ToString()} {WinProgression}";
            return $"Match Id: {Id} {Opp1} vs {Opp2} {State.ToString()}";
        }

    }
}
