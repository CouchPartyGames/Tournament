using System.Collections.Generic;
using System.Linq;

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

            var matchList = new List<(int seedPos1, int seedPos2)> {
                (1, 4),
                (3, 2)
            };

            AddMatch(matchList, round);
        }


        void DrawQuarterfinals() {
            var round = IndividualMatch.RoundId.Quarterfinals;

            var matchList = new List<(int seedPos1, int seedPos2)> {
                (1, 8),
                (6, 3),
                (4, 5),
                (7, 2),
            };

            AddMatch(matchList, round);
        }


        void Draw16() {
            var round = IndividualMatch.RoundId.Round16;

            var matchList = new List<(int seedPos1, int seedPos2)> {
                (1, 16),
                (9, 8),
                (4, 13),
                (5, 12),
                (3, 14),
                (11,6),
                (7,10),
                (2,15)
            };

            AddMatch(matchList, round);
        }


        // https://www.printyourbrackets.com/32seeded.html
        void Draw32() {
            var round = IndividualMatch.RoundId.Round32;

            var matchList = new List<(int seedPos1, int seedPos2)> {
                // 1st Half
                (1, 32),
                (16, 17),
                (9, 24),
                (8, 25),
                // sec
                (4, 29),
                (13, 20),
                (12, 21),
                (5, 28),
                // 2nd Half
                (2,31),
                (15,18),
                (10,23),
                (7,26),
                // sec
                (3,30),
                (14,19),
                (11,22),
                (6,27)
            };

            AddMatch(matchList, round);
        }


        // <summary>
        // Place seeded opponents in the proper match in the draw for 64 draw
        //
        // https://www.printyourbrackets.com/64seeded.html
        // </summary>
        void Draw64() {
            var round = IndividualMatch.RoundId.Round64;

            var matchList = new List<(int seedPos1, int seedPos2)> {
                // 1st Bracket
                (1,64),
                (32,33),
                (17,48),
                (16,49),
                (9,56),
                (24,41),
                (25,40),
                (8,57),
                // 2nd Bracket
                (4,61),
                (29,36),
                (20,45),
                (13,52),
                (12,53),
                (21,44),
                (28,37),
                (5,60),
                // 3rd Bracket
                (2,63),
                (31,34),
                (18,47),
                (15,50),
                (10,55),
                (23,42),
                (26,39),
                (7,58),
                // 4th Bracket
                (3,62),
                (30,35),
                (19,46),
                (14,51),
                (11,54),
                (22,43),
                (27,38),
                (6,59)
            };

            AddMatch(matchList, round);
        }

        // <summary>
        // Place seeded opponents in the proper match in the draw for 128 draw
        //
        // https://www.printyourbrackets.com/pdfbrackets/128teamseeded.pdf
        // </summary>
        void Draw128() {
            var round = IndividualMatch.RoundId.Round128;

            var matchList = new List<(int seedPos1, int seedPos2)> {
                // 1st Bracket
                (1,128),
                (64,65),
                (32,97),
                (33,96),
                (16,113),
                (49,80),
                (17,112),
                (48,81),
                (8,121),
                (57,72),
                (25,104),
                (40,89),
                (9,120),
                (56,73),
                (24,105),
                (41,88),
                // 2nd Bracket
                (4,125),
                (61,68),
                (29,100),
                (36,93),
                (13,116),
                (52,77),
                (20,109),
                (45,84),
                (5,124),
                (60,69),
                (28,101),
                (37,92),
                (12,117),
                (53,76),
                (21,108),
                (44,85),
                // 3rd Bracket
                (2,127),
                (63,66),
                (31,98),
                (34,95),
                (15,114),
                (50,79),
                (18,111),
                (47,82),
                (7,122),
                (58,71),
                (26,103),
                (39,90),
                (10,119),
                (55,74),
                (23,106),
                (42,87),
                // 4th Bracket
                (3,126),
                (62,67),
                (30,99),
                (35,94),
                (14,115),
                (51,78),
                (19,110),
                (46,83),
                (6,123),
                (59,70),
                (27,102),
                (38,91),
                (11,118),
                (54,75),
                (22,107),
                (43,86)

            };

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

