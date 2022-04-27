public class Question{
    public Guid QuesionId { get; set; }
    public string? Title { get; set; }
    public QuestionType Type { get; set; }
    public int MaxChoice { get; set; }
    public int MinChoice { get; set; }

    public ICollection<Item> Items { get; set; }
}