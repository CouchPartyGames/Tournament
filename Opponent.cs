
namespace CouchParty.Tournament;


public interface IOpponent {

    // Opponent id
    int Id { get; }

    string Name { get; }

    int Rank { get; }
}



public sealed class Opponent : IOpponent {

    public const int ByeRank = Int32.MaxValue;

    public const int NotRank = Int32.MaxValue - 1;


    public int Id { get; private set; }

    public string Name { get; private set; }

    public int Rank { get; private set; }

    public bool IsBye { get; private set; }


    public Opponent(int id, string name, int rank = NotRank)
        => (Id, Name, Rank) = (id, name, rank); 


    public static bool operator ==(Opponent o1, Opponent o2)
        => (o1.Id) == (o2.Id);

    public static bool operator !=(Opponent o1, Opponent o2) 
        => (o1.Id) != (o2.Id);


    public Opponent(int id, string name, bool isBye, int rank) {
        Id = id;
        Name = name;
        IsBye = isBye;
        Rank = rank;
    }

	public static Opponent CreateUnranked(int id, string name) {
		return new Opponent(id, name, false, NotRank);	
	}

	public static Opponent CreateBye(int id, string name) {
		return new Opponent(id, name, true, ByeRank);	
	}


    public override string ToString() => $"{Name} ({Id})";
}
