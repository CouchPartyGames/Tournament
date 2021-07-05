using System.Collections.Generic;


namespace CouchParty.Tournament {

    /**
     * Base Class
     */
    public class OpponentOrder {

        public enum DrawType {
            Draw2 = 2,
            Draw4 = 4,
            Draw8 = 8,
            Draw16 = 16,
            Draw32 = 32,
            Draw64 = 64,
            Draw128 = 128
        }

        public DrawType DrawSize { get; private set; }

        public Dictionary<int, Opponent> OpponentsInOrder { get; private set; }

        public int NumByes { get; private set; }


        public OpponentOrder(List<Opponent> opps) {
            OpponentsInOrder = new Dictionary<int, Opponent>();

                // Set Draw Type
            if (opps.Count <= (int)DrawType.Draw2) {
                DrawSize = DrawType.Draw2;
            } else if (opps.Count <= (int)DrawType.Draw4) {
                DrawSize = DrawType.Draw4;
            } else if (opps.Count <= (int)DrawType.Draw8) {
                DrawSize = DrawType.Draw8;
            } else if (opps.Count <= (int)DrawType.Draw16) {
                DrawSize = DrawType.Draw16;
            } else if (opps.Count <= (int)DrawType.Draw32) {
                DrawSize = DrawType.Draw32;
            } else if (opps.Count <= (int)DrawType.Draw64) {
                DrawSize = DrawType.Draw64;
            } else {
                DrawSize = DrawType.Draw128;
            }

            NumByes = (int)DrawSize - opps.Count;
        }

        protected void AddByeOpponents(int startPos) {

                // Determine if Byes are needed
            if (NumByes > 0) {
                for(int j = 0; j < NumByes; j++) {
                    OpponentsInOrder.Add(startPos, new Opponent(0, "Bye", true));
                    startPos++;
                }
            }
        }
    }
}
