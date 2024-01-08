namespace BOOKMAN.ConsoleApp.Views
{
    using BOOKMAN.ConsoleApp.Framework;
    using BOOKMAN.ConsoleApp.Models;
    internal class BookUpdateView : ViewBase
    {

        public BookUpdateView(Book model) : base(model) { }
        public void Render()
        {
            ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green); //sử dụng phương thức static
            // chuyển đổi kiểu từ object sang Book, chỉ áp dụng với kiểu class
            var model = Model as Book;
            var authors     = ViewHelp.InputString("Authors",       model.Authors);
            var title       = ViewHelp.InputString("Title",         model.Title);
            var publisher   = ViewHelp.InputString("Publisher",     model.Publisher);
            var isbn        = ViewHelp.InputString("Isbn",          model.Isbn);
            var tags        = ViewHelp.InputString("Tags",          model.Tags);
            var description = ViewHelp.InputString("Description",   model.Description);
            var file        = ViewHelp.InputString("File",          model.File);
            var year        = ViewHelp.InputInt("Year",             model.Year);
            var edition     = ViewHelp.InputInt("Edition",          model.Edition);
            var rating      = ViewHelp.InputInt("Rate",             model.Rating);
            var reading     = ViewHelp.InputBool("Reading",         model.Reading);
        }
    }
}
