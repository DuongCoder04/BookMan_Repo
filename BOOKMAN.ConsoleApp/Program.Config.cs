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
            IDataAccess context         = new BinaryDataAccess();
            BookController controller   = new BookController(context);
            ShellController shell       = new ShellController(context);

            Router r = Router.Instance;
            r.Register("about", About);
            r.Register("help", Help);
            r.Register(route: "create",
                action: p => controller.Create(),
                help: "[create]\r\nAdd new book");
            r.Register(route: "do create",
                action: p => controller.Create(toBook(p)),
                help: "this route should be used only in code");
            r.Register(route: "list",
                action: p => controller.List(),
                help: "[list]\r\nShow all book");
            r.Register(route: "list file",
                action: p => controller.List(p["path"]),
                help: "[list file ? path = <value>]\r\nShow all book");
            r.Register(route: "single",
                action: p => controller.Single(p["id"].ToInt()),
                help: "[single ? id = < value >]\r\nShow book for id");
            r.Register(route: "single file",
                action: p => controller.Single(p["id"].ToInt(), p["path"]),
                help: "[single file ? id = <value> & path = <value>]");
            r.Register(route: "update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "[update ? id = <value>]\r\nFind and update book");
            r.Register(route: "do update",
                action: p => controller.Update(p["id"].ToInt(), toBook(p)),
                help: "this route should be used only in code");
            r.Register(route: "delete",
                action: p => controller.Delete(p["id"].ToInt()),
                help: "[delete ? id = <value>]");
            r.Register(route: "do delete",
                action: p => controller.Delete(p["id"].ToInt(), true),
                help: "this route should be used only in code");
            r.Register(route: "filter",
                action: p => controller.Filter(p["key"]),
                help: "[filter ? key = <value>]\r\nFind book for keyword");
            r.Register(route: "add shell",
                action: p => shell.Shell(p["path"], p["ext"]),
                help: "[add shell ? path = <value>]");
            r.Register(route: "read",
                action: p => shell.Read(p["id"].ToInt()),
                help: "[read ? id = <value>]");
            r.Register(route: "mark",
                action: p => controller.Mark(p["id"].ToInt()),
                help: "[mark ? id = <value>]");
            r.Register(route: "unmark",
                action: p => controller.Mark(p["id"].ToInt(), false),
                help: "[unmark ? id = <value>]");
            r.Register(route: "show marks",
                action: p => controller.ShowMarks(),
                help: "show marks");
            r.Register(route: "clear",
                action: p => shell.Clear(),
                help: "[clear]\r\nUse with care");
            r.Register(route: "do clear",
                action: p => shell.Clear(true),
                help: "[clear]\r\nUse with care");
            r.Register(route: "save shell",
                action: p => shell.Save(),
                help: "[save shell]");
            //r.Register(route: "",
            //    action: null,
            //    help: "");            
            #region helper
            //local function to convert parameter to book object
            Book toBook(Parameter p)
            {
                var b = new Book();
                if (p.ContainsKey("id"))            b.Id            = p["id"].ToInt();
                if (p.ContainsKey("authors"))       b.Authors       = p["authors"];
                if (p.ContainsKey("title"))         b.Title         = p["title"];
                if (p.ContainsKey("publisher"))     b.Publisher     = p["publisher"];
                if (p.ContainsKey("year"))          b.Year          = p["year"].ToInt();
                if (p.ContainsKey("edition"))       b.Edition       = p["edition"].ToInt();
                if (p.ContainsKey("isbn"))          b.Isbn          = p["isbn"];
                if (p.ContainsKey("tags"))          b.Tags          = p["tags"];
                if (p.ContainsKey("description"))   b.Description   = p["description"];
                if (p.ContainsKey("file"))          b.File          = p["file"];
                if (p.ContainsKey("rate"))          b.Rating        = p["rate"].ToInt();
                if (p.ContainsKey("reading"))       b.Reading       = p["reading"].ToBool();
                return b;
            }
            #endregion
        }
    }
}