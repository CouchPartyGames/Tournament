namespace CouchParty.Tournament.Entities;


public sealed class Attachment : BaseEntity {

    string Url;

    public Attachment(Guid id, string url) : base(id) {
        Url = url;
    }
}