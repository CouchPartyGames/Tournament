

namespace CouchParty.Tournament; 

public class IndividualMatch : Match {


    public IndividualMatch(int id, RoundId round) : base(id, round) {
        MinOpponents = 2;
        MaxOpponents = 2;
        NumWinners = 1;
    }


    public IndividualMatch(int id, RoundId round, Opponent opp1, Opponent opp2) : base(id, round) {
        AddOpponent(opp1);
        AddOpponent(opp2);
    }

    // <summary>
    // Set Opponents of the Match
    // </summary>
    public void SetOpponents(Opponent opp1, Opponent opp2) {
        AddOpponent(opp1);
        AddOpponent(opp2);
    }


    public override void AddOpponent(Opponent opponent) {
        if (Opponents.Count >= 2) {
            return;
        }

        Opponents.Add(opponent);
    }


    public void SetWinner(Opponent winner) {
        /*
        if (Opponents.Contains(winner)) {
            foreach(var opp in Opponents.ToList()) {
                
            }

            SortedList finalResults = new SortedList<int, Opponent>() {
                1, winner,
                2, loser
            };
            SetResults(finalResults);
        }*/
    }



    public override string ToString() {

        var sb = new System.Text.StringBuilder();
        sb.Append( $"Individual Match: #{Id} Opponents: ");

        foreach(var opponent in Opponents) {
            sb.Append( $" {opponent} ");
        }
        return sb.ToString();
        //return $"Individual Match: #{Id} - {Opponents[0]} vs {Opponents[1]} - {State.ToString()}";
    }
}
