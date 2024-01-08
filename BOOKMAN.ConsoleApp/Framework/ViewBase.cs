namespace BOOKMAN.ConsoleApp.Framework
{
    public class ViewBase
    {
        protected object Model;
        protected Router Router = Router.Instance;
        public ViewBase() { }
        public ViewBase(object model)=> Model = model;
        public void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving data to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            File.WriteAllText(path, json );
            ViewHelp.WriteLine("Done!");
        }
    }
}
