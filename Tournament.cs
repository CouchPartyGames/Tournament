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
    }


    public interface IMatch {
        int Id { get; set; }
    }


    public class Match : IMatch {

        public enum RoundId {
            Round128,
            Round64,
            Round32,
            Round16,
            Quarterfinals,
            Semifinals,
            Finals
        }

        public enum MatchState {
            Ready = 0,
            InProgress,
            Completed
        }


        public int Id { get; set; }
        public MatchState State { get; set; } = MatchState.Ready;
        public Opponent Opp1 { get; private set; }
        public Opponent Opp2 { get; private set; }
        public Opponent Winner { get; set; } 
        public RoundId Round { get; private set; }


        public Match(int id, RoundId round) {
            Id = id;
            Round = round;
        }


        public Match(int id, RoundId round, Opponent opp1, Opponent opp2) {
            Id = id;
            Round = round;

            SetOpponents(opp1, opp2);
        }

        public void SetOpponents(Opponent opp1, Opponent opp2) {
            Opp1 = opp1;
            Opp2 = opp2;
        }


        public void SetWinner(Opponent winner) {
            if (Winner == null) {
                if (winner.Id == Opp1.Id || winner.Id == Opp2.Id) {
                    State = MatchState.Completed;
                    Winner = winner;
                }
            }
        }

        public override string ToString() {
            return $"Match Id: {Id} {Opp1} vs {Opp2} {State.ToString()}";
        }
    }


    public class GroupMatch : IMatch {

        public enum MatchState {
            Ready = 0,
            InProgress,
            Completed
        }

        public enum RoundId {
            Round128,
            Round64,
            Round32,
            Round16,
            Quarterfinals,
            Semifinals,
            Finals
        }

        public int Id { get; set; }

        public Dictionary<int,Opponent> opponents = new Dictionary<int, Opponent>();

        public MatchState State { get; set; } = MatchState.Ready;
        public int MinOpponents { get; set; } = 2;
        public int MaxOpponents { get; set; } = 4;
        public int NumWinners { get; set; } = 1;
        public RoundId Round { get; private set; }

        public Dictionary<int,Opponent> winners = new Dictionary<int, Opponent>();

        public GroupMatch(int id) {
            Id = id;
        }

        public bool AddOpponent(Opponent opp) {
            if (opponents.Count < MaxOpponents) {
                opponents.Add(opp.Id, opp);
                return true;
            }

            return false;
        }


        public void SetWinners(Dictionary<int, Opponent> opps) {
            winners = opps;
            this.State = MatchState.Completed;
        }
    }


    public interface IOpponent {
        int Id { get; set; }
        string Name { get; set; }
        int Rank { get; set; }
    }


    public class Opponent : IOpponent {

        public const int ByeRank = 999999;
        public const int NotRank = 888888;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public bool IsBye { get; private set; }


        public Opponent(int id, string name, int rank = NotRank) {
            Id = id;
            Name = name;
            Rank = rank;
        }


        public Opponent(int id, string name, bool isBye) {
            Id = id;
            Name = name;
            IsBye = isBye;
            Rank = isBye ? ByeRank : NotRank;
        }


        public override string ToString() {
            return $"{Name} ({Id})";
        }
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


    public interface IOpponentOrder {
        int NumberOpponents { get; set; }
    }


    public class OpponentOrderRandom : OpponentOrder {

        public OpponentOrderRandom(List<Opponent> opps) : base(opps) {
            Random rng = new Random();
            var randomList = opps.OrderBy(a => rng.Next()).ToList();

            int i = 0;
            foreach(Opponent opp in randomList) {
                OpponentsInOrder.Add(i, opp);
                i++;
            }

                // Determine if Byes are needed
            AddByeOpponents(i);
        }

    }


    /**
     * All Opponents are ranked in order
     */
    public class OpponentOrderRank : OpponentOrder {

        public OpponentOrderRank(List<Opponent> opps) : base(opps) {
            var OpponentsRanked = opps.OrderBy(o => o.Rank);
            //var OpponentsRanked = opps.OrderByDescending(o => o.Rank);
            int i = 0;
            foreach(Opponent opp in OpponentsRanked) {
                OpponentsInOrder.Add(i, opp);
                i++;
            }

            AddByeOpponents(i);
        }
    }

}
