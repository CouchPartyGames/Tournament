namespace CouchParty.Tournament.ValueObjects;

// <summary>
// set range of participants 
// </summary>
public sealed record ParticipantLimits {

	public int MaxParticipants { get; }

	public int MinParticipants { get; }

	private ParticipantLimits(int min, int max) => (MinParticipants, MaxParticipants) = (min, max);

	public static ParticipantLimits? Create(int min, int max) {
		if (max < min) {
			return null;
		}

		return new ParticipantLimits(min, max);
	}
}
