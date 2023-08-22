
namespace CouchParty.Tournament.Preset;

public sealed class SingleElimination : Tournament {


    public SingleElimination(int id, string name, List<Opponent> opps) : 
		base(id, name, opps) {
    }


    public override void Generate() {
        int numToAdvance = 1;
        int numMatchesInRound = 0; 
        int id = 100;

        Round prevRound = null;
        Match prevMatch1 = null;
        Match prevMatch2 = null;

        Match nextMatch = null;
        
            // order all opponents in the draw (doesn't include byes)
        IOpponentOrder orderedOpponents = OpponentOrder.Factory(Opponents, Order);

            // Generate Matches for First Round (adds byes)
        MatchGenerator gen = MatchGenerator.Factory(orderedOpponents, Mode, DrawSize);

            // Add 1st Round
        Round round = new(1, "Round 1");

            // Add Matches for the First Round
        foreach(var match in gen.MatchList) {
            round.AddMatch(match);
        }
        Rounds.Add(round);
        
        numToAdvance = Mode == BracketMode.Individual ? 1 : 2;

            // All Additional Rounds
        for(int roundId = 2; roundId <= NumRounds; roundId++) {

            round = new Round(roundId, $"Round {roundId}");

                // Find the number of matches in this round
            numMatchesInRound = (int)gen.DrawSize / (int)Math.Pow(2, roundId);
            
            prevRound = Rounds[roundId - 2];

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
    }
}
