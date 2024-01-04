namespace BOOKMAN.ConsoleApp
{
    using Controllers;
    internal class Program
    {
        private static void Main(string[] args)
        {
            BookController controller = new BookController();
            while (true)
            {
                Console.Write("Request> ");
                string request = Console.ReadLine();
                switch (request.ToLower())
                {
                    case "single":
                        controller.Single(1);
                        break;
                    case "create":
                        controller.Create();
                        break;
                    case "update":
                        controller.Update(1);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }

}
