
namespace CouchParty.Tournament {


    public class Progression {

        // <summary>
        // The next match after completing a match
        // </summary>
        IMatch NextMatch { get; set; }

        // <summary>
        // Is Progression Complete
        // </summary>
        bool IsCompleted { get; set; } = false;


        //  Number of Opponents to Progress

        public Progression(IMatch nextMatch) {
            NextMatch = nextMatch;
        }
    }
}
