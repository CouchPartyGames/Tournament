namespace CouchParty.Tournament;

public enum RoundId {
    Finals = 0,
    Semifinals,
    Quarterfinals,
    RoundOf16,
    RoundOf32,
    RoundOf64,
    RoundOf128
}


public class Round {

    public int Id { get; init; }

    public string Name { get; init; }

    public bool IsCompleted { get; set; } = false;

    //public Dictionary<int, IMatch> Matches = new Dictionary<int, IMatch>();
    public List<Match> Matches = new List<Match>();

    public RoundId RoundId { get; init; }

	public Round(int id, string name) {
		Id = id;
		Name = name;
	}


    public bool AddMatch(Match match) {
        try {
            //Matches.Add(match.Id, match);
            Matches.Add(match);
        } catch(ArgumentException) {
            //Console.WwriteLine("Match already exists");
            return false;
        }
        return true;
    }


    public static string RoundToString(RoundId roundId) => roundId switch {
		RoundId.Finals => "Finals",
		RoundId.Semifinals => "Semifinals",
		RoundId.Quarterfinals => "Quarterfinals",
		RoundId.RoundOf16 => "Round of 16",
		RoundId.RoundOf32 => "Round of 32",
		RoundId.RoundOf64 => "Round of 64",
        RoundId.RoundOf128    => "Round of 128"
    };

    public override string ToString() => $"Round: {Id} - {RoundId.ToString()} - # of Matches: {Matches.Count} - {Name}";
}

