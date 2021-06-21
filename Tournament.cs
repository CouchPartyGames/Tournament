using System.Collections.Generic;


namespace Tournament {

    public class Tournament {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsCompleted { get; set; } = false;

            // Start Time for the Tournament
        public DateTime? StartDate { get; set; } = null;

            // All Opponents
        public Dictionary<int, Opponent> opponents;


        public void Generate() {
            Opponent opp1 = new Opponent(1, "Bob");
            Opponent opp2 = new Opponent(2, "Bill");

            Match match = new Match();
            match.SetOpponents(opp1, opp2);

            Round round = new Round();
            round.AddMatch(match);

            Add(round);
        }

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
        public ?Opponent winner { get; set; } = null;


        public SetOpponents(Opponent opp1, Opponent opp2) {
            this.opp1 = opp1;
            this.opp2 = opp2;
        }


        public SetWinner(Opponent winner) {
            if (winner == opp1 || winner == opp2) {
                this.State = State.Completed;
                this.winner = winner;
            }
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
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Opponent(int id, string name) {
            Id = id;
            Name = name;
        }
    }


    public class ByeOpponent : Opponent {
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
                Console.WwriteLine("Match already exists");
                return false;
            }
            return true;
        }
    }
}
