
namespace CouchParty.Tournament;

public class Simulate {

    public Simulate(Tournament tourny) {

        Opponent winner = null;
        Random rand = new Random();

        foreach(var round in tourny.Rounds) {
            Console.WriteLine($"{round}");
            foreach(Match match in round.Matches) {
                //winner = rand.Next(0, 2) == 0 ? match.Opp1 : match.Opp2;

                match.SetResults(GetRandomResults(match));
                //match.SetResults(match.Opponents);
                Console.WriteLine($"{match}");
            }
        }
    }


    List<Opponent> GetRandomResults(Match match) {
        var rnd = new Random();

        List<Opponent> opps = match.Opponents.Where(x => x.IsBye == false).ToList();
        var randomized = opps.OrderBy(item => rnd.Next()).ToList();
        List<Opponent> byes = match.Opponents.Where(x => x.IsBye == true).ToList();


        if (byes != null) {
            return randomized.Concat(byes).ToList();
        } else {
            return randomized;
        }
    }

}
