using System.IO;
namespace BOOKMAN.ConsoleApp.Framework
{
    public class ViewBase
    {
        protected Router Router = Router.Instance;
        public ViewBase() { }
        public virtual void Render() { }
    }
    public class ViewBase<T> : ViewBase
    {
        protected T Model;
        public ViewBase(T model) => Model = model;
        public virtual void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving data to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            File.WriteAllText(path, json );
            ViewHelp.WriteLine("Done!");
        }
    
    }
    
}
