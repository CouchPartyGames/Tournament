
namespace CouchParty.Tournament {

    public interface IOpponentOrder {
        Dictionary<int, Opponent> OpponentsInOrder { get; set; }
    }



    public abstract class OpponentOrder {

        // <summary>
        // Factory
        // </summary>
        public static IOpponentOrder Factory(List<Opponent> opponents, DrawOrderType order) {
            IOpponentOrder myOrder = null;
            switch(order) {
                case DrawOrderType.BlindDraw:
                    myOrder = new OpponentOrderRandom(opponents);
                    break;
                case DrawOrderType.SeededDraw:
                    myOrder = new OpponentOrderRank(opponents);
                    break;
            }

            return myOrder;
        }
    }


    // <summary>
    // Order opponents randomly in the Tournament draw
    // </summary>
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
        }

    }


    // <summary
    // Order Opponents in terms of rank in the Tournament draw
    // </summary>
    public class OpponentOrderRank : IOpponentOrder {

        public enum SortOrder {
            HighToLow,
            LowToHigh
        }

        // <summary>
        // Dictionary of ordered opponents
        // </summary>
        public Dictionary<int, Opponent> OpponentsInOrder { get; set; }


        // <summary>
        // Constructor
        // </summary>
        public OpponentOrderRank(List<Opponent> opps, SortOrder order = SortOrder.HighToLow) {
            OpponentsInOrder = new Dictionary<int, Opponent>();

            var OpponentsRanked = order == SortOrder.HighToLow ?  
                opps.OrderBy(o => o.Rank) :
                    opps.OrderByDescending(o => o.Rank);

            int i = 0;
            foreach(Opponent opp in OpponentsRanked) {
                OpponentsInOrder.Add(i, opp);
                i++;
            }
        }
    }
}
