
namespace CouchParty.Tournament;


public enum MatchState {
        // All Opponents are ready
    Ready = 0,

        // All Opponents are accounted for on the dedicated server 
    OpponentsRegistered,

        // Match Started on dedicated server
    Started,

        // match is in progress
    InProgress,

        // Completed
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

    public List<Opponent> Opponents { get; protected set; }

    public List<Opponent> MatchResults { get; set; }


    public Match(int id, RoundId round) {
        Id = id;
        Round = round;

        Progressions = new List<Progression>();
        Opponents = new List<Opponent>();
        MatchResults = new List<Opponent>();
    }


    public static bool operator ==(Match m1, Match m2) 
        => (m1.Id) == (m2.Id);
    
    public static bool operator !=(Match m1, Match m2) 
        => (m1.Id) != (m2.Id);


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
