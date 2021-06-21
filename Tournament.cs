using System.Collections.Generic;
using System;


namespace Tournament {

    public class Tournament {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsCompleted { get; set; } = false;

            // Start Time for the Tournament
        public DateTime? StartDate { get; set; } = null;

            // All Opponents
        public Dictionary<int, Opponent> Opponents { get; private set; }

            // Rounds
        public List<Round> Rounds { get; set; }


        public TournamentSettings Settings { get; private set; }



        public Tournament(TournamentSettings settings) {
            Settings = settings;

            Rounds = new List<Round>();
            Opponents = new Dictionary<int, Opponent>();
        }

        public void SetOpponents() {
            //Opponents = 
        }

        public void AddOpponent(Opponent opp1) {
            try {
                Opponents.Add(opp1.Id, opp1);
            } catch(ArgumentException) {
            }
        }

        public void Generate() {

            if (Opponents.Count > 2) {

                if (Opponents.Count == 2) {
                    /*
                    foreach(KeyValuePair<int, Opponent> entry in Opponents) {
                        entry;
                    }

                    Match match = new Match(opp1, opp2);

                    Round round = new Round();
                    round.AddMatch(match);
                        // Add the Round
                    Rounds.Add(round);
                    */

                    var numRounds = 1;

                } else if (Opponents.Count <= 4) {
                    var numRounds = 2;

                } else if (Opponents.Count <= 8) {
                    var numRounds = 3;

                } else if (Opponents.Count <= 16) {
                    var numRounds = 4;

                } else if (Opponents.Count <= 32) {
                    var numRounds = 5;

                } else if (Opponents.Count <= 64) {
                    var numRounds = 6;

                } else if (Opponents.Count <= 128) {
                    var numRounds = 7;

                }
                    /* 
                    // Setup Matches
                Match match = new Match(opp1, opp2);
                    // Setup the Round
                Round round = new Round();
                round.AddMatch(match);
                    // Add the Round
                Rounds.Add(round);
                */
            }

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


        public Match(Opponent opp1, Opponent opp2) {
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

        public int Id { get; set; }

        public Dictionary<int,Opponent> opponents = new Dictionary<int, Opponent>();

        public int MinOpponents { get; set; } = 2;
        public int MaxOpponents { get; set; } = 4;
        public int NumWinners { get; set; } = 1;

        public Dictionary<int,Opponent> winners = new Dictionary<int, Opponent>();

        public bool AddOpponent(Opponent opp) {
            if (opponents.Count < MaxOpponents) {
                opponents.Add(opp.Id, opp);
                return true;
            }

            return false;
        }

        public void AddWinners(Opponent opp) {
        }

        public void SetWinners(Dictionary<int, Opponent> opps) {
            winners = opps;
            //this.State = State.Completed;
        }
    }

    public interface IOpponent {
        int Id { get; set; }
        string Name { get; set; }
    }

    public class Opponent : IOpponent {

        public int Id { get; set; }
        public string Name { get; set; }

        public Opponent(int id, string name) {
            Id = id;
            Name = name;
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
}
