using System.Collections.Generic;
using System;


namespace CouchParty.Tournament {

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
}
