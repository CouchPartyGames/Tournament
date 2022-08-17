namespace CouchParty.Tournament;

public interface IProgression {

    int Offset { get; }

    void ProgressOpponents() {}
}