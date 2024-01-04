namespace BOOKMAN.ConsoleApp.Controllers
{
    using BookMan.ConsoleApp.Views;
    using BOOKMAN.ConsoleApp.Views;
    using Models; //lưu ý cách dùng using với không gian tên con

    /// <summary>
    /// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
    /// </summary>
    internal class BookController
    {
        /// <summary>
        /// ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuốn sách
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách</param>
        public void Single(int id)
        {
            // khởi tạo object với property
            Book model = new Book
            {
                Id = 1,
                Authors = "Adam Freeman",
                Title = "Expert ASP.NET Web API 2 for MVC Developers (The Expert's Voice in .NET)",
                Publisher = "Apress",
                Year = 2014,
                Tags = "c#, asp.net, mvc",
                Description = "Expert insight and understanding of how to create, customize, and deploy complex, flexible, and robust HTTP web services",
                Rating = 5,
                Reading = true
            };
            // khởi tạo view
            BookSingleView view = new BookSingleView(model);
            // hiển thị ra màn hình
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
            var model = new Book();
            var view = new BookUpdateView(model);
            view.Render(model);
        }

    }
}
