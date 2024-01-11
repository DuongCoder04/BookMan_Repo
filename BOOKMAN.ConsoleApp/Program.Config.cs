namespace BOOKMAN.ConsoleApp
{
    using Models;
    using Controllers;
    using DataServices;
    using Framework;
    internal partial class Program
    {
        private static void ConfigRouter()
        {
            SimpleDataAccess context = new SimpleDataAccess();
            BookController controller = new BookController(context);

            Router r = Router.Instance;
            r.Register("about", About);
            r.Register("help", Help);
            r.Register(route: "create",
                action: p => controller.Create(),
                help: "[create]rnnhập sách mới");
            r.Register(route: "do create",
                action: p => controller.Create(toBook(p)),
                help: "this route should be used only in code");
            
            r.Register(route: "list",
                action: p => controller.List(),
                help: "[list]rnhiển thị tất cả sách");
            r.Register(route: "list file",
                action: p => controller.List(p["path"]),
                help: "[list file ? path = <value>]rnhiển thị tất cả sách");
            
            r.Register(route: "single",
                action: p => controller.Single(p["id"].ToInt()),
                help: "[single ? id = < value >]rnhiển thị một cuốn sách theo id");
            r.Register(route: "single file",
                action: p => controller.Single(p["id"].ToInt(), p["path"]),
                help: "[single file ? id = <value> & path = <value>]");
            r.Register(route: "update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "[update ? id = <value>]\r\nFind and update book");
            r.Register(route: "do update",
                action: p => controller.Update(p["id"].ToInt(), toBook(p)),
                help: "this route should be used only in code");
            //r.Register(route: "",
            //    action: null,
            //    help: "");            
            #region helper
            //local function to convert parameter to book object
            Book toBook(Parameter p)
            {
                var b = new Book();
                if (p.ContainsKey("id")) b.Id = p["id"].ToInt();
                if (p.ContainsKey("authors")) b.Authors = p["authors"];
                if (p.ContainsKey("title")) b.Title = p["title"];
                if (p.ContainsKey("publisher")) b.Publisher = p["publisher"];
                if (p.ContainsKey("year")) b.Year = p["year"].ToInt();
                if (p.ContainsKey("edition")) b.Edition = p["edition"].ToInt();
                if (p.ContainsKey("isbn")) b.Isbn = p["isbn"];
                if (p.ContainsKey("tags")) b.Tags = p["tags"];
                if (p.ContainsKey("description")) b.Description = p["description"];
                if (p.ContainsKey("file")) b.File = p["file"];
                if (p.ContainsKey("rate")) b.Rating = p["rate"].ToInt();
                if (p.ContainsKey("reading")) b.Reading = p["reading"].ToBool();
                return b;
            }
            #endregion
        }
    }
}