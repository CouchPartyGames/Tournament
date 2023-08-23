namespace CouchParty.Tournament.ValueObjects;

// <summary>
// rank/seed of opponents in a match
// </summary>
public sealed record SeededMatch(int opponent1Seed, int opponent2Seed);
