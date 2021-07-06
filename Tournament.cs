using System.Collections.Generic;
using System;
using System.Linq;


namespace CouchParty.Tournament {

    public class Tournament {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsCompleted { get; set; } = false;

            // Start Time for the Tournament
        public DateTime? StartDate { get; set; } = null;

            // All Opponents
        public List<Opponent> Opponents { get; private set; }

            // Rounds
        public List<Round> Rounds { get; set; }


        public TournamentSettings Settings { get; private set; }



        public Tournament(TournamentSettings settings) {
            Settings = settings;

            Rounds = new List<Round>();
            Opponents = new List<Opponent>();
        }

        public void SetOpponents(List<Opponent> opps) {
            Opponents = opps;
        }

        public void AddOpponent(Opponent opp1) {
            try {
                Opponents.Add(opp1);
            } catch(ArgumentException) {
            }
        }

        public void Generate() {

             //var ordered = new OpponentOrderRank();
             //var random = new OpponentOrderRandom();
        }
    }


    public class TournamentSettings {
        public enum EliminationMode {
            Single = 1,
            Double
        }

        public enum BracketMode {
            Individual,
            Group
        }

        public bool IsSeeded { get; set; }
        public int TotalSeeds { get; set; }

        public EliminationMode Elimination { get; set; }

        public BracketMode Mode { get; set; } = BracketMode.Individual;

        public int MaxOpponents { get; set; }
    }


    public class GroupSettings {
        public int minOpponents;
        public int maxOpponents;

        public int numToAdvance;

        public GroupSettings() {
            minOpponents = 2;
            maxOpponents = 4;
            numToAdvance = 2;
        }
    }


    public interface IMatch {
        int Id { get; set; }
    }


    public class Round {

        public enum Stage {
            Finals,
            Semifinals,
            Quarterfinals
        }

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
    }

}
