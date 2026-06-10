namespace ConsoleCrudApp
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int? PublishedYear { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}