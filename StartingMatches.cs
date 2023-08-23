namespace CouchParty.Tournament;

using CouchParty.Tournament.Exceptions;
using CouchParty.Tournament.ObjectValues;


public interface ISeededMatches {

	uint DrawSize { get; }

	List<SeededMatch> MatchList { get; }
}

public sealed class StartingMatches : ISeededMatches {

	public uint DrawSize { get; private set; }

	public List<SeededMatch> MatchList { get; private set; }

	public StartingMatches(uint drawSize) {
		DrawSize = drawSize;
		MatchList = SetSeededMatches();
	}


    private List<SeededMatch> SetSeededMatches() {
        List<SeededMatch> matchList = new List<SeededMatch>();

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


	private List<SeededMatch> GetDrawSize2() {
		return new List<SeededMatch> {
			new SeededMatch(1, 2)
		};
	}

	private List<SeededMatch> GetDrawSize4() {
		return new List<SeededMatch> {
			new SeededMatch(1, 4),
			new SeededMatch(3, 2)
		};
	}

	private List<SeededMatch> GetDrawSize8() {
		return new List<SeededMatch> {
				// Top Half
			new SeededMatch(1, 8),
			new SeededMatch(6, 3),
				// Bottom Half
			new SeededMatch(4, 5),
			new SeededMatch(7, 2)
		};
	}

	private List<SeededMatch> GetDrawSize16() {
		return new List<SeededMatch> {
				// Top Half
			new SeededMatch(1, 16),
			new SeededMatch(9, 8),
			new SeededMatch(4, 13),
			new SeededMatch(5, 12),
				// Bottom Half
			new SeededMatch(3, 14),
			new SeededMatch(11, 6),
			new SeededMatch(7, 10),
			new SeededMatch(2, 15)
		};
	}

	private List<SeededMatch> GetDrawSize32() {
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
		};
	}

	private List<SeededMatch> GetDrawSize64() {
		return new List<SeededMatch> {
				// 1st Bracket
			new SeededMatch(1, 64),
			new SeededMatch(32, 33),
			new SeededMatch(17, 48),
			new SeededMatch(16, 49),
			new SeededMatch(9, 56),
			new SeededMatch(24, 41),
			new SeededMatch(25, 40),
			new SeededMatch(8, 57),
				// 2nd Bracket
			new SeededMatch(4, 61),
			new SeededMatch(29, 36),
			new SeededMatch(20, 45),
			new SeededMatch(13, 52),
			new SeededMatch(12, 53),
			new SeededMatch(21, 44),
			new SeededMatch(28, 37),
			new SeededMatch(5, 60),
				// 3rd Bracket
			new SeededMatch(2, 63),
			new SeededMatch(31, 34),
			new SeededMatch(18, 47),
			new SeededMatch(15, 50),
			new SeededMatch(10, 55),
			new SeededMatch(23, 42),
			new SeededMatch(26, 39),
			new SeededMatch(7, 58),
				// 4th Bracket
			new SeededMatch(3, 62),
			new SeededMatch(30, 35),
			new SeededMatch(19, 46),
			new SeededMatch(14, 51),
			new SeededMatch(11, 54),
			new SeededMatch(22, 43),
			new SeededMatch(27, 38),
			new SeededMatch(6, 59)
		};
	}

	private List<SeededMatch> GetDrawSize128() {
		return new List<SeededMatch> {
				// 1st Bracket
			new SeededMatch(1, 128),
			new SeededMatch(64, 65),
			new SeededMatch(32, 97),
			new SeededMatch(33, 96),
			new SeededMatch(16, 113),
			new SeededMatch(49, 80),
			new SeededMatch(17, 112),
			new SeededMatch(48, 81),
			new SeededMatch(8, 121),
			new SeededMatch(57, 72),
			new SeededMatch(25, 104),
			new SeededMatch(40, 89),
			new SeededMatch(9, 120),
			new SeededMatch(56, 73),
			new SeededMatch(24, 105),
			new SeededMatch(41, 88),
				// 2nd Bracket
			new SeededMatch(4, 125),
			new SeededMatch(61, 68),
			new SeededMatch(29, 100),
			new SeededMatch(36, 93),
			new SeededMatch(13, 116),
			new SeededMatch(52, 77),
			new SeededMatch(20, 109),
			new SeededMatch(45, 84),
			new SeededMatch(5, 124),
			new SeededMatch(60, 69),
			new SeededMatch(28, 101),
			new SeededMatch(37, 92),
			new SeededMatch(12, 117),
			new SeededMatch(53, 76),
			new SeededMatch(21, 108),
			new SeededMatch(44, 85),
				// 3rd Bracket
			new SeededMatch(2, 127),
			new SeededMatch(63, 66),
			new SeededMatch(31, 98),
			new SeededMatch(34, 95),
			new SeededMatch(15, 114),
			new SeededMatch(50, 79),
			new SeededMatch(18, 111),
			new SeededMatch(47, 82),
			new SeededMatch(7, 122),
			new SeededMatch(58, 71),
			new SeededMatch(26, 103),
			new SeededMatch(39, 90),
			new SeededMatch(10, 119),
			new SeededMatch(55, 74),
			new SeededMatch(23, 106),
			new SeededMatch(42, 87),
				// 4th Bracket
			new SeededMatch(3, 126),
			new SeededMatch(62, 67),
			new SeededMatch(30, 99),
			new SeededMatch(35, 94),
			new SeededMatch(14, 115),
			new SeededMatch(51, 78),
			new SeededMatch(19, 110),
			new SeededMatch(46, 83),
			new SeededMatch(6, 123),
			new SeededMatch(59, 70),
			new SeededMatch(27, 102),
			new SeededMatch(38, 91),
			new SeededMatch(11, 118),
			new SeededMatch(54, 75),
			new SeededMatch(22, 107),
			new SeededMatch(43, 86)
		};

	}
}
