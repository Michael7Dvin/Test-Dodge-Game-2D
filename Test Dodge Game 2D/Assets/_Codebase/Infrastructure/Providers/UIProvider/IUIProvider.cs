using UnityEngine;
using UnityEngine.EventSystems;

namespace _Codebase.Infrastructure.Providers.UIProvider
{
    public interface IUIProvider
    {
        Canvas Canvas { get; }
        EventSystem EventSystem { get; }
        
        void SetCanvas(Canvas canvas);
        void SetEventSystem(EventSystem eventSystem);
    }
}