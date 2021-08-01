
namespace CouchParty.Tournament.Server {


    public class TournamentServer {

        int tournamentId;

        string apiKey;

        public TournamentServer(int tournamentId) {

        }

        public bool UpdateMatch(int matchId, int winnerId) {
            
            return true;
        }

        public bool UpdateMatch(IMatch match /*, IMatchResults results*/) {
            return true;
        }

        public bool UpdateGroupMatch(int matchId, List<int> winners) {

            return true;
        }

        /*
        public bool GetOpponents() {

        }*/

        public bool VerifyOpponents() {
            return true; 
        }
    }
}
