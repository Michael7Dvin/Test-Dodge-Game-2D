using UnityEngine;
using UnityEngine.EventSystems;

namespace _Codebase.Infrastructure.Providers.UIProvider
{
    public class UIProvider : IUIProvider
    {
        public Canvas Canvas { get; private set; }
        public EventSystem EventSystem { get; private set; }
        
        public void SetCanvas(Canvas canvas) => 
            Canvas = canvas;

        public void SetEventSystem(EventSystem eventSystem) => 
            EventSystem = eventSystem;
    }
}