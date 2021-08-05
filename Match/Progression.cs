
namespace CouchParty.Tournament {


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

        public Progression(Match prevMatch, Match nextMatch, int numOpponents = 1) {
            PrevMatch = prevMatch;
            NextMatch = nextMatch;
            NumOpponents = numOpponents;
        }


        public override string ToString() {
            return $"Next Match: {NextMatch.Id}";
        }


        public void ProgressOpponents() {
            if (IsCompleted == true) {
                return;
            }

                // Advance Opponents to the next Match
                // Advance 1 to many opponents

                // 
            NextMatch.AddOpponent(PrevMatch.Winner);

            Console.WriteLine($"Prev Match: {PrevMatch}");
            Console.WriteLine($"Next Match: {NextMatch}");

                // Progression is Complete
            IsCompleted = true;
        }
    }
}
