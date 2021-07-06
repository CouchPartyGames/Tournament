using System.Collections.Generic;

namespace CouchParty.Tournament {

    public class GroupMatchGenerator {
        public List<IMatch> MatchList { get; private set; }

        public GroupMatchGenerator(OpponentOrder oppOrder) {
            MatchList = new List<IMatch>();
            

            switch(oppOrder.GroupDrawSize) {
                case OpponentOrder.DrawType.Draw2:
                    Draw2(oppOrder.OpponentsInOrder);
                    break;

/*                case OpponentOrder.DrawType.Draw4:
                    Draw4(oppOrder.OpponentsInOrder);
                    break;

                case OpponentOrder.DrawType.Draw8:
                    Draw8(oppOrder.OpponentsInOrder);
                    break;

                case OpponentOrder.DrawType.Draw16:
                    Draw16(oppOrder.OpponentsInOrder);
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
