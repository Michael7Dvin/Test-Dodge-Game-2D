using System;
using UnityEngine;

namespace _Codebase.UI.Windows.Base
{
    public abstract class BaseWindowView : MonoBehaviour
    {
        public event Action Shown;
        public event Action Hidden;
        
        public void Show()
        {
            gameObject.SetActive(true);
            Shown?.Invoke();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            Hidden?.Invoke();
        }
    }
}