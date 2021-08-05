
namespace CouchParty.Tournament {

    public class GroupMatch : Match {


        public Dictionary<int,Opponent> Opponents { get; private set; }


        public int MinOpponents { get; set; } = 2;

        public int MaxOpponents { get; set; } = 4;

        public int NumWinners { get; set; } = 1;


        public Dictionary<int,Opponent> winners = new Dictionary<int, Opponent>();



        public GroupMatch(int id, RoundId round) : base(id, round) {
        }


        public bool AddOpponent(Opponent opponent) {
            if (Opponents.Count < MaxOpponents) {

                Opponents.TryAdd(opponent.Id, opponent);
                return true;
            }

            return false;
        }


        public void SetWinners(Dictionary<int, Opponent> opponents) {
            winners = opponents;
            this.State = MatchState.Completed;
        }


        public override string ToString() {
            var sb = new System.Text.StringBuilder();
            sb.Append( $"Group Match Id: {Id} Opponents:");
            foreach(KeyValuePair<int, Opponent> opponent in Opponents) {
                sb.Append( $" {opponent.Value.Name}{opponent.Value.Id} ");
            }
            return sb.ToString();
        }


    }

}
