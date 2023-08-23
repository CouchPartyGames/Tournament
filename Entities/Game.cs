namespace CouchParty.Tournament.Entities;


public sealed class Game : BaseEntity {
    string Name;

    public Game(Guid id, string name) : base(id) {
        Name = name;
    }
}