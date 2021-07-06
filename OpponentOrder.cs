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

        public DrawType GroupDrawSize { get; private set; }

        public Dictionary<int, Opponent> OpponentsInOrder { get; private set; }

        public int NumByes { get; private set; }


        public OpponentOrder(List<Opponent> opps) {
            OpponentsInOrder = new Dictionary<int, Opponent>();

            var numOpponents = opps.Count;

                // Individual
            DrawSize = DetermineDrawSize(numOpponents);
            NumByes = (int)DrawSize - numOpponents;

                
                // Group/Bracket
            var maxInGroup = 4;
            var numGroups = (numOpponents % maxInGroup) + (numOpponents % maxInGroup == 0 ? 0 : 1);
            GroupDrawSize = DetermineDrawSize(numGroups);
            //NumByes = (int)DrawSize - opps.Count;
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


        DrawType DetermineDrawSize(int num) {

            DrawType drawSize = 0;
            if (num <= (int)DrawType.Draw2) {
                drawSize = DrawType.Draw2;
            } else if (num <= (int)DrawType.Draw4) {
                drawSize = DrawType.Draw4;
            } else if (num <= (int)DrawType.Draw8) {
                drawSize = DrawType.Draw8;
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
    }
}
