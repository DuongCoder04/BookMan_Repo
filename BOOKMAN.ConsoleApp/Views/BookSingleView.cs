using BOOKMAN.ConsoleApp.Framework;

namespace BOOKMAN.ConsoleApp.Views
{
    using BOOKMAN.ConsoleApp.Models;
    using System;

    /// <summary>
    /// Cách để hiển thị một cuốn sách 
    /// </summary>
    internal class BookSingleView : ViewBase<Book>
    {
        /// <summary>
        /// Đây là hàm tạo, sẽ được gọi đầu tiên khi tạo object
        /// </summary>
        /// <param name="model">cuốn sách cụ thể sẽ được hiển thị</param>
        public BookSingleView(Book model) : base(model) { }
        public override void Render()
        {
            if(Model == null)
            {
                ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
                return;
            }
            ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            // chuyển đổi kiểu từ object sang Book, chỉ áp dụng với kiểu class
            Console.WriteLine($"Authors:     {Model.Authors}");
            Console.WriteLine($"Title:       {Model.Title}");
            Console.WriteLine($"Publisher:   {Model.Publisher}");
            Console.WriteLine($"Year:        {Model.Year}");
            Console.WriteLine($"Edition:     {Model.Edition}");
            Console.WriteLine($"Isbn:        {Model.Isbn}");
            Console.WriteLine($"Tags:        {Model.Tags}");
            Console.WriteLine($"Description: {Model.Description}");
            Console.WriteLine($"Rating:      {Model.Rating}");
            Console.WriteLine($"Reading:     {Model.Reading}");
            Console.WriteLine($"File:        {Model.File}");
            Console.WriteLine($"File Name:   {Model.FileName}");

        }

    }

}
