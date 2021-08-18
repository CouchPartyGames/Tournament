namespace CouchParty.Tournament;


public class GroupMatch : Match {


    public int MinOpponents { get; set; } = 2;

    public int MaxOpponents { get; set; } = 4;

    public int NumWinners { get; set; } = 2;



    public GroupMatch(int id, RoundId round) : base(id, round) {
    }


    public override void AddOpponent(Opponent opponent) {
        if (Opponents.Count >= MaxOpponents) {
            return;
        }

        Opponents.Add(opponent);
    }



    public override string ToString() {
        var sb = new System.Text.StringBuilder();
        sb.Append( $"Group Match Id: {Id} Opponents:");
        foreach(var opponent in Opponents) {
        //foreach(KeyValuePair<int, Opponent> opponent in Opponents) {
            //sb.Append( $" {opponent.Value.Name}{opponent.Value.Id} ");
            sb.Append( $" {opponent.Name} {opponent.Id} ");
        }
        return sb.ToString();
    }
}

