namespace CouchParty.Tournament;

using CouchParty.Tournament.Exceptions;


public sealed record SeededMatch(int opponent1Seed, int opponent2seed);


public sealed class StartingMatches {

	public uint DrawSize { get; private set; }

	//public List<(int,int)> matchList { get; private set; }

	public StartingMatches(uint drawSize) {
		DrawSize = drawSize;
		//MatchList = SetSeededMatches();
	}


    public List<(int,int)> GetSeededMatches() {
        List<(int,int)> matchList = new List<(int seedPos1, int seedPos2)>();

            // Setup Matches Per Round
        switch(DrawSize) {
            case 2:
				matchList = GetDrawSize2();
                break;

            case 4:
				matchList = GetDrawSize4();
                break;

            case 8:
				matchList = GetDrawSize8();
                break;

            case 16:
				matchList = GetDrawSize16();
                break;

            case 32:
				matchList = GetDrawSize32();
                break;

            case 64:
				matchList = GetDrawSize64();
                break;

            case 128:
				matchList = GetDrawSize128();
                break;

			default:
				throw new InvalidDrawSizeException();
				break;
		}

        return matchList;
    }


	private List<(int,int)> GetDrawSize2() {
		/*
		return new List<SeededMatch> {
			new SeededMatch(1, 2)
		};*/

    	return new List<(int seedPos1, int seedPos2)> {
    		(1, 2)
    	};
	}

	private List<(int,int)> GetDrawSize4() {
		/*
		return new List<SeededMatch> {
			new SeededMatch(1, 4),
			new SeededMatch(3, 2)
		};*/

    	return new List<(int seedPos1, int seedPos2)> {
        	(1, 4),
        	(3, 2)
    	};
	}

	private List<(int,int)> GetDrawSize8() {
		/*
		return new List<SeededMatch> {
				// Top Half
			new SeededMatch(1, 8),
			new SeededMatch(6, 3),
				// Bottom Half
			new SeededMatch(4, 5),
			new SeededMatch(7, 2)
		};*/

    	return new List<(int seedPos1, int seedPos2)> {
			(1, 8),
			(6, 3),
			(4, 5),
			(7, 2),
		};
	}

	private List<(int,int)> GetDrawSize16() {
		/*
		return new List<SeededMatch> {
				// Top Half
			new SeededMatch(1, 16),
			new SeededMatch(9, 8),
			new SeededMatch(4, 13),
			new SeededMatch(5, 12)
				// Bottom Half
			new SeededMatch(3, 14),
			new SeededMatch(11,6),
			new SeededMatch(7,10),
			new SeededMatch(2,15)
		};*/

    	return new List<(int seedPos1, int seedPos2)> {
			(1, 16),
			(9, 8),
			(4, 13),
			(5, 12),
			(3, 14),
			(11,6),
			(7,10),
			(2,15)
		};
	}

	private List<(int,int)> GetDrawSize32() {
		/*
		return new List<SeededMatch> {
				// 1st Half
			new SeededMatch(1, 32),
			new SeededMatch(16, 17),
			new SeededMatch(9, 24),
			new SeededMatch(8, 25),
				// section
			new SeededMatch(4, 29),
			new SeededMatch(13, 20),
			new SeededMatch(12, 21),
			new SeededMatch(5, 28),
				// 2nd Half
			new SeededMatch(2,31),
			new SeededMatch(15,18),
			new SeededMatch(10,23),
			new SeededMatch(7,26),
				// section
			new SeededMatch(3,30),
			new SeededMatch(14,19),
			new SeededMatch(11,22),
			new SeededMatch(6,27)
		};*/

   		return new List<(int seedPos1, int seedPos2)> {
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
	}

	private List<(int,int)> GetDrawSize64() {
		return new List<(int seedPos1, int seedPos2)> {
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
	}

	private List<(int,int)> GetDrawSize128() {
    	return new List<(int seedPos1, int seedPos2)> {
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
	}
}
