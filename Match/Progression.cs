namespace CouchParty.Tournament;


public class Progression : IProgression {

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
    int NumAdvancing { get; }


    // <summary>
    // Where to start advancing opponents in a match
    // </summary>
    public int Offset { get; }


    public Progression() {
        PrevMatch = new IndividualMatch(0,0);
        NextMatch = new IndividualMatch(0,0);
        NumAdvancing = 0;
        Offset = 0;
        isCompleted = false;
    }

    public Progression(Match nextMatch, int numOpponents, int offset = 0) {
        NextMatch = nextMatch;

        NumAdvancing = numOpponents;
        Offset = offset;
        isCompleted = false;
    }

    public Progression(Match prevMatch, Match nextMatch, int numOpponents = 1, int offset = 0) {
        PrevMatch = prevMatch;
        NextMatch = nextMatch;

        NumAdvancing = numOpponents;
        Offset = offset;
        isCompleted = false;
    }



    public void ProgressOpponents() {
        if (isCompleted == true ) {
            return;
        }
            // Advance Opponents to the next Match
            // Advance 1 to many opponents
        Console.WriteLine($"progress - {PrevMatch} {Offset} {NumAdvancing}");
        var opponents = PrevMatch.MatchResults.Skip(Offset).Take(NumAdvancing).ToList();

        if (opponents.Count == 0) {
            Console.WriteLine("No Opponents to progress");
        }

        foreach(var opponent in opponents) {
            NextMatch.AddOpponent(opponent);
        }

            // Progression is Complete
        isCompleted = true;
    }


    public override string ToString() => $"Next Match: {NextMatch.Id}  ";
}
