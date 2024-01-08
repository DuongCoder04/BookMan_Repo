using BOOKMAN.ConsoleApp.Framework;

namespace BOOKMAN.ConsoleApp.Views
{
    using BOOKMAN.ConsoleApp.Models;
    /// <summary>
    /// Cách để hiển thị một cuốn sách 
    /// </summary>
    internal class BookSingleView : ViewBase
    {
        /// <summary>
        /// Đây là hàm tạo, sẽ được gọi đầu tiên khi tạo object
        /// </summary>
        /// <param name="model">cuốn sách cụ thể sẽ được hiển thị</param>
        public BookSingleView(Book[] model) : base(model) { }
        public void Render()
        {
            if(Model == null)
            {
                ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
                return;
            }
            ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            // chuyển đổi kiểu từ object sang Book, chỉ áp dụng với kiểu class
            var model = Model as Book;
            Console.WriteLine($"Authors:     {model.Authors}");
            Console.WriteLine($"Title:       {model.Title}");
            Console.WriteLine($"Publisher:   {model.Publisher}");
            Console.WriteLine($"Year:        {model.Year}");
            Console.WriteLine($"Edition:     {model.Edition}");
            Console.WriteLine($"Isbn:        {model.Isbn}");
            Console.WriteLine($"Tags:        {model.Tags}");
            Console.WriteLine($"Description: {model.Description}");
            Console.WriteLine($"Rating:      {model.Rating}");
            Console.WriteLine($"Reading:     {model.Reading}");
            Console.WriteLine($"File:        {model.File}");
            Console.WriteLine($"File Name:   {model.FileName}");

        }

    }

}
