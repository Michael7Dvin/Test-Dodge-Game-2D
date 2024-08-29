using _Codebase.UI.Score;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Codebase.Infrastructure.Providers.UIProvider
{
    public class UIProvider : IUIProvider
    {
        public Canvas Canvas { get; set; }
        public EventSystem EventSystem { get; set; }
        public ScoreCounter ScoreCounter { get; set; }
        
    }
}