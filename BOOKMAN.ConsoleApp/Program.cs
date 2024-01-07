namespace BOOKMAN.ConsoleApp
{
    using BOOKMAN.ConsoleApp.Framework;
    using BOOKMAN.ConsoleApp.DataServices;
    using Controllers;
    using global::Framework.BOOKMAN.ConsoleApp.Framework;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var context = new SimpleDataAccess();
            BookController controller = new BookController(context);
            Router.Instance.Register("about", About);
            Router.Instance.Register("help", Help);
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
