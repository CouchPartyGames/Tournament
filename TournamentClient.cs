using System.Collections.Generic;
using CouchParty.Tournament;

namespace CouchParty.Tournament.Client {

    public class TournamentClient {

        private List<TournamentInfo> enterableTournays;
        private List<TournamentInfo> upcomingTournays;

        public bool HasEnterableTournaments { 
            get { 
                return false; 
            } 
        }

        public bool HasUpcomingTournaments { 
            get { 
                return false; 
            } 
        }


        public TournamentClient() {
            enterableTournays = new List<TournamentInfo>();
            upcomingTournays = new List<TournamentInfo>();
        }

        public List<TournamentInfo> GetEnterableTournaments() {
            return enterableTournays;
        }

        public List<TournamentInfo> GetUpcomingTournaments() {
            return upcomingTournays;
        }

        public TournamentResults GetTournamentResults(int tournamentId) {
            TournamentResults results = new TournamentResults();
            return results;
        }

        /*
        public TournamentResults GetTournamentResults(startDate, endDate) {
        }*/


        
    }
}
