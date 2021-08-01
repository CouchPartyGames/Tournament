namespace CouchParty.Tournament {

    public class GroupMatchGenerator : MatchGenerator {

        public enum GroupDrawType {
            Finals = 1,
            Semifinals = 2,
            Quarterfinals = 4,
            Draw16 = 8,
            Draw32 = 16,
            Draw64 = 32,
            Draw128 = 64
        }

        public int OpponentsPerGroup { get; private set; }


        public GroupMatchGenerator(IOpponentOrder oppOrder) : base(oppOrder.OpponentsInOrder) {

            OpponentsPerGroup = 4;
         

            var numOpponents = OpponentList.Count;
            var maxInGroup = 4;
            var numGroups = (numOpponents / maxInGroup) + (numOpponents % maxInGroup == 0 ? 0 : 1);
           
            var drawSize = DetermineDrawSize(numGroups);
            NumByes = ((int)drawSize * maxInGroup) - numOpponents;


            AddByeOpponents();

            switch(drawSize) {
                case GroupDrawType.Finals:
                    DrawFinals();
                    break;

                case GroupDrawType.Semifinals:
                    DrawSemifinals();
                    break;

                case GroupDrawType.Quarterfinals:
                    DrawQuarterfinals();
                    break;

                case GroupDrawType.Draw16:
                    Draw16();
                    break;
            }
        }


        // <summary>
        // Finals
        // </summary>
        void DrawFinals() {
            var round = GroupMatch.RoundId.Finals;

                // Create List of Match
            var matchList = new Dictionary<int, List<int>> {
                { 1, new List<int>(OpponentList.Keys.ToList()) }
            };

            Console.WriteLine("Group DrawFinals");

            AddMatch(matchList, round);
        }


        // <summary>
        // Semifinals
        // </summary>
        void DrawSemifinals() {
            var round = GroupMatch.RoundId.Semifinals;
            var numOpponents = OpponentList.Count;

                // Get Seeded Positions for each Opponent
            var seedsList = FlattenSeeds(GetOpponentSeeding(numOpponents));
            /*foreach(var seed in seedsList) {
                Console.WriteLine($"seed: {seed}");
            }*/

                // Split the seeds into 2 Groups
            List<List<int>> matchList = GroupSeedsIntoListOfMatches(seedsList);
            
            /*
            foreach(List<int> outer in matchList) {

                Console.WriteLine("outer");
                foreach(int inner in outer) {
                    Console.WriteLine($"inner: {inner}");
                }
            }*/


            AddMatch(matchList, round);
        }


        void DrawQuarterfinals() {
            var round = GroupMatch.RoundId.Quarterfinals;
            var numOpponents = OpponentList.Count;

                // Get Seeded Positions for each Opponent
            var seedsList = FlattenSeeds(GetOpponentSeeding(numOpponents));
            /*foreach(var seed in seedsList) {
                Console.WriteLine($"seed: {seed}");
            }*/

                // Split the seeds into 2 Groups
            List<List<int>> matchList = GroupSeedsIntoListOfMatches(seedsList);
            
            
            foreach(List<int> outer in matchList) {

                Console.WriteLine("outer");
                foreach(int inner in outer) {
                    Console.WriteLine($"inner: {inner}");
                }
            }


            AddMatch(matchList, round);
        }


        void Draw16() {
            var round = GroupMatch.RoundId.Round16;
            var numOpponents = OpponentList.Count;

                // Get Seeded Positions for each Opponent
            var seedsList = FlattenSeeds(GetOpponentSeeding(numOpponents));
            /*foreach(var seed in seedsList) {
                Console.WriteLine($"seed: {seed}");
            }*/

                // Split the seeds into 2 Groups
            List<List<int>> matchList = GroupSeedsIntoListOfMatches(seedsList);
            
            /*
            foreach(List<int> outer in matchList) {

                Console.WriteLine("outer");
                foreach(int inner in outer) {
                    Console.WriteLine($"inner: {inner}");
                }
            }*/


            AddMatch(matchList, round);
        }


        void AddMatch(List<List<int>> matchList, GroupMatch.RoundId round) {
            int id = 1;
            foreach(List<int> match in matchList) {
                GroupMatch groupMatch = new GroupMatch(id, round);
                foreach(int index in match) {
                    groupMatch.AddOpponent(OpponentList[index - 1]);
                }
                MatchList.Add(groupMatch);
                id++; 
            }
        }

        void AddMatch(Dictionary<int, List<int>> matchList, GroupMatch.RoundId round) {
            int id = 1;
            
            foreach(KeyValuePair<int, List<int>> match in matchList) {

                GroupMatch groupMatch = new GroupMatch(match.Key, round);
                foreach(var opponentId in match.Value) {
                    groupMatch.AddOpponent(OpponentList[opponentId]);
                }
                MatchList.Add(groupMatch);

                id++;
            }
        }


        // <summary>
        // 
        // </summary>
        protected GroupDrawType DetermineDrawSize(int num) {
            GroupDrawType drawSize = 0;
            if (num <= (int)GroupDrawType.Finals) {
                drawSize = GroupDrawType.Finals;
            } else if (num <= (int)GroupDrawType.Semifinals) {
                drawSize = GroupDrawType.Semifinals;
            } else if (num <= (int)GroupDrawType.Quarterfinals) {
                drawSize = GroupDrawType.Quarterfinals;
            } else if (num <= (int)GroupDrawType.Draw16) {
                drawSize = GroupDrawType.Draw16;
            } else if (num <= (int)GroupDrawType.Draw32) {
                drawSize = GroupDrawType.Draw32;
            } else if (num <= (int)GroupDrawType.Draw64) {
                drawSize = GroupDrawType.Draw64;
            } else {
                drawSize = GroupDrawType.Draw128;
            }

            return drawSize;
        }

        // <summary>
        // Create a flat list of all seeded positions
        // </summary>
        List<int> FlattenSeeds(List<(int, int)> seedsList) {
            var flattenList = new List<int>();
            foreach(var item in seedsList) {
                flattenList.Add(item.Item1);
                flattenList.Add(item.Item2);
            }
            return flattenList;
        }

        // <summary>
        // Convert entire list of seeds into multiple groups
        // </summary>
        List<List<int>> GroupSeedsIntoListOfMatches(List<int> seedsList) {
            return seedsList
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / OpponentsPerGroup)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

    }
}
