using System;
using UniRx;
using UnityEngine;

namespace _Codebase.Gameplay.Heroes.Components
{
    public class Health : MonoBehaviour
    {
        private ReactiveProperty<bool> _isDead = new();
        public IReadOnlyReactiveProperty<bool> IsDead => _isDead;

        public void Damage() => 
            _isDead.Value = true;

        public void Revive() => 
            _isDead.Value = false;
    }
}