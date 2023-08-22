namespace CouchParty.Tournament;

using CouchParty.Tournament.Exceptions;
using CouchParty.Tournament.ObjectValues;


public class IndividualMatchGenerator : MatchGenerator {


    public IndividualMatchGenerator(IOpponentOrder order, uint drawSize) : base(order.OpponentsInOrder) {

        var numOpponents = OpponentList.Count;
        NumByes = (int)drawSize - numOpponents;

            // Add Byes
        AddByeOpponents();


            // Setup Matches Per Round
        switch(drawSize) {
            case 2:
                DrawOther(RoundId.Finals, drawSize);
                break;

            case 4:
                DrawOther(RoundId.Semifinals, drawSize);
                break;

            case 8:
                DrawOther(RoundId.Quarterfinals, drawSize);
                break;

            case 16:
                DrawOther(RoundId.Round16, drawSize);
                break;

            case 32:
                DrawOther(RoundId.Round32, drawSize);
                break;

            case 64:
                DrawOther(RoundId.Round64, drawSize);
                break;

            case 128:
                DrawOther(RoundId.Round128, drawSize);
                break;

			default:
				throw new InvalidDrawSizeException();
				break;
        }
    }


    // <summary>
    // Place seeded opponents in the proper match in the draw for 64 draw
    //
    // https://www.printyourbrackets.com/32seeded.html
    // https://www.printyourbrackets.com/64seeded.html
    // https://www.printyourbrackets.com/pdfbrackets/128teamseeded.pdf
    // </summary>
    void DrawOther(RoundId round, uint drawSize) {
		var seededMatches = new StartingMatches(drawSize);

        AddMatch(seededMatches.MatchList, round);
    }


    
    // <summary>
    // Add Opponents from Seeded Matches
    // </summary>
    void AddMatch(List<SeededMatch> matchList, RoundId round) {
        int id = 1;
		int seedIndex = 0;

        foreach( var seededMatch in matchList) {

			seedIndex = seededMatch.opponent1Seed - 1;
            if (!OpponentList.TryGetValue(seedIndex, out Opponent opponent1)) {
                throw new MissingOpponentFromListException();
            }

			seedIndex = seededMatch.opponent2Seed - 1;
            if (!OpponentList.TryGetValue(seedIndex, out Opponent opponent2)) {
                throw new MissingOpponentFromListException();
            }

            var match = new IndividualMatch(id, round, opponent1, opponent2);
            MatchList.Add(match);
            id++;
        }
    }
}

