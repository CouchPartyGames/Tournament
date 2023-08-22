using CouchParty.Tournament.Preset;
using CouchParty.Tournament;


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
    new Opponent(13, "Tron", 95),
    new Opponent(14, "Obama", 75),
};

bool isDoubleElimination = true;
bool isGroup = false;
bool isSeeded = true;
string name = "CouchParty Tournament";


TournamentSettings settings = new TournamentSettings();
/*if (isDoubleElimination) {
	Tournament tourny = new DoubleElimination(name, settings);
} else {
}*/
Tournament tourny = new SingleElimination(1, name, opps);


tourny.Mode = isGroup ? BracketMode.Group : BracketMode.Individual;
tourny.Order = isSeeded ? DrawOrderType.SeededDraw : DrawOrderType.BlindDraw;
tourny.Generate();

Console.WriteLine("hello");
Console.WriteLine(tourny);


foreach(var round in tourny.Rounds) {
    Console.WriteLine($"{round}");
    foreach(var match in round.Matches) {
    //foreach(KeyValuePair<int, IMatch> match in round.Matches) {
        //Console.WriteLine($"{match}");
        
    }
}

Console.WriteLine();
Console.WriteLine("Simulation");
Simulate sim = new Simulate(tourny);
