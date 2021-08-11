
namespace CouchParty.Tournament;


public enum DrawType {
    Finals = 2,
    Semifinals = 4,
    Quarterfinals = 8,
    Draw16 = 16,
    Draw32 = 32,
    Draw64 = 64,
    Draw128 = 128
}


public class MatchGenerator {


    // <summary>
    // List of Matches
    // </summary>
    public List<Match> MatchList { get; protected set; }

    public DrawType DrawSize { get; protected set; }

    public int NumByes { get; protected set; }

    public Dictionary<int, Opponent> OpponentList { get; private set; }


    public MatchGenerator(Dictionary<int, Opponent> opps) {
        MatchList = new List<Match>();
        NumByes = 0;

        OpponentList = new Dictionary<int, Opponent>(opps);
    }



    public static MatchGenerator Factory(IOpponentOrder orderedOpponents, BracketMode type) {
        MatchGenerator generator = null;
        switch(type) {
            case BracketMode.Individual:
                generator = new IndividualMatchGenerator(orderedOpponents);
                break;

            case BracketMode.Group:
                generator = new GroupMatchGenerator(orderedOpponents);
                break;
        }

        return generator;
    }


    // <summary>
    // Add Byes where needed
    // </summary>
    protected void AddByeOpponents() {
        var id = OpponentList.Count;

            // Determine if Byes are needed
        if (NumByes > 0) {
            for(int j = 0; j < NumByes; j++) {
                OpponentList.Add(id, new Opponent(0, "Bye", true));
                id ++;
            }
        }
    }


    // <summary>
    // </summary>
    protected DrawType DetermineDrawSize(int num) {
        DrawType drawSize = 0;
        if (num <= (int)DrawType.Finals) {
            drawSize = DrawType.Finals;
        } else if (num <= (int)DrawType.Semifinals) {
            drawSize = DrawType.Semifinals;
        } else if (num <= (int)DrawType.Quarterfinals) {
            drawSize = DrawType.Quarterfinals;
        } else if (num <= (int)DrawType.Draw16) {
            drawSize = DrawType.Draw16;
        } else if (num <= (int)DrawType.Draw32) {
            drawSize = DrawType.Draw32;
        } else if (num <= (int)DrawType.Draw64) {
            drawSize = DrawType.Draw64;
        } else {
            drawSize = DrawType.Draw128;
        }

        return drawSize;
    }


    // <summary>
    // Get Player Seeding/Position in the Tournament depending on player/draw size
    // </summary>
    protected List<(int,int)> GetOpponentSeeding(int numOpponents) {

        List<(int,int)> matchList = new List<(int seedPos1, int seedPos2)>();

            // Setup Matches Per Round
        switch(numOpponents) {
            case 2:

                matchList = new List<(int seedPos1, int seedPos2)> {
                    (1, 2)
                };
                break;

            case 4:
                matchList = new List<(int seedPos1, int seedPos2)> {
                    (1, 4),
                    (3, 2)
                };
                break;

            case 8:
                matchList = new List<(int seedPos1, int seedPos2)> {
                    (1, 8),
                    (6, 3),
                    (4, 5),
                    (7, 2),
                };

                break;

            case 16:
                matchList = new List<(int seedPos1, int seedPos2)> {
                    (1, 16),
                    (9, 8),
                    (4, 13),
                    (5, 12),
                    (3, 14),
                    (11,6),
                    (7,10),
                    (2,15)
                };
                break;

            case 32:

                matchList = new List<(int seedPos1, int seedPos2)> {
                    // 1st Half
                    (1, 32),
                    (16, 17),
                    (9, 24),
                    (8, 25),
                    // section
                    (4, 29),
                    (13, 20),
                    (12, 21),
                    (5, 28),
                    // 2nd Half
                    (2,31),
                    (15,18),
                    (10,23),
                    (7,26),
                    // section
                    (3,30),
                    (14,19),
                    (11,22),
                    (6,27)
                };

                break;

            case 64:

                matchList = new List<(int seedPos1, int seedPos2)> {
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

                break;

            case 128:
                matchList = new List<(int seedPos1, int seedPos2)> {
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

                break;
            }

        return matchList;
    }

}
