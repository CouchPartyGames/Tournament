
namespace CouchParty.Tournament;

public class Simulate {

    public Simulate(Tournament tourny) {

        Opponent winner = null;
        Random rand = new Random();

        foreach(var round in tourny.Rounds) {
            Console.WriteLine($"{round}");
            foreach(Match match in round.Matches) {
                //winner = rand.Next(0, 2) == 0 ? match.Opp1 : match.Opp2;

                match.SetResults(match.Opponents);
                Console.WriteLine($"{match}");
            }
        }
    }
}
