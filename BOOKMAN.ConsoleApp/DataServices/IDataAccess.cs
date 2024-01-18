namespace BOOKMAN.ConsoleApp.DataServices
{
    using Models;
    using System.Collections.Generic;

    public interface IDataAccess
    {
        List<Book> Books { get; set; }
        void Load();
        void SaveChanges();
    }
}
