public class Participant{
    public Guid ParticipantId { get; set; }
    public string? Email { get; set; }
    public string? TokenValue { get; set; }

    public bool isValid { get; set; }
}