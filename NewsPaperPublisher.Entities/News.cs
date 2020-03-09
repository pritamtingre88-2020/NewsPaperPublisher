namespace NewsPaperPublisher.Entities
{
    public class News
    {
        public string Headline { get; set; }

        public string Content { get; set; }

        public NewsCategory Category { get; set; }

        public Priority Priority { get; set; }
    }

    public enum NewsCategory
    {
        Political,
        Finance,
        Crime,
        Entertainment,
        Technical,
        Health,
        Sports
    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }
}
