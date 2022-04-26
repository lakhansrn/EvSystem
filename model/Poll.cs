public class Poll{
    public int PollId { get; set; }
    public string? Title { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public PollState State { get; set; }
    public string? Description { get; set; }

    public bool IsTrackingEnabled { get; set; }
    public ICollection<Question> Questions { get; set; }
    public ICollection<Participant> Participants { get; set; }  

}