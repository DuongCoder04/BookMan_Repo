using BOOKMAN.ConsoleApp.Framework;

namespace BOOKMAN.ConsoleApp.Views
{
    using BOOKMAN.ConsoleApp.Models;
    /// <summary>
    /// Cách để hiển thị một cuốn sách 
    /// </summary>
    internal class BookSingleView
    {
        protected Book Model;
        /// <summary>
        /// Đây là hàm tạo, sẽ được gọi đầu tiên khi tạo object
        /// </summary>
        /// <param name="model">cuốn sách cụ thể sẽ được hiển thị</param>
        public BookSingleView(Book model) 
        {
            Model = model;
            // Chuyển dữ liệu từ tham số sang biến thành viên để sử dựng trong toàn class
        }
        /// <summary>
        /// thực hiện in thông tin ra màn hình console
        /// </summary>

        public void Render()
        {
            if(Model == null)//kiểm tra xem có dữ liệu không
            {
                // sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
                ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
                return;//kết thúc thực hiện phương thức (bỏ qua phần còn lại)
            }
            // sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
            ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            /*
             * các dòng dưới đây viết ra thông tin cụ thể theo từng dòng
             * sử dụng cách tạo xâu kiểu "interpolation"
             * và dùng dấu cách để căn chỉnh tạo thẩm mỹ
             */
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
