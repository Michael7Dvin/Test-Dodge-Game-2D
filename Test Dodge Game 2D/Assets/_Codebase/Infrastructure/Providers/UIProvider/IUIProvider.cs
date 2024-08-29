using _Codebase.UI.Score;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Codebase.Infrastructure.Providers.UIProvider
{
    public interface IUIProvider
    {
        Canvas Canvas { get; set; }
        EventSystem EventSystem { get; set;}
        
        ScoreCounter ScoreCounter { get; set;}
    }
}