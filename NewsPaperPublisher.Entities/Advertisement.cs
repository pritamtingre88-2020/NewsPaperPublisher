namespace NewsPaperPublisher.Entities
{
    public class Advertisement
    {
        public string Product { get; set; }

        public string AdContent { get; set; }

        public AddCategory AddCategory { get; set; }
    }

    public enum AddCategory
    {
        BeautyProducts,
        SportsAccessories,
        Political
    }
}
