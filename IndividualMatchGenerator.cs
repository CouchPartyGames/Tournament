
namespace CouchParty.Tournament {

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
                    DrawSemifinals();
                    break;

                case DrawType.Quarterfinals:
                    DrawQuarterfinals();
                    break;

                case DrawType.Draw16:
                    Draw16();
                    break;

                case DrawType.Draw32:
                    Draw32();
                    break;

                case DrawType.Draw64:
                    Draw64();
                    break;

                case DrawType.Draw128:
                    Draw128();
                    break;
            }
        }


        void DrawFinals() {
            var round = IndividualMatch.RoundId.Finals;

            var matchList = new List<(int seedPos1, int seedPos2)> {
                (1, 2)
            };

            AddMatch(matchList, round);
        }


        void DrawSemifinals() {
            var round = IndividualMatch.RoundId.Semifinals;

            var matchList = GetOpponentSeeding(OpponentList.Count);

            AddMatch(matchList, round);
        }


        void DrawQuarterfinals() {
            var round = IndividualMatch.RoundId.Quarterfinals;

            var matchList = GetOpponentSeeding(OpponentList.Count);

            AddMatch(matchList, round);
        }


        void Draw16() {
            var round = IndividualMatch.RoundId.Round16;

            var matchList = GetOpponentSeeding(OpponentList.Count);

            AddMatch(matchList, round);
        }


        // https://www.printyourbrackets.com/32seeded.html
        void Draw32() {
            var round = IndividualMatch.RoundId.Round32;

            var matchList = GetOpponentSeeding(OpponentList.Count);

            AddMatch(matchList, round);
        }


        // <summary>
        // Place seeded opponents in the proper match in the draw for 64 draw
        //
        // https://www.printyourbrackets.com/64seeded.html
        // </summary>
        void Draw64() {
            var round = IndividualMatch.RoundId.Round64;

            var matchList = GetOpponentSeeding(OpponentList.Count);

            AddMatch(matchList, round);
        }

        // <summary>
        // Place seeded opponents in the proper match in the draw for 128 draw
        //
        // https://www.printyourbrackets.com/pdfbrackets/128teamseeded.pdf
        // </summary>
        void Draw128() {
            var round = IndividualMatch.RoundId.Round128;

            var matchList = GetOpponentSeeding(OpponentList.Count);

            AddMatch(matchList, round);
        }


        
        void AddMatch(List<(int,int)> matchList, IndividualMatch.RoundId round) {
            int id = 1;

            foreach( var matchOpponents in matchList) {
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
}

