namespace CouchParty.Tournament;

public enum BracketType {

    Winner,

    Consolation,

    WinnerVsConsolidation
}


public class Bracket {

    public int Id { get; init; }

    public string Name { get; init; }

    List<Round> Rounds = new List<Round>();

    BracketType Type;


    public Bracket(int id, string name, BracketType type) 
        => (Id, Name, Type) = (id, name, type);


    public void AddRound(Round round) {
        Rounds.Add(round);
    }


    public override string ToString() => "${Name} {Type.ToString()}";
}
