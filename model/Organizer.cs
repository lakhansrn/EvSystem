using Newtonsoft.Json;

public class Organizer{
     [JsonProperty(PropertyName = "id")]
    public Guid OrganizerId { get; set; }

    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ICollection<Poll> Polls { get; set; }
    public ICollection<ParticipationList> ParticipationLists { get; set; }
}