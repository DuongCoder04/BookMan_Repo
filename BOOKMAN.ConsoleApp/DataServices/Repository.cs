using BOOKMAN.ConsoleApp.Models;

namespace BOOKMAN.ConsoleApp.DataServices
{
    public class Repository
    {
        protected readonly SimpleDataAccess context;
        public Repository(SimpleDataAccess context)
        {
            this.context = context;
            context.Load();
        }
        public void SaveChanges()=> context.SaveChanges();
        public List<Book> Books=> context.Books;
        public Book[] Select()=> context.Books.ToArray();
        public Book Select(int id)
        {
            foreach(var b in context.Books)
            {
                if (b.Id == id) return b;
            }
            return null;
        }
        public Book[] Select(string key) 
        {
            var temp = new List<Book>();
            var k = key.ToLower();
            foreach(var b in context.Books)
            {
                var logic =
                    b.Title.ToLower().Contains(k) ||
                    b.Authors.ToLower().Contains(k) ||
                    b.Publisher.ToLower().Contains(k) ||
                    b.Tags.ToLower().Contains(k) ||
                    b.Description.ToLower().Contains(k)
                    ;
                if(logic) temp.Add(b);
            }
            return temp.ToArray();
        }
        public void Insert(Book book)
        {
            var lastIndex = context.Books.Count - 1;
            var id = lastIndex < 0 ? 1: context.Books[lastIndex].Id + 1;
            book.Id = id;
            context.Books.Add(book);
        }
        public bool Delete(int id)
        {
            var b = Select(id);
            if (b == null) return false;
            context.Books.Remove(b);
            return true;   
        }
        public bool Update(int id, Book book)
        {
            var b = Select(id);
            if (b == null) return false;
            b.Authors       = book.Authors;
            b.Description   = book.Description;
            b.Edition       = book.Edition;
            b.File          = book.File;
            b.Isbn          = book.Isbn;
            b.Publisher     = book.Publisher;
            b.Rating        = book.Rating;
            b.Reading       = book.Reading;
            b.Tags          = book.Tags;                                                            
            b.Title         = book.Title;
            b.Year          = book.Year;
            return true;
        }
        public Book[] SelectMarked()
        {
            var list = new List<Book>();
            foreach(var b in Books)
            {
                if(b.Reading) list.Add(b);
            }
            return list.ToArray();
        }
        public void Clear()
        {
            context.Books.Clear();
        }

    }
}
