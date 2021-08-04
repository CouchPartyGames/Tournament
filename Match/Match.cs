
namespace CouchParty.Tournament {

    public enum MatchState {
        Ready = 0,
        InProgress,
        Completed
    }

    public interface IMatch {
        int Id { get; set; }

        MatchState State { get; set; }

        //Progression win;

        //Progression lose;
    }

}
