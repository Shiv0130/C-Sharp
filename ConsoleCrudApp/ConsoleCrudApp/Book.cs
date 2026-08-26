namespace ConsoleCrudApp
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int? PublishedYear { get; set; }
        public int CategoryId { get; set; }
        //Why is it public Category? Category does this state that this has a one to many relationship with the Category class?
        //Yes, it does. The public Category? Category { get; set; } line in the Book class indicates that each Book can be associated with one Category, and the question mark (?) indicates that this association is optional (i.e., a Book may or may not have a Category). This establishes a one-to-many relationship between Category and Book, where one Category can have many Books, but each Book can belong to only one Category.
        public Category? Category { get; set; }
    }
}