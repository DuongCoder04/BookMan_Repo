using System;
using BOOKMAN.ConsoleApp.Framework;
using BOOKMAN.ConsoleApp.Models;

namespace BOOKMAN.ConsoleApp.Views
{
    /// <summary>
    /// Class để hiển thị danh sách Book
    /// </summary>
    internal class BookListView
    {
        protected Book[] Model;// mảng của object kiểu Book
        /// <summary>
        /// Hàm tạo
        /// </summary>
        /// <param name="model">danh sách object kiểu Book</param>
        public BookListView(Book[] model) 
        {
            Model = model;
        }
        /// <summary>
        /// danh sách ra console
        /// </summary>
        public void Render()
        {
            if(Model.Length == 0)
            {
                ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
                return;
            }
            ViewHelp.WriteLine("THE BOOK LIST", ConsoleColor.Green);
            int i = 0;
            while(i < Model.Length)
            {
                ViewHelp.Write($"[{Model[i].Id}]", ConsoleColor.Yellow);
                ViewHelp.WriteLine($" {Model[i].Title}", Model[i].Reading ? ConsoleColor.Cyan : ConsoleColor.White);
                i++;
            }
        }
    }
}