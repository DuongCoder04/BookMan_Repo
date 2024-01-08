namespace BOOKMAN.ConsoleApp
{
    using BOOKMAN.ConsoleApp.Framework;
    using BOOKMAN.ConsoleApp.DataServices;
    using Controllers;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            SimpleDataAccess context = new SimpleDataAccess();
            BookController controller = new BookController(context);

            Router r = Router.Instance;
            r.Register("about", About);
            r.Register("help", Help);
            r.Register(route: "create",
                action: p => controller.Create(),
                help: "[create]\r\nAdd new book");
            r.Register(route: "update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "[update ? id = <value>]\r\nFind and update book");
            r.Register(route: "list",
                action: p => controller.List(),
                help: "[list]\r\nShow all books");
            r.Register(route: "single",
                action: p => controller.Single(p["id"].ToInt()),
                help: "[single ? id = <value>]\r\nDisplay a book by id");
            r.Register(route: "list file",
                action: p => controller.List(p["path"]),
                help: "[list file ? path = <value>]\r\nShow all book");
            r.Register(route: "single file",
                action: p => controller.Single(p["id"].ToInt(), p["path"]),
                help: "[single file ? id = <value> & path = <value>]");
            while (true)
            {
                ViewHelp.Write("# Request >>>", ConsoleColor.Green);
                string request = Console.ReadLine();
                Console.Write("Request> ");
                Router.Instance.Forward(request);
                Console.WriteLine();
            }
        }
        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("BOOK MANAGER v1.0", ConsoleColor.Green);
            ViewHelp.WriteLine("by duong192k4@gmail.com", ConsoleColor.Magenta);
        }
        private static void Help(Parameter parameter)
        {
            if(parameter == null)
            {
                ViewHelp.WriteLine("SUPPORTED COMMANDS:", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("type: help ? cmd= <command> to get command details", ConsoleColor.Cyan);
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            var conmand = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(conmand));
        }

     }

}
