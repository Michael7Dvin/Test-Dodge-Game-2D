using _Codebase.UI.Windows.Base;

namespace _Codebase.UI.Services.WindowService
{
    public interface IWindowService
    {
        void ShowWindow(WindowID windowID);
        void HideWindow(WindowID windowID);
    }
}