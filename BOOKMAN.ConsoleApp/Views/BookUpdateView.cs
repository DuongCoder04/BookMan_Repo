namespace BOOKMAN.ConsoleApp.Views
{
    using BOOKMAN.ConsoleApp.Framework;
    using BOOKMAN.ConsoleApp.Models;
    internal class BookUpdateView
    {
        protected Book Model;
        public BookUpdateView(Book model)
        {
            Model = model;
        }
        public void Render(Book Model)
        {
            ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green); //sử dụng phương thức static
            var authors = ViewHelp.InputString("Authors", Model.Authors);
            var title = ViewHelp.InputString("Title", Model.Title);
            var publisher = ViewHelp.InputString("Publisher", Model.Publisher);
            var isbn = ViewHelp.InputString("Isbn", Model.Isbn);
            var tags = ViewHelp.InputString("Tags", Model.Tags);
            var description = ViewHelp.InputString("Description", Model.Description);
            var file = ViewHelp.InputString("File", Model.File);
            var year = ViewHelp.InputInt("Year", Model.Year);
            var edition = ViewHelp.InputInt("Edition", Model.Edition);
            var rating = ViewHelp.InputInt("Rate", Model.Rating);
            var reading = ViewHelp.InputBool("Reading", Model.Reading);
        }
    }
}
