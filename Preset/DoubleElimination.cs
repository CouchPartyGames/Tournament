
namespace CouchParty.Tournament.Preset;


public class DoubleElimination : Tournament {

    public DoubleElimination(int id, string name, List<Opponent> opps) : 
		base(id, name, opps) {
    }


    // <summary>
    // Generate All Matches in the Draw
    // </summary>
    public override void Generate() {
        int id = 100;


            // order all opponents in the draw (doesn't include byes)
        IOpponentOrder orderedOpponents = OpponentOrder.Factory(Opponents, Order);

            // Generate Matches for First Round (adds byes)
        MatchGenerator gen = MatchGenerator.Factory(orderedOpponents, Mode, DrawSize);

            // Get the Total Num of Rounds in Tournament
        int totalRounds = (int)NumRounds;

            // Add 1st Round
        Round round = new(1, "Round 1");

            // Add Matches for the First Round
        foreach(var match in gen.MatchList) {
            round.AddMatch(match);
        }
        Rounds.Add(round);

            // All Additional Rounds
        for(int roundId = 2; roundId <= totalRounds; roundId++) {

            GenerateWinningBracket(totalRounds, roundId, (int)gen.DrawSize, 100 * roundId);
            GenerateLosingBracket(totalRounds, roundId, (int)gen.DrawSize, 1000 * roundId);
        }

    }


    // <summary>
    // Generate Winning Side Bracket
    // </summary>
    public void GenerateWinningBracket(int totalRounds, int roundId, int drawSize, int id) {
        Round prevRound = null;
        Match prevMatch1 = null;
        Match prevMatch2 = null;
        Match nextMatch = null;

        var round = new Round(roundId, $"Round {roundId}");
            //RoundId = (RoundId)(totalRounds - (roundId - 1))
        //};

            // Find the number of matches in this round
        int numMatchesInRound = drawSize / (int)Math.Pow(2, roundId);
        
        prevRound = Rounds[roundId - 2];

        int numToAdvance = 1;

        for(int matchId = 1; matchId <= numMatchesInRound; matchId++) {

                // create a match for this round
            nextMatch = Mode == BracketMode.Individual ? 
                new IndividualMatch(id, (RoundId)roundId) :
                new GroupMatch(id, (RoundId)roundId);

            prevMatch1 = prevRound.Matches[(matchId * 2) - 2];
            prevMatch2 = prevRound.Matches[(matchId * 2) - 1]; 

                // Single Elimination means there is only one progression, winner(s) advance
            prevMatch1.SetProgressions(new Progression( prevMatch1, nextMatch, numToAdvance ));
            prevMatch2.SetProgressions(new Progression( prevMatch2, nextMatch, numToAdvance ));

            round.AddMatch(nextMatch);

            id++;
        }


        Rounds.Add(round);
    }


    // <summary>
    // Generate Losing side of Bracket
    // </summary>
    public void GenerateLosingBracket(int totalRounds, int roundId, int drawSize, int id) {
        int numToAdvance = 1;
        int offset = 1;

        Round prevRound = null;
        Match prevMatch1 = null;
        Match prevMatch2 = null;
        Match nextMatch = null;


        if (Mode == BracketMode.Individual) {
            numToAdvance = 1;
            offset = 1;
        } else {
            offset = 2;
            numToAdvance = 2;
        }

        var round = new Round(roundId, $"Consolation Round {roundId}");
            //RoundId = (RoundId)(totalRounds - (roundId - 1))
        //};

        prevRound = Rounds[roundId - 2];
        
            // Find the number of matches in this round
        int numMatchesInRound = drawSize / (int)Math.Pow(2, roundId);

        for(int i = 1; i <= numMatchesInRound; i++) {

                // create a match for this round
            nextMatch = Mode == BracketMode.Individual ? 
                new IndividualMatch(id, (RoundId)roundId) :
                new GroupMatch(id, (RoundId)roundId);

        
            prevMatch1 = prevRound.Matches[(i * 2) - 2];
            prevMatch2 = prevRound.Matches[(i * 2) - 1]; 

                // Single Elimination means there is only one progression, winner(s) advance
            prevMatch1.SetProgressions(new Progression( prevMatch1, nextMatch, numToAdvance, offset ));
            prevMatch2.SetProgressions(new Progression( prevMatch2, nextMatch, numToAdvance, offset ));

            round.AddMatch(nextMatch);

            id++;
            Console.WriteLine($"  {nextMatch}");

        }
        
        Console.WriteLine($"{round}");

        //Rounds.Add(round);
    }
}
