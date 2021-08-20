
namespace CouchParty.Tournament;


public enum ProgressionType {
    Win,
    Lose
}


public class Progression {

    // <summary>
    // the current match
    // </summary>
    Match PrevMatch { get; }


    // <summary>
    // The next match after completing a match
    // </summary>
    Match NextMatch { get;  }

    // <summary>
    // Is Progression Complete
    // </summary>
    bool IsCompleted { get { return isCompleted; } } 
    bool isCompleted;


    // <summary>
    // Number of opponents that progress to the next match
    // </summary>
    int NumOpponents { get; }


    // <summary>
    // Where to start advancing opponents in a match
    // </summary>
    int Offset { get; }



    public Progression(Match prevMatch, Match nextMatch, int numOpponents = 1, int offset = 0) {
        PrevMatch = prevMatch;
        NextMatch = nextMatch;

        NumOpponents = numOpponents;
        Offset = offset;
        isCompleted = false;
    }



    public void ProgressOpponents() {
        if (isCompleted == true) {
            return;
        }

            // Advance Opponents to the next Match
            // Advance 1 to many opponents
        var opponents = PrevMatch.MatchResults.Skip(Offset).Take(NumOpponents);

        foreach(var opponent in opponents) {
            NextMatch.AddOpponent(opponent);
        }

            // Progression is Complete
        isCompleted = true;
    }


    public override string ToString() => $"Next Match: {NextMatch.Id}";
}
