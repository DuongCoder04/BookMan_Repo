namespace BOOKMAN.ConsoleApp.Framework
{
    public class ControllerBase
    {
        public virtual void Render(ViewBase view) { view.Render(); }
        public virtual void Render<T>(ViewBase<T> view, string path = "", bool both = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                view.Render();
                return;
            }
            if (both)
            {
                view.Render();
                view.RenderToFile(path);
                return;
            }
            view.RenderToFile(path);
        }
    }
}
