namespace CouchParty.Tournament;


public enum DrawOrderType {
    BlindDraw,
    SeededDraw
}

public enum BracketMode {
    Individual,
    Group
}


public class Tournament {

    public int Id { get; private set; }

    public string Name { get; private set; }

    public bool IsCompleted { get; set; } = false;

        // Start Time for the Tournament
    public DateTime? StartDate { get; set; } = null;

        // All Opponents
    public List<Opponent> Opponents { get; private set; }

        // Rounds
    public List<Round> Rounds { get; set; }

    public DrawOrderType Order { get; set; }

    public BracketMode Mode { get; set; }

	public uint DrawSize { get; private set; }

	public uint NumRounds { get; private set; }


    protected Tournament(int id,
		string name,
		List<Opponent> opps) {

		Id = id;
		Name = name;
		Opponents = opps;

		if (Opponents.Count < 2) {
			throw new InvalidOperationException("Bad number of participants for tournament");
		}

		DrawSize = BitOperations.RoundUpToPowerOf2((uint)Opponents.Count);
		NumRounds = (uint)Math.Log2((double) DrawSize) ;

        Rounds = new List<Round>();
        Order = DrawOrderType.SeededDraw;
        Mode = BracketMode.Individual;
    }


    public virtual void Generate() {
    }


    public override string ToString() =>  $"Name: {Name}\nNum Opponents: {Opponents.Count}";
}


public class TournamentSettings {

    public enum EliminationMode {
        Single = 1,
        Double,
        Triple
    }


    public bool IsSeeded { get; set; }

    public int TotalSeeds { get; set; }

    public EliminationMode Elimination { get; set; }

    public BracketMode Mode { get; set; } = BracketMode.Individual;

    public int MaxOpponents { get; set; }

    public TournamentSettings() {
        Elimination = EliminationMode.Single;
    }
}



public class GroupSettings {
    public int minOpponents;
    public int maxOpponents;

    public int numToAdvance;

    public GroupSettings() {
        minOpponents = 2;
        maxOpponents = 4;
        numToAdvance = 2;
    }
}

