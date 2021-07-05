using System.Collections.Generic;

namespace CouchParty.Tournament {

    public class MatchGenerator {

        public List<IMatch> MatchList { get; private set; }


        public MatchGenerator(OpponentOrder order) {
            MatchList = new List<IMatch>();

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
            }
        }


        void Draw2(Dictionary<int, Opponent> opp) {
                // #1 vs #2
            Match match = new Match(1, Match.RoundId.Finals, opp[0], opp[1]);
            
        }

        void Draw4(Dictionary<int, Opponent> opp) {
                // #1 vs 4
            Match match1 = new Match(1, Match.RoundId.Semifinals, opp[0], opp[3]);
                // #3 vs 2
            Match match2 = new Match(2, Match.RoundId.Semifinals, opp[2], opp[1]);
        }

        void Draw8(Dictionary<int, Opponent> opp) {

                // #1 vs #8
            Match match1 = new Match(1, Match.RoundId.Quarterfinals, opp[0], opp[7]);
                // #6 vs #3
            Match match2 = new Match(2, Match.RoundId.Quarterfinals, opp[5], opp[2]);
                // #4 vs #5
            Match match3 = new Match(3, Match.RoundId.Quarterfinals, opp[3], opp[4]);
                // #7 vs #2
            Match match4 = new Match(4, Match.RoundId.Quarterfinals, opp[6], opp[1]);

            /*
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
            */
        }

        void Draw16(Dictionary<int, Opponent> opp) {

                // #1 vs #16
            MatchList.Add(new Match(1, Match.RoundId.Round16, opp[0], opp[15]));

                // #9 vs #8
            MatchList.Add(new Match(2, Match.RoundId.Round16, opp[8], opp[7]));
            
                // #4 vs #13
            MatchList.Add(new Match(3, Match.RoundId.Round16, opp[3], opp[12]));

                // #5 vs 12
            MatchList.Add(new Match(4, Match.RoundId.Round16, opp[3], opp[11]));


                // #3 vs #14
            MatchList.Add(new Match(5, Match.RoundId.Round16, opp[2], opp[13]));

                // #11 vs #6
            MatchList.Add(new Match(6, Match.RoundId.Round16, opp[10], opp[5]));

                // #7 vs #10
            MatchList.Add(new Match(7, Match.RoundId.Round16, opp[6], opp[9]));
                
                // #2 vs #15
            MatchList.Add(new Match(8, Match.RoundId.Round16, opp[1], opp[14]));
        }

        /*
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
        */
    }
}
