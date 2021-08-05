
namespace CouchParty.Tournament {

    public class Simulate {

        public Simulate(Tournament tourny) {

            Opponent winner = null;
            Random rand = new Random();


            foreach(var round in tourny.Rounds) {
                foreach(IndividualMatch match in round.Matches) {
                    winner = rand.Next(0, 2) == 0 ? match.Opp1 : match.Opp2;

                    Console.WriteLine($"Match Id: {match.Id} {winner}");
                    match.SetWinner(winner);
                }
            }
        }
    }
}