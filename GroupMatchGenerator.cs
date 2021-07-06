using System.Collections.Generic;
using System;
using System.Linq;

namespace CouchParty.Tournament {

    public class GroupMatchGenerator : MatchGenerator {

        public GroupMatchGenerator(IOpponentOrder oppOrder) : base(oppOrder.OpponentsInOrder) {

            var numOpponents = Opponents.Count;
            var maxInGroup = 4;
            var numGroups = (numOpponents / maxInGroup) + (numOpponents % maxInGroup == 0 ? 0 : 1);
           
            Console.WriteLine($"Groups: {numGroups} Opponents: {numOpponents}");
            DrawSize = DetermineDrawSize(numGroups);
            NumByes = ((int)DrawSize * maxInGroup) - numOpponents;

            foreach(var opp in Opponents.Values.ToList()) {
                Console.WriteLine($"{opp.Name} {opp.Rank}");
            }

            switch(DrawSize) {
                case DrawType.Finals:
                    DrawFinals(Opponents);
                    break;

                case DrawType.Semifinals:
                    DrawSemifinals(Opponents);
                    break;

                case DrawType.Quarterfinals:
                    DrawQuarterfinals(Opponents);
                    break;

                case DrawType.Draw16:
                    Draw16(Opponents);
                    break;
            }
        }


        void DrawFinals(Dictionary<int, Opponent> opp) {
            var round = GroupMatch.RoundId.Finals;

                // Create List of Match
            var matchList = new List<List<int>>();
            matchList.Add(new List<int>());

            Console.WriteLine("Group DrawFinals");

            AddMatch(opp, matchList, round);
        }


        void DrawSemifinals(Dictionary<int, Opponent> opp) {
            var round = GroupMatch.RoundId.Finals;

                // Create List of Match
            var matchList = new List<List<int>>();
            matchList.Add(new List<int>());

            Console.WriteLine("Group: Semifinals");

            AddMatch(opp, matchList, round);
        }


        void DrawQuarterfinals(Dictionary<int, Opponent> opp) {
            var round = GroupMatch.RoundId.Finals;

                // Create List of Match
            var matchList = new List<List<int>>();
            matchList.Add(new List<int>());

            Console.WriteLine("Group: Quarterfinals");


            AddMatch(opp, matchList, round);
        }


        void Draw16(Dictionary<int, Opponent> opp) {
            var round = GroupMatch.RoundId.Finals;

                // Create List of Match
            var matchList = new List<List<int>>();
            matchList.Add(new List<int>());


            AddMatch(opp, matchList, round);
        }


        void AddMatch(Dictionary<int, Opponent> opponentList, List<List<int>> matchList, GroupMatch.RoundId round) {
            int id = 1;
            int opp1 = 0, opp2 = 0;

            foreach( var match in matchList) {

                GroupMatch groupMatch = new GroupMatch(id, round);
                MatchList.Add(groupMatch);
                id++;
            }
        }

    }
}
