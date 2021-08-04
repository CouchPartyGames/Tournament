
namespace CouchParty.Tournament {

    public class GroupMatch : IMatch {

        public int Id { get; set; }

        public Dictionary<int,Opponent> opponents = new Dictionary<int, Opponent>();

        public MatchState State { get; set; } = MatchState.Ready;

        public int MinOpponents { get; set; } = 2;

        public int MaxOpponents { get; set; } = 4;

        public int NumWinners { get; set; } = 1;

        public RoundId Round { get; private set; }

        public Dictionary<int,Opponent> winners = new Dictionary<int, Opponent>();


        public GroupMatch(int id, RoundId round) {
            Id = id;
            Round = round;
        }


        public bool AddOpponent(Opponent opp) {
            if (opponents.Count < MaxOpponents) {

                opponents.TryAdd(opp.Id, opp);
                return true;
            }

            return false;
        }


        public void SetWinners(Dictionary<int, Opponent> opps) {
            winners = opps;
            this.State = MatchState.Completed;
        }


        public override string ToString() {
            var sb = new System.Text.StringBuilder();
            sb.Append( $"Group Match Id: {Id} Opponents:");
            foreach(KeyValuePair<int, Opponent> opponent in opponents) {
                sb.Append( $" {opponent.Value.Name}{opponent.Value.Id} ");
            }
            return sb.ToString();
        }
    }

}
