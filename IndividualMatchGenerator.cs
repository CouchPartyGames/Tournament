namespace CouchParty.Tournament;

using CouchParty.Tournament.Exceptions;


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
		var matchList = seededMatches.GetSeededMatches();

        AddMatch(matchList, round);
    }


    
    // <summary>
    // Add Matches to List 
    //
    // </summary>
    void AddMatch(List<(int,int)> matchList, RoundId round) {
        int id = 1;

        foreach( var matchOpponents in matchList) {

            if (!OpponentList.TryGetValue(matchOpponents.Item1 - 1, out Opponent opponent1)) {
                throw new ArgumentOutOfRangeException("Bad Index in OpponentList", nameof(opponent1));
            }

            if (!OpponentList.TryGetValue(matchOpponents.Item2 - 1, out Opponent opponent2)) {
                throw new ArgumentOutOfRangeException("Bad Index in OpponentList", nameof(opponent2));
            }

            /*
            Opponent opponent1 = OpponentList.FirstOrDefault(x => x.Id == matchOpponents.Item1 - 1);
            Opponent opponent2 = OpponentList.FirstOrDefault(x => x.Id == matchOpponents.Item2 - 1);
            */
            var match = new IndividualMatch(id, round, opponent1, opponent2);
            MatchList.Add(match);
            id++;
        }
    }
}

