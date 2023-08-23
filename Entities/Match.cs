namespace CouchParty.Tournament.Entities;


public sealed class Match : BaseEntity {

    List<Guid> _participants;

    Score score;

    List<Guid> _attachments;

    public Match(Guid id) : base(id) {

    }
}