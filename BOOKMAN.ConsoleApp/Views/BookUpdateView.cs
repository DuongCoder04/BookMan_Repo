using System;
using System.Reflection;
namespace BookMan.ConsoleApp.Views
{
    using BOOKMAN.ConsoleApp.Models;
    class BookUpdateView
    {
        protected Book Model;
        public BookUpdateView(Book model)
        {
            Model = model;
        }
        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("UPDATE BOOK INFORMATION");
            Console.ResetColor();
            // hiển thị giá trị cũ
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Authors: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Model.Authors);
            // yêu cầu nhập giá trị mới
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("New value: ");
            Console.ResetColor();
            // đọc giá trị mới 
            var str = Console.ReadLine();
            /* nếu người dùng ấn enter luôn (bỏ qua nhập dữ liệu) thì lấy lại giá trị cũ
             * của trường Authors gán cho biến cục bộ authors.
             * Nếu người dùng nhập giá trị mới thì biến cục bộ authors nhận giá trị này.
             * Giá trị của biến authors về sau sẽ chuyển về controller để xử lý.
             */
            var authors = string.IsNullOrEmpty(str.Trim()) ? Model.Authors : str;
            // TẠM DỪNG .... QUÁ NHIỀU CODE LẶP
        }
    }
}
