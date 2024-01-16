using System.Diagnostics;
namespace BOOKMAN.ConsoleApp.Controllers
{
    using DataServices;
    using Models;
    using Framework;

    internal class ShellController : ControllerBase
    {
        protected Repository Repository;
        public ShellController(IDataAccess context)
        {
            Repository = new Repository(context);
        }
        
        public void Shell_pdf(string folder, string ext = "*.pdf")
        {
            if (!Directory.Exists(folder))
            {
                Error("Folder not found!");     
                return;
            }
            var files = Directory.GetFiles(folder, ext ?? "*.pdf", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                Repository.Insert(new Book { Title = Path.GetFileNameWithoutExtension(f), File = f });
            }
            if(files.Length > 0)
            {
                //Render(new BookListView(Repository.Select()));
                Success($"{files.Length} item(s) found!");
                return;
            }
            Inform("No item found!", "Sorry!");
        }
        public void Shell_docx(string folder, string ext = "*.docx")
        {
            if (!Directory.Exists(folder))
            {
                Error("Folder not found!");
                return;
            }
            var files = Directory.GetFiles(folder, ext ?? "*.docx", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                Repository.Insert(new Book { Title = Path.GetFileNameWithoutExtension(f), File = f });
            }
            if (files.Length > 0)
            {
                //Render(new BookListView(Repository.Select()));
                Success($"{files.Length} item(s) found!");
                return;
            }
            Inform("No item found!", "Sorry!");
        }
        public void Shell_xlsx(string folder, string ext = "*.xlsx")
        {
            if (!Directory.Exists(folder))
            {
                Error("Folder not found!");
                return;
            }
            var files = Directory.GetFiles(folder, ext ?? "*.xlsx", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                Repository.Insert(new Book { Title = Path.GetFileNameWithoutExtension(f), File = f });
            }
            if (files.Length > 0)
            {
                //Render(new BookListView(Repository.Select()));
                Success($"{files.Length} item(s) found!");
                return;
            }
            Inform("No item found!", "Sorry!");
        }
        public void Save()
        {
            Repository.SaveChanges();
            Success("Data save!");
        }
        public void Read(int id)
        {
            var book = Repository.Select(id);
            if (book == null)
            {
                Error("Book not found!");
                return;
            }
            if(!File.Exists(book.File))
            {
                Error("File not found!");
                return;
            }
            //Process.Start(book.File);
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = book.File,
                UseShellExecute = true,
            });
            Success($"You are reading the book '{book.Title}'");
        }
        public void Clear(bool process = false)
        {
            if (!process)
            {
                Confirm("Do you really want to clear the shell?", "do clear");
                return;
            }
            Repository.Clear();
            Inform("The shell has been cleared");
        }
    }
}
