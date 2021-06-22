using System.Collections.Generic;
using System;
using System.Linq;


namespace Tournament {

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
            return $"{Opp1} vs {Opp2} {State}";
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

    /***
     * Only Seeds are Ranked in Order, Everyone outside of the seeded are randomly ordered in the draw
     */


    /**
     * Base Class
     */
    public class OpponentOrder {

        public enum DrawType {
            Draw2 = 2,
            Draw4 = 4,
            Draw8 = 8,
            Draw16 = 16,
            Draw32 = 32,
            Draw64 = 64,
            Draw128 = 128
        }

        public DrawType DrawSize { get; private set; }

        public Dictionary<int, Opponent> OpponentsInOrder { get; private set; }

        public int NumByes { get; private set; }


        public OpponentOrder(List<Opponent> opps) {
            OpponentsInOrder = new Dictionary<int, Opponent>();

                // Set Draw Type
            if (opps.Count <= (int)DrawType.Draw2) {
                DrawSize = DrawType.Draw2;
            } else if (opps.Count <= (int)DrawType.Draw4) {
                DrawSize = DrawType.Draw4;
            } else if (opps.Count <= (int)DrawType.Draw8) {
                DrawSize = DrawType.Draw8;
            } else if (opps.Count <= (int)DrawType.Draw16) {
                DrawSize = DrawType.Draw16;
            } else if (opps.Count <= (int)DrawType.Draw32) {
                DrawSize = DrawType.Draw32;
            } else if (opps.Count <= (int)DrawType.Draw64) {
                DrawSize = DrawType.Draw64;
            } else {
                DrawSize = DrawType.Draw128;
            }

            NumByes = (int)DrawSize - opps.Count;
        }


        protected void AddByeOpponents(int startPos) {

                // Determine if Byes are needed
            if (NumByes > 0) {
                for(int j = 0; j < NumByes; j++) {
                    OpponentsInOrder.Add(startPos, new Opponent(0, "Bye", true));
                    startPos++;
                }
            }
        }
    }


    /*
    public class MatchGenerator {

        public void Generate() {
        }

        void Draw2() {
                // #1 vs #2
            Match match = new Match(1, OpponentsInOrder[0], OpponentsInOrder[1]);
        }

        void Draw4() {
                // #1 vs 4
            Match match1 = new Match(1, OpponentsInOrder[0], OpponentsInOrder[3]);
                // #3 vs 2
            Match match2 = new Match(1, OpponentsInOrder[2], OpponentsInOrder[1]);
        }

        void Draw8() {

                // #1 vs #8
            Match match1 = new Match(1, OpponentsInOrder[0], OpponentsInOrder[7]);
                // #6 vs #3
            Match match2 = new Match(1, OpponentsInOrder[5], OpponentsInOrder[2]);
                // #4 vs #5
            Match match3 = new Match(1, OpponentsInOrder[3], OpponentsInOrder[4]);
                // #7 vs #2
            Match match4 = new Match(1, OpponentsInOrder[6], OpponentsInOrder[1]);

                // Quarterfinals
            Round quarters = new Round();
            Add(match1);
            Add(match2);
            Add(match3);
            Add(match4);

                // Semifinals
            Round semis = new Round();
            semis.Add(match5);
            semis.Add(match6);

                // Finals
            Round finals = new Round();
            finals.Add(match7);
        }

        void Draw16() {
                // #1 vs #16
            Match match1 = new Match(1, OpponentsInOrder[0], OpponentsInOrder[15]);
            Match match2 = new Match(1, OpponentsInOrder[5], OpponentsInOrder[2]);
            Match match3 = new Match(1, OpponentsInOrder[3], OpponentsInOrder[4]);
            Match match4 = new Match(1, OpponentsInOrder[6], OpponentsInOrder[1]);
        }

        void Draw32() {
            Match match1 = new Match(1, OpponentsInOrder[0], OpponentsInOrder[7]);
            Match match2 = new Match(1, OpponentsInOrder[5], OpponentsInOrder[2]);
            Match match3 = new Match(1, OpponentsInOrder[3], OpponentsInOrder[4]);
            Match match4 = new Match(1, OpponentsInOrder[6], OpponentsInOrder[1]);
        }


        void Draw64() {
            Match match1 = new Match(1, OpponentsInOrder[0], OpponentsInOrder[7]);
            Match match2 = new Match(1, OpponentsInOrder[5], OpponentsInOrder[2]);
            Match match3 = new Match(1, OpponentsInOrder[3], OpponentsInOrder[4]);
            Match match4 = new Match(1, OpponentsInOrder[6], OpponentsInOrder[1]);
        }

        void Draw128() {
            Match match1 = new Match(1, OpponentsInOrder[0], OpponentsInOrder[7]);
            Match match2 = new Match(1, OpponentsInOrder[5], OpponentsInOrder[2]);
            Match match3 = new Match(1, OpponentsInOrder[3], OpponentsInOrder[4]);
            Match match4 = new Match(1, OpponentsInOrder[6], OpponentsInOrder[1]);
        }
    }*/

}
