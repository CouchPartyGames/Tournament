using System.Collections.Generic;

namespace CouchParty.Tournament {


    public class MatchGenerator {

        public enum DrawType {
            Finals = 2,
            Semifinals = 4,
            Quarterfinals = 8,
            Draw16 = 16,
            Draw32 = 32,
            Draw64 = 64,
            Draw128 = 128
        }

        public List<IMatch> MatchList { get; protected set; }

        public DrawType DrawSize { get; protected set; }

        public int NumByes { get; protected set; }

        public Dictionary<int, Opponent> Opponents { get; private set; }

        public MatchGenerator(Dictionary<int, Opponent> opps) {
            MatchList = new List<IMatch>();
            NumByes = 0;

            Opponents = new Dictionary<int, Opponent>(opps);
        }


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


        protected void AddByeOpponents(int startPos) {

                // Determine if Byes are needed
            if (NumByes > 0) {
                for(int j = 0; j < NumByes; j++) {
                    Opponents.Add(startPos, new Opponent(0, "Bye", true));
                    startPos++;
                }
            }
        }
    }
}
