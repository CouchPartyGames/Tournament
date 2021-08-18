
namespace CouchParty.Tournament;


public class IndividualMatchGenerator : MatchGenerator {


    public IndividualMatchGenerator(IOpponentOrder order) : base(order.OpponentsInOrder) {

        var numOpponents = OpponentList.Count;
        DrawSize = DetermineDrawSize(numOpponents);
        NumByes = (int)DrawSize - numOpponents;

            // Add Byes
        AddByeOpponents();


            // Setup Matches Per Round
        switch(DrawSize) {
            case DrawType.Finals:
                DrawFinals();
                break;

            case DrawType.Semifinals:
                DrawOther(RoundId.Semifinals);
                break;

            case DrawType.Quarterfinals:
                DrawOther(RoundId.Quarterfinals);
                break;

            case DrawType.Draw16:
                DrawOther(RoundId.Round16);
                break;

            case DrawType.Draw32:
                DrawOther(RoundId.Round32);
                break;

            case DrawType.Draw64:
                DrawOther(RoundId.Round64);
                break;

            case DrawType.Draw128:
                DrawOther(RoundId.Round128);
                break;
        }
    }


    void DrawFinals() {
        var round = RoundId.Finals;

        var matchList = new List<(int seedPos1, int seedPos2)> {
            (1, 2)
        };

        AddMatch(matchList, round);
    }


    // <summary>
    // Place seeded opponents in the proper match in the draw for 64 draw
    //
    // https://www.printyourbrackets.com/32seeded.html
    // https://www.printyourbrackets.com/64seeded.html
    // https://www.printyourbrackets.com/pdfbrackets/128teamseeded.pdf
    // </summary>
    void DrawOther(RoundId round) {
        var matchList = GetOpponentSeeding(OpponentList.Count);

        AddMatch(matchList, round);
    }


    
    void AddMatch(List<(int,int)> matchList, RoundId round) {
        int id = 1;

        foreach( var matchOpponents in matchList) {

            /*if (!OpponentList.TryGetValue(matchOpponents.Item1, out Opponent opponent1)) {
            }*/
            Opponent opponent1 = OpponentList[matchOpponents.Item1 - 1];
            Opponent opponent2 = OpponentList[matchOpponents.Item2 - 1];

            /*
            Opponent opponent1 = OpponentList.FirstOrDefault(x => x.Id == matchOpponents.Item1 - 1);
            Opponent opponent2 = OpponentList.FirstOrDefault(x => x.Id == matchOpponents.Item2 - 1);
            */
            MatchList.Add(new IndividualMatch(id, round, opponent1, opponent2));
            id++;
        }
    }
}

