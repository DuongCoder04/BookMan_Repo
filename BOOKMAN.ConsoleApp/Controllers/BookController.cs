using BOOKMAN.ConsoleApp.Views;
using BOOKMAN.ConsoleApp.DataServices;

namespace BOOKMAN.ConsoleApp.Controllers
{
    /// <summary>
    /// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
    /// </summary>
    internal class BookController
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
            // khởi tạo view
            BookSingleView view = new BookSingleView(model);
            // hiển thị ra màn hình
            if(!string.IsNullOrEmpty(path)) { view.RenderToFile(path); return; }
            view.Render();
        }
        /// <summary>
        /// kích hoạt chức năng nhập dữ liệu cho 1 cuốn sách
        /// </summary>
        public void Create()
        {
            BookCreateView view = new BookCreateView();// khởi tạo object
            view.Render(); // hiển thị ra màn hình
        }
        /// <summary>
        /// kích hoạt chức năng cập nhật
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id)
        {
            // lấy dữ liệu qua repository
            var model = Repository.Select(id);
            var view = new BookUpdateView(model);
            view.Render(model);
        }
        /// <summary>
        /// kích hoạt chức năng hiển thị danh sách
        /// </summary>
        public void List(string path = "")
        {
            // lấy dữ liệu qua repository
            var model = Repository.Select();
            // khởi tạo view
            BookListView view = new BookListView(model);
            if(!string.IsNullOrEmpty(path)) { view.RenderToFile(path); return; }
            view.Render();
        }

    }
}
