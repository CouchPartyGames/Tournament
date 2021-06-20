using System.Collections.Generic;


namespace Tournament {

    public class Tournament {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsCompleted { get; set; } = false;


    }

    public class TournamentSettings {
        public enum EliminationMode {
            Single = 1,
            Double
        }

        public bool IsSeeded { get; set; }
        public int TotalSeeds { get; set; }

    }

    public interfac IMatch {
    }

    public class Match : IMatch {

        enum State {
            Ready = 0,
            InProgress,
            Completed
        }

        public int Id { get; set; }
        public State State { get; set; } = State.Ready;
        public Opponent opp1;
        public Opponent opp2;
        public Opponent winner;


        public SetOpponents(Opponent opp1, Opponent opp2) {
            this.opp1 = opp1;
            this.opp2 = opp2;
        }


        public SetWinner(Opponent winner) {
            this.State = State.Completed;
            this.winner = winner;
        }

    }

    public class GroupMatch {

        public Dictionary<int,Opponent> opponents;
        public int MinOpponents { get; set; } = 2;
        public int MaxOpponents { get; set; } = 4;
        public int NumWinners { get; set; } = 1;
        public Dictionary<int,Opponent> winners;

        public bool AddOpponent(Opponent opp) {
            if (opponents.Count < MaxOpponents) {
                opponents.Add(Opponent.Id, Opponent);
                return true;
            }

            return false;
        }

        public void AddWinners(Opponent opp) {
        }

        public void SetWinners(Dictionary<int, Opponent> opps) {
            winners = opps;
        }
    }


    public class Opponent {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class ByeOpponent : Opponent {
    }


    public class Round {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public Dictionary<int, Match> Matches = new Dictionary<int, Match>();

        public bool AddMatch(IMatch match) {
            try {
                Matches.Add(match.Id, match);
            } catch(ArgumentException) {
                Console.WwriteLine("Match already exists");
                return false;
            }
            return true;
        }
    }
}
