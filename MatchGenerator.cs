using System.Collections.Generic;

namespace CouchParty.Tournament {

    public class MatchGenerator {

        public List<IMatch> MatchList { get; private set; }

        //List<Opponent> opponents; 


        public MatchGenerator(OpponentOrder order) {
            MatchList = new List<IMatch>();
            //opponents = order; 

            switch(order.DrawSize) {
                case OpponentOrder.DrawType.Draw2:
                    Draw2(order.OpponentsInOrder);
                    break;

                case OpponentOrder.DrawType.Draw4:
                    Draw4(order.OpponentsInOrder);
                    break;

                case OpponentOrder.DrawType.Draw8:
                    Draw8(order.OpponentsInOrder);
                    break;

                case OpponentOrder.DrawType.Draw16:
                    Draw16(order.OpponentsInOrder);
                    break;

                case OpponentOrder.DrawType.Draw32:
                    Draw32(order.OpponentsInOrder);
                    break;

                    /*
                case OpponentOrder.DrawType.Draw64:
                    Draw64(order.OpponentsInOrder);
                    break;

                case OpponentOrder.DrawType.Draw128:
                    Draw128(order.OpponentsInOrder);
                    break;
                    */
            }
        }


        void Draw2(Dictionary<int, Opponent> opp) {
            var round = Match.RoundId.Finals;

            var matchTuple = new List<(int opp1, int opp2)> {
                (1, 2)
            };

            AddMatch(opp, matchTuple, round);
        }

        void Draw4(Dictionary<int, Opponent> opp) {
            var round = Match.RoundId.Semifinals;

            var matchTuple = new List<(int opp1, int opp2)> {
                (1, 4),
                (3, 2)
            };

            AddMatch(opp, matchTuple, round);
        }


        void Draw8(Dictionary<int, Opponent> opp) {
            var round = Match.RoundId.Quarterfinals;

            var matchTuple = new List<(int opp1, int opp2)> {
                (1, 8),
                (6, 3),
                (4, 5),
                (7, 2),
            };

            AddMatch(opp, matchTuple, round);
        }


        void Draw16(Dictionary<int, Opponent> opp) {
            var round = Match.RoundId.Round16;

            var matchTuple = new List<(int opp1, int opp2)> {
                (1, 16),
                (9, 8),
                (4, 13),
                (5, 12),
                (3, 14),
                (11,6),
                (7,10),
                (2,15)
            };

            AddMatch(opp, matchTuple, round);
        }


        // https://www.printyourbrackets.com/32seeded.html
        void Draw32(Dictionary<int, Opponent> opp) {
            var round = Match.RoundId.Round32;

                // #1 vs #32
            MatchList.Add(new Match(1, round, opp[0], opp[31]));

                // #16 vs #17
            MatchList.Add(new Match(1, round, opp[0], opp[31]));
                // #9 vs #24
                // #8 vs #25
                // #4 vs #29
                // #13 vs #20
                // #12 vs #21


                // #2 vs #31
            MatchList.Add(new Match(8, Match.RoundId.Round32, opp[1], opp[30]));
        }

        /*

        void Draw64(Dictionary<int, Opponent> opp) {
            var round = Match.RoundId.Round64;
            int id = 1;

            Match match1 = new Match(1, OpponentsInOrder[0], OpponentsInOrder[7]);
            Match match2 = new Match(1, OpponentsInOrder[5], OpponentsInOrder[2]);
            Match match3 = new Match(1, OpponentsInOrder[3], OpponentsInOrder[4]);
            Match match4 = new Match(1, OpponentsInOrder[6], OpponentsInOrder[1]);
        }

        void Draw128(Dictionary<int, Opponent> opp) {
            var round = Match.RoundId.Round128;
            int id = 1;

            Match match1 = new Match(1, OpponentsInOrder[0], OpponentsInOrder[7]);
            Match match2 = new Match(1, OpponentsInOrder[5], OpponentsInOrder[2]);
            Match match3 = new Match(1, OpponentsInOrder[3], OpponentsInOrder[4]);
            Match match4 = new Match(1, OpponentsInOrder[6], OpponentsInOrder[1]);
        }
        */

        
        void AddMatch(Dictionary<int, Opponent> opponentList, List<(int,int)> matchList, Match.RoundId round) {

            int id = 1;
            int opp1 = 0, opp2 = 0;

            foreach( var item in matchList) {
                opp1 = item.Item1 - 1;
                opp2 = item.Item2 - 1;

                MatchList.Add(new Match(id, round, opponentList[opp1], opponentList[opp2]));
                id++;
            }
        }
    }
}
