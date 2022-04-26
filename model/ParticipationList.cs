public class ParticipationList{
    public int ParticipationListId { get; set; }
    public string? Name { get; set; }

    public ICollection<string?>? Emails { get; set; }
}