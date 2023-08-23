namespace CouchParty.Tournament.Entities;

public class BaseEntity {
    public Guid Id { get; private set; }

    protected BaseEntity(Guid id) => Id = id;
}