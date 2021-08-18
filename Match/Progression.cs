
namespace CouchParty.Tournament;


public class Progression {

    // <summary>
    // the current match
    // </summary>
    Match PrevMatch { get; set; }


    // <summary>
    // The next match after completing a match
    // </summary>
    Match NextMatch { get; set; }

    // <summary>
    // Is Progression Complete
    // </summary>
    bool IsCompleted { get; set; } = false;


    // <summary>
    // Number of opponents that advance to the next match
    // </summary>
    int NumOpponents { get; set; }


    //  Number of Opponents to Progress

    public Progression(Match prevMatch, Match nextMatch, int numOpponents = 1) =>
        (PrevMatch, NextMatch, NumOpponents) = (prevMatch, nextMatch, numOpponents);



    public void ProgressOpponents() {
        int offset = 0;

        if (IsCompleted == true) {
            return;
        }

            // Advance Opponents to the next Match
            // Advance 1 to many opponents
        var opps = PrevMatch.MatchResults.Skip(offset).Take(NumOpponents);

        foreach(var opp in opps) {
            NextMatch.AddOpponent(opp);
        }

            // Progression is Complete
        IsCompleted = true;
    }


    public override string ToString() => $"Next Match: {NextMatch.Id}";
}
