namespace CouchParty.Tournament;

public sealed class NoProgression : IProgression {
    public NoProgression() {
        Offset = 0;
    }

    public int Offset { get; }

    public override string ToString() => $"No Progression";

    public void ProgressOpponents() {
        Console.WriteLine("No progression");
    }
}
