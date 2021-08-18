
namespace CouchParty.Tournament;

public enum RoundId {
    Finals = 1,
    Semifinals,
    Quarterfinals,
    Round16,
    Round32,
    Round64,
    Round128
}


public class Round {

    public int Id { get; init; }

    public string Name { get; init; }

    public bool IsCompleted { get; set; } = false;

    //public Dictionary<int, IMatch> Matches = new Dictionary<int, IMatch>();
    public List<Match> Matches = new List<Match>();

    public RoundId RoundId { get; init; }


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


    /*
    public static string RoundToString(RoundId rId) => rId switch {
        RoundId.Round128    => "Round of 128",
        Direction.Right => Orientation.East,
        Direction.Down  => Orientation.South,
        Direction.Left  => Orientation.West,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
    };*/

    public override string ToString() => $"Round: {Id} - {RoundId.ToString()} - # of Matches: {Matches.Count}";
}

