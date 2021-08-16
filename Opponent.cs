
namespace CouchParty.Tournament;


public interface IOpponent {
    int Id { get; set; }

    string Name { get; set; }

    int Rank { get; set; }
}


public class Opponent : IOpponent {

    public const int ByeRank = Int32.MaxValue;

    public const int NotRank = 888_888;

    public int Id { get; set; }

    public string Name { get; set; }

    public int Rank { get; set; }

    public bool IsBye { get; private set; }


    public Opponent(int id, string name, int rank = NotRank)
        => (Id, Name, Rank) = (id, name, rank); 


    public static bool operator ==(Opponent o1, Opponent o2)
        => (o1.Id) == (o2.Id);

    public static bool operator !=(Opponent o1, Opponent o2) 
        => (o1.Id) != (o2.Id);


    public Opponent(int id, string name, bool isBye) {
        Id = id;
        Name = name;
        IsBye = isBye;
        Rank = isBye ? ByeRank : NotRank;
    }


    public override string ToString() {
        return $"{Name} ({Id})";
    }
}
