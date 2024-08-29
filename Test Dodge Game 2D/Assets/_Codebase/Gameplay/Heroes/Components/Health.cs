using System;
using UnityEngine;

namespace _Codebase.Gameplay.Heroes.Components
{
    public class Health : MonoBehaviour
    {
        public event Action Died;

        public void Damage()
        {
            Died?.Invoke();
        }
    }
}