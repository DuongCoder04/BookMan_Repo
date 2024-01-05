using BOOKMAN.ConsoleApp.Models;

namespace BOOKMAN.ConsoleApp.DataServices
{
    public class SimpleDataAccess
    {
        public List<Book> Books { get; set; }
        public void Load()
        {
            Books = new List<Book>
            {
                new Book{Id=1, Title = "A new book 1"},
                new Book{Id=2, Title = "A new book 2"},
                new Book{Id=3, Title = "A new book 3"},
                new Book{Id=4, Title = "A new book 4"},
                new Book{Id=5, Title = "A new book 5"},
                new Book{Id=6, Title = "A new book 6"},
                new Book{Id=7, Title = "A new book 7"},
                new Book{Id=8, Title = "A new book 8"},
                new Book{Id=9, Title = "A new book 9"},
            };
        }
        public void SaveChanges() { }
    }
}
