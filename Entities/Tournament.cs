namespace CouchParty.Tournament.Entities;

public sealed class Tournament : BaseEntity {

    string Name; 

    Guid GameId; 

    Registration _registration;

    Location _location;

    public Tournament(Guid id, string name, Guid gameId) : base(id) {

    }
}