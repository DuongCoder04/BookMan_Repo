using BOOKMAN.ConsoleApp.Views;
using BOOKMAN.ConsoleApp.DataServices;
using BOOKMAN.ConsoleApp.Framework;
using BOOKMAN.ConsoleApp.Models;

namespace BOOKMAN.ConsoleApp.Controllers
{
    /// <summary>
    /// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
    /// </summary>
    internal class BookController : ControllerBase
    {
        protected Repository Repository;
        public BookController(SimpleDataAccess context)
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
            return;          
        }
        /// <summary>
        /// kích hoạt chức năng cập nhật
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id)
        {
            var model = Repository.Select(id);
            Render(new BookUpdateView(model));
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

    }
}
