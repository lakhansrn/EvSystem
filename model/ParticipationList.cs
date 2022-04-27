public class ParticipationList{
    public Guid ParticipationListId { get; set; }
    public string? Name { get; set; }

    public ICollection<string?>? Emails { get; set; }
}