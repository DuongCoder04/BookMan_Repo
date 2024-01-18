using BOOKMAN.ConsoleApp.Views;
using BOOKMAN.ConsoleApp.DataServices;
using BOOKMAN.ConsoleApp.Framework;
using BOOKMAN.ConsoleApp.Models;
using System;

namespace BOOKMAN.ConsoleApp.Controllers
{
    /// <summary>
    /// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
    /// </summary>
    internal class BookController : ControllerBase
    {
        protected Repository Repository;
        public BookController(IDataAccess context)
        {
            Repository = new Repository(context);
        }

        /// <summary>
        /// ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuốn sách
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách</param>
        public void Single(int id, string path = "")
        {
            // lấy dữ liệu qua repository
            var model = Repository.Select(id);
            Render(new BookSingleView(model), path);
        }
        /// <summary>
        /// kích hoạt chức năng nhập dữ liệu cho 1 cuốn sách
        /// </summary>
        public void Create(Book book = null)
        {
            if(book == null)
            {
                Render(new BookCreateView());
                return;
            }
            Repository.Insert(book);
            Success("Book created!");    
        }
        /// <summary>
        /// kích hoạt chức năng cập nhật
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id, Book book = null)
        {
            if(book == null)
            {
                var model = Repository.Select(id);
                var view = new BookUpdateView(model);
                Render(view);
                return;
            }
            Repository.Update(id, book);
            Success("Book updated!");
        }
        /// <summary>
        /// kích hoạt chức năng hiển thị danh sách
        /// </summary>
        public void List(string path = "")
        {
            // lấy dữ liệu qua repository
            var model = Repository.Select();
            // khởi tạo view
            Render(new BookListView(model), path);
        }
        public void Delete(int id, bool process = false)
        {
            if(process == false)
            {
                var b = Repository.Select(id);
                Confirm($"Do you want to delete this book ({b.Title})?(yes/no): ",
                        $"do delete?id={b.Id}");
            }
            else
            {
                Repository.Delete(id);
                Success("Book delete!");
            }

        }
        public void Filter(string key)
        {
            var model = Repository.Select(key);
            if (model.Length == 0) Inform("No matched book found!");
            else Render(new BookListView(model));
        }
        public void Mark(int id, bool read = true)
        {
            var book = Repository.Select(id);
            if(book == null)
            {
                Error("Book not found!");
                return;
            }
            book.Reading = read;
            Success($"The book '{book.Title}' are marked as {(read ? "READ" : "UNREAD")}");
        }
        public void ShowMarks()
        {
            var model = Repository.SelectMarked();
            var view = new BookListView(model);
            Render(view);
        }
        public void Stats()
        {
            var model = Repository.Stats();
            var view = new BookStatsView(model);
            Render(view);
        }
        public void Exit(bool process = false)
        {
            if (!process)
            {
                Confirm("Do you really want to exit the program ?", "do exit");
                return;
            }
            Inform("Program exited");
            Environment.Exit(0);
            
        }
    }

}
