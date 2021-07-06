using System.Collections.Generic;
using System;
using System.Linq;


namespace CouchParty.Tournament {

    public interface IOpponentOrder {
        Dictionary<int, Opponent> OpponentsInOrder { get; set; }
    }


    public class OpponentOrderRandom : IOpponentOrder {

        // <summary>
        // Dictionary of ordered opponents
        // </summary>
        public Dictionary<int, Opponent> OpponentsInOrder { get; set; }



        public OpponentOrderRandom(List<Opponent> opps) {
            OpponentsInOrder = new Dictionary<int, Opponent>();

            Random rng = new Random();
            var randomList = opps.OrderBy(a => rng.Next()).ToList();

            int i = 0;
            foreach(Opponent opp in randomList) {
                OpponentsInOrder.Add(i, opp);
                i++;
            }

                // Determine if Byes are needed
            //AddByeOpponents(i);
        }

    }


    // <summary
    // Order Opponents in terms of Rank
    // </summary>
    public class OpponentOrderRank : IOpponentOrder {

        // <summary>
        // Dictionary of ordered opponents
        // </summary>
        public Dictionary<int, Opponent> OpponentsInOrder { get; set; }


        public OpponentOrderRank(List<Opponent> opps) {
            OpponentsInOrder = new Dictionary<int, Opponent>();

            var OpponentsRanked = opps.OrderBy(o => o.Rank);
            //var OpponentsRanked = opps.OrderByDescending(o => o.Rank);
            int i = 0;
            foreach(Opponent opp in OpponentsRanked) {
                OpponentsInOrder.Add(i, opp);
                i++;
            }

            //AddByeOpponents(i);
        }
    }
}
