
namespace CouchParty.Tournament {

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


        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        public Dictionary<int, IMatch> Matches = new Dictionary<int, IMatch>();


        public bool AddMatch(IMatch match) {
            try {
                Matches.Add(match.Id, match);
            } catch(ArgumentException) {
                //Console.WwriteLine("Match already exists");
                return false;
            }
            return true;
        }

        /*
        public static string RoundToString(RoundId rId) => rId switch {
            Direction.Round128    => "Round of 128",
            Direction.Right => Orientation.East,
            Direction.Down  => Orientation.South,
            Direction.Left  => Orientation.West,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
        };*/
    }

}
