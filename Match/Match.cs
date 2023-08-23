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

        // match is completed
    Completed
}



public enum MatchMode {
        // Match only has 2 Opponents 
    OneVsOne,
        // Multiple Opponents in the Match
    Group
}


public interface IMatch {

    int Id { get; set; }

    MatchState State { get; set; }

}


public sealed class NoMatch : Match {

    public NoMatch(int id, RoundId round) : base(id, round) {
    }

    public void SetResults(List<Opponent> results) {
    }
}

public abstract class Match : IMatch {

    // Id of the match
    public int Id { get; set; }

    // Round - Is this needed
    public RoundId Round { get; private set; }

    // State of the Match
    public MatchState State { get; set; }

	public IProgression WinProgression { get ; protected set; }
	public IProgression LoseProgression { get ; protected set; }

    // List of Opponents in the match
    public List<Opponent> Opponents { get; protected set; }

    // Results of the completed match ordered from highest score (winner) to lowest score (loser)
    public List<Opponent> MatchResults { get; set; }
    //public SortedList<int, Opponent> MatchResults { get; set; }


    public int MinOpponents { get; set; }

    public int MaxOpponents { get; set; }

    public int NumWinners { get; set; } 


    public Match(int id, RoundId round) {
        Id = id;
        Round = round;

        Opponents = new List<Opponent>();
        MatchResults = new List<Opponent>();
        WinProgression = new NoProgression();
        LoseProgression = new NoProgression();
    }



    public static bool operator ==(Match m1, Match m2) 
        => (m1.Id) == (m2.Id);
    
    public static bool operator !=(Match m1, Match m2) 
        => (m1.Id) != (m2.Id);


    public override bool Equals(object obj) {
        throw new NotImplementedException();
        /*if (ReferenceEquals(null, obj)) {
            return false;
        } else if (ReferenceEquals(this, obj)) {
            return true;
        }
        */
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

        if (WinProgression != null) {
            WinProgression.ProgressOpponents();
        }
        if (LoseProgression != null) {
            LoseProgression.ProgressOpponents();
        }
        /*foreach(var progress in Progressions) {
            progress.ProgressOpponents();
        }*/
    }


	public void SetProgressions(IProgression win, IProgression lose = null) {
		WinProgression = win;
        LoseProgression = lose;
    }

}
