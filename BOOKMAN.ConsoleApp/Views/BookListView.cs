using System.IO;
using BOOKMAN.ConsoleApp.Framework;
using BOOKMAN.ConsoleApp.Models;

namespace BOOKMAN.ConsoleApp.Views
{
    /// <summary>
    /// Class để hiển thị danh sách Book
    /// </summary>
    internal class BookListView : ViewBase
    {
        public BookListView(Book[] model) : base(model) { }
        public void Render()
        {
            if (((Book[])Model).Length == 0)
            {
                ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THE BOOK LIST");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(Book b in Model as Book[])
            {
                ViewHelp.Write($"[{b.Id}]", ConsoleColor.Yellow);
                ViewHelp.WriteLine($"{b.Title}", b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
            }
            Console.ResetColor();
        }
        
    }

}