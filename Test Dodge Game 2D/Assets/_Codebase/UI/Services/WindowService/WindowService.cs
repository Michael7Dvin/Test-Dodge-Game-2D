using System.Collections.Generic;
using _Codebase.Infrastructure.Factories.WindowFactory;
using _Codebase.UI.Windows.Base;
using UnityEngine;

namespace _Codebase.UI.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly IWindowFactory _windowFactory;
        
        private readonly Dictionary<WindowID, BaseWindowView> _windows = new();

        public WindowService(IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
        }

        public void ShowWindow(WindowID windowID)
        {
            if (_windows.ContainsKey(windowID) == false)
            {
                CreateWindow(windowID);
                return;
            }
            
            _windows[windowID].Show();
        }

        private void CreateWindow(WindowID windowID)
        {
            switch (windowID)
            {
                case WindowID.GameOverWindow:
                    _windows[windowID] = _windowFactory.CreateGameOverWindow();
                    break;
                default:
                    Debug.LogError($"Unable to create window. Unsupported {nameof(WindowID)} value: '{windowID}'");
                    break;
            }
        }

        public void HideWindow(WindowID windowID)
        {
            if (_windows.ContainsKey(windowID) == false)
            {
                Debug.LogError($"Unable to hide window. No window registered with ID: '{windowID}'.");
                return;
            }
            
            _windows[windowID].Hide();
        }
    }
}