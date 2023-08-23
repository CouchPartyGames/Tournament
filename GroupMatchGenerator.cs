namespace CouchParty.Tournament;

using CouchParty.Tournament.Exceptions;
using CouchParty.Tournament.ValueObjects;

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


	//ISeededMatches list
    public GroupMatchGenerator(IOpponentOrder oppOrder, uint drawSize) : base(oppOrder.OpponentsInOrder) {

        OpponentsPerGroup = 4;
     

        var numOpponents = OpponentList.Count;
        var maxInGroup = 4;
        var numGroups = (numOpponents / maxInGroup) + (numOpponents % maxInGroup == 0 ? 0 : 1);
       
        NumByes = ((int)drawSize * maxInGroup) - numOpponents;


        AddByeOpponents();

        switch(drawSize) {
            case 2:
                DrawFinals();
                break;

            case 4:
                DrawOther(RoundId.Semifinals, drawSize);
                break;

            case 8:
                DrawOther(RoundId.Quarterfinals, drawSize);
                break;

            case 16:
                DrawOther(RoundId.RoundOf16, drawSize);
                break;

			default:
				throw new InvalidDrawSizeException();
				break;
        }
    }


    // <summary>
    // Finals
    // </summary>
    void DrawFinals() {
        var round = RoundId.Finals;

            // Create List of Match
        var matchList = new Dictionary<int, List<int>> {
            { 1, new List<int>(OpponentList.Keys.ToList()) }
        };

        //AddMatch(matchList, round);
    }


    // <summary>
    // Draw
    // </summary>
    void DrawOther(RoundId round, uint drawSize) {
		var seededMatches = new StartingMatches(drawSize);

            // Get Seeded Positions for each Opponent
        var seedsList = FlattenSeeds(seededMatches.MatchList);

        /*foreach(var seed in seedsList) {
            Console.WriteLine($"seed: {seed}");
        }*/

            // Split the seeds into # of Groups
        //List<List<int>> matchList = GroupSeedsIntoListOfMatches(seedsList, OpponentsPerGroup);
        
        //DebugMatchList(matchList);

        //AddMatch(matchList, round);
    }




    void AddMatch(List<List<int>> matchList, RoundId round) {
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

    void AddMatch(Dictionary<int, List<int>> matchList, RoundId round) {
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
            DrawSize = DrawType.Finals;
        } else if (num <= (int)GroupDrawType.Semifinals) {
            drawSize = GroupDrawType.Semifinals;
            DrawSize = DrawType.Semifinals;
        } else if (num <= (int)GroupDrawType.Quarterfinals) {
            drawSize = GroupDrawType.Quarterfinals;
            DrawSize = DrawType.Quarterfinals;
        } else if (num <= (int)GroupDrawType.Draw16) {
            drawSize = GroupDrawType.Draw16;
            DrawSize = DrawType.Draw16;
        } else if (num <= (int)GroupDrawType.Draw32) {
            drawSize = GroupDrawType.Draw32;
            DrawSize = DrawType.Draw32;
        } else if (num <= (int)GroupDrawType.Draw64) {
            drawSize = GroupDrawType.Draw64;
            DrawSize = DrawType.Draw64;
        } else {
            drawSize = GroupDrawType.Draw128;
            DrawSize = DrawType.Draw128;
        }

        return drawSize;
    }

    // <summary>
    // Create a flat list of all seeded positions
    // </summary>
    List<int> FlattenSeeds(List<SeededMatch> seedsList) {
        var flattenList = new List<int>();
        foreach(var item in seedsList) {
            flattenList.Add(item.opponent1Seed);
            flattenList.Add(item.opponent2Seed);
        }
        return flattenList;
    }

    // <summary>
    // Convert entire flat list of seeds into multiple groups
    // </summary>
    // <param>A list of seeded positions for opponents</param>
    // <param></param>
    List<List<int>> GroupSeedsIntoListOfMatches(List<SeededMatch> seedsList, int opponentsPerGroup) {
        if (opponentsPerGroup < 2) {
            //throw new Exception('');
        }

		return new List<List<int>>();
/*
        return seedsList
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / opponentsPerGroup)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();*/
    }


    // <summary>
    // </summary>
    void DebugMatchList(List<List<int>> matchList) {
        foreach(List<int> outer in matchList) {
            Console.WriteLine("outer");
            foreach(int inner in outer) {
                Console.WriteLine($"  inner: {inner}");
            }
        }
    }

}
