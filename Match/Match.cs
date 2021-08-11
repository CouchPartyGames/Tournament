
namespace CouchParty.Tournament {

    public enum MatchState {
        Ready = 0,
        InProgress,
        Completed
    }

    public interface IMatch {

        int Id { get; set; }

        MatchState State { get; set; }

        List<Progression> Progressions { get; set; }

        void AddProgression(Progression progression);

    }



    public abstract class Match : IMatch {

        public int Id { get; set; }

        public RoundId Round { get; private set; }

        public MatchState State { get; set; }

        public List<Progression> Progressions { get; set; }

        public List<Opponent> Opponents { get; set; }

        public List<Opponent> MatchResults { get; set; }


        public Match(int id, RoundId round) {
            Id = id;
            Round = round;

            Progressions = new List<Progression>();
            Opponents = new List<Opponent>();
            MatchResults = new List<Opponent>();
        }


        // <summary>
        // </summary>
        public virtual void AddOpponent(Opponent opponent) {
            Opponents.Add(opponent);
        }


        // <summary>
        // </summary>
        public virtual void SetResults(List<Opponent> results) {
            if (State == MatchState.Completed) {
                return ;
            }

            MatchResults = results;
            State = MatchState.Completed;

            foreach(var progress in Progressions) {
                progress.ProgressOpponents();
            }
        }

        // <summary>
        // Add a match progression
        // </summary>
        public void AddProgression(Progression progression) {
            Progressions.Add(progression);
        }
    }
}
