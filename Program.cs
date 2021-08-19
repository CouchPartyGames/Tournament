using CouchParty.Tournament.Preset;

namespace CouchParty.Tournament;

class Program {

    static void Main(string[] args) {

        List<Opponent> opps = new List<Opponent>() {
            new Opponent(1, "Bill"),
            new Opponent(2, "Bob"),
            new Opponent(3, "Steve"),
            new Opponent(4, "Greg", 3),
            new Opponent(5, "Jeter", 7),
            new Opponent(6, "Carter", 9),
            new Opponent(7, "Aaron", 2),
            new Opponent(8, "Tom", 4),
            new Opponent(9, "Carl", 5),
            new Opponent(10, "Rick", 15),
            new Opponent(11, "Will", 25),
            new Opponent(12, "George", 35),
            new Opponent(13, "Don", 95),
            new Opponent(14, "Obama", 75),
        };

        bool isDoubleElimination = false;
        bool isGroup = false;
        bool isSeeded = true;

        TournamentSettings settings = new TournamentSettings();
        Tournament tournay = isDoubleElimination ? new DoubleElimination(settings) : new SingleElimination(settings);

        tournay.Name = "CouchParty Tournament";
        tournay.Mode = isGroup ? BracketMode.Group : BracketMode.Individual;
        tournay.Order = isSeeded ? DrawOrderType.SeededDraw : DrawOrderType.BlindDraw;

        foreach(Opponent opp in opps) {
            tournay.AddOpponent(opp);
        }

        tournay.Generate();
        Console.WriteLine(tournay);


        foreach(var round in tournay.Rounds) {
            Console.WriteLine($"{round}");
            foreach(var match in round.Matches) {
            //foreach(KeyValuePair<int, IMatch> match in round.Matches) {
                Console.WriteLine($"{match}");
                
            }
        }

        Console.WriteLine();
        Simulate sim = new Simulate(tournay);

    }
}
