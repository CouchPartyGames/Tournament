
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

    public string Name { get; set; }

    public int Id { get; set; }

    public bool IsCompleted { get; set; } = false;

        // Start Time for the Tournament
    public DateTime? StartDate { get; set; } = null;

        // All Opponents
    public List<Opponent> Opponents { get; protected set; }

        // Rounds
    public List<Round> Rounds { get; set; }
    //public Dictionary<int, Round> Rounds { get; set; }

    public TournamentSettings Settings { get; private set; }


    public DrawOrderType Order { get; set; }

    public BracketMode Mode { get; set; }



    public Tournament(TournamentSettings settings) {
        Settings = settings;

        Rounds = new List<Round>();
        Opponents = new List<Opponent>();
        Order = DrawOrderType.SeededDraw;
        Mode = BracketMode.Individual;
    }

    public void SetOpponents(List<Opponent> opps) {
        Opponents = opps;
    }


    public void AddOpponent(Opponent opp1) {
        try {
            Opponents.Add(opp1);
        } catch(ArgumentException) {
        }
    }


    public virtual void Generate() {
    }


    public override string ToString() {
        return $"Name: {Name}\nNum Opponents: {Opponents.Count}";
    }
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

